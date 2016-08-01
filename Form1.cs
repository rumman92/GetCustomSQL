using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomReportConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Clear();

                string val = null;

                int start = richTextBox1.Text.IndexOf("<CommandText>") + 13;
                int end = richTextBox1.Text.IndexOf("</CommandText>", start);

                val = "use cvent_report\n" + richTextBox1.Text.Substring(start, end - start);

                val = val.Replace("@parked_flag@", comboBox1.Text);
                val = val.Replace("@acct_user_stub@", textBox4.Text);
                val = val.Replace("&lt;", "<");
                val = val.Replace("&gt;", ">");
                val = val.Replace("--select @SQLEXPR", "select @SQLEXPR");
                val = val.Remove(val.IndexOf("execute sp_executesql"));

                richTextBox2.Text = val;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops!");
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox2.Copy();
        }
    }
}
