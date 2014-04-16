namespace CloudClassForms
{
    partial class Form1
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
            this.ButtonPen = new System.Windows.Forms.Button();
            this.ButtonColors = new System.Windows.Forms.Button();
            this.ButtonEraser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonPen
            // 
            this.ButtonPen.Location = new System.Drawing.Point(798, 45);
            this.ButtonPen.Name = "ButtonPen";
            this.ButtonPen.Size = new System.Drawing.Size(75, 23);
            this.ButtonPen.TabIndex = 1;
            this.ButtonPen.Text = "button2";
            this.ButtonPen.UseVisualStyleBackColor = true;
            this.ButtonPen.Click += new System.EventHandler(this.ButtonPen_Click);
            // 
            // ButtonColors
            // 
            this.ButtonColors.Location = new System.Drawing.Point(798, 138);
            this.ButtonColors.Name = "ButtonColors";
            this.ButtonColors.Size = new System.Drawing.Size(75, 23);
            this.ButtonColors.TabIndex = 2;
            this.ButtonColors.Text = "buttonColors";
            this.ButtonColors.UseVisualStyleBackColor = true;
            // 
            // ButtonEraser
            // 
            this.ButtonEraser.Location = new System.Drawing.Point(798, 88);
            this.ButtonEraser.Name = "ButtonEraser";
            this.ButtonEraser.Size = new System.Drawing.Size(75, 23);
            this.ButtonEraser.TabIndex = 3;
            this.ButtonEraser.Text = "button3";
            this.ButtonEraser.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(885, 648);
            this.Controls.Add(this.ButtonEraser);
            this.Controls.Add(this.ButtonColors);
            this.Controls.Add(this.ButtonPen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonPen;
        private System.Windows.Forms.Button ButtonColors;
        private System.Windows.Forms.Button ButtonEraser;
    }
}

