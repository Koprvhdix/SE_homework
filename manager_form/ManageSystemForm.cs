using Microsoft.Office.Interop.Excel;
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
    public partial class ManageSystemForm : Form
    {
        public ManageSystemForm()
        {
            InitializeComponent();
        }

        private void ManageSystemForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);

            YearBox.Items.Add("-请输入年份-");
            YearBox.Items.Add("2015");
            MonthBox.Items.Add("-请输入月份-");
            for (int i = 1; i < 13; i++)
            {
                MonthBox.Items.Add(i.ToString());
            }
            DayBox.Items.Add("-请输入日期-");
            for (int i = 1; i < 32; i++)
            {
                DayBox.Items.Add(i);
            }
            YearBox.SelectedIndex = 0;
            MonthBox.SelectedIndex = 0;
            DayBox.SelectedIndex = 0;
        }

        private void GetEXCELButton_Click(object sender, EventArgs e)
        {
            if (DataTemporary.Rows.Count > 0)
            {
                var app = new Microsoft.Office.Interop.Excel.Application { Visible = false };
                Workbook workbook = app.Workbooks.Add();
                Worksheet worksheet = app.ActiveSheet;
                for (int i = 0; i < DataTemporary.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = DataTemporary.Columns[i].HeaderText;
                } 
                for (int i = 0; i < DataTemporary.Rows.Count; i++)
                {
                    for (int j = 0; j < DataTemporary.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = DataTemporary.Rows[i].Cells[j].Value.ToString();
                    }
                }
                string path = "D:\\";
                workbook.SaveAs(
                    Filename: path + DateTime.Now.Hour.ToString()+DateTime.Now.Minute.ToString()+DateTime.Now.Second.ToString()+".xls",
                    FileFormat: XlFileFormat.xlWorkbookNormal
                    );
                app.Application.Quit();
            }
        }

        private void GetData_Click(object sender, EventArgs e)
        {
            DataTemporary.Rows.Clear();
            string get_year = YearBox.SelectedItem.ToString();
            string get_month = MonthBox.SelectedItem.ToString();
            int get_day = 0;
            if (DayBox.SelectedItem.ToString() != "-请输入日期-")
            {
                get_day = Convert.ToInt32(DayBox.SelectedItem);
            }
            if (get_year.Length > 4)//全部
            {
                try
                {
                    string Url;
                    Url = "http://localhost:8888/alltemporarydata";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                    req.Method = "GET";
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    Stream resst = res.GetResponseStream();
                    StreamReader sr = new StreamReader(resst);
                    string str = sr.ReadToEnd();

                    string te = "";
                    PayListData = new List<PayPageData>();
                    for (int i = 0, j = 0; ; )
                    {
                        i = str.IndexOf('{', i + 1);
                        j = str.IndexOf('}', j + 1);
                        te = str.Substring(i, j - i + 1);
                        PayPageData combo = JSON.parse<PayPageData>(te);
                        PayListData.Add(combo);
                        if (str[j + 1] == ']')
                            break;
                    }

                    for (int m = 0; m < PayListData.Count; m++)
                    {
                        DataTemporary.Rows.Add(
                            PayListData[m].CardNum,
                            PayListData[m].CarNum,
                            PayListData[m].ArriveTime,
                            PayListData[m].LeaveTime,
                            PayListData[m].UsingTime,
                            PayListData[m].GetMoney);
                    }
                }
                catch(Exception m)
                {

                }
                return;
            }
            if (get_day != 0)//2015-6-24
            {
                switch (get_month)
                {
                    case "-请输入月份-":
                        StateLabel.Text = "日期格式不对！";
                        return;
                    case "2":
                        if (get_day > 29)
                        {
                            StateLabel.Text = "日期格式不对！";
                            return;
                        }
                        if (Convert.ToInt32(get_year) % 4 != 0 || (Convert.ToInt32(get_year) % 100 == 0 && Convert.ToInt32(get_year) % 400 != 0))
                        {
                            if (get_day == 29)
                            {
                                StateLabel.Text = "日期格式不对！";
                                return;
                            }
                        }
                        break;
                    case "4":
                        if (get_day == 31)
                        {
                            StateLabel.Text = "日期格式不对！";
                            return;
                        }
                        break;
                    case "6":
                        if (get_day == 31)
                        {
                            StateLabel.Text = "日期格式不对！";
                            return;
                        }
                        break;
                    case "9":
                        if (get_day == 31)
                        {
                            StateLabel.Text = "日期格式不对！";
                            return;
                        }
                        break;
                    case "11":
                        if (get_day == 31)
                        {
                            StateLabel.Text = "日期格式不对！";
                            return;
                        }
                        break;
                    default: break;
                }
                try
                {
                    string Url;
                    Url = "http://localhost:8888/temporarydata";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                    req.Method = "POST";
                    string PostData = "year=" + get_year
                        + "&month=" + get_month
                        + "&day=" + get_day.ToString()
                        + "&manage_user_id=" + MainForm.user_name
                        + "&session=" + MainForm.session;
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

                    string te = "";
                    PayListData = new List<PayPageData>();
                    for (int i = 0, j = 0; ; )
                    {
                        i = str.IndexOf('{', i + 1);
                        j = str.IndexOf('}', j + 1);
                        te = str.Substring(i, j - i + 1);
                        PayPageData combo = JSON.parse<PayPageData>(te);
                        PayListData.Add(combo);
                        if (str[j + 1] == ']')
                            break;
                    }

                    for (int m = 0; m < PayListData.Count; m++)
                    {
                        DataTemporary.Rows.Add(
                            PayListData[m].CardNum,
                            PayListData[m].CarNum,
                            PayListData[m].ArriveTime,
                            PayListData[m].LeaveTime,
                            PayListData[m].UsingTime,
                            PayListData[m].GetMoney);
                    }
                }
                catch(Exception m)
                {

                }
            }
            if (get_month == "-请输入月份-")//2015
            {
                try
                {
                    string Url;
                    Url = "http://localhost:8888/temporarydata";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                    req.Method = "POST";
                    string PostData = "year=" + get_year
                        + "&month=0"
                        + "&day=0"
                        + "&manage_user_id=" + MainForm.user_name
                        + "&session=" + MainForm.session;
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

                    string te = "";
                    PayListData = new List<PayPageData>();
                    for (int i = 0, j = 0; ; )
                    {
                        i = str.IndexOf('{', i + 1);
                        j = str.IndexOf('}', j + 1);
                        te = str.Substring(i, j - i + 1);
                        PayPageData combo = JSON.parse<PayPageData>(te);
                        PayListData.Add(combo);
                        if (str[j + 1] == ']')
                            break;
                    }

                    for (int m = 0; m < PayListData.Count; m++)
                    {
                        DataTemporary.Rows.Add(
                            PayListData[m].CardNum,
                            PayListData[m].CarNum,
                            PayListData[m].ArriveTime,
                            PayListData[m].LeaveTime,
                            PayListData[m].UsingTime,
                            PayListData[m].GetMoney);
                    }
                }
                catch(Exception m)
                {

                }

                return;
            }
            else//2015-06
            {
                try
                {
                    string Url;
                    Url = "http://localhost:8888/temporarydata";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                    req.Method = "POST";
                    string PostData = "year=" + get_year
                        + "&month=" + get_month
                        + "&day=0"
                        + "&manage_user_id=" + MainForm.user_name
                        + "&session=" + MainForm.session;
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

                    string te = "";
                    PayListData = new List<PayPageData>();
                    for (int i = 0, j = 0; ; )
                    {
                        i = str.IndexOf('{', i + 1);
                        j = str.IndexOf('}', j + 1);
                        te = str.Substring(i, j - i + 1);
                        PayPageData combo = JSON.parse<PayPageData>(te);
                        PayListData.Add(combo);
                        if (str[j + 1] == ']')
                            break;
                    }

                    for (int m = 0; m < PayListData.Count; m++)
                    {
                        DataTemporary.Rows.Add(
                            PayListData[m].CardNum,
                            PayListData[m].CarNum,
                            PayListData[m].ArriveTime,
                            PayListData[m].LeaveTime,
                            PayListData[m].UsingTime,
                            PayListData[m].GetMoney);
                    }
                }
                catch(Exception m)
                {

                }
            }
        }
    }
}