using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Configuration;
using System.Timers;
using System.Diagnostics;
namespace serial_FXPLC
{
   
    public partial class Form1 : Form
    {
         mitsubishi mit;
        bool isYPortOpen = false;//Y口打开标志
        bool isSerialPortOpen = false; //串口打开标志
        public static Char[] xPortStatus;

        public Form1()
        {
            //程序初始化
            InitializeComponent(); 
            portsComboBox.DataSource = SerialPort.GetPortNames();
            toolStripStatusLabel1.Text = "请连接PLC";
            portsComboBox.Text = ConfigurationManager.AppSettings["portname"];
            foreach (Control item in groupBox2.Controls)
            {
                item.Enabled = false;
            }
            foreach (Control item in groupBox3.Controls)
            {
                item.Enabled = false;
            }

        }
        

  
        //打开/关闭串口
        public void openClosePortButton_Click(object sender, EventArgs e)
        {
           
                if (isSerialPortOpen == false)
                {
                    string portName = portsComboBox.Text;
                    mit = new mitsubishi(portName, 0, 10, 10, 10);
                    isSerialPortOpen = true;
                    openClosePortButton.Text = "关闭";
                    toolStripStatusLabel1.Text = "串口已打开";
                    switchControl(groupBox2);
                    switchControl(groupBox3);
                    timer1.Start();
                    Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    cfg.AppSettings.Settings["portname"].Value = portsComboBox.Text;
                    cfg.Save();
                    ConfigurationManager.RefreshSection("appSettings");
                }
                else
                {
                    mit.stop();
                    timer1.Stop();
                    timer1.Dispose();
                    switchControl(groupBox2);
                    switchControl(groupBox3);
                    isSerialPortOpen = false;
                    openClosePortButton.Text = "打开";
                    toolStripStatusLabel1.Text = "串口已关闭";
            }
          
            
            
        }


        bool CheckConnection(string portname)
        {
            SerialPort port = new SerialPort();
            port.PortName = portname;
            return port.IsOpen;
        }

        //打开Y输出点函数
        bool OpenCloseYPort(string yPort,Button yButton) //(要打开的口，触发的按钮)
        {
            //首先检查是否已经连接到PLC
            if (mit.IsFXPLCConneted())
             {
                if (isYPortOpen == false)
                {
                    mit.set(yPort);
                    yButton.BackColor = Color.Red;
                    isYPortOpen = true;
                }
                else
                {
                    mit.rst(yPort);
                    yButton.BackColor = Color.WhiteSmoke;
                    isYPortOpen = false;
                }
             }
            else
            {
                toolStripStatusLabel1.Text = "PLC未连接";
                toolStripStatusLabel1.BackColor = Color.Yellow;
             }


            return true;
        }

        #region 控制Y输出口
        private void openCloseY0Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y0", openCloseY0Button);
        }

        private void openCloseY1Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y1", openCloseY1Button);
        }

        private void openCloseY2Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y2", openCloseY2Button);
        }

        private void openCloseY3Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y3", openCloseY3Button);
        }

        private void openCloseY4Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y4", openCloseY4Button);
        }

        private void openCloseY5Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y5", openCloseY5Button);
        }

        private void openCloseY6Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y6", openCloseY6Button);
        }

        private void openCloseY7Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y7", openCloseY7Button);
        }
        private void openCloseY10Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y8", openCloseY10Button);
        }
        private void openCloseY11Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y9", openCloseY11Button);
        }
        private void openCloseY12Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y10", openCloseY12Button);
        }
        private void openCloseY13Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y11", openCloseY13Button);
        }

        private void openCloseY14Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y12", openCloseY14Button);
        }

        private void openCloseY15Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y13", openCloseY15Button);
        }

        private void openCloseY16Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y14", openCloseY16Button);
        }
        private void openCloseY17Button_Click(object sender, EventArgs e)
        {
            OpenCloseYPort("y15", openCloseY17Button);
        }
        #endregion

        //菜单退出
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mit == null)
            {
                this.Close();
            }
            else
            {
                mit.stop();
                this.Close();
            }
                
        }

        //窗口关闭时执行
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mit == null)
            { }
            else
            {
                try
                { mit.stop(); }
                finally
                { }
            }

        }


 
        private void timer1_Tick(object sender, EventArgs e)
        {
            xPortStatus = mit.xStatus;
            string[] x4PortsStatus=new string[6];
            for (int i = 0; i < xPortStatus.Length; i++)
            {

                x4PortsStatus[i] = System.Convert.ToString(Convert.ToInt32(xPortStatus[i].ToString(), 16), 2).PadLeft(4, '0');
                //Debug.Print(x4PortsStatus[i]);
            }
            //Debug.Print( x4PortsStatus[0].ToArray()[1].ToString());

            changeColor(statusX07Label, x4PortsStatus[0].ToArray()[0].ToString());
            changeColor(statusX06Label, x4PortsStatus[0].ToArray()[1].ToString());
            changeColor(statusX05Label, x4PortsStatus[0].ToArray()[2].ToString());
            changeColor(statusX04Label, x4PortsStatus[0].ToArray()[3].ToString());
            changeColor(statusX03Label, x4PortsStatus[1].ToArray()[0].ToString());
            changeColor(statusX02Label, x4PortsStatus[1].ToArray()[1].ToString());
            changeColor(statusX01Label, x4PortsStatus[1].ToArray()[2].ToString());
            changeColor(statusX00Label, x4PortsStatus[1].ToArray()[3].ToString());
            changeColor(statusX17Label, x4PortsStatus[2].ToArray()[0].ToString());
            changeColor(statusX16Label, x4PortsStatus[2].ToArray()[1].ToString());
            changeColor(statusX15Label, x4PortsStatus[2].ToArray()[2].ToString());
            changeColor(statusX14Label, x4PortsStatus[2].ToArray()[3].ToString());
            changeColor(statusX13Label, x4PortsStatus[3].ToArray()[0].ToString());
            changeColor(statusX12Label, x4PortsStatus[3].ToArray()[1].ToString());
            changeColor(statusX11Label, x4PortsStatus[3].ToArray()[2].ToString());
            changeColor(statusX10Label, x4PortsStatus[3].ToArray()[3].ToString());
            changeColor(statusX27Label, x4PortsStatus[4].ToArray()[0].ToString());
            changeColor(statusX26Label, x4PortsStatus[4].ToArray()[1].ToString());
            changeColor(statusX25Label, x4PortsStatus[4].ToArray()[2].ToString());
            changeColor(statusX24Label, x4PortsStatus[4].ToArray()[3].ToString());
            changeColor(statusX23Label, x4PortsStatus[5].ToArray()[0].ToString());
            changeColor(statusX22Label, x4PortsStatus[5].ToArray()[1].ToString());
            changeColor(statusX21Label, x4PortsStatus[5].ToArray()[2].ToString());
            changeColor(statusX20Label, x4PortsStatus[5].ToArray()[3].ToString());


            //statusX00Label.Text = new string(xPortStatus);
        }
        private  void switchControl(Control groupbox)
        {
            foreach (Control item in groupbox.Controls)
            {
                if (item.Enabled==true)
                { item.Enabled = false; }
                else
                {
                    item.Enabled = true;
                }
            }
        }
        private void changeColor(Label labelname,string isopen)
        {
            if (isopen == 1.ToString())
            {
                labelname.BackColor = Color.Red;
            }
            else
            {
                labelname.BackColor = Color.WhiteSmoke;
            }
        }

    }
}
