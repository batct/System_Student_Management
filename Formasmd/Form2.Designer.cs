
namespace Formasmd
{
    partial class FrmAllManage
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
            this.btnstudent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTeacher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnstudent
            // 
            this.btnstudent.Location = new System.Drawing.Point(256, 139);
            this.btnstudent.Name = "btnstudent";
            this.btnstudent.Size = new System.Drawing.Size(75, 23);
            this.btnstudent.TabIndex = 0;
            this.btnstudent.Text = "Student";
            this.btnstudent.UseVisualStyleBackColor = true;
            this.btnstudent.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin";
            // 
            // btnTeacher
            // 
            this.btnTeacher.Location = new System.Drawing.Point(398, 139);
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.Size = new System.Drawing.Size(75, 23);
            this.btnTeacher.TabIndex = 2;
            this.btnTeacher.Text = "Teacher";
            this.btnTeacher.UseVisualStyleBackColor = true;
            this.btnTeacher.Click += new System.EventHandler(this.btnTeacher_Click);
            // 
            // FrmAllManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTeacher);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnstudent);
            this.Name = "FrmAllManage";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FrmAllManage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnstudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTeacher;
    }
}