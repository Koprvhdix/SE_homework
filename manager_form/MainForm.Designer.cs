using System.Collections.Generic;
using System.Windows.Forms;
namespace manager_form
{
    partial class MainForm
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
            this.RegisterButton = new System.Windows.Forms.Button();
            this.PayButton = new System.Windows.Forms.Button();
            this.GetTemporaryData = new System.Windows.Forms.Button();
            this.StateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserName.Location = new System.Drawing.Point(258, 133);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(200, 26);
            this.UserName.TabIndex = 0;
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Password.Location = new System.Drawing.Point(258, 183);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(200, 26);
            this.Password.TabIndex = 1;
            this.Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPress);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UserNameLabel.Location = new System.Drawing.Point(70, 131);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(100, 23);
            this.UserNameLabel.TabIndex = 2;
            this.UserNameLabel.Text = "用户名：";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PasswordLabel.Location = new System.Drawing.Point(139, 183);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(100, 23);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "密码：";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SignInButton
            // 
            this.SignInButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SignInButton.Location = new System.Drawing.Point(276, 240);
            this.SignInButton.Name = "SignInButton";
            this.SignInButton.Size = new System.Drawing.Size(100, 30);
            this.SignInButton.TabIndex = 4;
            this.SignInButton.Text = "登录";
            this.SignInButton.UseVisualStyleBackColor = true;
            this.SignInButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RegisterButton.Location = new System.Drawing.Point(0, 0);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(150, 100);
            this.RegisterButton.TabIndex = 5;
            this.RegisterButton.Text = "办卡注册";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // PayButton
            // 
            this.PayButton.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PayButton.Location = new System.Drawing.Point(356, 39);
            this.PayButton.Name = "PayButton";
            this.PayButton.Size = new System.Drawing.Size(150, 100);
            this.PayButton.TabIndex = 6;
            this.PayButton.Text = "缴纳费用";
            this.PayButton.UseVisualStyleBackColor = true;
            this.PayButton.Click += new System.EventHandler(this.PayButton_Click);
            // 
            // GetTemporaryData
            // 
            this.GetTemporaryData.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GetTemporaryData.Location = new System.Drawing.Point(132, 39);
            this.GetTemporaryData.Name = "GetTemporaryData";
            this.GetTemporaryData.Size = new System.Drawing.Size(150, 100);
            this.GetTemporaryData.TabIndex = 7;
            this.GetTemporaryData.Text = "生成报表";
            this.GetTemporaryData.UseVisualStyleBackColor = true;
            this.GetTemporaryData.Click += new System.EventHandler(this.ManageSystemButton_Click);
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StateLabel.Location = new System.Drawing.Point(256, 300);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(0, 19);
            this.StateLabel.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.GetTemporaryData);
            this.Controls.Add(this.PayButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.SignInButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserName);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BeforeClosing);
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
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button PayButton;
        private System.Windows.Forms.Button GetTemporaryData;
        List<Button> ButtonList;
        public static string session;
        public static string user_name;
        private Label StateLabel;
    }
}

