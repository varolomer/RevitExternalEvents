
namespace RevitModelessWinForm
{
    partial class ModelessWinForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(246, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(46, 126);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(246, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(46, 180);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(246, 37);
            this.button4.TabIndex = 3;
            this.button4.Text = "Button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(46, 237);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(246, 37);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close Button";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ModelessWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 312);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ModelessWinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModelessWinForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ModelessWinForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button closeButton;
    }
}