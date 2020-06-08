

using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CommUtility.Properties;




namespace CommUtility
{

    public partial class Form1 : Form
    {
        Boolean StxEtxDelim = true;
        Boolean OtherDelim = false;
        Boolean NoDelim = false;     
        Boolean ActiveFlag = false;
        Boolean error;
        Boolean CommError = true;
        Boolean PortIsAlreadyOpen = false;

        const char STX = '\x02';
        const char ETX = '\x03';
        const char CR = '\x0d';
        const char LF = '\x0a';
        string CommandMessage1 = "\r\n";
        string CommandMessage2 = "\r\n";
        string CommandMessage3 = "\r\n";
        string CommandMessage4 = "\r\n";
        string CommandMessage5 = "\r\n";
        string CommandMessage6 = "\r\n";
        string CommandMessage7 = "\r\n";
        string CommandMessage8 = "\r\n";
        string CommandMessage9 = "\r\n";
        string CommandMessage10 = "\r\n";
        string CommandMessage11 = "\r\n";
        string CommandMessage12 = "\r\n";
        string CommandMessage13 = "\r\n";
        string SliderCommandMessage = "\r\n";

        string RxString;
        string ComPortName; // = "COM2";
        string ClearScreenCommand = "CLRSCR\r\n\r\n";
        string ScreenHomeCommand = "\x1b[H";
        string InstrumentType;
        string InputValueRead;
       

       

        // delegate is used to write to a UI control from a non-UI thread
        private delegate void SetTextDeleg(string text);






        public Form1()
        {
            InitializeComponent();
            // Adding the event handler in the constructor
            this.Shown += new EventHandler(Form1_Shown);
           
        }




        void Form1_Load(object sender, EventArgs e)
        {
           // listBox1.SelectedIndex = 4;
            serialPort1.BaudRate = Settings1.Default.BaudRate;
            textBox4.Text = Settings1.Default.StartDelimiter;
            textBox6.Text = Settings1.Default.EndDelimiter;
            BaudSelect.Text = Settings1.Default.BaudSelect;
            radioButton8.Checked = Settings1.Default.StxEtxDelimSel;
            radioButton9.Checked = Settings1.Default.OtherDelimSel;
            radioButton10.Checked = Settings1.Default.NoneDelimSel;
            radioButton1.Checked = Settings1.Default.DataBitsSel8;
            radioButton2.Checked = Settings1.Default.DataBitsSel7;
            radioButton4.Checked = Settings1.Default.ParitySelNone;
            radioButton3.Checked = Settings1.Default.ParitySelOdd;
            radioButton5.Checked = Settings1.Default.ParitySelEven;
            radioButton7.Checked = Settings1.Default.StopBitsOne;
            radioButton6.Checked = Settings1.Default.StopBitsTwo;

        }

        
    
    

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }






        private void button2_Click_1(object sender, EventArgs e)
        {
           Form2 frm = new Form2(this);
           frm.Show();
                       
        }



        public string LabelText1
        {
            get { return button16.Text; }
            set { button16.Text = value; }
        }

        public string LabelText2
        {
            get { return button17.Text; }
            set { button17.Text = value; }
        }

        public string LabelText3
        {
            get { return button18.Text; }
            set { button18.Text = value; }
        }

        public string LabelText4
        {
            get { return button19.Text; }
            set { button19.Text = value; }
        }

        public string LabelText5
        {
            get { return button20.Text; }
            set { button20.Text = value; }
        }

        public string LabelText6
        {
            get { return button26.Text; }
            set { button26.Text = value; }
        }

        public string LabelText7
        {
            get { return button25.Text; }
            set { button25.Text = value; }
        }

        public string LabelText8
        {
            get { return button24.Text; }
            set { button24.Text = value; }
        }

        public string LabelText9
        {
            get { return button23.Text; }
            set { button23.Text = value; }
        }

        public string LabelText10
        {
            get { return button22.Text; }
            set { button22.Text = value; }
        }


          public string LabelText11
        {
            get { return button28.Text; }
            set { button28.Text = value; }
        }

        public string LabelText12
        {
            get { return button9.Text; }
            set { button9.Text = value; }
        }

        public string LabelText13
        {
            get { return button29.Text; }
            set { button29.Text = value; }
        }







         public string CommandString1
        {
            get { return CommandMessage1; }
            set {CommandMessage1 = value; }
        }

         public string CommandString2
         {
             get { return CommandMessage2; }
             set { CommandMessage2 = value; }
         }

         public string CommandString3
         {
             get { return CommandMessage3; }
             set { CommandMessage3 = value; }
         }


         public string CommandString4
         {
             get { return CommandMessage4; }
             set { CommandMessage4 = value; }
         }

         public string CommandString5
         {
             get { return CommandMessage5; }
             set { CommandMessage5 = value; }
         }


         public string CommandString6
         {
             get { return CommandMessage6; }
             set { CommandMessage6 = value; }
         }

         public string CommandString7
         {
             get { return CommandMessage7; }
             set { CommandMessage7 = value; }
         }
        
         public string CommandString8
         {
             get { return CommandMessage8; }
             set { CommandMessage8 = value; }
         }

         public string CommandString9
         {
             get { return CommandMessage9; }
             set { CommandMessage9 = value; }
         }


         public string CommandString10
         {
             get { return CommandMessage10; }
             set { CommandMessage10 = value; }
         }


         public string CommandString11
         {
             get { return CommandMessage11; }
             set { CommandMessage11 = value; }
         }


         public string CommandString12
         {
             get { return CommandMessage12; }
             set { CommandMessage12 = value; }
         }


         public string CommandString13
         {
             get { return CommandMessage13; }
             set { CommandMessage13 = value; }
         }

        
         public string SliderCommandString
         {
             get { return SliderCommandMessage; }
             set { SliderCommandMessage = value; }
         }



        private void button1_Click(object sender, EventArgs e)
         {
             if (!PortIsAlreadyOpen)
             {
                 if (numericUpDown1.Value == 1)
                     serialPort1.PortName = "COM1";
                 if (numericUpDown1.Value == 2)
                     serialPort1.PortName = "COM2";
                 if (numericUpDown1.Value == 3)
                     serialPort1.PortName = "COM3";
                 if (numericUpDown1.Value == 4)
                     serialPort1.PortName = "COM4";
                 if (numericUpDown1.Value == 5)
                     serialPort1.PortName = "COM5";
                 if (numericUpDown1.Value == 6)
                     serialPort1.PortName = "COM6";
                 if (numericUpDown1.Value == 7)
                     serialPort1.PortName = "COM7";
                 if (numericUpDown1.Value == 8)
                     serialPort1.PortName = "COM8";
             }
            
             else
                 textBox1.Text = "ERROR: Port is already open!";     /// if the user tries to re-init the port once is open


            if (!serialPort1.IsOpen)
            {
                ComPortName = serialPort1.PortName;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                try
                { serialPort1.Open(); }
                catch (UnauthorizedAccessException) { error = true; }
                catch (IOException) { error = true; }
                catch (ArgumentException) { error = true; }
                if (error) textBox1.Text = "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable COM Port Unavalible";

                else
                {
                    textBox1.Text = "Port Active on: " + ComPortName + ", Baud = " + serialPort1.BaudRate + ", Bits = " + serialPort1.StopBits + ", Parity = " + serialPort1.Parity + ", HandShake = " + serialPort1.Handshake + "\r\n";
                    CommError = false;
                    PortIsAlreadyOpen = true;

                }


                // textBox1.BackColor = System.Drawing.Color.OrangeRed;
            }
        }


        

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { indata });
        }



        private void si_DataReceived(string data)  //this is the routine to write received text onto terminal
        {
            if (data == "\r")  
                textBox1.Text += "\r\n";
            else
                textBox1.Text += data;

            if (data == "CLRSCR\r\n\r\n")
                        textBox1.Clear();
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
       public void button16_Click(object sender, EventArgs e)
        {
            if (!CommError) //prevents program crash due to user using the port before initialization
            {
                if (StxEtxDelim)
                    serialPort1.Write((char)STX + CommandMessage1 + (char)ETX);

                if (OtherDelim)
                    serialPort1.Write(textBox4.Text + CommandMessage1 + textBox6.Text);

                if (NoDelim)
                    serialPort1.Write(CommandMessage1);
            }
            else
                PorTnotOpen();  // let the user know what the error is without creating a system crash
        }
                     

        public void button17_Click(object sender, EventArgs e)
        {
             if (!CommError)
            {
            if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage2 + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage2 + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage2);
            }
             else
                 PorTnotOpen();
        }


       public void button18_Click(object sender, EventArgs e)
        {
          if (!CommError)
          { 
           if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage3 + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage3 + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage3);
          }
          else
              PorTnotOpen();
        }

        public void button19_Click(object sender, EventArgs e)
        {
            if (!CommError)
          { 
            if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage4 + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage4 + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage4);
          }
            else
                PorTnotOpen();
        }



        public void button20_Click(object sender, EventArgs e)
        {
          if (!CommError)
          { 
            if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage5 + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage5 + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage5);
          }
          else
              PorTnotOpen();
        }



        private void button35_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        

        public void button26_Click(object sender, EventArgs e)
        {
          if (!CommError)
          { 
            if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage6 + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage6 + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage6);
          }
          else
              PorTnotOpen();
        }



        public void button25_Click(object sender, EventArgs e)
        {
           if (!CommError)
          { 
            if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage7 + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage7 + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage7);
          }
           else
               PorTnotOpen();
        }



        public void button24_Click(object sender, EventArgs e)
        {
            if (!CommError)
          { 
            if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage8 + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage8 + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage8);
          }
            else
                PorTnotOpen();
        }





        public void button23_Click(object sender, EventArgs e)
        {
             if (!CommError)
          { 
            if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage9 + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage9 + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage9);
          }
             else
                 PorTnotOpen();
        }





       public void button22_Click(object sender, EventArgs e)
        {
          if (!CommError)
          { 
           if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage10 + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage10 + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage10);
          }
          else
              PorTnotOpen();
        }



      
        private void button28_Click(object sender, EventArgs e)
        {
            if (!CommError)
          { 
            if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage11 + textBox5.Text + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage11 + textBox5.Text + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage11 + textBox5.Text);
          }
            else
                PorTnotOpen();

        }

        private void button29_Click(object sender, EventArgs e)
        {
           
        }

           private void label1_Click(object sender, EventArgs e)
        {

        }

  
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
      

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

     
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

       
       private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

              
        private void button9_Click_1(object sender, EventArgs e)
        {
          if (!CommError)
          { 
            if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage12 + textBox2.Text + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage12 + textBox2.Text + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage12 + textBox2.Text);
          }
          else
              PorTnotOpen();
        }



        private void button29_Click_1(object sender, EventArgs e)
        {
            if (!CommError)
          { 
            if (StxEtxDelim)
                serialPort1.Write((char)STX + CommandMessage13 + textBox3.Text + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + CommandMessage13 + textBox3.Text + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(CommandMessage13 + textBox3.Text);
          }
            else
                PorTnotOpen();
        }

      

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            if (!PortIsAlreadyOpen)
            {
                if (numericUpDown1.Value == 1)
                    serialPort1.PortName = "COM1";
                if (numericUpDown1.Value == 2)
                    serialPort1.PortName = "COM2";
                if (numericUpDown1.Value == 3)
                    serialPort1.PortName = "COM3";
                if (numericUpDown1.Value == 4)
                    serialPort1.PortName = "COM4";
                if (numericUpDown1.Value == 5)
                    serialPort1.PortName = "COM5";
                if (numericUpDown1.Value == 6)
                    serialPort1.PortName = "COM6";
                if (numericUpDown1.Value == 7)
                    serialPort1.PortName = "COM7";
                if (numericUpDown1.Value == 8)
                    serialPort1.PortName = "COM8";
            }
            else
            textBox1.Text = "ERROR: Serial Port is alredy open, close and re-start application to change port# before pressing\r\n [Init-Ser_Port] button\r\n Note: All serial port settings must be set before port initialization";
                
                
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

       
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {   
          if (!CommError)
          { 
            textBox7.Text = trackBar1.Value.ToString();
            if (StxEtxDelim)
                serialPort1.Write((char)STX + SliderCommandMessage + textBox7.Text + (char)ETX);

            if (OtherDelim)
                serialPort1.Write(textBox4.Text + SliderCommandMessage  + textBox7.Text + textBox6.Text);

            if (NoDelim)
                serialPort1.Write(SliderCommandMessage  + textBox7.Text);

             System.Threading.Thread.Sleep(40);
          }
          else
              PorTnotOpen();
        }



        private void label10_Click(object sender, EventArgs e)
        {

        }

       

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }




        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            serialPort1.DataBits = 8;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            serialPort1.DataBits = 7;
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            serialPort1.Parity = Parity.None; 
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            serialPort1.Parity = Parity.Odd; 
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            serialPort1.Parity = Parity.Even; 
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.StopBits = StopBits.One; 
        }

        private void radioButton6_CheckedChanged_1(object sender, EventArgs e)
        {
            serialPort1.StopBits = StopBits.Two; 
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           // Properties.Settings.Default.Save();
            Settings1.Default.BaudRate = serialPort1.BaudRate;
            Settings1.Default.StartDelimiter = textBox4.Text;
            Settings1.Default.EndDelimiter = textBox6.Text;           
            Settings1.Default.BaudSelect = BaudSelect.Text;
            Settings1.Default.StxEtxDelimSel = radioButton8.Checked;
            Settings1.Default.OtherDelimSel = radioButton9.Checked;
            Settings1.Default.NoneDelimSel = radioButton10.Checked;
            Settings1.Default.DataBitsSel8 = radioButton1.Checked;
            Settings1.Default.DataBitsSel7 = radioButton2.Checked;
            Settings1.Default.ParitySelNone = radioButton4.Checked;
            Settings1.Default.ParitySelOdd = radioButton3.Checked;
            Settings1.Default.ParitySelEven = radioButton5.Checked;
            Settings1.Default.StopBitsOne = radioButton7.Checked;
            Settings1.Default.StopBitsTwo = radioButton6.Checked;

            Settings1.Default.Save();

            Environment.Exit(0); //exit program
            
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
               StxEtxDelim = true;
               OtherDelim = false;
               NoDelim = false;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
               StxEtxDelim = false;
               OtherDelim = true;
               NoDelim = false;   
            
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
               StxEtxDelim = false;
               OtherDelim = false;
               NoDelim = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = BaudSelect.Text;

            switch (text)
            {
                case "110":
                    serialPort1.BaudRate = 110;
                    break;
                case "300":
                    serialPort1.BaudRate = 300;
                    break;
                case "600":
                    serialPort1.BaudRate = 600;
                    break;
                case "1200":
                    serialPort1.BaudRate = 1200;
                    break;
                case "2400":
                    serialPort1.BaudRate = 2400;
                    break;
                case "4800":
                    serialPort1.BaudRate = 4800;
                    break;
                case "9600":
                    serialPort1.BaudRate = 9600;
                    break;
                case "19200":
                    serialPort1.BaudRate = 19200;
                    break;
                case "38400":
                    serialPort1.BaudRate = 38400;
                    break;
                case "57600":
                    serialPort1.BaudRate = 57600;
                    break;
                case "115200":
                    serialPort1.BaudRate = 115200;
                    break;

                default:
                    serialPort1.BaudRate = 9600;
                    break;
            }

        }

       



         public void PorTnotOpen()
        {
            textBox1.Text = "ERROR: Serial Port is NOT OPEN, Press [Init-Ser_Port] button";
        }

         private void groupBox3_Enter(object sender, EventArgs e)
         {

         }

         private void radioButton13_CheckedChanged(object sender, EventArgs e)
         {
             serialPort1.Handshake = Handshake.None; 
         }

         private void radioButton12_CheckedChanged(object sender, EventArgs e)
         {
             serialPort1.Handshake = Handshake.RequestToSend; 
         }

         private void radioButton11_CheckedChanged(object sender, EventArgs e)
         {
             serialPort1.Handshake = Handshake.XOnXOff;
         }

         private void groupBox2_Enter(object sender, EventArgs e)
         {

         }

         private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
         {

         }








    }
}
