namespace Labyrinthe
{
    partial class MazeViewHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MazeViewHome));
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.ofdXmlFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(71, 32);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(98, 21);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "Nouvelle partie";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(71, 92);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(98, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Charger";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(71, 153);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(98, 23);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "À propos";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // ofdXmlFile
            // 
            this.ofdXmlFile.FileName = "openFileDialog1";
            // 
            // MazeViewHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 219);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnNewGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MazeViewHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Labyrinthe - Acceuil";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MazeViewHome_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.OpenFileDialog ofdXmlFile;
    }
}