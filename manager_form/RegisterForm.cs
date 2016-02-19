using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manager_form
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            string str = "";
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);
            //页面
            NameLabel.Location = new Point(20, 100);
            NameTxt.Location = new Point(150, 100);
            SexLabel.Location = new Point(370, 100);
            MaleCheck.Location = new Point(500, 100);
            FemaleCheck.Location = new Point(570, 100);
            NumEmployeeLabel.Location = new Point(20, 150);
            NumEmployeeTxt.Location = new Point(150, 150);
            PhoneNumLabel.Location = new Point(370, 150);
            moneyLabel.Location = new Point(370, 190);
            PhoneNumTxt.Location = new Point(500, 150);
            MoneyText.Location = new Point(500, 190);
            PayTypeID.Location = new Point(70, 230);
            SelectParkingPosition.Location = new Point(70, 230);
            SelectParkingPosition.Visible = false;
            SelectCombo.Location = new Point(70, 190);
            SelectParking.Location = new Point(200, 190);
            StateLabel.Location = new Point(300, 450);
            try
            {
                string Url;
                Url = "http://localhost:8888/timemoneyset";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                req.Method = "GET";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream resst = res.GetResponseStream();
                StreamReader sr = new StreamReader(resst);
                str = sr.ReadToEnd();
            }
            catch (Exception m)
            {
                StateLabel.Text = "请检查网络连接";
                return;
            }

            listData = new List<ComboData>();

            string te1 = "";
            for (int i = 0, j = 0; ;)
            {
                i = str.IndexOf('{', i + 1);
                j = str.IndexOf('}', j + 1);
                te1 = str.Substring(i, j - i + 1);
                ComboData combo = JSON.parse<ComboData>(te1);
                listData.Add(combo);
                if (str[j + 1] == ']')
                    break;
            }

            for (int i = 0; i < listData.Count(); i++)
            {
                PayTypeID.Items.Add(listData[i].ComboID
                    + "  " + listData[i].ComboName
                    + "：免费" + listData[i].FreeHour+"小时"
                    + "，月费" + listData[i].ComboMoney + "元"
                    + "，超时后每小时收费" + listData[i].MoneyPerHour + "元");
            }

            try
            {
                string Url;
                Url = "http://localhost:8888/getparking";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                req.Method = "GET";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                Stream resst = res.GetResponseStream();
                StreamReader sr = new StreamReader(resst);
                str = sr.ReadToEnd();
            }
            catch (Exception m)
            {
                StateLabel.Text = "请检查网络连接";
            }

            listParkingData = new List<ParkingInformation>();
            te1 = "";
            for (int i = 0, j = 0; ; )
            {
                i = str.IndexOf('{', i + 1);
                j = str.IndexOf('}', j + 1);
                te1 = str.Substring(i, j - i + 1);
                ParkingInformation parking = JSON.parse<ParkingInformation>(te1);
                listParkingData.Add(parking);
                if (str[j + 1] == ']')
                    break;
            }

            for (int i = 0; i < listParkingData.Count();i++ )
            {
                SelectParkingPosition.Items.Add(
                    listParkingData[i].ParkingID + "："
                    + listParkingData[i].ParkingDescribeName
                    );
            }

            CommitRegisterButton.Location = new Point(300, 410);
        }

        private void MaleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (FemaleCheck.Checked == true && MaleCheck.Checked == true)
            {
                FemaleCheck.Checked = false;
            }
            if(MaleCheck.Checked == true)
            {
                sex = "Male";
            }
        }

        private void FemaleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (FemaleCheck.Checked == true && MaleCheck.Checked == true)
            {
                MaleCheck.Checked = false;
            }
            if(FemaleCheck.Checked == true)
            {
                sex = "Female";
            }
        }

        private void CommitRegisterButton_Click(object sender, EventArgs e)
        {
            if (NameTxt.Text == String.Empty)
            {
                StateLabel.Text = "请输入用户名";
                return;
            }
            if (NumEmployeeTxt.Text == String.Empty)
            {
                StateLabel.Text = "请输入工号";
                return;
            }
            if (PhoneNumTxt.Text == String.Empty && PhoneNumTxt.Text.Length != 11)
            {
                StateLabel.Text = "请输入手机号码";
                return;
            }
            if (sex == String.Empty)
            {
                StateLabel.Text = "请选择性别";
                return;
            }
            if (MoneyText.Text == String.Empty)
            {
                StateLabel.Text = "请缴纳费用";
                return;
            }

            combo_id = "";
            for (int i = 0; i < listData.Count; i++)
            {
                if (PayTypeID.GetItemChecked(i))
                {
                    combo_id = listData[i].ComboID;
                    break;
                }
            }
            if (combo_id == String.Empty)
            {
                StateLabel.Text = "请选择套餐";
                return;
            }

            string parking_id = "";
            for (int i = 0; i < listParkingData.Count; i++)
            {
                if (SelectParkingPosition.GetItemChecked(i))
                {
                    parking_id = listParkingData[i].ParkingID;
                    break;
                }
            }
            if(parking_id == String.Empty)
            {
                StateLabel.Text = "请选择车位号";
                return;
            }

            try
            {
                string register_name = NameTxt.Text;
                string Url;
                Url = "http://localhost:8888/userregister";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                req.Method = "POST";
                string PostData = "user_name=" + register_name
                    + "&manage_user_id=" + MainForm.user_name
                    + "&user_work_num=" + NumEmployeeTxt.Text
                    + "&user_sex=" + sex + "&user_phone_num=" + PhoneNumTxt.Text
                    + "&session=" + MainForm.session
                    + "&combo_id=" + combo_id + "&get_money=" + MoneyText.Text
                    + "&parking_position_id=" + parking_id;
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

                if (str == "Fail to Insert" || str == "Error")
                {
                    StateLabel.Text = str;
                    return;
                }

                MainForm.session = str;

                try
                {
                    string Url1;
                    Url1 = "http://localhost:8888/timemoneyset";
                    HttpWebRequest req1 = (HttpWebRequest)WebRequest.Create(Url1);
                    req1.Method = "GET";
                    HttpWebResponse res1 = (HttpWebResponse)req1.GetResponse();
                    Stream resst1 = res1.GetResponseStream();
                    StreamReader sr1 = new StreamReader(resst1);
                    str = sr1.ReadToEnd();
                }
                catch (Exception m)
                {
                    StateLabel.Text = "请检查网络连接";
                }

                listData = new List<ComboData>();

                string te1 = "";
                for (int i = 0, j = 0; ; )
                {
                    i = str.IndexOf('{', i + 1);
                    j = str.IndexOf('}', j + 1);
                    te1 = str.Substring(i, j - i + 1);
                    ComboData combo = JSON.parse<ComboData>(te1);
                    listData.Add(combo);
                    if (str[j + 1] == ']')
                        break;
                }

                PayTypeID.Items.Clear();
                for (int i = 0; i < listData.Count(); i++)
                {
                    PayTypeID.Items.Add(listData[i].ComboID
                        + "  " + listData[i].ComboName
                        + "：免费" + listData[i].FreeHour + "小时"
                        + "，月费" + listData[i].ComboMoney + "元"
                        + "，超时后每小时收费" + listData[i].MoneyPerHour + "元");
                }

                try
                {
                    string Url1;
                    Url1 = "http://localhost:8888/getparking";
                    HttpWebRequest req1 = (HttpWebRequest)WebRequest.Create(Url1);
                    req1.Method = "GET";
                    HttpWebResponse res1 = (HttpWebResponse)req1.GetResponse();
                    Stream resst1 = res1.GetResponseStream();
                    StreamReader sr1 = new StreamReader(resst1);
                    str = sr1.ReadToEnd();
                }
                catch (Exception m)
                {
                    StateLabel.Text = "请检查网络连接";
                }

                listParkingData = new List<ParkingInformation>();
                te1 = "";
                for (int i = 0, j = 0; ; )
                {
                    i = str.IndexOf('{', i + 1);
                    j = str.IndexOf('}', j + 1);
                    te1 = str.Substring(i, j - i + 1);
                    ParkingInformation parking = JSON.parse<ParkingInformation>(te1);
                    listParkingData.Add(parking);
                    if (str[j + 1] == ']')
                        break;
                }
                SelectParkingPosition.Items.Clear();
                for (int i = 0; i < listParkingData.Count(); i++)
                {
                    SelectParkingPosition.Items.Add(
                        listParkingData[i].ParkingID + "："
                        + listParkingData[i].ParkingDescribeName
                        );
                }
            }
            catch (Exception m)
            {
                StateLabel.Text = "请检查网络连接";
            }
        }

        private void itemChecked(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < PayTypeID.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    PayTypeID.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            }
        }

        private void SelectCombo_Click(object sender, EventArgs e)
        {
            PayTypeID.Visible = true;
            SelectParkingPosition.Visible = false;
        }

        private void SelectParking_Click(object sender, EventArgs e)
        {
            SelectParkingPosition.Visible = true;
            PayTypeID.Visible = false;
        }

        private void IsNumPress(object sender, KeyPressEventArgs e)
        {
            char m = e.KeyChar;
            if (m == '\b')
                return;
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void IsPhoneNum(object sender, KeyPressEventArgs e)
        {
            char m = e.KeyChar;
            if (m == '\b')
                return;
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
