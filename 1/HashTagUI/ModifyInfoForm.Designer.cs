namespace HashTagUI
{
	partial class ModifyInfoForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tboxName = new System.Windows.Forms.TextBox();
			this.tboxID = new System.Windows.Forms.TextBox();
			this.tboxPassword = new System.Windows.Forms.TextBox();
			this.tboxPasswordConfirm = new System.Windows.Forms.TextBox();
			this.tboxEmail = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.cboxInterest = new System.Windows.Forms.ComboBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "이름";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "아이디";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 152);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "비밀번호";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(25, 213);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(102, 15);
			this.label4.TabIndex = 3;
			this.label4.Text = "비밀번호 확인";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(25, 269);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 15);
			this.label5.TabIndex = 4;
			this.label5.Text = "E-mail";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(25, 321);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(117, 15);
			this.label6.TabIndex = 5;
			this.label6.Text = "선호하는 여행지";
			// 
			// tboxName
			// 
			this.tboxName.Location = new System.Drawing.Point(169, 28);
			this.tboxName.Name = "tboxName";
			this.tboxName.Size = new System.Drawing.Size(180, 25);
			this.tboxName.TabIndex = 6;
			// 
			// tboxID
			// 
			this.tboxID.Location = new System.Drawing.Point(169, 87);
			this.tboxID.Name = "tboxID";
			this.tboxID.ReadOnly = true;
			this.tboxID.Size = new System.Drawing.Size(180, 25);
			this.tboxID.TabIndex = 7;
			// 
			// tboxPassword
			// 
			this.tboxPassword.Location = new System.Drawing.Point(169, 149);
			this.tboxPassword.Name = "tboxPassword";
			this.tboxPassword.Size = new System.Drawing.Size(180, 25);
			this.tboxPassword.TabIndex = 8;
			// 
			// tboxPasswordConfirm
			// 
			this.tboxPasswordConfirm.Location = new System.Drawing.Point(169, 210);
			this.tboxPasswordConfirm.Name = "tboxPasswordConfirm";
			this.tboxPasswordConfirm.Size = new System.Drawing.Size(180, 25);
			this.tboxPasswordConfirm.TabIndex = 9;
			// 
			// tboxEmail
			// 
			this.tboxEmail.Location = new System.Drawing.Point(169, 266);
			this.tboxEmail.Name = "tboxEmail";
			this.tboxEmail.Size = new System.Drawing.Size(180, 25);
			this.tboxEmail.TabIndex = 10;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(67, 379);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "수정";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(229, 379);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "취소";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// cboxInterest
			// 
			this.cboxInterest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxInterest.FormattingEnabled = true;
			this.cboxInterest.Location = new System.Drawing.Point(169, 318);
			this.cboxInterest.Name = "cboxInterest";
			this.cboxInterest.Size = new System.Drawing.Size(180, 23);
			this.cboxInterest.Sorted = true;
			this.cboxInterest.TabIndex = 11;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(148, 379);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 14;
			this.btnDelete.Text = "탈퇴";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// ModifyInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(388, 435);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.cboxInterest);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tboxEmail);
			this.Controls.Add(this.tboxPasswordConfirm);
			this.Controls.Add(this.tboxPassword);
			this.Controls.Add(this.tboxID);
			this.Controls.Add(this.tboxName);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ModifyInfoForm";
			this.Text = "개인정보 수정";
			this.Load += new System.EventHandler(this.ModifyInfo_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tboxName;
		private System.Windows.Forms.TextBox tboxID;
		private System.Windows.Forms.TextBox tboxPassword;
		private System.Windows.Forms.TextBox tboxPasswordConfirm;
		private System.Windows.Forms.TextBox tboxEmail;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cboxInterest;
		private System.Windows.Forms.Button btnDelete;
	}
}