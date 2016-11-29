namespace HashTagManagerUI
{
    partial class MainForm
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
            this.btnFindPw = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnFindId = new System.Windows.Forms.Button();
            this.btnLoginout = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFindPw
            // 
            this.btnFindPw.Location = new System.Drawing.Point(395, 215);
            this.btnFindPw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFindPw.Name = "btnFindPw";
            this.btnFindPw.Size = new System.Drawing.Size(98, 30);
            this.btnFindPw.TabIndex = 27;
            this.btnFindPw.Text = "PW찾기";
            this.btnFindPw.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(244, 184);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 25);
            this.textBox2.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(244, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 25);
            this.textBox1.TabIndex = 25;
            // 
            // btnFindId
            // 
            this.btnFindId.Location = new System.Drawing.Point(255, 216);
            this.btnFindId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFindId.Name = "btnFindId";
            this.btnFindId.Size = new System.Drawing.Size(98, 29);
            this.btnFindId.TabIndex = 24;
            this.btnFindId.Text = "ID찾기";
            this.btnFindId.UseVisualStyleBackColor = true;
            // 
            // btnLoginout
            // 
            this.btnLoginout.Location = new System.Drawing.Point(395, 144);
            this.btnLoginout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoginout.Name = "btnLoginout";
            this.btnLoginout.Size = new System.Drawing.Size(98, 66);
            this.btnLoginout.TabIndex = 23;
            this.btnLoginout.Text = "로그인";
            this.btnLoginout.UseVisualStyleBackColor = true;
            this.btnLoginout.Click += new System.EventHandler(this.btnLoginout_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 20F);
            this.label4.Location = new System.Drawing.Point(272, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 34);
            this.label4.TabIndex = 28;
            this.label4.Text = "해시태그";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 485);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFindPw);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnFindId);
            this.Controls.Add(this.btnLoginout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindPw;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnFindId;
        public System.Windows.Forms.Button btnLoginout;
        private System.Windows.Forms.Label label4;


    }
}