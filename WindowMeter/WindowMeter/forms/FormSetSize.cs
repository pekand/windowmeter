using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowMeter
{
    public partial class FormSetSize : Form
    {
        public WindowMeterForm windowMeterForm = null;

        public FormSetSize()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string[] result = Regex.Split(textSize.Text, "\\s*(\\d+)\\s*(?:[xX\\s]+)\\s*(\\d+)\\s*");

                if (result.Length != 4)
                {
                    return;
                }

                windowMeterForm.SetSize(Int32.Parse(result[1]), Int32.Parse(result[2]));
            } catch (Exception ex) {
                
            }

            this.Close();
        }

        private void FormSetSize_Load(object sender, EventArgs e)
        {

        }

        public void SetSize(int width = 0, int height = 0) {
            textSize.Text = width.ToString() + "x" + height.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                button2_Click(sender, e);
            }
        }
    }
}
