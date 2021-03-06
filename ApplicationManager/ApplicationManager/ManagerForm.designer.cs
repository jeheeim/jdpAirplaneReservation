﻿namespace ApplicationManager
{
	partial class ManagerForm
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.lblAirplaneID = new System.Windows.Forms.Label();
			this.lblDepartApt = new System.Windows.Forms.Label();
			this.lblDepartTime = new System.Windows.Forms.Label();
			this.lblDepartDate = new System.Windows.Forms.Label();
			this.lblDestApt = new System.Windows.Forms.Label();
			this.btnModify = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tboxAirplaneID = new System.Windows.Forms.TextBox();
			this.tboxDepartApt = new System.Windows.Forms.TextBox();
			this.tboxDestApt = new System.Windows.Forms.TextBox();
			this.dtpDepartDate = new System.Windows.Forms.DateTimePicker();
			this.dtpDepartTime = new System.Windows.Forms.DateTimePicker();
			this.lblDestCountry = new System.Windows.Forms.Label();
			this.tboxDestCountry = new System.Windows.Forms.TextBox();
			this.lblNumOfSeat = new System.Windows.Forms.Label();
			this.lblCost = new System.Windows.Forms.Label();
			this.tboxCost = new System.Windows.Forms.TextBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.rbtn30 = new System.Windows.Forms.RadioButton();
			this.rbtn50 = new System.Windows.Forms.RadioButton();
			this.tboxRegion = new System.Windows.Forms.TextBox();
			this.lblRegion = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "운항중인 항공기 리스트";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(12, 58);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(142, 304);
			this.listBox1.TabIndex = 2;
			this.listBox1.Click += new System.EventHandler(this.listBox1_ItemClicked);
			// 
			// lblAirplaneID
			// 
			this.lblAirplaneID.AutoSize = true;
			this.lblAirplaneID.Location = new System.Drawing.Point(179, 61);
			this.lblAirplaneID.Name = "lblAirplaneID";
			this.lblAirplaneID.Size = new System.Drawing.Size(87, 15);
			this.lblAirplaneID.TabIndex = 3;
			this.lblAirplaneID.Text = "항공기 편명";
			// 
			// lblDepartApt
			// 
			this.lblDepartApt.AutoSize = true;
			this.lblDepartApt.Location = new System.Drawing.Point(179, 92);
			this.lblDepartApt.Name = "lblDepartApt";
			this.lblDepartApt.Size = new System.Drawing.Size(67, 15);
			this.lblDepartApt.TabIndex = 4;
			this.lblDepartApt.Text = "출발공항";
			// 
			// lblDepartTime
			// 
			this.lblDepartTime.AutoSize = true;
			this.lblDepartTime.Location = new System.Drawing.Point(179, 158);
			this.lblDepartTime.Name = "lblDepartTime";
			this.lblDepartTime.Size = new System.Drawing.Size(67, 15);
			this.lblDepartTime.TabIndex = 5;
			this.lblDepartTime.Text = "출발시각";
			// 
			// lblDepartDate
			// 
			this.lblDepartDate.AutoSize = true;
			this.lblDepartDate.Location = new System.Drawing.Point(179, 127);
			this.lblDepartDate.Name = "lblDepartDate";
			this.lblDepartDate.Size = new System.Drawing.Size(52, 15);
			this.lblDepartDate.TabIndex = 6;
			this.lblDepartDate.Text = "출발일";
			// 
			// lblDestApt
			// 
			this.lblDestApt.AutoSize = true;
			this.lblDestApt.Location = new System.Drawing.Point(179, 247);
			this.lblDestApt.Name = "lblDestApt";
			this.lblDestApt.Size = new System.Drawing.Size(67, 15);
			this.lblDestApt.TabIndex = 7;
			this.lblDestApt.Text = "도착공항";
			// 
			// btnModify
			// 
			this.btnModify.Location = new System.Drawing.Point(170, 340);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(75, 23);
			this.btnModify.TabIndex = 9;
			this.btnModify.Text = "수정";
			this.btnModify.UseVisualStyleBackColor = true;
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(251, 340);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 10;
			this.btnAdd.Text = "추가";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(413, 340);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "취소";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tboxAirplaneID
			// 
			this.tboxAirplaneID.Location = new System.Drawing.Point(272, 58);
			this.tboxAirplaneID.Name = "tboxAirplaneID";
			this.tboxAirplaneID.Size = new System.Drawing.Size(216, 25);
			this.tboxAirplaneID.TabIndex = 12;
			// 
			// tboxDepartApt
			// 
			this.tboxDepartApt.Location = new System.Drawing.Point(272, 89);
			this.tboxDepartApt.Name = "tboxDepartApt";
			this.tboxDepartApt.Size = new System.Drawing.Size(216, 25);
			this.tboxDepartApt.TabIndex = 13;
			// 
			// tboxDestApt
			// 
			this.tboxDestApt.Location = new System.Drawing.Point(272, 244);
			this.tboxDestApt.Name = "tboxDestApt";
			this.tboxDestApt.Size = new System.Drawing.Size(216, 25);
			this.tboxDestApt.TabIndex = 16;
			// 
			// dtpDepartDate
			// 
			this.dtpDepartDate.Location = new System.Drawing.Point(272, 120);
			this.dtpDepartDate.Name = "dtpDepartDate";
			this.dtpDepartDate.Size = new System.Drawing.Size(216, 25);
			this.dtpDepartDate.TabIndex = 18;
			// 
			// dtpDepartTime
			// 
			this.dtpDepartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtpDepartTime.Location = new System.Drawing.Point(272, 151);
			this.dtpDepartTime.Name = "dtpDepartTime";
			this.dtpDepartTime.Size = new System.Drawing.Size(216, 25);
			this.dtpDepartTime.TabIndex = 19;
			// 
			// lblDestCountry
			// 
			this.lblDestCountry.AutoSize = true;
			this.lblDestCountry.Location = new System.Drawing.Point(179, 216);
			this.lblDestCountry.Name = "lblDestCountry";
			this.lblDestCountry.Size = new System.Drawing.Size(67, 15);
			this.lblDestCountry.TabIndex = 20;
			this.lblDestCountry.Text = "도착국가";
			// 
			// tboxDestCountry
			// 
			this.tboxDestCountry.Location = new System.Drawing.Point(272, 213);
			this.tboxDestCountry.Name = "tboxDestCountry";
			this.tboxDestCountry.Size = new System.Drawing.Size(216, 25);
			this.tboxDestCountry.TabIndex = 21;
			// 
			// lblNumOfSeat
			// 
			this.lblNumOfSeat.AutoSize = true;
			this.lblNumOfSeat.Location = new System.Drawing.Point(179, 275);
			this.lblNumOfSeat.Name = "lblNumOfSeat";
			this.lblNumOfSeat.Size = new System.Drawing.Size(52, 15);
			this.lblNumOfSeat.TabIndex = 22;
			this.lblNumOfSeat.Text = "좌석수";
			// 
			// lblCost
			// 
			this.lblCost.AutoSize = true;
			this.lblCost.Location = new System.Drawing.Point(179, 303);
			this.lblCost.Name = "lblCost";
			this.lblCost.Size = new System.Drawing.Size(87, 15);
			this.lblCost.TabIndex = 24;
			this.lblCost.Text = "좌석당 가격";
			// 
			// tboxCost
			// 
			this.tboxCost.Location = new System.Drawing.Point(272, 300);
			this.tboxCost.Name = "tboxCost";
			this.tboxCost.Size = new System.Drawing.Size(216, 25);
			this.tboxCost.TabIndex = 25;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(332, 340);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 28;
			this.btnDelete.Text = "삭제";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// rbtn30
			// 
			this.rbtn30.AutoSize = true;
			this.rbtn30.Location = new System.Drawing.Point(300, 273);
			this.rbtn30.Name = "rbtn30";
			this.rbtn30.Size = new System.Drawing.Size(59, 19);
			this.rbtn30.TabIndex = 29;
			this.rbtn30.TabStop = true;
			this.rbtn30.Text = "30석";
			this.rbtn30.UseVisualStyleBackColor = true;
			// 
			// rbtn50
			// 
			this.rbtn50.AutoSize = true;
			this.rbtn50.Location = new System.Drawing.Point(400, 273);
			this.rbtn50.Name = "rbtn50";
			this.rbtn50.Size = new System.Drawing.Size(59, 19);
			this.rbtn50.TabIndex = 30;
			this.rbtn50.TabStop = true;
			this.rbtn50.Text = "50석";
			this.rbtn50.UseVisualStyleBackColor = true;
			// 
			// tboxRegion
			// 
			this.tboxRegion.Location = new System.Drawing.Point(272, 182);
			this.tboxRegion.Name = "tboxRegion";
			this.tboxRegion.Size = new System.Drawing.Size(216, 25);
			this.tboxRegion.TabIndex = 31;
			// 
			// lblRegion
			// 
			this.lblRegion.AutoSize = true;
			this.lblRegion.Location = new System.Drawing.Point(179, 185);
			this.lblRegion.Name = "lblRegion";
			this.lblRegion.Size = new System.Drawing.Size(37, 15);
			this.lblRegion.TabIndex = 32;
			this.lblRegion.Text = "대륙";
			// 
			// ManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 380);
			this.Controls.Add(this.lblRegion);
			this.Controls.Add(this.tboxRegion);
			this.Controls.Add(this.rbtn50);
			this.Controls.Add(this.rbtn30);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.tboxCost);
			this.Controls.Add(this.lblCost);
			this.Controls.Add(this.lblNumOfSeat);
			this.Controls.Add(this.tboxDestCountry);
			this.Controls.Add(this.lblDestCountry);
			this.Controls.Add(this.dtpDepartTime);
			this.Controls.Add(this.dtpDepartDate);
			this.Controls.Add(this.tboxDestApt);
			this.Controls.Add(this.tboxDepartApt);
			this.Controls.Add(this.tboxAirplaneID);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnModify);
			this.Controls.Add(this.lblDestApt);
			this.Controls.Add(this.lblDepartDate);
			this.Controls.Add(this.lblDepartTime);
			this.Controls.Add(this.lblDepartApt);
			this.Controls.Add(this.lblAirplaneID);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.label1);
			this.Name = "ManagerForm";
			this.Text = "ManagerForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManagerForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label lblAirplaneID;
		private System.Windows.Forms.Label lblDepartApt;
		private System.Windows.Forms.Label lblDepartTime;
		private System.Windows.Forms.Label lblDepartDate;
		private System.Windows.Forms.Label lblDestApt;
		private System.Windows.Forms.Button btnModify;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox tboxAirplaneID;
		private System.Windows.Forms.TextBox tboxDepartApt;
		private System.Windows.Forms.TextBox tboxDestApt;
		private System.Windows.Forms.DateTimePicker dtpDepartDate;
		private System.Windows.Forms.DateTimePicker dtpDepartTime;
		private System.Windows.Forms.Label lblDestCountry;
		private System.Windows.Forms.TextBox tboxDestCountry;
		private System.Windows.Forms.Label lblNumOfSeat;
		private System.Windows.Forms.Label lblCost;
		private System.Windows.Forms.TextBox tboxCost;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.RadioButton rbtn30;
		private System.Windows.Forms.RadioButton rbtn50;
		private System.Windows.Forms.TextBox tboxRegion;
		private System.Windows.Forms.Label lblRegion;
	}
}