using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommUtility.Properties;


namespace CommUtility
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form1 mainForm = null;
        public Form2(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }






        private void Form2_Load(object sender, EventArgs e)
        {
            //Here we load up the saved setting info to the form
            textBox1.Text = Settings1.Default.Button1Legend;
            textBox2.Text = Settings1.Default.Button2Legend;
            textBox3.Text = Settings1.Default.Button3Legend;
            textBox4.Text = Settings1.Default.Button4Legend;
            textBox5.Text = Settings1.Default.Button5Legend;
            textBox6.Text = Settings1.Default.Button6Legend;
            textBox7.Text = Settings1.Default.Button7Legend;
            textBox8.Text = Settings1.Default.Button8Legend;
            textBox9.Text = Settings1.Default.Button9Legend;
            textBox10.Text = Settings1.Default.Button10Legend;
            textBox21.Text = Settings1.Default.Button11Legend;
            textBox33.Text = Settings1.Default.Button12Legend;
            textBox35.Text = Settings1.Default.Button13Legend;
            textBox13.Text = Settings1.Default.Command1Text;
            textBox15.Text = Settings1.Default.Command2Text;
            textBox17.Text = Settings1.Default.Command3Text;
            textBox11.Text = Settings1.Default.Command4Text;
            textBox19.Text = Settings1.Default.Command5Text;
            textBox20.Text = Settings1.Default.Command6Text;
            textBox18.Text = Settings1.Default.Command7Text;
            textBox16.Text = Settings1.Default.Command8Text;
            textBox14.Text = Settings1.Default.Command9Text;
            textBox12.Text = Settings1.Default.Command10Text;
            textBox32.Text = Settings1.Default.Command11Text;
            textBox34.Text = Settings1.Default.Command12Text;
            textBox36.Text = Settings1.Default.Command13Text;
            textBox37.Text = Settings1.Default.SliderValue;

           
        }




        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText3 = textBox3.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText1 = textBox1.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText6 = textBox6.Text;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString1 = textBox13.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText4 = textBox4.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText9 = textBox9.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText8 = textBox8.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText7 = textBox7.Text;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText10 = textBox10.Text;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString2 = textBox15.Text;
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString3 = textBox17.Text;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString4 = textBox11.Text;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString5 = textBox19.Text;
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString6 = textBox20.Text;
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString7 = textBox18.Text;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString8 = textBox16.Text;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString9 = textBox14.Text;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString10 = textBox12.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  Settings for each button and command gets saved
        
            Settings1.Default.Button1Legend = textBox1.Text;
            Settings1.Default.Button2Legend = textBox2.Text;
            Settings1.Default.Button3Legend = textBox3.Text;
            Settings1.Default.Button4Legend = textBox4.Text;
            Settings1.Default.Button5Legend = textBox5.Text;
            Settings1.Default.Button6Legend = textBox6.Text;
            Settings1.Default.Button7Legend = textBox7.Text;
            Settings1.Default.Button8Legend = textBox8.Text;
            Settings1.Default.Button9Legend = textBox9.Text;
            Settings1.Default.Button10Legend = textBox10.Text;
            Settings1.Default.Button11Legend = textBox21.Text;
            Settings1.Default.Button12Legend = textBox33.Text;
            Settings1.Default.Button13Legend = textBox35.Text;


            Settings1.Default.Command1Text = textBox13.Text;
            Settings1.Default.Command2Text = textBox15.Text;
            Settings1.Default.Command3Text = textBox17.Text;
            Settings1.Default.Command4Text = textBox11.Text;
            Settings1.Default.Command5Text = textBox19.Text;
            Settings1.Default.Command6Text = textBox20.Text;
            Settings1.Default.Command7Text = textBox18.Text;
            Settings1.Default.Command8Text = textBox16.Text;
            Settings1.Default.Command9Text = textBox14.Text;
            Settings1.Default.Command10Text = textBox12.Text;
            Settings1.Default.Command11Text = textBox32.Text;
            Settings1.Default.Command12Text = textBox34.Text;
            Settings1.Default.Command13Text = textBox36.Text;

           
            Settings1.Default.SliderValue = textBox37.Text;

            Settings1.Default.Save();

            this.Hide();
    
            foreach (Form frm in Application.OpenForms)
            {
              if (frm is Form1)
                {
                    frm.Show();
                    return;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText2 = textBox2.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText5 = textBox5.Text;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText11 = textBox21.Text;
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText12 = textBox33.Text;
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.LabelText13 = textBox35.Text;
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString11 = textBox32.Text;
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString12 = textBox34.Text;
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.CommandString13 = textBox36.Text;
        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            this.mainForm.SliderCommandString = textBox37.Text;
        }


                 

    }
}
