using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace webbrowse
{
    public partial class Form1 : Form
    {
        public Form1(string title,string url, string postData)
        {
            InitializeComponent();
            this.Text = title;
            Url = url;
            PostData = postData;
        }

        public string Url { get; }
        public string PostData { get; }

        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder s_b = new StringBuilder();
            s_b.AppendLine("=============START=================");
            s_b.AppendLine($"正在打卡网址：{Url}");
            s_b.AppendLine($"参数：{PostData}");
            s_b.AppendLine("=============END===================");
            Logger.Info(s_b.ToString());
            webBrowser1.Navigate(Url, null, Encoding.UTF8.GetBytes(PostData), "Content-Type:application/x-www-form-urlencoded");
        }
    }
}
