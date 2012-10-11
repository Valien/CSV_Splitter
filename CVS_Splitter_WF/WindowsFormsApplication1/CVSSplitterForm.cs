using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class CVSSplitterForm : Form
    {
        public CVSSplitterForm()
        {
            InitializeComponent();
        }

        OpenFileDialog OFD = new OpenFileDialog();

        private void browse_Button_Click(object sender, EventArgs e)
        {
            
            if (OFD.ShowDialog() == DialogResult.OK) {
                csv_TextBox.Text = "Success!"; //OFD.FileName();
            }
        }
    }
}
