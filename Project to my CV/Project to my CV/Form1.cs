using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports; //uart funcation
using System.IO;
using System.Threading;

namespace Project_to_my_CV
{
    public partial class Form1 : Form
    {
        int[,] count = new int[8, 8]{ { 1,1,1,1,1,1,1,1},
                                      { 1,1,1,1,1,1,1,1},
                                      { 1,1,1,1,1,1,1,1},
                                      { 1,1,1,1,1,1,1,1},
                                      { 1,1,1,1,1,1,1,1},
                                      { 1,1,1,1,1,1,1,1},
                                      { 1,1,1,1,1,1,1,1},
                                      { 1,1,1,1,1,1,1,1} };     // counter array 
        byte[,] pressbt = new byte[8, 8] { { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                                           { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                                           { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                                           { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                                           { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                                           { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                                           { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                                           { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },}; // press button array

        byte[] datasend =   { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}; // data array sent 
        byte[] heartsend = { 0x00, 0x66, 0x99, 0x81, 0x81, 0x42, 0x24, 0x18, }; // array of heart 
        byte[] smilesend = { 0x3C, 0x42, 0xA5, 0x81, 0xA5, 0x99, 0x42, 0x3C, }; // array of smile
        byte[] swansend = { 0x0E, 0x0B, 0x09, 0x04, 0x02, 0xFA, 0x7E, 0x3C, }; // array of swan
        byte[] Robotsend = { 0x14, 0x14, 0x7E, 0xDB, 0xFF, 0xFF, 0xA5, 0x24, }; // array of swan
        string strch = "B";
        private SerialPort serialPort = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            InitializeSerialport();
            string[] ports = SerialPort.GetPortNames();
            Port_name.Items.AddRange(ports);
           
        }
        
        private void InitializeSerialport() //setting of uart 
        {
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
        }

        private void culcdata()
        {

            for (int i = 0; i <= 7; i++)
                datasend[i] = 0x0;

            
            switch (strch)
            {
                case "H":
                    {
                        for (int i = 0; i <= 7; i++)
                            for (int j = 0; j <= 7; j++)
                                datasend[i] = (byte)((datasend[i]) + (pressbt[i, j]));
                        for (int i = 0; i <= 7; i++)
                            datasend[i] = (byte)(datasend[i] + heartsend[i]);
                    }
                    break;

                case "S":
                    {
                        for (int i = 0; i <= 7; i++)
                            for (int j = 0; j <= 7; j++)
                                datasend[i] = (byte)((datasend[i]) + (pressbt[i, j]));
                        for (int i = 0; i <= 7; i++)
                            datasend[i] = (byte)(datasend[i] + smilesend[i]);
                    }
                    break;

                case "SW":
                    {
                        for (int i = 0; i <= 7; i++)
                            for (int j = 0; j <= 7; j++)
                                datasend[i] = (byte)((datasend[i]) + (pressbt[i, j]));
                        for (int i = 0; i <= 7; i++)
                            datasend[i] = (byte)(datasend[i] + swansend[i]);
                    }
                    break;

                case "R":
                    {
                        for (int i = 0; i <= 7; i++)
                            for (int j = 0; j <= 7; j++)
                                datasend[i] = (byte)((datasend[i]) + (pressbt[i, j]));
                        for (int i = 0; i <= 7; i++)
                            datasend[i] = (byte)(datasend[i] + Robotsend[i]);
                    }
                    break;

                default:
                    {

                        for (int i = 0; i <= 7; i++)
                            for (int j = 0; j <= 7; j++)
                                datasend[i] = (byte)((datasend[i]) + (pressbt[i, j]));
                    }
                    break;

            }

            } // culclate Led matrix data

        private void button1_Click(object sender, EventArgs e)
        {
            if (count[0,0] == 1)
            {
                button1.BackColor = Color.Red;
                count[0,0] = count[0,0] + 1;
                pressbt[0, 0] = 0x01;
            }
            else
            {
                button1.BackColor = Color.SeaShell;
                count[0,0] = count[0,0] - 1;
                pressbt[0, 0] = 0x00;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (count[0,1] == 1)
            {
                button2.BackColor = Color.Red;
                count[0, 1] = count[0, 1] + 1;
                pressbt[0, 1] = 0x02;
            }
            else
            {
                button2.BackColor = Color.SeaShell;
                count[0,1] = count[0,1] - 1;
                pressbt[0, 1] = 0x00;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (count[0, 2] == 1)
            {
                button3.BackColor = Color.Red;
                count[0, 2] = count[0, 2] + 1;
                pressbt[0,2] = 0x04;
            }
            else
            {
                button3.BackColor = Color.SeaShell;
                count[0, 2] = count[0, 2] - 1;
                pressbt[0, 2] = 0x00;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (count[0, 3] == 1)
            {
                button4.BackColor = Color.Red;
                count[0, 3] = count[0, 3] + 1;
                pressbt[0, 3] = 0x08;
            }
            else
            {
                button4.BackColor = Color.SeaShell;
                count[0, 3] = count[0, 3] - 1;
                pressbt[0, 3] = 0x00;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (count[0, 4] == 1)
            {
                button5.BackColor = Color.Red;
                count[0, 4] = count[0, 4] + 1;
                pressbt[0, 4] = 0x10;
            }
            else
            {
                button5.BackColor = Color.SeaShell;
                count[0, 4] = count[0, 4] - 1;
                pressbt[0, 4] = 0x00;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (count[0, 5] == 1)
            {
                button6.BackColor = Color.Red;
                count[0, 5] = count[0, 5] + 1;
                pressbt[0, 5] = 0x20;
            }
            else
            {
                button6.BackColor = Color.SeaShell;
                count[0, 5] = count[0, 5] - 1;
                pressbt[0,5] = 0x00;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (count[0, 6] == 1)
            {
                button7.BackColor = Color.Red;
                count[0, 6] = count[0, 6] + 1;
                pressbt[0, 6] = 0x40;
            }
            else
            {
                button7.BackColor = Color.SeaShell;
                count[0, 6] = count[0, 6] - 1;
                pressbt[0, 6] = 0x00;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (count[0, 7] == 1)
            {
                button8.BackColor = Color.Red;
                count[0, 7] = count[0, 7] + 1;
                pressbt[0, 7] = 0x80;
            }
            else
            {
                button8.BackColor = Color.SeaShell;
                count[0, 7] = count[0, 7] - 1;
                pressbt[0, 7] = 0x00;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (count[1, 0] == 1)
            {
                button9.BackColor = Color.Red;
                count[1, 0] = count[1, 0] + 1;
                pressbt[1, 0] = 0x01;
            }
            else
            {
                button9.BackColor = Color.SeaShell;
                count[1, 0] = count[1, 0] - 1;
                pressbt[1, 0] = 0x00;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (count[1, 1] == 1)
            {
                button10.BackColor = Color.Red;
                count[1, 1] = count[1, 1] + 1;
                pressbt[1, 1] = 0x02;
            }
            else
            {
                button10.BackColor = Color.SeaShell;
                count[1, 1] = count[1, 1] - 1;
                pressbt[1, 1] = 0x00;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (count[1, 2] == 1)
            {
                button11.BackColor = Color.Red;
                count[1, 2] = count[1, 2] + 1;
                pressbt[1, 2] = 0x04;
            }
            else
            {
                button11.BackColor = Color.SeaShell;
                count[1, 2] = count[1, 2] - 1;
                pressbt[1, 2] = 0x00;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (count[1, 3] == 1)
            {
                button12.BackColor = Color.Red;
                count[1, 3] = count[1, 3] + 1;
                pressbt[1, 3] = 0x08;
            }
            else
            {
                button12.BackColor = Color.SeaShell;
                count[1, 3] = count[1, 3] - 1;
                pressbt[1, 3] = 0x00;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (count[1, 4] == 1)
            {
                button13.BackColor = Color.Red;
                count[1, 4] = count[1, 4] + 1;
                pressbt[1,4] = 0x10;
            }
            else
            {
                button13.BackColor = Color.SeaShell;
                count[1, 4] = count[1, 4] - 1;
                pressbt[1,4] = 0x00;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (count[1, 5] == 1)
            {
                button14.BackColor = Color.Red;
                count[1, 5] = count[1, 5] + 1;
                pressbt[1,5] = 0x20;
            }
            else
            {
                button14.BackColor = Color.SeaShell;
                count[1, 5] = count[1, 5] - 1;
                pressbt[1,5] = 0x00;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (count[1, 6] == 1)
            {
                button15.BackColor = Color.Red;
                count[1, 6] = count[1, 6] + 1;
                pressbt[1, 6] = 0x40;
            }
            else
            {
                button15.BackColor = Color.SeaShell;
                count[1, 6] = count[1, 6] - 1;
                pressbt[1, 1] = 0x00;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (count[1, 7] == 1)
            {
                button16.BackColor = Color.Red;
                count[1, 7] = count[1, 7] + 1;
                pressbt[1, 7] = 0x80;
            }
            else
            {
                button16.BackColor = Color.SeaShell;
                count[1, 7] = count[1, 7] - 1;
                pressbt[1, 7] = 0x00;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (count[2, 0] == 1)
            {
                button17.BackColor = Color.Red;
                count[2, 0] = count[2, 0] + 1;
                pressbt[2, 0] = 0x01;
            }
            else
            {
                button17.BackColor = Color.SeaShell;
                count[2, 0] = count[2, 0] - 1;
                pressbt[2, 0] = 0x00;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (count[2, 1] == 1)
            {
                button18.BackColor = Color.Red;
                count[2, 1] = count[2, 1] + 1;
                pressbt[2, 1] = 0x02;
            }
            else
            {
                button18.BackColor = Color.SeaShell;
                count[2,1] = count[2, 1] - 1;
                pressbt[2, 1] = 0x00;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (count[2, 2] == 1)
            {
                button19.BackColor = Color.Red;
                count[2, 2] = count[2, 2] + 1;
                pressbt[2, 2] = 0x04;
            }
            else
            {
                button19.BackColor = Color.SeaShell;
                count[2, 2] = count[2, 2] - 1;
                pressbt[2, 2] = 0x00;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (count[2, 3] == 1)
            {
                button20.BackColor = Color.Red;
                count[2, 3] = count[2, 3] + 1;
                pressbt[2, 3] = 0x08;
            }
            else
            {
                button20.BackColor = Color.SeaShell;
                count[2, 3] = count[2, 3] - 1;
                pressbt[2, 3] = 0x00;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (count[2, 4] == 1)
            {
                button21.BackColor = Color.Red;
                count[2, 4] = count[2, 4] + 1;
                pressbt[2,4] = 0x010;
            }
            else
            {
                button21.BackColor = Color.SeaShell;
                count[2, 4] = count[2, 4] - 1;
                pressbt[2,4] = 0x00;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (count[2, 5] == 1)
            {
                button22.BackColor = Color.Red;
                count[2, 5] = count[2, 5] + 1;
                pressbt[2,5] = 0x20;
            }
            else
            {
                button22.BackColor = Color.SeaShell;
                count[2, 5] = count[2, 5] - 1;
                pressbt[2, 5] = 0x00;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (count[2, 6] == 1)
            {
                button23.BackColor = Color.Red;
                count[2, 6] = count[2, 6] + 1;
                pressbt[2, 6] = 0x40;
            }
            else
            {
                button23.BackColor = Color.SeaShell;
                count[2, 6] = count[2, 6] - 1;
                pressbt[2, 6] = 0x00;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (count[2, 7] == 1)
            {
                button24.BackColor = Color.Red;
                count[2, 7] = count[2, 7] + 1;
                pressbt[2, 7] = 0x80;
            }
            else
            {
                button24.BackColor = Color.SeaShell;
                count[2, 7] = count[2, 7] - 1;
                pressbt[2,7] = 0x00;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (count[3, 0] == 1)
            {
                button25.BackColor = Color.Red;
                count[3, 0] = count[3, 0] + 1;
                pressbt[3, 0] = 0x01;
            }
            else
            {
                button25.BackColor = Color.SeaShell;
                count[3, 0] = count[3, 0] - 1;
                pressbt[3, 0] = 0x00;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (count[3, 1] == 1)
            {
                button26.BackColor = Color.Red;
                count[3, 1] = count[3, 1] + 1;
                pressbt[3, 1] = 0x02;
            }
            else
            {
                button26.BackColor = Color.SeaShell;
                count[3, 1] = count[3, 1] - 1;
                pressbt[3, 1] = 0x00;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (count[3, 2] == 1)
            {
                button27.BackColor = Color.Red;
                count[3, 2] = count[3, 2] + 1;
                pressbt[3, 2] = 0x04;
            }
            else
            {
                button27.BackColor = Color.SeaShell;
                count[3, 2] = count[3, 2] - 1;
                pressbt[3,2] = 0x00;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (count[3, 3] == 1)
            {
                button28.BackColor = Color.Red;
                count[3, 3] = count[3, 3] + 1;
                pressbt[3, 3] = 0x08;
            }
            else
            {
                button28.BackColor = Color.SeaShell;
                count[3, 3] = count[3, 3] - 1;
                pressbt[3, 3] = 0x00;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (count[3, 4] == 1)
            {
                button29.BackColor = Color.Red;
                count[3, 4] = count[3, 4] + 1;
                pressbt[3, 4] = 0x10;
            }
            else
            {
                button29.BackColor = Color.SeaShell;
                count[3,4] = count[3, 4] - 1;
                pressbt[3, 4] = 0x00;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (count[3, 5] == 1)
            {
                button30.BackColor = Color.Red;
                count[3, 5] = count[3, 5] + 1;
                pressbt[3,5] = 0x20;
            }
            else
            {
                button30.BackColor = Color.SeaShell;
                count[3, 5] = count[3, 5] - 1;
                pressbt[3,5] = 0x00;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if(count[3, 6] == 1)
            {
                button31.BackColor = Color.Red;
                count[3, 6] = count[3, 6] + 1;
                pressbt[3,6] = 0x40;
            }
            else
            {
                button31.BackColor = Color.SeaShell;
                count[3, 6] = count[3, 6] - 1;
                pressbt[3,6] = 0x00;
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (count[3, 7] == 1)
            {
                button32.BackColor = Color.Red;
                count[3, 7] = count[3, 7] + 1;
                pressbt[3,7] = 0x80;
            }
            else
            {
                button32.BackColor = Color.SeaShell;
                count[3, 7] = count[3, 7] - 1;
                pressbt[3,7] = 0x00;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (count[4, 0] == 1)
            {
                button33.BackColor = Color.Red;
                count[4, 0] = count[4, 0] + 1;
                pressbt[4, 0] = 0x01;
            }
            else
            {
                button33.BackColor = Color.SeaShell;
                count[4, 0] = count[4, 0] - 1;
                pressbt[4, 0] = 0x00;
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (count[4,1] == 1)
            {
                button34.BackColor = Color.Red;
                count[4, 1] = count[4,1] + 1;
                pressbt[4, 1] = 0x02;
            }
            else
            {
                button34.BackColor = Color.SeaShell;
                count[4, 1] = count[4, 1] - 1;
                pressbt[4, 1] = 0x00;
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (count[4, 2] == 1)
            {
                button35.BackColor = Color.Red;
                count[4, 2] = count[4, 2] + 1;
                pressbt[4, 2] = 0x04;
            }
            else
            {
                button35.BackColor = Color.SeaShell;
                count[4, 2] = count[4, 2] - 1;
                pressbt[4,2] = 0x00;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (count[4, 3] == 1)
            {
                button36.BackColor = Color.Red;
                count[4,3] = count[4, 3] + 1;
                pressbt[4, 3] = 0x08;
            }
            else
            {
                button36.BackColor = Color.SeaShell;
                count[4, 3] = count[4, 3] - 1;
                pressbt[4,3] = 0x00;
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (count[4,4] == 1)
            {
                button37.BackColor = Color.Red;
                count[4, 4] = count[4, 4] + 1;
                pressbt[4, 4] = 0x10;
            }
            else
            {
                button37.BackColor = Color.SeaShell;
                count[4, 4] = count[4, 4] - 1;
                pressbt[4, 4] = 0x00;
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (count[4, 5] == 1)
            {
                button38.BackColor = Color.Red;
                count[4, 5] = count[4, 5] + 1;
                pressbt[4, 5] = 0x20;
            }
            else
            {
                button38.BackColor = Color.SeaShell;
                count[4, 5] = count[4, 5] - 1;
                pressbt[4, 5] = 0x00;
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (count[4,6] == 1)
            {
                button39.BackColor = Color.Red;
                count[4, 6] = count[4, 6] + 1;
                pressbt[4,6] = 0x40;
            }
            else
            {
                button39.BackColor = Color.SeaShell;
                count[4,6] = count[4, 6] - 1;
                pressbt[4, 6] = 0x00;
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (count[4, 7] == 1)
            {
                button40.BackColor = Color.Red;
                count[4, 7] = count[4, 7] + 1;
                pressbt[4, 7] = 0x80;
            }
            else
            {
                button40.BackColor = Color.SeaShell;
                count[4, 7] = count[4,7] - 1;
                pressbt[4,7] = 0x00;
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (count[5, 0] == 1)
            {
                button41.BackColor = Color.Red;
                count[5, 0] = count[5, 0] + 1;
                pressbt[5, 0] = 0x01;
            }
            else
            {
                button41.BackColor = Color.SeaShell;
                count[5, 0] = count[5, 0] - 1;
                pressbt[5, 0] = 0x00;
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (count[5, 1] == 1)
            {
                button42.BackColor = Color.Red;
                count[5, 1] = count[5, 1] + 1;
                pressbt[5, 1] = 0x02;
            }
            else
            {
                button42.BackColor = Color.SeaShell;
                count[5,1] = count[5, 1] - 1;
                pressbt[5, 1] = 0x00;
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (count[5, 2] == 1)
            {
                button43.BackColor = Color.Red;
                count[5, 2] = count[5, 2] + 1;
                pressbt[5,2] = 0x04;
            }
            else
            {
                button43.BackColor = Color.SeaShell;
                count[5, 2] = count[5, 2] - 1;
                pressbt[5, 2] = 0x00;
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            if (count[5, 3] == 1)
            {
                button44.BackColor = Color.Red;
                count[5, 3] = count[5, 3] + 1;
                pressbt[5,3] = 0x08;
            }
            else
            {
                button44.BackColor = Color.SeaShell;
                count[5, 3] = count[5, 3] - 1;
                pressbt[5, 3] = 0x00;
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            if (count[5, 4] == 1)
            {
                button45.BackColor = Color.Red;
                count[5, 4] = count[5, 4] + 1;
                pressbt[5, 4] = 0x10;
            }
            else
            {
                button45.BackColor = Color.SeaShell;
                count[5, 4] = count[5, 4] - 1;
                pressbt[5, 4] = 0x00;
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (count[5, 5] == 1)
            {
                button46.BackColor = Color.Red;
                count[5, 5] = count[5, 5] + 1;
                pressbt[5,5] = 0x20;
            }
            else
            {
                button46.BackColor = Color.SeaShell;
                count[5,5] = count[5, 5] - 1;
                pressbt[5,5] = 0x00;
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            if (count[5,6] == 1)
            {
                button47.BackColor = Color.Red;
                count[5,6] = count[5,6] + 1;
                pressbt[5,6] = 0x40;
            }
            else
            {
                button47.BackColor = Color.SeaShell;
                count[5, 6] = count[5, 6] - 1;
                pressbt[5,6] = 0x00;
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            if (count[5, 7] == 1)
            {
                button48.BackColor = Color.Red;
                count[5, 7] = count[5,7] + 1;
                pressbt[5, 7] = 0x80;
            }
            else
            {
                button48.BackColor = Color.SeaShell;
                count[5, 7] = count[5, 7] - 1;
                pressbt[5,7] = 0x00;
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (count[6, 0] == 1)
            {
                button49.BackColor = Color.Red;
                count[6, 0] = count[6, 0] + 1;
                pressbt[6, 0] = 0x01;
            }
            else
            {
                button49.BackColor = Color.SeaShell;
                count[6, 0] = count[6, 0] - 1;
                pressbt[6, 0] = 0x00;
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            if (count[6, 1] == 1)
            {
                button50.BackColor = Color.Red;
                count[6, 1] = count[6, 1] + 1;
                pressbt[6,1] = 0x02;
            }
            else
            {
                button50.BackColor = Color.SeaShell;
                count[6, 1] = count[6, 1] - 1;
                pressbt[6, 1] = 0x00;
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            if (count[6,2] == 1)
            {
                button51.BackColor = Color.Red;
                count[6, 2] = count[6, 2] + 1;
                pressbt[6,2] = 0x04;
            }
            else
            {
                button51.BackColor = Color.SeaShell;
                count[6,2] = count[6,2] - 1;
                pressbt[6,2] = 0x00;
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            if (count[6,3] == 1)
            {
                button52.BackColor = Color.Red;
                count[6,3] = count[6,3] + 1;
                pressbt[6,3] = 0x08;
            }
            else
            {
                button52.BackColor = Color.SeaShell;
                count[6,3] = count[6,3] - 1;
                pressbt[6,3] = 0x00;
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (count[6, 4] == 1)
            {
                button53.BackColor = Color.Red;
                count[6,4] = count[6,4] + 1;
                pressbt[6,4] = 0x10;
            }
            else
            {
                button53.BackColor = Color.SeaShell;
                count[6,4] = count[6,4] - 1;
                pressbt[6,4] = 0x00;
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            if (count[6, 5] == 1)
            {
                button54.BackColor = Color.Red;
                count[6, 5] = count[6,5] + 1;
                pressbt[6, 5] = 0x20;
            }
            else
            {
                button54.BackColor = Color.SeaShell;
                count[6,5] = count[6,5] - 1;
                pressbt[6,5] = 0x00;
            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            if (count[6, 6] == 1)
            {
                button55.BackColor = Color.Red;
                count[6,6] = count[6,6] + 1;
                pressbt[6,6] = 0x40;
            }
            else
            {
                button55.BackColor = Color.SeaShell;
                count[6,6] = count[6,6] - 1;
                pressbt[6,6] = 0x00;
            }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            if (count[6, 7] == 1)
            {
                button56.BackColor = Color.Red;
                count[6, 7] = count[6, 7] + 1;
                pressbt[6,7] = 0x80;
            }
            else
            {
                button56.BackColor = Color.SeaShell;
                count[6,7] = count[6, 7] - 1;
                pressbt[6,7] = 0x00;
            }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            if (count[7, 0] == 1)
            {
                button57.BackColor = Color.Red;
                count[7, 0] = count[7, 0] + 1;
                pressbt[7, 0] = 0x01;
            }
            else
            {
                button57.BackColor = Color.SeaShell;
                count[7, 0] = count[7, 0] - 1;
                pressbt[7, 0] = 0x00;
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            if (count[7, 1] == 1)
            {
                button58.BackColor = Color.Red;
                count[7, 1] = count[7, 1] + 1;
                pressbt[7, 1] = 0x02;
            }
            else
            {
                button58.BackColor = Color.SeaShell;
                count[7, 1] = count[7, 1] - 1;
                pressbt[7, 1] = 0x00;
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            if (count[7,2] == 1)
            {
                button59.BackColor = Color.Red;
                count[7,2] = count[7,2] + 1;
                pressbt[7, 2] = 0x04;
            }
            else
            {
                button59.BackColor = Color.SeaShell;
                count[7,2] = count[7,2] - 1;
                pressbt[7,2] = 0x00;
            }
        }

        private void button60_Click(object sender, EventArgs e)
        {
            if (count[7, 3] == 1)
            {
                button60.BackColor = Color.Red;
                count[7, 3] = count[7,3] + 1;
                pressbt[7,3] = 0x08;
            }
            else
            {
                button60.BackColor = Color.SeaShell;
                count[7,3] = count[7,3] - 1;
                pressbt[7,3] = 0x00;
            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            if (count[7,4] == 1)
            {
                button61.BackColor = Color.Red;
                count[7,4] = count[7,4] + 1;
                pressbt[7,4] = 0x10;
            }
            else
            {
                button61.BackColor = Color.SeaShell;
                count[7,4] = count[7,4] - 1;
                pressbt[7,4] = 0x00;
            }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            if (count[7, 5] == 1)
            {
                button62.BackColor = Color.Red;
                count[7,5] = count[7,5] + 1;
                pressbt[7, 5] = 0x20;
            }
            else
            {
                button62.BackColor = Color.SeaShell;
                count[7, 5] = count[7,5] - 1;
                pressbt[7, 5] = 0x00;
            }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            if (count[7, 6] == 1)
            {
                button63.BackColor = Color.Red;
                count[7, 6] = count[7,6] + 1;
                pressbt[7, 6] = 0x40;
            }
            else
            {
                button63.BackColor = Color.SeaShell;
                count[7,6] = count[7,6] - 1;
                pressbt[7,6] = 0x00;
            }
        }

        private void button64_Click(object sender, EventArgs e)
        {
            if (count[7,7] == 1)
            {
                button64.BackColor = Color.Red;
                count[7,7] = count[7,7] + 1;
                pressbt[7,7] = 0x80;
            }
            else
            {
                button64.BackColor = Color.SeaShell;
                count[7,7] = count[7,7] - 1;
                pressbt[7,7] = 0x00;
            }
        }

        private void button65_Click(object sender, EventArgs e)
        {
            clearall();
            
        }
        private void clearall ()
        {
            for (int i = 0; i <= 7; i++)
                datasend[i] = 0x0;

            for (int i = 0; i <= 7; i++)
                for (int j = 0; j <= 7; j++)
                    pressbt[i, j] = 0x0;

            richTextBox1.Text = "";
            strch = "B";
            for (int i = 0; i <= 7; i++)
                for (int j = 0; j <= 7; j++)
                    count[i, j] = 1;
            Controls.OfType<Button>().ToList().ForEach(button => button.BackColor = Color.SeaShell);
        } //clear all buttons
        private void Hearton()
        {
          
            strch = "H";

            button10.BackColor = Color.Red;
            count[1, 1] = 2;
            button11.BackColor = Color.Red;
            count[1, 2] = 2;
            button14.BackColor = Color.Red;
            count[1, 5] = 2;
            button15.BackColor = Color.Red;
            count[1, 6] = 2;
            button17.BackColor = Color.Red;
            count[2, 0] = 2;
            button20.BackColor = Color.Red;
            count[2, 3] = 2;
            button21.BackColor = Color.Red;
            count[2, 4] = 2;
            button24.BackColor = Color.Red;
            count[2, 7] = 2;
            button25.BackColor = Color.Red;
            count[3, 0] = 2;
            button32.BackColor = Color.Red;
            count[3, 7] = 2;
            button33.BackColor = Color.Red;
            count[4, 1] = 2;
            button40.BackColor = Color.Red;
            count[4, 7] = 2;
            button42.BackColor = Color.Red;
            count[5, 1] = 2;
            button47.BackColor = Color.Red;
            count[5, 6] = 2;
            button51.BackColor = Color.Red;
            count[6, 2] = 2;
            button54.BackColor = Color.Red;
            count[6, 5] = 2;
            button60.BackColor = Color.Red;
            count[7, 3] = 2;
            button61.BackColor = Color.Red;
            count[7, 4] = 2;
        } //Heart light on 
        private void Smileon()
        {
            strch = "S";
            button3.BackColor = Color.Red;
            count[0, 2] = 2;
            button4.BackColor = Color.Red;
            count[0, 3] = 2;
            button5.BackColor = Color.Red;
            count[0, 4] = 2;
            button6.BackColor = Color.Red;
            count[0, 5] = 2;
            button10.BackColor = Color.Red;
            count[1, 1] = 2;
            button15.BackColor = Color.Red;
            count[1, 6] = 2;
            button17.BackColor = Color.Red;
            count[2, 0] = 2;
            button19.BackColor = Color.Red;
            count[2, 2] = 2;
            button22.BackColor = Color.Red;
            count[2, 5] = 2;
            button24.BackColor = Color.Red;
            count[2, 7] = 2;
            button25.BackColor = Color.Red;
            count[3, 0] = 2;
            button32.BackColor = Color.Red;
            count[3, 7] = 2;
            button33.BackColor = Color.Red;
            count[4, 0] = 2;
            button35.BackColor = Color.Red;
            count[4, 2] = 2;
            button38.BackColor = Color.Red;
            count[4, 5] = 2;
            button40.BackColor = Color.Red;
            count[4,7] = 2;
            button41.BackColor = Color.Red;
            count[5, 0] = 2;
            button44.BackColor = Color.Red;
            count[5,3] = 2;
            button45.BackColor = Color.Red;
            count[5,4] = 2;
            button48.BackColor = Color.Red;
            count[5,7] = 2;
            button50.BackColor = Color.Red;
            count[6, 1] = 2;
            button55.BackColor = Color.Red;
            count[6, 6] = 2;
            button59.BackColor = Color.Red;
            count[7, 2] = 2;
            button60.BackColor = Color.Red;
            count[7, 3] = 2;
            button61.BackColor = Color.Red;
            count[7,4] = 2;
            button62.BackColor = Color.Red;
            count[7, 5] = 2;

        } //Smile light on
        private void Swanon()
        {
            strch = "SW";
            button2.BackColor = Color.Red;
            count[0, 1] = 2;
            button3.BackColor = Color.Red;
            count[0, 2] = 2;
            button4.BackColor = Color.Red;
            count[0, 3] = 2;
            button9.BackColor = Color.Red;
            count[1,0] = 2;
            button10.BackColor = Color.Red;
            count[1, 1] = 2;
            button13.BackColor = Color.Red;
            count[1,4] = 2;
            button17.BackColor = Color.Red;
            count[2, 0] = 2;
            button21.BackColor = Color.Red;
            count[2, 4] = 2;
            button28.BackColor = Color.Red;
            count[3, 3] = 2;
            button35.BackColor = Color.Red;
            count[4,2] = 2;
            button42.BackColor = Color.Red;
            count[5, 1] = 2;
            button44.BackColor = Color.Red;
            count[5,3] = 2;
            button45.BackColor = Color.Red;
            count[5, 4] = 2;
            button46.BackColor = Color.Red;
            count[5,5] = 2;
            button47.BackColor = Color.Red;
            count[5, 6] = 2;
            button48.BackColor = Color.Red;
            count[5, 7] = 2;
            button50.BackColor = Color.Red;
            count[6,1] = 2;
            button51.BackColor = Color.Red;
            count[6,2] = 2;
            button52.BackColor = Color.Red;
            count[6,3] = 2;
            button53.BackColor = Color.Red;
            count[6,4] = 2;
            button54.BackColor = Color.Red;
            count[6,5] = 2;
            button55.BackColor = Color.Red;
            count[6, 6] = 2;
            button59.BackColor = Color.Red;
            count[7, 2] = 2;
            button60.BackColor = Color.Red;
            count[7, 3] = 2;
            button61.BackColor = Color.Red;
            count[7, 4] = 2;
            button62.BackColor = Color.Red;
            count[7, 5] = 2;
        } // Swan light on 
        private void Roboton()
        {
            strch = "R";
            button3.BackColor = Color.Red;
            count[0, 2] = 2;
            button6.BackColor = Color.Red;
            count[0, 5] = 2;
            button11.BackColor = Color.Red;
            count[1,2] = 2;
            button14.BackColor = Color.Red;
            count[1,5] = 2;
            button18.BackColor = Color.Red;
            count[2, 1] = 2;
            button19.BackColor = Color.Red;
            count[2, 2] = 2;
            button20.BackColor = Color.Red;
            count[2,3] = 2;
            button21.BackColor = Color.Red;
            count[2,4] = 2;
            button22.BackColor = Color.Red;
            count[2, 5] = 2;
            button23.BackColor = Color.Red;
            count[2,6] = 2;
            button25.BackColor = Color.Red;
            count[3, 0] = 2;
            button26.BackColor = Color.Red;
            count[3, 1] = 2;
            button28.BackColor = Color.Red;
            count[3,3] = 2;
            button29.BackColor = Color.Red;
            count[3,4] = 2;
            button31.BackColor = Color.Red;
            count[3,6] = 2;
            button32.BackColor = Color.Red;
            count[3,7] = 2;
            button33.BackColor = Color.Red;
            count[4, 0] = 2;
            button34.BackColor = Color.Red;
            count[4,1] = 2;
            button35.BackColor = Color.Red;
            count[4, 2] = 2;
            button36.BackColor = Color.Red;
            count[4,3] = 2;
            button37.BackColor = Color.Red;
            count[4,4] = 2;
            button38.BackColor = Color.Red;
            count[4,5] = 2;
            button39.BackColor = Color.Red;
            count[4,6] = 2;
            button40.BackColor = Color.Red;
            count[4,7] = 2;
            button41.BackColor = Color.Red;
            count[5,0] = 2;
            button42.BackColor = Color.Red;
            count[5, 1] = 2;
            button43.BackColor = Color.Red;
            count[5, 2] = 2;
            button44.BackColor = Color.Red;
            count[5,3] = 2;
            button45.BackColor = Color.Red;
            count[5,4] = 2;
            button46.BackColor = Color.Red;
            count[5,5] = 2;
            button47.BackColor = Color.Red;
            count[5, 6] = 2;
            button48.BackColor = Color.Red;
            count[5, 7] = 2;
            button49.BackColor = Color.Red;
            count[6,1] = 2;
            button51.BackColor = Color.Red;
            count[6,3] = 2;
            button54.BackColor = Color.Red;
            count[6, 5] = 2;
            button56.BackColor = Color.Red;
            count[6, 7] = 2;
            button59.BackColor = Color.Red;
            count[7, 2] = 2;
            button62.BackColor = Color.Red;
            count[7, 5] = 2;
        } // Robot light on 

        private void heartbt_Click(object sender, EventArgs e)
        {
            clearall();
            Hearton();
        }

        private void Smilebt_Click(object sender, EventArgs e)
        {
            clearall();
            Smileon();
        }

        private void Swanbt_Click(object sender, EventArgs e)
        {
            clearall();
            Swanon();
        }

        private void Robotbt_Click(object sender, EventArgs e)
        {
            clearall();
            Roboton();
        }

        private void cBoxConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxConnect.Checked)
            {
                if (Port_name.Text == string.Empty)
                {
                    cBoxConnect.CheckState = CheckState.Unchecked;
                    MessageBox.Show(" You forget enter port name!", "ERROR", MessageBoxButtons.OK,
                  MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                }
                else
                {
                    try
                    {
                        serialPort1 = new SerialPort(Port_name.Text, 9600, Parity.None, 8, StopBits.One);
                        Thread.Sleep(50);
                        serialPort1.Open();
                        Thread.Sleep(200);
                        progressBar1.Value = 50;
                        Thread.Sleep(200);
                        progressBar1.Value = 100;
                        cBoxConnect.Text = "Connected";
                    }
                    catch (Exception)
                    {
                        cBoxConnect.CheckState = CheckState.Unchecked;
                    }
                }
            }
            else
            {
                try
                {
                    Thread.Sleep(50);
                    serialPort1.Close();
                    Port_name.Enabled = true;
                    cBoxConnect.Text = "Disconnected";
                    progressBar1.Value = 0;
                }
                catch (Exception)
                {

                }
            }
                
                
        } // Find  port 

        private void Gnbtn_Click(object sender, EventArgs e)
        {

            culcdata();
            richTextBox1.Text = BitConverter.ToString(datasend);//System.Text.Encoding.UTF32.GetString(datasend);

        } // generate button 

        private void Sendbt_Click(object sender, EventArgs e)
        {
            if (Port_name.Text == string.Empty)
            {
                cBoxConnect.CheckState = CheckState.Unchecked;
                MessageBox.Show(" You forget enter port name!", "ERROR", MessageBoxButtons.OK,
              MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            serialPort1.Write(richTextBox1.Text+"-");
        }// Send DATA in UART 

        private void checkBoxBlink_CheckedChanged(object sender, EventArgs e)
        {
            if (Port_name.Text == string.Empty)
            {
                cBoxConnect.CheckState = CheckState.Unchecked;
                MessageBox.Show(" You forget enter port name!", "ERROR", MessageBoxButtons.OK,
              MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else {
                serialPort1.Write("Blink");
               
            }
        }
    }
}

