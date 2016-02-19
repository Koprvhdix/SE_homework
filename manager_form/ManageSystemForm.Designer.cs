using System.Collections.Generic;
namespace manager_form
{
    partial class ManageSystemForm
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
            this.YearBox = new System.Windows.Forms.ComboBox();
            this.MonthBox = new System.Windows.Forms.ComboBox();
            this.DayBox = new System.Windows.Forms.ComboBox();
            this.GetData = new System.Windows.Forms.Button();
            this.DataTemporary = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetEXCELButton = new System.Windows.Forms.Button();
            this.StateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataTemporary)).BeginInit();
            this.SuspendLayout();
            // 
            // YearBox
            // 
            this.YearBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.YearBox.FormattingEnabled = true;
            this.YearBox.Location = new System.Drawing.Point(100, 100);
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(120, 27);
            this.YearBox.TabIndex = 0;
            // 
            // MonthBox
            // 
            this.MonthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonthBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MonthBox.FormattingEnabled = true;
            this.MonthBox.Location = new System.Drawing.Point(270, 100);
            this.MonthBox.Name = "MonthBox";
            this.MonthBox.Size = new System.Drawing.Size(120, 27);
            this.MonthBox.TabIndex = 1;
            // 
            // DayBox
            // 
            this.DayBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DayBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DayBox.FormattingEnabled = true;
            this.DayBox.Location = new System.Drawing.Point(440, 100);
            this.DayBox.Name = "DayBox";
            this.DayBox.Size = new System.Drawing.Size(120, 27);
            this.DayBox.TabIndex = 2;
            // 
            // GetData
            // 
            this.GetData.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetData.Location = new System.Drawing.Point(600, 100);
            this.GetData.Name = "GetData";
            this.GetData.Size = new System.Drawing.Size(120, 30);
            this.GetData.TabIndex = 3;
            this.GetData.Text = "获取数据";
            this.GetData.UseVisualStyleBackColor = true;
            this.GetData.Click += new System.EventHandler(this.GetData_Click);
            // 
            // DataTemporary
            // 
            this.DataTemporary.AllowUserToAddRows = false;
            this.DataTemporary.AllowUserToDeleteRows = false;
            this.DataTemporary.AllowUserToResizeColumns = false;
            this.DataTemporary.AllowUserToResizeRows = false;
            this.DataTemporary.BackgroundColor = System.Drawing.Color.White;
            this.DataTemporary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTemporary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5});
            this.DataTemporary.Location = new System.Drawing.Point(100, 170);
            this.DataTemporary.Name = "DataTemporary";
            this.DataTemporary.ReadOnly = true;
            this.DataTemporary.RowTemplate.Height = 23;
            this.DataTemporary.Size = new System.Drawing.Size(620, 250);
            this.DataTemporary.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "临时卡号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "车牌号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "进入时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "离开时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "停留时间";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "所收费用";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // GetEXCELButton
            // 
            this.GetEXCELButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetEXCELButton.Location = new System.Drawing.Point(325, 440);
            this.GetEXCELButton.Name = "GetEXCELButton";
            this.GetEXCELButton.Size = new System.Drawing.Size(150, 30);
            this.GetEXCELButton.TabIndex = 5;
            this.GetEXCELButton.Text = "一键生成Excel";
            this.GetEXCELButton.UseVisualStyleBackColor = true;
            this.GetEXCELButton.Click += new System.EventHandler(this.GetEXCELButton_Click);
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StateLabel.Location = new System.Drawing.Point(98, 139);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(0, 20);
            this.StateLabel.TabIndex = 6;
            // 
            // ManageSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.GetEXCELButton);
            this.Controls.Add(this.DataTemporary);
            this.Controls.Add(this.GetData);
            this.Controls.Add(this.DayBox);
            this.Controls.Add(this.MonthBox);
            this.Controls.Add(this.YearBox);
            this.Name = "ManageSystemForm";
            this.Text = "ManageSystemForm";
            this.Load += new System.EventHandler(this.ManageSystemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTemporary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox YearBox;
        private System.Windows.Forms.ComboBox MonthBox;
        private System.Windows.Forms.ComboBox DayBox;
        private System.Windows.Forms.Button GetData;
        private System.Windows.Forms.DataGridView DataTemporary;
        private System.Windows.Forms.Button GetEXCELButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label StateLabel;
        List<PayPageData> PayListData;
    }
}