using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
namespace In_out_form
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.UserName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SignInButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NumCard = new System.Windows.Forms.TextBox();
            this.CarNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LevelCard = new System.Windows.Forms.Label();
            this.NumPosition = new System.Windows.Forms.Label();
            this.EnterTime = new System.Windows.Forms.Label();
            this.LeaveTime = new System.Windows.Forms.Label();
            this.NumMoney = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.CountParkingLabel = new System.Windows.Forms.Label();
            this.CountParking = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserName.Location = new System.Drawing.Point(278, 125);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(200, 26);
            this.UserName.TabIndex = 0;
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Password.Location = new System.Drawing.Point(278, 194);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(200, 26);
            this.Password.TabIndex = 1;
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterKey);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameLabel.Location = new System.Drawing.Point(150, 125);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(100, 26);
            this.UserNameLabel.TabIndex = 2;
            this.UserNameLabel.Text = "用户名：";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordLabel.Location = new System.Drawing.Point(150, 193);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(100, 26);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "密码：";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SignInButton
            // 
            this.SignInButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SignInButton.Location = new System.Drawing.Point(245, 252);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(100, 30);
            this.SignInButton.TabIndex = 2;
            this.SignInButton.Text = "登录";
            this.SignInButton.UseVisualStyleBackColor = true;
            this.SignInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(542, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "用户卡号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(545, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "等级：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(545, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "车位号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(548, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "进入时间：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(548, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "离开时间：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(676, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "车牌号：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumCard
            // 
            this.NumCard.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumCard.Location = new System.Drawing.Point(12, 12);
            this.NumCard.Name = "NumCard";
            this.NumCard.Size = new System.Drawing.Size(100, 26);
            this.NumCard.TabIndex = 4;
            this.NumCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEnter);
            // 
            // CarNum
            // 
            this.CarNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CarNum.ImeMode = System.Windows.Forms.ImeMode.On;
            this.CarNum.Location = new System.Drawing.Point(107, 376);
            this.CarNum.Name = "CarNum";
            this.CarNum.Size = new System.Drawing.Size(100, 26);
            this.CarNum.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(545, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "应收费用：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LevelCard
            // 
            this.LevelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LevelCard.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LevelCard.Location = new System.Drawing.Point(12, 178);
            this.LevelCard.Name = "LevelCard";
            this.LevelCard.Size = new System.Drawing.Size(41, 12);
            this.LevelCard.TabIndex = 20;
            this.LevelCard.Visible = false;
            // 
            // NumPosition
            // 
            this.NumPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumPosition.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumPosition.Location = new System.Drawing.Point(12, 193);
            this.NumPosition.Name = "NumPosition";
            this.NumPosition.Size = new System.Drawing.Size(41, 12);
            this.NumPosition.TabIndex = 21;
            this.NumPosition.Visible = false;
            // 
            // EnterTime
            // 
            this.EnterTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EnterTime.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EnterTime.Location = new System.Drawing.Point(12, 212);
            this.EnterTime.Name = "EnterTime";
            this.EnterTime.Size = new System.Drawing.Size(100, 29);
            this.EnterTime.TabIndex = 22;
            this.EnterTime.Visible = false;
            // 
            // LeaveTime
            // 
            this.LeaveTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeaveTime.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LeaveTime.Location = new System.Drawing.Point(44, 252);
            this.LeaveTime.Name = "LeaveTime";
            this.LeaveTime.Size = new System.Drawing.Size(47, 12);
            this.LeaveTime.TabIndex = 23;
            this.LeaveTime.Visible = false;
            // 
            // NumMoney
            // 
            this.NumMoney.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumMoney.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumMoney.Location = new System.Drawing.Point(12, 270);
            this.NumMoney.Name = "NumMoney";
            this.NumMoney.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NumMoney.Size = new System.Drawing.Size(100, 23);
            this.NumMoney.TabIndex = 24;
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CommitButton.Location = new System.Drawing.Point(185, 32);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(200, 30);
            this.CommitButton.TabIndex = 5;
            this.CommitButton.Text = "提交";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StatusLabel.Location = new System.Drawing.Point(378, 309);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 20);
            this.StatusLabel.TabIndex = 26;
            // 
            // CountParkingLabel
            // 
            this.CountParkingLabel.AutoEllipsis = true;
            this.CountParkingLabel.AutoSize = true;
            this.CountParkingLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CountParkingLabel.Location = new System.Drawing.Point(493, 252);
            this.CountParkingLabel.Name = "CountParkingLabel";
            this.CountParkingLabel.Size = new System.Drawing.Size(121, 19);
            this.CountParkingLabel.TabIndex = 27;
            this.CountParkingLabel.Text = "剩余临时停车位：";
            this.CountParkingLabel.Visible = false;
            // 
            // CountParking
            // 
            this.CountParking.AutoEllipsis = true;
            this.CountParking.AutoSize = true;
            this.CountParking.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CountParking.Location = new System.Drawing.Point(498, 281);
            this.CountParking.Name = "CountParking";
            this.CountParking.Size = new System.Drawing.Size(0, 20);
            this.CountParking.TabIndex = 28;
            this.CountParking.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.CountParking);
            this.Controls.Add(this.CountParkingLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.NumMoney);
            this.Controls.Add(this.LeaveTime);
            this.Controls.Add(this.EnterTime);
            this.Controls.Add(this.NumPosition);
            this.Controls.Add(this.LevelCard);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CarNum);
            this.Controls.Add(this.NumCard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SignInButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserName);
            this.Name = "Main";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BeforeClose);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button SignInButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private List<Label> LabelList;
        private TextBox NumCard;
        private TextBox CarNum;
        private Label label7;
        private Label LevelCard;
        private Label NumPosition;
        private Label EnterTime;
        private Label LeaveTime;
        private Label NumMoney;
        private List<Label> DataFromServer;
        private Button CommitButton;
        private string session;
        private string user_name;
        private Label StatusLabel;

        private Thread GetCountPosition;
        private ParameterizedThreadStart threadStart;
        private Label CountParkingLabel;
        protected internal Label CountParking;
    }
}