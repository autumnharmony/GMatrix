using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GMatrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            int n;
            int cnt;
            int.TryParse(nTb.Text.Trim(),out n);
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = n;
            tableLayoutPanel1.RowCount = n + 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    TextBox tb = new TextBox();
                    tb.Name = "item"+i+j+"Tb";
                    tableLayoutPanel1.Controls.Add(tb);
                    //tb.Enter += new EventHandler(tb_Enter); { cnt++; if (cnt == n * n) { tableLayoutPanel1.Controls.Add(new Button()); } }
                }
            }

            tableLayoutPanel1.Controls.Add(new Button());
        }

        void tb_Enter(object sender, EventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {

            }
        }
    }
}