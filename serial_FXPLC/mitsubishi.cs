using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Diagnostics;

namespace serial_FXPLC
{
    class mitsubishi
    {
        Thread mitsubishiTread; //mitsubishi
        SerialPort m_sp;
        int m_sendAddr, m_sendLen, m_recieveAddr, m_recieveLen;
        bool[] m_Q = new bool[5];    //是否已请求
        bool[] m_R = new bool[5];    //是否已回复
        char[] m_T = new char[5];    //类型
        int[] m_A = new int[5];    //地址
        char[] m_C = new char[5];    //命令
        int[] m_D = new int[5];    //发出数据
        bool[] m_R_Bool = new bool[5];    //返回值
        int[] m_R_Int = new int[5];    //返回值
        public byte[] m_wData, m_rData;    //循环写和读数据
        char[] m_WData;    //循环写数据转换格式
        bool circle = false;    //是否循环读写,判断不同字节长度
        public Char[] xStatus = null;

        #region mitsubishi类构造函数
        public mitsubishi(string portName, int sendA, int sendL, int revA, int revL)    //（串口号、写入起始地址、写入字节长度、读取起始地址、读取字节长度）
        {


            m_sp = new SerialPort();
            m_sp.PortName = portName;
            m_sp.BaudRate = 9600;
            m_sp.DataBits = 7;
            m_sp.StopBits = (StopBits)1;
            m_sp.Parity = Parity.Even;
            m_sp.ReadTimeout = 500;

            //收发数据起始地址和字节长度
            m_sendAddr = sendA;
            m_sendLen = sendL;
            m_recieveAddr = revA;
            m_recieveLen = revL;
            m_wData = new byte[sendL];
            m_rData = new byte[revL];
            m_WData = new char[sendL * 2];

            if (!m_sp.IsOpen)
            {
                try
                {
                    m_sp.Open();

                    Thread.Sleep(500);  //串口打开，等待0.5S后开始启动线程
                    mitsubishiTread = new Thread(new ThreadStart(start));
                    mitsubishiTread.Start();
                }
                catch (NullReferenceException)
                {
                    Debug.Print("error");

                }
                finally
                {

                }

            }
            else
            {
                MessageBox.Show("串口已被打开,请检查端口！");
                m_sp.Close();
            }

        }
        #endregion
        #region mitsubishi类析构函数
        ~mitsubishi()
        {
            m_sp.Close();
        }
        #endregion
        #region 单线程排队发送
        public void start()
        {
            try
            {
                while (true)
                {
                    //这里用排序发送
                    if (!m_sp.IsOpen)
                    {
                        m_sp.Open();
                        Thread.Sleep(500);  //串口打开，等待0.5S后开始发送
                    }

                    //有排队先完成
                    xStatus = readX();
                    //m_First();

                    //循环写部分
                    //circle = true;
                    //for (int i = 0; i < m_sendLen; i++)
                    //{
                    //    m_WData[i * 2] = Tran2(m_wData[i] / 0x10);
                    //    m_WData[i * 2 + 1] = Tran2(m_wData[i] % 0x10);
                    //}
                    //char[] m_write = SendData('d', m_sendAddr, 'w', m_WData);
                    //if (m_write[0] - 6 != 0)
                    //{
                    //    MessageBox.Show("循环写入数据出错！");
                    //}

                    //有排队先完成
                    m_First();

                    //readX("x0");

                    //循环读部分
                    //circle = true;
                    //char[] m_read = SendData('d', m_recieveAddr, 'r', m_WData);
                    //if (m_read.Length / 2 == m_recieveLen)
                    //{
                    //    for (int i = 0; i < m_read.Length; i = i + 2)
                    //    {
                    //        m_rData[i / 2] = (byte)(Tran1(m_read[i]) * 0x10 + Tran1(m_read[i + 1]));
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("循环读出数据出错！");
                    //}

                }
            }
            catch (NullReferenceException)
            {
                Debug.Print("error");
            }
            finally
            {

            }

        }
        #endregion

        public void stop()
        {
            mitsubishiTread.Abort();
            m_sp.Close();
        }
        #region 优先处理
        private void m_First()
        {
            circle = false;
            for (int i = 0; i < 5; i++)
            {
                if (m_Q[i] && !m_R[i])  //有请求但无回复
                {
                    int m_Data_Len;
                    if (m_C[i] == 'D' || m_C[i] == 'S')
                    {
                        m_Data_Len = 8;
                    }
                    else
                    {
                        m_Data_Len = 4;
                    }
                    char[] m_Data = HTC(m_D[i], m_Data_Len);
                    char[] m_return = SendData(m_T[i], m_A[i], m_C[i], m_Data);

                    int n = m_return.Length;
                    if (n > 1)
                    {
                        m_R_Int[i] = 0;
                        for (int j = n - 1; j > 0; j = j - 2)
                        {
                            m_R_Int[i] *= 0x100;
                            m_R_Int[i] += (Tran1(m_return[j - 1]) * 0x10 + Tran1(m_return[j]));
                        }
                    }
                    else if (n == 1 && m_return[0] - 6 == 0)
                    {
                        m_R_Bool[i] = true;
                    }

                    m_R[i] = true;
                }
            }
        }
        #endregion


        #region  编码转换
        private int Tran1(Char InChar)   //ASCII码转数字，接收时使用
        {
            int OutInt;
            if (InChar < 0x40)
            {
                OutInt = InChar - 0x30;
            }
            else
            {
                OutInt = InChar - 0x37;
            }
            return OutInt;
        }

        private Char Tran2(int InChar)   //数字转ASCII码，发送时使用
        {
            Char OutChar;
            if (InChar < 10)
            {
                OutChar = (Char)(InChar + 0x30);
            }
            else
            {
                OutChar = (Char)(InChar + 0x37);
            }
            return OutChar;
        }
        #endregion


        #region 发送或接收数据，返回Char数组
        private Char[] SendData(Char type, int startAdd, Char cmd, char[] inChar) //（S、D、M、X、Y、T、C）   （E00/1000/100/80/A0/C0/1C0）   （0、1、w/W、r/R）
        {
            Char[] outChar = null;

            //报文长度
            int n = 0;
            if (cmd == '0' || cmd == '1') //  0、1复位置位
            {
                n = 9;
            }
            else if (cmd == 'R' || cmd == 'r') // R/r读单双字
            {
                n = 11;
            }
            else if (cmd == 'w' || cmd == 'W') // w写单字
            {
                n = 11 + inChar.Length;
            }

            char[] subuffer = new char[n];

            //报文首
            subuffer[0] = (char)2;

            //命令代码
            if (cmd == '0')
            {
                subuffer[1] = (char)0x38;
            }
            else if (cmd == '1')
            {
                subuffer[1] = (char)0x37;
            }
            else if (n == 11)
            {
                subuffer[1] = (char)0x30;
            }
            else
            {
                subuffer[1] = (char)0x31;
            }

            //首地址
            int Addr = 0;
            if (type == 'S' || type == 's') // S、s
            {
                Addr = 0xE00;
            }
            else if (type == 'D' || type == 'd') // D、d
            {
                Addr = 0x1000;
            }
            else if (type == 'M' || type == 'm') // M、m
            {
                Addr = 0x100;
            }
            else if (type == 'X' || type == 'x') // X、x
            {
                Addr = 0x80;
            }
            else if (type == 'Y' || type == 'y') // Y、y
            {
                Addr = 0xA0;
            }
            else if (type == 'T' || type == 't') // T、t
            {
                Addr = 0xC0;
            }
            else if (type == 'C' || type == 'c') // C、c
            {
                Addr = 0x1C0;
            }

            //计算首地址
            Char[] Addrs = new Char[4];
            if (n == 9)
            {
                Addr = Addr * 8 + startAdd;
                Addrs = HTC(Addr, 4);
            }
            else
            {
                Addr += (startAdd * 2);
                Addrs = StartData(Addr);
            }
            Addrs.CopyTo(subuffer, 2);

            //字节长度
            if (circle)
            {
                if (cmd == 'R' || cmd == 'W') // R/W  读写双字
                {
                    subuffer[7] = Tran2(m_sendLen % 0x10);
                    subuffer[6] = Tran2(m_sendLen / 0x10);
                }
                else if (cmd == 'r' || cmd == 'w') // r/w  读写单字
                {
                    subuffer[7] = Tran2(m_recieveLen % 0x10);
                    subuffer[6] = Tran2(m_recieveLen / 0x10);
                }
            }
            else
            {
                subuffer[6] = (char)0x30;
                if (cmd == 'R' || cmd == 'W') // R/W  读写双字
                {
                    subuffer[7] = (char)0x34;
                }
                else if (cmd == 'r' || cmd == 'w') // r/w  读写单字
                {
                    subuffer[7] = (char)0x32;
                }
            }

            //数据内容
            if (cmd == 'w' || cmd == 'W')
            {
                inChar.CopyTo(subuffer, 8);
            }


            //报文尾
            subuffer[n - 3] = (char)3;

            //校验码            
            Char[] T = new Char[2];
            T = CCD(subuffer, n - 3);
            T.CopyTo(subuffer, n - 2);

            if (m_sp.IsOpen)
            {
                m_sp.Write(subuffer, 0, n);
                //MessageBox.Show("已发送成功!");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    int Len = m_sp.BytesToRead;
                    if (Len > 0)
                    {
                        i = 5;  //跳出循环
                        char[] RecieveBuf = new char[Len];
                        m_sp.Read(RecieveBuf, 0, Len);

                        if (Len == 1)   //非写入或出错状态
                        {
                            outChar = RecieveBuf;
                        }
                        else   //写入状态，读取返回数据
                        {
                            T = CCD(RecieveBuf, Len - 3); //验证接收信息校验码
                            if (T[0] == RecieveBuf[Len - 2] && T[1] == RecieveBuf[Len - 1])
                            {
                                Char[] outChar2 = new Char[Len - 4];
                                Array.Copy(RecieveBuf, 1, outChar2, 0, Len - 4);
                                outChar = outChar2;
                            }
                        }
                    }
                }

            }
            return outChar;
        }
        #endregion


        #region 和校验
        private char[] CCD(char[] InChar, int len)    //和校验
        {
            int S = 3;
            for (int i = 1; i < len; i++)
            {
                S += InChar[i];
            }
            char[] OutChar = HTC(S % 0x100, 2);
            return OutChar;
        }
        #endregion


        #region 字元件起始地址转化
        private char[] StartData(int inData)    //字元件起始地址转化
        {
            int t = inData;
            int[] tt = new int[4];
            char[] H = new char[4];
            for (int i = 3; i >= 0; i--)
            {
                tt[i] = t % 0x10;
                t = t / 0x10;
                H[i] = Tran2(tt[i]);
            }
            return H;
        }
        #endregion


        #region 位元件起始地址、发送数据转化
        public char[] HTC(int inData, int inBit)    //位元件起始地址、发送数据转化
        {
            byte[] TranByte = System.BitConverter.GetBytes(inData);
            int len = TranByte.Length;
            if (2 * len > inBit)
            {
                len = inBit / 2;
            }

            char[] OutChar = new char[inBit];
            for (int i = 0; i < len; i++)
            {
                int HL = TranByte[i];
                int H = HL / 0x10;
                OutChar[2 * i] = Tran2(H);

                int L = HL % 0x10;
                OutChar[2 * i + 1] = Tran2(L);
            }

            return OutChar;
        }
        #endregion


        #region 读SD/D
        public int read(string s)
        {
            int outInt = 0;
            if (System.Text.RegularExpressions.Regex.IsMatch(s, @"^[dDxXsS]\d{1,4}$+"))
            {
                Char[] inChar = s.ToCharArray(0, 1);
                Char type = inChar[0];
                Char cmd;
                if (type == 'd' || type == 's')
                {
                    cmd = 'r';
                }
                else
                {
                    cmd = 'R';
                }
                int addr = Convert.ToInt32(s.Substring(1));
                int n = 5;
                for (int i = 0; i < 5; i++)
                {
                    if (!m_Q[i])
                    {
                        n = i;
                        i = 5;
                        m_Q[n] = true;
                        m_T[n] = type;
                        m_A[n] = addr;
                        m_C[n] = cmd;
                        m_R[n] = false;
                        m_R_Bool[n] = false;
                    }
                }

                for (int i = 0; i <= 5; i++)
                {
                    Thread.Sleep(100);
                    if (m_R[n])
                    {
                        m_Q[n] = false;
                        m_R[n] = false;
                        outInt = m_R_Int[n];
                        i = 5;
                    }
                }
            }
            else
            {
                MessageBox.Show("指令格式错误！");
            }
            return outInt;
        }
        #endregion


        #region 写SD/D
        public bool write(string s, int d)
        {
            bool outBool = false;
            if (System.Text.RegularExpressions.Regex.IsMatch(s, @"^[dDsS]\d{1,4}$+"))
            {
                Char type = s.ToCharArray(0, 1)[0], cmd;
                if (type == 'd' || type == 's')
                {
                    cmd = 'w';
                }
                else
                {
                    cmd = 'W';
                }
                int addr = Convert.ToInt32(s.Substring(1));
                int n = 5;
                for (int i = 0; i < 5; i++)
                {
                    if (!m_Q[i])
                    {
                        n = i;
                        i = 5;
                        m_Q[n] = true;
                        m_T[n] = type;
                        m_A[n] = addr;
                        m_C[n] = cmd;
                        m_D[n] = d;
                        m_R[n] = false;
                        m_R_Bool[n] = false;
                    }
                }

                for (int i = 0; i <= 5; i++)
                {
                    Thread.Sleep(100);
                    if (m_R[n])
                    {
                        m_Q[n] = false;
                        m_R[n] = false;
                        outBool = m_R_Bool[n];
                        i = 5;
                    }
                }
            }
            else
            {
                MessageBox.Show("指令格式错误！");
            }
            return outBool;
        }
        #endregion


        #region 置位X/Y/M/T/C
        public bool set(string s)
        {
            bool outBool = false;
            if (System.Text.RegularExpressions.Regex.IsMatch(s, @"^[xXyYmMtTcC]\d{1,4}$+"))
            {
                Char[] inChar = s.ToCharArray(0, 1);
                Char type = inChar[0];
                int addr = Convert.ToInt32(s.Substring(1));
                int n = 5;
                for (int i = 0; i < 5; i++)
                {
                    if (!m_Q[i])
                    {
                        n = i;
                        i = 5;
                        m_Q[n] = true;
                        m_T[n] = type;
                        m_A[n] = addr;
                        m_C[n] = '1';
                        m_R[n] = false;
                        m_R_Bool[n] = false;
                    }
                }

                for (int i = 0; i <= 5; i++)
                {
                    Thread.Sleep(100);
                    if (m_R[n])
                    {
                        m_Q[n] = false;
                        m_R[n] = false;
                        outBool = m_R_Bool[n];
                        i = 5;
                    }
                }
            }
            else
            {
                MessageBox.Show("指令格式错误！");
            }
            return outBool;
        }
        #endregion


        #region 复位X/Y/M/T/C
        public bool rst(string s)
        {
            bool outBool = false;
            if (System.Text.RegularExpressions.Regex.IsMatch(s, @"^[xXyYmMtTcC]\d{1,4}$+"))
            {
                Char[] inChar = s.ToCharArray(0, 1);
                Char type = inChar[0];
                int addr = Convert.ToInt32(s.Substring(1));
                int n = 5;
                for (int i = 0; i < 5; i++)
                {
                    if (!m_Q[i])
                    {
                        n = i;
                        i = 5;
                        m_Q[n] = true;
                        m_T[n] = type;
                        m_A[n] = addr;
                        m_C[n] = '0';
                        m_R[n] = false;
                        m_R_Bool[n] = false;
                    }
                }

                for (int i = 0; i <= 5; i++)
                {
                    Thread.Sleep(100);
                    if (m_R[n])
                    {
                        m_Q[n] = false;
                        m_R[n] = false;
                        outBool = m_R_Bool[n];
                        i = 5;
                    }
                }
            }
            else
            {
                MessageBox.Show("指令格式错误！");
            }
            return outBool;
        }
        #endregion

        //检查PLC是否已经连接
        public bool IsFXPLCConneted()
        {
            if (m_sp.IsOpen)
            {
                return true;
            }
            else
            { return false; }
        }

        public Char[] readX()
        {
            Char[] outChar;
            string textData = "02 30 30 30 38 30 30 33 03 35 45";
            string[] grp = textData.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<byte> list = new List<byte>();

            foreach (var item in grp)
            {
                list.Add(Convert.ToByte(item, 16));
            }

            m_sp.Write(list.ToArray(), 0, list.Count);

            //MessageBox.Show("已发送成功!");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100);
                int Len = m_sp.BytesToRead;
                if (Len > 0)
                {
                    i = 5;  //跳出循环
                    char[] RecieveBuf = new char[Len];
                    m_sp.Read(RecieveBuf, 0, Len);

                    if (Len == 1)   //非写入或出错状态
                    {
                        outChar = RecieveBuf;

                    }
                    else   //写入状态，读取返回数据
                    {

                        Char[] outChar2 = new Char[Len - 4];
                        Array.Copy(RecieveBuf, 1, outChar2, 0, Len - 4);
                        outChar = outChar2;
                        xStatus = outChar;
                        //Convert.ToString();
                        return outChar;
                    }
                }


            }
            return null;

        }
       
      
    }
}


     

        
