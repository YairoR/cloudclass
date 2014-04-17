namespace rectangle
{
    partial class ChooseCourseForm
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
            this.ListCourses = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ListCourses
            // 
            this.ListCourses.FormattingEnabled = true;
            this.ListCourses.Location = new System.Drawing.Point(41, 33);
            this.ListCourses.Name = "ListCourses";
            this.ListCourses.Size = new System.Drawing.Size(150, 212);
            this.ListCourses.TabIndex = 0;
            // 
            // ChooseCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 269);
            this.Controls.Add(this.ListCourses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseCourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "בחר קורס";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListCourses;
    }
}