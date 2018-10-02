using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Configuration;

namespace DSAS
{
    public partial class MainWindow : Form
    {
        FileSystemWatcher watcher;
        HttpClient httpClient = new HttpClient();
        Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        bool working = false;
        string lastFile = ""; //Created event can be called twice in a row, need to remember last file to prevent that
        string lastFolder = "";
        string lastUrl = "";
        string filter = "*.jpg";
        public MainWindow()
        {
            if(config.AppSettings.Settings["lastFolder"] != null)
                lastFolder = ConfigurationManager.AppSettings["lastFolder"];
            if (config.AppSettings.Settings["lastUrl"] != null)
                lastUrl = ConfigurationManager.AppSettings["lastUrl"];
            if (config.AppSettings.Settings["filter"] != null)
                filter = ConfigurationManager.AppSettings["filter"];
            InitializeComponent();
            tb_scrfolder.Text = lastFolder;
            tb_webhookurl.Text = lastUrl;
            tb_filter.Text = filter;
        }

        private void b_browse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                tb_scrfolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void b_startstop_Click(object sender, EventArgs e)
        {
            StartStop();
        }

        private void StartStop()
        {
            if (!working)
            {
                if (!Directory.Exists(tb_scrfolder.Text))
                {
                    MessageBox.Show(strings.str_direrror);
                    return;
                }
                Uri uriResult;
                bool result = Uri.TryCreate(tb_webhookurl.Text, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (!result)
                {
                    MessageBox.Show(strings.str_urlerror);
                    return;
                }
                watcher = new FileSystemWatcher();
                watcher.Path = tb_scrfolder.Text;
                watcher.Created += OnDetectNewFile;
                watcher.Filter = tb_filter.Text;
                watcher.EnableRaisingEvents = true;
                tb_scrfolder.ReadOnly = true;
                tb_webhookurl.ReadOnly = true;
                tb_filter.ReadOnly = true;
                b_browse.Enabled = false;
                b_test.Enabled = false;
                b_startstop.Text = strings.str_stop;
                trayMenuItem1.Text = strings.str_stop;
                working = true;
            }
            else
            {
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
                tb_scrfolder.ReadOnly = false;
                tb_webhookurl.ReadOnly = false;
                tb_filter.ReadOnly = false;
                b_browse.Enabled = true;
                b_test.Enabled = true;
                b_startstop.Text = strings.str_start;
                trayMenuItem1.Text = strings.str_start;
                working = false;
            }
        }
        async private void SendFile(string file)
        {
            while (!File.Exists(file) && IsFileLocked(file))
            {
                await Task.Delay(1500);
            }
            byte[] file_bytes = FileToByteArray(file);
            if (file_bytes == null) //in case file is locked anyway (often happens with steam screenshots)
            {
                SendFile(file);
                return;
            }
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "file", Path.GetFileName(file));
            try
            {
                await httpClient.PostAsync(tb_webhookurl.Text, form);
            }
            catch
            {
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private static byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs;
            try
            {
                fs = new FileStream(fileName,FileMode.Open,FileAccess.Read);
            }
            catch
            {
                return buff;
            }
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
        private static byte[] ImageToByteArray(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private bool IsFileLocked(string filename)
        {
            FileStream stream = null;
            FileInfo file = new FileInfo(filename);

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void OnDetectNewFile(object source, FileSystemEventArgs e)
        {
            if (lastFile != e.FullPath)
            {
                SendFile(e.FullPath);
                lastFile = e.FullPath;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.AppSettings.Settings.Remove("lastFolder");
            config.AppSettings.Settings.Add("lastFolder", tb_scrfolder.Text);
            config.AppSettings.Settings.Remove("lastUrl");
            config.AppSettings.Settings.Add("lastUrl", tb_webhookurl.Text);
            config.AppSettings.Settings.Remove("filter");
            config.AppSettings.Settings.Add("filter", tb_filter.Text);
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.F1)
                MessageBox.Show("by captain_n00by\nseamanmna@gmail.com");
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                trayIcon.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StartStop();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void b_test_Click(object sender, EventArgs e)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(tb_webhookurl.Text, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!result)
            {
                MessageBox.Show(strings.str_urlerror);
                return;
            }
            byte[] file_bytes = ImageToByteArray(testpic.testpic1);
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "file", "scr.jpg");
            try
            {
                httpClient.PostAsync(tb_webhookurl.Text, form);
            }
            catch(HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
