/*
 * Created by SharpDevelop.
 * User: anton
 * Date: 09.10.2010
 * Time: 16:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GMatrix
{
	/// <summary>
	/// Description of MatrixView.
	/// </summary>
	public partial class MatrixView : UserControl
	{
		public MatrixView()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public MatrixView(Matrix m, string t)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			groupBox1.Text = t;
			
			tlpItems.SuspendLayout();
			
            int n = m.n;
            tlpItems.Controls.Clear();
            tlpItems.ColumnCount = n;
            tlpItems.RowCount = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    TextBox tb = new TextBox();
                    tb.Text = "0";
                    tb.Width = 40;
                    tb.Name = "item"+i+j+"Tb";
                    tlpItems.Controls.Add(tb);
                }
            }
			tlpItems.ResumeLayout();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	}
}
