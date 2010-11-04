using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows;


namespace GMatrix
{
    public partial class Form1 : Form
    {
        int n;
        int cnt;
        bool correct = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
        	tableLayoutPanel1.SuspendLayout();
            int n;
            int.TryParse(nTb.Text.Trim(),out n);
            this.n = n;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnCount = n;
            tableLayoutPanel1.RowCount = n + 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    TextBox tb = new TextBox();
                    tb.Text = "0";
                    tb.Width = 40;
                    tb.Name = "item"+i+j+"Tb";
					tb.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(tb);
                    //tb.Enter += new EventHandler(tb_Enter); { cnt++; if (cnt == n * n) { tableLayoutPanel1.Controls.Add(new Button()); } }
                }
            }

            //tableLayoutPanel1.Controls.Add(new Button());
            tableLayoutPanel1.ResumeLayout();
            groupBox1.Show();
            //splitContainer2.AutoSize = true;
        }

        void tb_Enter(object sender, EventArgs e)
        {
        	//if (cnt == n*n){  calcDet.Click();} else cnt++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        
        private void ShowError(string msg, Control c){
        	resultLbl.Text = msg;
        	c.TextChanged += delegate(object sender, EventArgs e) { resultLbl.Text="" ;};
        }
        
        private void TakeAttention(Control c){
			c.BackColor = Color.Red;
           	
           	c.TextChanged += delegate(object s, EventArgs ea) { 
           		((Control)s).BackColor = Color.White; 
           		
           	};
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int[,] a = new int[n, n];
            int i = 0, j = 0;

            //bool correct = true;
            if (correct)
            {
                correct = true;
                foreach (TextBox c in tableLayoutPanel1.Controls)
                {
                    if (i == n) { i = 0; j++; }
                    try
                    {
                        a[j, i] = int.Parse(c.Text);
                    }
                    catch (Exception ex)
                    {
                        TakeAttention(c);
                        ShowError("Ошибка ввода", c);
                        //ShowError(ex.Message,c);
                        correct = false;

                    }
                    //int.TryParse(c.Text,out a[j,i]);




                    i++;
                }
                if (correct)
                {
                    Matrix m = new Matrix(a);
                    resultLbl.Text = "Определитель матрицы : " + Matrix.Det(m).ToString();
                }
            }
        }

       
        
        void TableLayoutPanel2Paint(object sender, PaintEventArgs e)
        {
        	
        }
        
        void GroupBox1Enter(object sender, EventArgs e)
        {
        	
        }
        
        void Panel1Paint(object sender, PaintEventArgs e)
        {
        	
        }
        
        void NTbTextChanged(object sender, EventArgs e)
        {
            correct = true;
        	this.Enabled = false;
        	tableLayoutPanel1.SuspendLayout();
            int n = 0;
            if (int.TryParse(nTb.Text.Trim(), out n))
            {

                this.n = n;
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel1.ColumnCount = n;
                tableLayoutPanel1.RowCount = n + 1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        TextBox tb = new TextBox();
                        tb.Text = "0";
                        tb.Width = 40;
                        tb.Name = "item" + i + j + "Tb";
                        tb.Dock = DockStyle.Fill;
                        tableLayoutPanel1.Controls.Add(tb);
                        tb.Enter += new EventHandler(tb_Enter);
                    }
                }
            }
            else { correct = false; ShowError("Ошибка", nTb); }

            //tableLayoutPanel1.Controls.Add(new Button());
            tableLayoutPanel1.ResumeLayout();
            groupBox1.Show();
            calcDet.Show();
            this.Enabled = true;
            //splitContainer2.AutoSize = true;
        }
        
        void NTbEnter(object sender, EventArgs e)
        {
        	this.Text = "";
        }

        private void nTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar) || (e.KeyChar == '0' && nTb.Text.Length == 0) || nTb.Text.Length > 1) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}