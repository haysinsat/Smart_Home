using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Smart_Home
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
            
            // Коментар
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            HttpClient clientPS = new HttpClient();
            string responseStringPS = await clientPS.GetStringAsync("http://192.168.1.41/dataPS");

            dynamic jsonDataPS = JObject.Parse(responseStringPS);

            string ipPS = jsonDataPS.ip;
            string tempBoyler = jsonDataPS.tempBoyler;
            string l_hour = jsonDataPS.l_hour;
            string flow_val = jsonDataPS.flow_val;
            string flow_day = jsonDataPS.flow_day;
            string tempBoylerCF = jsonDataPS.tempBoylerCF;
            string tempBoylerCF1 = jsonDataPS.tempBoylerCF1;
            //string PSarray = jsonDataPS.PSarray[58];
            
            JArray PSarray = JArray.Parse(jsonDataPS["PSarray"].ToString());
            var PSarrayData = PSarray.ToObject<List<int>>();

            richTextBox5.Text = tempBoyler;
            richTextBox6.Text = l_hour;
            richTextBox7.Text = flow_day;
            richTextBox8.Text = flow_val;
            //richTextBox13.Text = PSarray;
            richTextBox14.Text = tempBoylerCF1;
            richTextBox15.Text = tempBoylerCF;
        }

        
    }
}
