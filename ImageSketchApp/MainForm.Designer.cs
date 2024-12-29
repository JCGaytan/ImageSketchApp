namespace ImageSketchApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxSketch;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnGenerateSketch;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxSketch = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnGenerateSketch = new System.Windows.Forms.Button();

            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Controls.Add(this.pictureBoxOriginal, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.pictureBoxSketch, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnLoadImage, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnGenerateSketch, 1, 1);

            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // 
            // pictureBoxSketch
            // 
            this.pictureBoxSketch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxSketch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSketch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);

            // 
            // btnGenerateSketch
            // 
            this.btnGenerateSketch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerateSketch.Text = "Generate Sketch";
            this.btnGenerateSketch.Click += new System.EventHandler(this.btnGenerateSketch_Click);

            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel);
            this.Text = "Image Sketch App";
        }

        #endregion
    }
}
