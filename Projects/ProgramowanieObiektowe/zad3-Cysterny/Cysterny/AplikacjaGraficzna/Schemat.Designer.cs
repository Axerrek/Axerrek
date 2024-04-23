namespace Cysterny
{
    partial class Schemat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Wczytaj = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Rozwiaz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Wczytaj
            // 
            this.Wczytaj.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Wczytaj.Location = new System.Drawing.Point(358, 375);
            this.Wczytaj.Name = "Wczytaj";
            this.Wczytaj.Size = new System.Drawing.Size(108, 49);
            this.Wczytaj.TabIndex = 0;
            this.Wczytaj.Text = "Wczytaj";
            this.Wczytaj.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Wczytaj.UseVisualStyleBackColor = true;
            this.Wczytaj.Click += new System.EventHandler(this.Wczytaj_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 426);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Rozwiaz
            // 
            this.Rozwiaz.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Rozwiaz.Location = new System.Drawing.Point(472, 375);
            this.Rozwiaz.Name = "Rozwiaz";
            this.Rozwiaz.Size = new System.Drawing.Size(108, 49);
            this.Rozwiaz.TabIndex = 2;
            this.Rozwiaz.Text = "Rozwiąż";
            this.Rozwiaz.UseVisualStyleBackColor = true;
            this.Rozwiaz.Visible = false;
            this.Rozwiaz.Click += new System.EventHandler(this.button1_Click);
            // 
            // Schemat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Rozwiaz);
            this.Controls.Add(this.Wczytaj);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Schemat";
            this.Text = "Schemat";
            this.Load += new System.EventHandler(this.Schemat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Wczytaj;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Rozwiaz;
    }
}