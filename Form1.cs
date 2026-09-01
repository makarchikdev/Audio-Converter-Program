using System.IO;
using System.Reflection;
using NReco.VideoConverter;

namespace Audio_Converter_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lstFiles.AllowDrop = true;
            lstFiles.DragEnter += LstFiles_DragEnter;
            lstFiles.DragDrop += LstFiles_DragDrop;
        }

        private void LstFiles_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void LstFiles_DragDrop(object? sender, DragEventArgs e)
        {
            if (e.Data == null) return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop)!;
            foreach (string file in files)
            {
                AddTrack(file);
            }
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Audio files (*.mp3)|*.mp3";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        AddTrack(file);
                    }
                }
            }
        }

        private void AddTrack(string filePath)
        {
            if (Path.GetExtension(filePath).ToLower() == ".mp3")
            {
                ListViewItem item = new ListViewItem(Path.GetFileName(filePath));
                item.SubItems.Add("Pending");
                item.SubItems.Add(filePath);
                lstFiles.Items.Add(item);
            }
        }

        public void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            DateTime compileDate = File.GetLastWriteTime(assemblyPath);

            string info = $"Developer: makarchik.dev\n" +
                          $"Version: 1.0.0\n" +
                          $"Compiled on: {compileDate:yyyy-MM-dd HH:mm:ss}";

            MessageBox.Show(info, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public async void btnConvert_Click(object sender, EventArgs e)
        {
            if (lstFiles.Items.Count == 0) return;

            btnAdd.Enabled = false;
            btnConvert.Enabled = false;

            var converter = new FFMpegConverter();
            progressBar.Maximum = lstFiles.Items.Count;
            progressBar.Value = 0;

            string outputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Converted");
            Directory.CreateDirectory(outputFolder);

            foreach (ListViewItem item in lstFiles.Items)
            {
                string inputPath = item.SubItems[2].Text;
                string outputName = Path.GetFileNameWithoutExtension(inputPath) + ".ogg";
                string outputPath = Path.Combine(outputFolder, outputName);

                item.SubItems[1].Text = "Processing...";

                try
                {
                    var settings = new ConvertSettings
                    {
                        AudioSampleRate = 44100,
                        CustomOutputArgs = "-acodec libvorbis"
                    };

                    await Task.Run(() => converter.ConvertMedia(inputPath, "mp3", outputPath, "ogg", settings));
                    item.SubItems[1].Text = "Done";
                }
                catch
                {
                    item.SubItems[1].Text = "Error";
                }

                progressBar.Value++;
            }

            btnAdd.Enabled = true;
            btnConvert.Enabled = true;
            MessageBox.Show("Conversion process finished!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
