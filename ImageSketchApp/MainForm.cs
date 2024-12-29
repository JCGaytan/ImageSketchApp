using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageSketchApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            // Open File Dialog to load the image
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the image into the first PictureBox
                    pictureBoxOriginal.Image = new Bitmap(openFileDialog.FileName);
                    pictureBoxOriginal.Tag = openFileDialog.FileName; // Save file path for later use
                }
            }
        }

        private void btnGenerateSketch_Click(object sender, EventArgs e)
        {
            if (pictureBoxOriginal.Image == null || pictureBoxOriginal.Tag == null)
            {
                MessageBox.Show("Please load an image first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string inputPath = pictureBoxOriginal.Tag.ToString();
            string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "sketch_image.png");

            // Run Python script
            RunPythonScript("sketch_image.py", inputPath, outputPath);

            // Load the processed image into the second PictureBox using a MemoryStream
            if (File.Exists(outputPath))
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(outputPath)))
                {
                    pictureBoxSketch.Image = Image.FromStream(stream);
                }

                // Optionally delete the temporary file after loading
                try
                {
                    File.Delete(outputPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to delete temporary file: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Failed to generate sketch. Check the Python script.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RunPythonScript(string scriptPath, string inputPath, string outputPath)
        {
            try
            {
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = "python",
                    Arguments = $"\"{scriptPath}\" \"{inputPath}\" \"{outputPath}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(start))
                {
                    process.WaitForExit();
                    string result = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show(error, "Python Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
