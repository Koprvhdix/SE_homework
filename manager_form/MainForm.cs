using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manager_form
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StateLabel.Text = String.Empty;
            //POST请求
            string password = Password.Text;
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                password = sBuilder.ToString();
            }
            try
            {
                string Url;
                Url = "http://localhost:8888/managelogin";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                req.Method = "POST";
                string PostData = "manage_user_id=" + UserName.Text + "&password=" + password;
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] Data = encoding.GetBytes(PostData);
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = Data.Length;
                Stream newStream = req.GetRequestStream();
                newStream.Write(Data, 0, Data.Length);
                newStream.Close();
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream resst = res.GetResponseStream();
                StreamReader sr = new StreamReader(resst);
                string str = sr.ReadToEnd();

                if (str == "User isn't existed")
                {
                    StateLabel.Text = "用户名不存在";
                    return;
                }
                else if (str == "Error Password")
                {
                    StateLabel.Text = "密码错误";
                    return;
                }
                else
                {
                    session = str;
                    user_name = UserName.Text;
                }
            }
            catch (Exception m)
            {
                StateLabel.Text = "请检查网络连接";
                return;
            }

            UserName.Visible = false;
            UserNameLabel.Visible = false;
            Password.Visible = false;
            PasswordLabel.Visible = false;
            SignInButton.Visible = false;
            for (int i = 0; i < ButtonList.Count(); i++)
            {
                ButtonList[i].Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);
            //登录界面
            UserName.Location = new Point(350, 200);
            UserNameLabel.Location = new Point(250, 200);
            Password.Location = new Point(350, 250);
            PasswordLabel.Location = new Point(250, 250);
            Password.PasswordChar = '*';
            SignInButton.Location = new Point(350, 300);
            UserName.Text = "admin";
            Password.Text = "12345";
            StateLabel.Location = new Point(350, 350);

            //选择按钮
            ButtonList = new List<Button>();
            ButtonList.Add(RegisterButton);
            ButtonList.Add(PayButton);
            ButtonList.Add(GetTemporaryData);
            for (int i = 0; i < ButtonList.Count(); i++)
            {
                ButtonList[i].Location = new Point(100 + i * 210, 250);
                ButtonList[i].Visible = false;
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void ManageSystemButton_Click(object sender, EventArgs e)
        {
            ManageSystemForm manageSystem = new ManageSystemForm();
            manageSystem.Show();
        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            PayForm payForm = new PayForm();
            payForm.Show();
        }

        private void BeforeClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string Url;
                Url = "http://localhost:8888/inoutloginout";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                req.Method = "POST";
                string PostData = "user_id=" + user_name + "&session=" + session;
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] Data = encoding.GetBytes(PostData);
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = Data.Length;
                Stream newStream = req.GetRequestStream();
                newStream.Write(Data, 0, Data.Length);
                newStream.Close();
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream resst = res.GetResponseStream();
                StreamReader sr = new StreamReader(resst);
                string str = sr.ReadToEnd();
            }
            catch (Exception m)
            {

            }
        }

        private void EnterPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        }
    }
}
