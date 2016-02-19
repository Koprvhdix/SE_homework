using System.Collections.Generic;
namespace manager_form
{
    partial class PayForm
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
            this.CardNumLabel = new System.Windows.Forms.Label();
            this.CardNumBox = new System.Windows.Forms.TextBox();
            this.DataCard = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SummitButton = new System.Windows.Forms.Button();
            this.LeftMoneyLabel = new System.Windows.Forms.Label();
            this.LeftMoney = new System.Windows.Forms.Label();
            this.SendMoneyLabel = new System.Windows.Forms.Label();
            this.SendMoneyText = new System.Windows.Forms.TextBox();
            this.GetExcel = new System.Windows.Forms.Button();
            this.StateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataCard)).BeginInit();
            this.SuspendLayout();
            // 
            // CardNumLabel
            // 
            this.CardNumLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CardNumLabel.Location = new System.Drawing.Point(137, 69);
            this.CardNumLabel.Name = "CardNumLabel";
            this.CardNumLabel.Size = new System.Drawing.Size(150, 30);
            this.CardNumLabel.TabIndex = 0;
            this.CardNumLabel.Text = "卡号：";
            this.CardNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CardNumBox
            // 
            this.CardNumBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CardNumBox.Location = new System.Drawing.Point(366, 71);
            this.CardNumBox.Name = "CardNumBox";
            this.CardNumBox.Size = new System.Drawing.Size(200, 29);
            this.CardNumBox.TabIndex = 1;
            // 
            // DataCard
            // 
            this.DataCard.AllowUserToAddRows = false;
            this.DataCard.AllowUserToDeleteRows = false;
            this.DataCard.AllowUserToResizeColumns = false;
            this.DataCard.AllowUserToResizeRows = false;
            this.DataCard.BackgroundColor = System.Drawing.Color.White;
            this.DataCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4});
            this.DataCard.Location = new System.Drawing.Point(142, 202);
            this.DataCard.Name = "DataCard";
            this.DataCard.ReadOnly = true;
            this.DataCard.RowTemplate.Height = 23;
            this.DataCard.Size = new System.Drawing.Size(650, 150);
            this.DataCard.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "车牌号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "进入时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "离开时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "停留时间";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "金额";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // SummitButton
            // 
            this.SummitButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SummitButton.Location = new System.Drawing.Point(310, 202);
            this.SummitButton.Name = "SummitButton";
            this.SummitButton.Size = new System.Drawing.Size(150, 30);
            this.SummitButton.TabIndex = 3;
            this.SummitButton.Text = "提交";
            this.SummitButton.UseVisualStyleBackColor = true;
            this.SummitButton.Click += new System.EventHandler(this.SummitButton_Click);
            // 
            // LeftMoneyLabel
            // 
            this.LeftMoneyLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LeftMoneyLabel.Location = new System.Drawing.Point(173, 113);
            this.LeftMoneyLabel.Name = "LeftMoneyLabel";
            this.LeftMoneyLabel.Size = new System.Drawing.Size(150, 30);
            this.LeftMoneyLabel.TabIndex = 4;
            this.LeftMoneyLabel.Text = "所剩余额：";
            this.LeftMoneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LeftMoney
            // 
            this.LeftMoney.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LeftMoney.Location = new System.Drawing.Point(373, 125);
            this.LeftMoney.Name = "LeftMoney";
            this.LeftMoney.Size = new System.Drawing.Size(200, 30);
            this.LeftMoney.TabIndex = 5;
            this.LeftMoney.Text = "￥";
            this.LeftMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SendMoneyLabel
            // 
            this.SendMoneyLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SendMoneyLabel.Location = new System.Drawing.Point(183, 143);
            this.SendMoneyLabel.Name = "SendMoneyLabel";
            this.SendMoneyLabel.Size = new System.Drawing.Size(150, 30);
            this.SendMoneyLabel.TabIndex = 6;
            this.SendMoneyLabel.Text = "所交金额：";
            this.SendMoneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SendMoneyText
            // 
            this.SendMoneyText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SendMoneyText.Location = new System.Drawing.Point(366, 145);
            this.SendMoneyText.Name = "SendMoneyText";
            this.SendMoneyText.Size = new System.Drawing.Size(200, 29);
            this.SendMoneyText.TabIndex = 7;
            // 
            // GetExcel
            // 
            this.GetExcel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetExcel.Location = new System.Drawing.Point(324, 419);
            this.GetExcel.Name = "GetExcel";
            this.GetExcel.Size = new System.Drawing.Size(150, 30);
            this.GetExcel.TabIndex = 8;
            this.GetExcel.Text = "生成EXCEL";
            this.GetExcel.UseVisualStyleBackColor = true;
            this.GetExcel.Click += new System.EventHandler(this.GetExcel_Click);
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StateLabel.Location = new System.Drawing.Point(217, 187);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(0, 20);
            this.StateLabel.TabIndex = 9;
            // 
            // PayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.GetExcel);
            this.Controls.Add(this.SendMoneyText);
            this.Controls.Add(this.SendMoneyLabel);
            this.Controls.Add(this.LeftMoney);
            this.Controls.Add(this.LeftMoneyLabel);
            this.Controls.Add(this.SummitButton);
            this.Controls.Add(this.DataCard);
            this.Controls.Add(this.CardNumBox);
            this.Controls.Add(this.CardNumLabel);
            this.Name = "PayForm";
            this.Text = "PayForm";
            this.Load += new System.EventHandler(this.PayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CardNumLabel;
        private System.Windows.Forms.TextBox CardNumBox;
        private System.Windows.Forms.DataGridView DataCard;
        private System.Windows.Forms.Button SummitButton;
        private System.Windows.Forms.Label LeftMoneyLabel;
        private System.Windows.Forms.Label LeftMoney;
        private System.Windows.Forms.Label SendMoneyLabel;
        private System.Windows.Forms.TextBox SendMoneyText;
        private System.Windows.Forms.Button GetExcel;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        List<PayPageData> PayListData;
    }
}