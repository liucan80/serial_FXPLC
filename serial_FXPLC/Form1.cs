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

namespace serial_FXPLC
{
    public partial class Form1 : Form
    {
        mitsubishi mit;
        bool isYPortOpen = false;//Y口打开标志
        bool isSerialPortOpen = false; //串口打开标志
        public Form1()
        {
            InitializeComponent(); 
            portsComboBox.DataSource = SerialPort.GetPortNames();
            toolStripStatusLabel1.Text = "请连接PLC";
            portsComboBox.Text = ConfigurationManager.AppSettings["portname"];
            
        }

  
        //打开/关闭串口
        public void openClosePortButton_Click(object sender, EventArgs e)
        {
           
                if (isSerialPortOpen == false)
                {
                    string portName = portsComboBox.Text;
                    mit = new mitsubishi(portName, 0, 10, 10, 10);
                    if (false)
                     {
                        mit.stop();
                   
                     }
                    else
                    {
                    isSerialPortOpen = true;
                    openClosePortButton.Text = "关闭";
                    toolStripStatusLabel1.Text = "串口已打开";
                    Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    cfg.AppSettings.Settings["portname"].Value = portsComboBox.Text;
                    cfg.Save();
                    ConfigurationManager.RefreshSection("appSettings");

                     }
                   
                    
                }
                else
                {
                    mit.stop();


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
             }


            return true;
        }

        #region
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
        private void button1_Click(object sender, EventArgs e)
        {
            mit.readX("x0");
        }
    }
}
