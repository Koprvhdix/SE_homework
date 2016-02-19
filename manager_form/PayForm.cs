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
    public partial class PayForm : Form
    {
        public PayForm()
        {
            InitializeComponent();
        }

        private void PayForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);

            CardNumLabel.Location = new System.Drawing.Point(200, 100);
            CardNumBox.Location = new System.Drawing.Point(350, 100);
            LeftMoneyLabel.Location = new System.Drawing.Point(200, 140);
            LeftMoney.Location = new System.Drawing.Point(350, 140);
            SendMoneyLabel.Location = new System.Drawing.Point(200, 180);
            SendMoneyText.Location = new System.Drawing.Point(350, 180);
            SummitButton.Location = new System.Drawing.Point(300, 220);
            StateLabel.Location = new System.Drawing.Point(600, 220);
            DataCard.Location = new System.Drawing.Point(75, 260);
            GetExcel.Location = new System.Drawing.Point(300, 420);
        }

        private void GetExcel_Click(object sender, EventArgs e)
        {
            if (DataCard.Rows.Count > 0)
            {
                var app = new Microsoft.Office.Interop.Excel.Application { Visible = false };
                Workbook workbook = app.Workbooks.Add();
                Worksheet worksheet = app.ActiveSheet;
                for (int i = 0; i < DataCard.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = DataCard.Columns[i].HeaderText;
                }
                for (int i = 0; i < DataCard.Rows.Count; i++)
                {
                    for (int j = 0; j < DataCard.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = DataCard.Rows[i].Cells[j].Value.ToString();
                    }
                }
                string path = "D:\\";
                workbook.SaveAs(
                    Filename: path + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xls",
                    FileFormat: XlFileFormat.xlWorkbookNormal
                    );
                app.Application.Quit();
            }
        }

        private void SummitButton_Click(object sender, EventArgs e)
        {
            DataCard.Rows.Clear();
            StateLabel.Text = String.Empty;
            if(CardNumBox.Text == String.Empty)
            {
                StateLabel.Text = "请输入卡号";
                return;
            }
            try
            {
                string Url;
                Url = "http://localhost:8888/paypage";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                req.Method = "POST";
                string PostData = "card_num=" + CardNumBox.Text
                    + "&get_money=" + SendMoneyText.Text
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
                
                if(str == "Error")
                {
                    MessageBox.Show("Error!");
                    return;
                }

                string te = "";
                int i = 0, j = 0;
                i = str.IndexOf('{', i + 1);
                j = str.IndexOf('}', j + 1);
                te = str.Substring(i, j - i + 1);
                MoneyData moneyData = JSON.parse<MoneyData>(te);
                LeftMoney.Text = "￥" + moneyData.money.ToString();

                PayListData = new List<PayPageData>();
                for (; ; )
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
                    DataCard.Rows.Add(PayListData[m].CarNum,
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
