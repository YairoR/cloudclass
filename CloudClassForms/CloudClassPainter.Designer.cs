namespace CloudClassForms
{
    partial class CloudClassPainter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloudClassPainter));
            this.ButtonPen = new System.Windows.Forms.Button();
            this.ButtonColors = new System.Windows.Forms.Button();
            this.ButtonEraser = new System.Windows.Forms.Button();
            this.ButtonSize = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonPen
            // 
            this.ButtonPen.Image = ((System.Drawing.Image)(resources.GetObject("ButtonPen.Image")));
            this.ButtonPen.Location = new System.Drawing.Point(809, 0);
            this.ButtonPen.Name = "ButtonPen";
            this.ButtonPen.Size = new System.Drawing.Size(77, 77);
            this.ButtonPen.TabIndex = 1;
            this.ButtonPen.UseVisualStyleBackColor = true;
            // 
            // ButtonColors
            // 
            this.ButtonColors.Image = ((System.Drawing.Image)(resources.GetObject("ButtonColors.Image")));
            this.ButtonColors.Location = new System.Drawing.Point(809, 168);
            this.ButtonColors.Name = "ButtonColors";
            this.ButtonColors.Size = new System.Drawing.Size(78, 79);
            this.ButtonColors.TabIndex = 2;
            this.ButtonColors.UseVisualStyleBackColor = true;
            this.ButtonColors.Click += new System.EventHandler(this.ButtonColors_Click);
            // 
            // ButtonEraser
            // 
            this.ButtonEraser.Image = ((System.Drawing.Image)(resources.GetObject("ButtonEraser.Image")));
            this.ButtonEraser.Location = new System.Drawing.Point(809, 83);
            this.ButtonEraser.Name = "ButtonEraser";
            this.ButtonEraser.Size = new System.Drawing.Size(78, 79);
            this.ButtonEraser.TabIndex = 3;
            this.ButtonEraser.UseVisualStyleBackColor = true;
            // 
            // ButtonSize
            // 
            this.ButtonSize.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSize.Image")));
            this.ButtonSize.Location = new System.Drawing.Point(809, 253);
            this.ButtonSize.Name = "ButtonSize";
            this.ButtonSize.Size = new System.Drawing.Size(78, 79);
            this.ButtonSize.TabIndex = 4;
            this.ButtonSize.UseVisualStyleBackColor = true;
            this.ButtonSize.Click += new System.EventHandler(this.ButtonSize_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSave.Image")));
            this.ButtonSave.Location = new System.Drawing.Point(809, 338);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(78, 79);
            this.ButtonSave.TabIndex = 5;
            this.ButtonSave.UseVisualStyleBackColor = true;
            // 
            // ButtonNew
            // 
            this.ButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("ButtonNew.Image")));
            this.ButtonNew.Location = new System.Drawing.Point(809, 423);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(78, 79);
            this.ButtonNew.TabIndex = 6;
            this.ButtonNew.UseVisualStyleBackColor = true;
            // 
            // CloudClassPainter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(885, 648);
            this.Controls.Add(this.ButtonNew);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonSize);
            this.Controls.Add(this.ButtonEraser);
            this.Controls.Add(this.ButtonColors);
            this.Controls.Add(this.ButtonPen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CloudClassPainter";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloudClassPainter_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CloudClassPainter_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CloudClassPainter_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonPen;
        private System.Windows.Forms.Button ButtonColors;
        private System.Windows.Forms.Button ButtonEraser;
        private System.Windows.Forms.Button ButtonSize;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonNew;
    }
}

