namespace Labyrinthe
{
    partial class MazeViewConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MazeViewConfig));
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.lblHeightAndWidth = new System.Windows.Forms.Label();
            this.lblTextureCells = new System.Windows.Forms.Label();
            this.lblTexturePlayer = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.pcbColorCell = new System.Windows.Forms.PictureBox();
            this.pcbColorPlayer = new System.Windows.Forms.PictureBox();
            this.chxBorder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbColorCell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbColorPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(9, 66);
            this.numHeight.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(40, 20);
            this.numHeight.TabIndex = 1;
            this.numHeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblHeightAndWidth
            // 
            this.lblHeightAndWidth.AutoSize = true;
            this.lblHeightAndWidth.Location = new System.Drawing.Point(6, 50);
            this.lblHeightAndWidth.Name = "lblHeightAndWidth";
            this.lblHeightAndWidth.Size = new System.Drawing.Size(96, 13);
            this.lblHeightAndWidth.TabIndex = 4;
            this.lblHeightAndWidth.Text = "Hauteur et Largeur";
            // 
            // lblTextureCells
            // 
            this.lblTextureCells.AutoSize = true;
            this.lblTextureCells.Location = new System.Drawing.Point(9, 105);
            this.lblTextureCells.Name = "lblTextureCells";
            this.lblTextureCells.Size = new System.Drawing.Size(93, 13);
            this.lblTextureCells.TabIndex = 6;
            this.lblTextureCells.Text = "Couleurs des murs";
            // 
            // lblTexturePlayer
            // 
            this.lblTexturePlayer.AutoSize = true;
            this.lblTexturePlayer.Location = new System.Drawing.Point(9, 164);
            this.lblTexturePlayer.Name = "lblTexturePlayer";
            this.lblTexturePlayer.Size = new System.Drawing.Size(90, 13);
            this.lblTexturePlayer.TabIndex = 7;
            this.lblTexturePlayer.Text = "Couleur du joueur";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(35, 226);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Créer";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pcbColorCell
            // 
            this.pcbColorCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pcbColorCell.Location = new System.Drawing.Point(12, 122);
            this.pcbColorCell.Name = "pcbColorCell";
            this.pcbColorCell.Size = new System.Drawing.Size(58, 29);
            this.pcbColorCell.TabIndex = 10;
            this.pcbColorCell.TabStop = false;
            this.pcbColorCell.Click += new System.EventHandler(this.pcbColorCell_Click);
            // 
            // pcbColorPlayer
            // 
            this.pcbColorPlayer.BackColor = System.Drawing.Color.Blue;
            this.pcbColorPlayer.Location = new System.Drawing.Point(12, 180);
            this.pcbColorPlayer.Name = "pcbColorPlayer";
            this.pcbColorPlayer.Size = new System.Drawing.Size(58, 29);
            this.pcbColorPlayer.TabIndex = 11;
            this.pcbColorPlayer.TabStop = false;
            this.pcbColorPlayer.Click += new System.EventHandler(this.pcbColorPlayer_Click);
            // 
            // chxBorder
            // 
            this.chxBorder.AutoSize = true;
            this.chxBorder.Location = new System.Drawing.Point(10, 21);
            this.chxBorder.Name = "chxBorder";
            this.chxBorder.Size = new System.Drawing.Size(63, 17);
            this.chxBorder.TabIndex = 12;
            this.chxBorder.Text = "Bordure";
            this.chxBorder.UseVisualStyleBackColor = true;
            // 
            // MazeViewConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 264);
            this.Controls.Add(this.chxBorder);
            this.Controls.Add(this.pcbColorPlayer);
            this.Controls.Add(this.pcbColorCell);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblTexturePlayer);
            this.Controls.Add(this.lblTextureCells);
            this.Controls.Add(this.lblHeightAndWidth);
            this.Controls.Add(this.numHeight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MazeViewConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MazeViewConfig";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MazeViewConfig_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbColorCell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbColorPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label lblHeightAndWidth;
        private System.Windows.Forms.Label lblTextureCells;
        private System.Windows.Forms.Label lblTexturePlayer;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.PictureBox pcbColorCell;
        private System.Windows.Forms.PictureBox pcbColorPlayer;
        private System.Windows.Forms.CheckBox chxBorder;
    }
}