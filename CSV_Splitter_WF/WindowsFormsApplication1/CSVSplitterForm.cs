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

namespace CSVSplitter
{
    public partial class CSVSplitterForm : Form
    {
        public CSVSplitterForm()
        {
            InitializeComponent();
        }

        private Boolean _IsAbort;
        OpenFileDialog OFD = new OpenFileDialog();

        private void browse_Button_Click(object sender, EventArgs e)
        {
            
            if (OFD.ShowDialog() == DialogResult.OK) {
                csv_TextBox.Text = OFD.FileName.ToString();
            }
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitNow_Button_Click(object sender, EventArgs e)
        {
           
        }

        
    }
}
