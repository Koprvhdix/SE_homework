using System.Collections.Generic;
namespace manager_form
{
    partial class RegisterForm
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.SexLabel = new System.Windows.Forms.Label();
            this.NumEmployeeLabel = new System.Windows.Forms.Label();
            this.PhoneNumLabel = new System.Windows.Forms.Label();
            this.MaleCheck = new System.Windows.Forms.CheckBox();
            this.FemaleCheck = new System.Windows.Forms.CheckBox();
            this.PhoneNumTxt = new System.Windows.Forms.TextBox();
            this.NumEmployeeTxt = new System.Windows.Forms.TextBox();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.PayTypeID = new System.Windows.Forms.CheckedListBox();
            this.CommitRegisterButton = new System.Windows.Forms.Button();
            this.StateLabel = new System.Windows.Forms.Label();
            this.SelectCombo = new System.Windows.Forms.Button();
            this.SelectParking = new System.Windows.Forms.Button();
            this.SelectParkingPosition = new System.Windows.Forms.CheckedListBox();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.MoneyText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameLabel.Location = new System.Drawing.Point(81, 37);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(130, 23);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "姓名：";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SexLabel
            // 
            this.SexLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SexLabel.Location = new System.Drawing.Point(81, 109);
            this.SexLabel.Name = "SexLabel";
            this.SexLabel.Size = new System.Drawing.Size(130, 23);
            this.SexLabel.TabIndex = 1;
            this.SexLabel.Text = "性别：";
            this.SexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumEmployeeLabel
            // 
            this.NumEmployeeLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumEmployeeLabel.Location = new System.Drawing.Point(81, 190);
            this.NumEmployeeLabel.Name = "NumEmployeeLabel";
            this.NumEmployeeLabel.Size = new System.Drawing.Size(130, 23);
            this.NumEmployeeLabel.TabIndex = 2;
            this.NumEmployeeLabel.Text = "员工号：";
            this.NumEmployeeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PhoneNumLabel
            // 
            this.PhoneNumLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PhoneNumLabel.Location = new System.Drawing.Point(339, 123);
            this.PhoneNumLabel.Name = "PhoneNumLabel";
            this.PhoneNumLabel.Size = new System.Drawing.Size(130, 23);
            this.PhoneNumLabel.TabIndex = 3;
            this.PhoneNumLabel.Text = "联系方式：";
            this.PhoneNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MaleCheck
            // 
            this.MaleCheck.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaleCheck.Location = new System.Drawing.Point(344, 190);
            this.MaleCheck.Name = "MaleCheck";
            this.MaleCheck.Size = new System.Drawing.Size(50, 24);
            this.MaleCheck.TabIndex = 1;
            this.MaleCheck.Text = "男";
            this.MaleCheck.UseVisualStyleBackColor = true;
            this.MaleCheck.CheckedChanged += new System.EventHandler(this.MaleCheck_CheckedChanged);
            // 
            // FemaleCheck
            // 
            this.FemaleCheck.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FemaleCheck.Location = new System.Drawing.Point(347, 236);
            this.FemaleCheck.Name = "FemaleCheck";
            this.FemaleCheck.Size = new System.Drawing.Size(50, 24);
            this.FemaleCheck.TabIndex = 2;
            this.FemaleCheck.Text = "女";
            this.FemaleCheck.UseVisualStyleBackColor = true;
            this.FemaleCheck.CheckedChanged += new System.EventHandler(this.FemaleCheck_CheckedChanged);
            // 
            // PhoneNumTxt
            // 
            this.PhoneNumTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PhoneNumTxt.Location = new System.Drawing.Point(313, 158);
            this.PhoneNumTxt.Name = "PhoneNumTxt";
            this.PhoneNumTxt.Size = new System.Drawing.Size(200, 26);
            this.PhoneNumTxt.TabIndex = 4;
            this.PhoneNumTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsPhoneNum);
            // 
            // NumEmployeeTxt
            // 
            this.NumEmployeeTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumEmployeeTxt.Location = new System.Drawing.Point(313, 81);
            this.NumEmployeeTxt.Name = "NumEmployeeTxt";
            this.NumEmployeeTxt.Size = new System.Drawing.Size(200, 26);
            this.NumEmployeeTxt.TabIndex = 3;
            // 
            // NameTxt
            // 
            this.NameTxt.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameTxt.ImeMode = System.Windows.Forms.ImeMode.On;
            this.NameTxt.Location = new System.Drawing.Point(313, 37);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(200, 26);
            this.NameTxt.TabIndex = 0;
            // 
            // PayTypeID
            // 
            this.PayTypeID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PayTypeID.FormattingEnabled = true;
            this.PayTypeID.Location = new System.Drawing.Point(87, 245);
            this.PayTypeID.Name = "PayTypeID";
            this.PayTypeID.Size = new System.Drawing.Size(644, 172);
            this.PayTypeID.TabIndex = 6;
            this.PayTypeID.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.itemChecked);
            // 
            // CommitRegisterButton
            // 
            this.CommitRegisterButton.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CommitRegisterButton.Location = new System.Drawing.Point(591, 112);
            this.CommitRegisterButton.Name = "CommitRegisterButton";
            this.CommitRegisterButton.Size = new System.Drawing.Size(200, 35);
            this.CommitRegisterButton.TabIndex = 11;
            this.CommitRegisterButton.Text = "提交";
            this.CommitRegisterButton.UseVisualStyleBackColor = true;
            this.CommitRegisterButton.Click += new System.EventHandler(this.CommitRegisterButton_Click);
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StateLabel.Location = new System.Drawing.Point(33, 69);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(0, 20);
            this.StateLabel.TabIndex = 12;
            // 
            // SelectCombo
            // 
            this.SelectCombo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectCombo.Location = new System.Drawing.Point(480, 202);
            this.SelectCombo.Name = "SelectCombo";
            this.SelectCombo.Size = new System.Drawing.Size(100, 30);
            this.SelectCombo.TabIndex = 13;
            this.SelectCombo.Text = "选择套餐";
            this.SelectCombo.UseVisualStyleBackColor = true;
            this.SelectCombo.Click += new System.EventHandler(this.SelectCombo_Click);
            // 
            // SelectParking
            // 
            this.SelectParking.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectParking.Location = new System.Drawing.Point(591, 176);
            this.SelectParking.Name = "SelectParking";
            this.SelectParking.Size = new System.Drawing.Size(100, 30);
            this.SelectParking.TabIndex = 14;
            this.SelectParking.Text = "选择停车位";
            this.SelectParking.UseVisualStyleBackColor = true;
            this.SelectParking.Click += new System.EventHandler(this.SelectParking_Click);
            // 
            // SelectParkingPosition
            // 
            this.SelectParkingPosition.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectParkingPosition.FormattingEnabled = true;
            this.SelectParkingPosition.Location = new System.Drawing.Point(86, 282);
            this.SelectParkingPosition.Name = "SelectParkingPosition";
            this.SelectParkingPosition.Size = new System.Drawing.Size(644, 172);
            this.SelectParkingPosition.TabIndex = 15;
            // 
            // moneyLabel
            // 
            this.moneyLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.moneyLabel.Location = new System.Drawing.Point(589, 51);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(100, 23);
            this.moneyLabel.TabIndex = 16;
            this.moneyLabel.Text = "缴费：";
            this.moneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MoneyText
            // 
            this.MoneyText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MoneyText.Location = new System.Drawing.Point(569, 85);
            this.MoneyText.Name = "MoneyText";
            this.MoneyText.Size = new System.Drawing.Size(200, 26);
            this.MoneyText.TabIndex = 5;
            this.MoneyText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsNumPress);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.MoneyText);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.SelectParkingPosition);
            this.Controls.Add(this.SelectParking);
            this.Controls.Add(this.SelectCombo);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.CommitRegisterButton);
            this.Controls.Add(this.PayTypeID);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.NumEmployeeTxt);
            this.Controls.Add(this.PhoneNumTxt);
            this.Controls.Add(this.FemaleCheck);
            this.Controls.Add(this.MaleCheck);
            this.Controls.Add(this.PhoneNumLabel);
            this.Controls.Add(this.NumEmployeeLabel);
            this.Controls.Add(this.SexLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SexLabel;
        private System.Windows.Forms.Label NumEmployeeLabel;
        private System.Windows.Forms.Label PhoneNumLabel;
        private System.Windows.Forms.CheckBox MaleCheck;
        private System.Windows.Forms.CheckBox FemaleCheck;
        private System.Windows.Forms.TextBox PhoneNumTxt;
        private System.Windows.Forms.TextBox NumEmployeeTxt;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.CheckedListBox PayTypeID;
        private System.Windows.Forms.Button CommitRegisterButton;
        private System.Windows.Forms.Label StateLabel;
        List<ComboData> listData;
        List<ParkingInformation> listParkingData;
        string sex = "";
        string combo_id = "";
        private System.Windows.Forms.Button SelectCombo;
        private System.Windows.Forms.Button SelectParking;
        private System.Windows.Forms.CheckedListBox SelectParkingPosition;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.TextBox MoneyText;
    }
}