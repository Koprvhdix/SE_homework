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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace In_out_form
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            session = String.Empty;
            threadStart = new ParameterizedThreadStart(GetCountFromServer);
            GetCountPosition = new Thread(threadStart);
            GetCountPosition.IsBackground = true;
        }

        private void GetCountFromServer(object obj)
        {
            for (; ; )
            {
                try
                {
                    string Url;
                    Url = "http://localhost:8888/countparking";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                    req.Method = "GET";
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    Stream resst = res.GetResponseStream();
                    StreamReader sr = new StreamReader(resst);
                    string str = sr.ReadToEnd();
                    CountParking.Text = str;
                    Thread.Sleep(1000);
                }
                catch (Exception m)
                {

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);
            //登录界面
            UserName.Location = new Point(350, 200);
            UserNameLabel.Location = new Point(250, 200);
            Password.Location = new Point(350, 250);
            PasswordLabel.Location = new Point(250, 250);
            Password.PasswordChar = '*';
            SignInButton.Location = new Point(350, 300);
            StatusLabel.Location = new Point(350, 330);

            //使用界面
            LabelList = new List<Label>();
            LabelList.Add(label6);
            LabelList.Add(label1);
            LabelList.Add(label2);
            LabelList.Add(label3);
            LabelList.Add(label4);
            LabelList.Add(label5);
            LabelList.Add(label7);
            for (int i = 0; i < LabelList.Count(); i++)
            {
                LabelList[i].Visible = false;
                LabelList[i].Location = new Point(100, 80 + i * 50);
                LabelList[i].AutoSize = false;
                LabelList[i].Width = 200;
            }

            CarNum.Visible = false;
            NumCard.Visible = false;
            CarNum.Location = new Point(300, 80);
            NumCard.Location = new Point(300, 130);
            CarNum.Width = 300;
            NumCard.Width = 300;

            DataFromServer = new List<Label>();
            DataFromServer.Add(LevelCard);
            DataFromServer.Add(NumPosition);
            DataFromServer.Add(EnterTime);
            DataFromServer.Add(LeaveTime);
            DataFromServer.Add(NumMoney);
            for (int i = 0; i < DataFromServer.Count(); i++)
            {
                DataFromServer[i].Visible = false;
                DataFromServer[i].Width = 300;
                DataFromServer[i].Height = 26;
                DataFromServer[i].Location = new Point(300, 180 + i * 50);
            }
            CommitButton.Location = new Point(300, 430);
            CommitButton.Visible = false;
            UserName.Text = "root";
            Password.Text = "23333";
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {   
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
            string str;
            try
            {
                string Url;
                Url = "http://localhost:8888/inoutlogin";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                req.Method = "POST";
                string PostData = "user_id=" + UserName.Text + "&password=" + password;
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
                str = sr.ReadToEnd();

                if (str == "Password Error")
                {
                    StatusLabel.Text = "密码错误";
                }
                else if (str == "User isn't existed")
                {
                    StatusLabel.Text = "用户不存在";
                }
                else
                {
                    session = str;
                    user_name = UserName.Text;
                    for (int i = 0; i < LabelList.Count(); i++)
                    {
                        LabelList[i].Visible = true;
                    }
                    label6.Visible = true;
                    UserName.Visible = false;
                    UserNameLabel.Visible = false;
                    Password.Visible = false;
                    PasswordLabel.Visible = false;
                    SignInButton.Visible = false;

                    NumCard.Visible = true;
                    CarNum.Visible = true;
                    for (int i = 0; i < DataFromServer.Count(); i++)
                    {
                        DataFromServer[i].Visible = true;
                    }
                    CommitButton.Visible = true;
                    StatusLabel.Visible = false;                  

                    CountParkingLabel.Location = new Point(500, 50);
                    CountParkingLabel.Visible = true;
                    CountParking.Location = new Point(630, 50);
                    CountParking.Visible = true;
                    GetCountPosition.Start();
                }
            }
            catch(Exception m)
            {
                StatusLabel.Text = "请检查网络连接";
            }          
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DataFromServer.Count(); i++)
            {
                DataFromServer[i].Text = String.Empty;
            }
            try
            {
                string Url;
                Url = "http://localhost:8888/inoutcommitcard";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                req.Method = "POST";
                string PostData = "session=" + session + "&user_id=" + user_name + "&card_num=" + NumCard.Text + "&car_num=" + CarNum.Text;
                byte[] Data = Encoding.UTF8.GetBytes(PostData);
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = Data.Length;
                Stream newStream = req.GetRequestStream();
                newStream.Write(Data, 0, Data.Length);
                newStream.Close();
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream resst = res.GetResponseStream();
                StreamReader sr = new StreamReader(resst);
                string str = sr.ReadToEnd();

                str = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(str));

                if (str == "Error")
                {
                    MessageBox.Show("Error");
                    return;
                }

                ReturnData returnData = JSON.parse<ReturnData>(str);
                session = returnData.Session;
                if (returnData.CardQuality == "fixed")
                    LevelCard.Text = "成员卡";
                else
                    LevelCard.Text = "临时卡";
                NumPosition.Text = returnData.ParkingPosition;
                EnterTime.Text = returnData.EnterTime;
                if (CarNum.Text == String.Empty)
                {
                    CarNum.Text = returnData.CarNum;
                    LeaveTime.Text = returnData.LeaveTime;
                    NumMoney.Text = returnData.GetMoney;
                }
            }
            catch(Exception m)
            {

            }
        }

        private void BeforeClose(object sender, FormClosingEventArgs e)
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
            catch(Exception m)
            {

            }
        }

        private void EnterKey(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.SignInButton_Click(sender, e);
            }
        }

        private void KeyEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CommitButton_Click(sender, e);
            }
        }
    }
}
