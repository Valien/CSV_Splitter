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

        public delegate void UpdateProgressSub(int CurrentLine);
        private Boolean _IsAbort;
        OpenFileDialog OFD = new OpenFileDialog();

        private void SplitCSV(string FilePath, int LineCount, int MaxOutputFile, Action<int> UpdateProgress, bool IsAbort)
        {
            // Validate first
            if (LineCount < 100) throw new Exception("Number of lines must be more than 100.");

            // Open the CSV file for reading
            StreamReader Reader = new StreamReader(FilePath);

            // Create the output directory
            string OutputFolder = FilePath + "_Pieces";
            if (Directory.Exists(FilePath) == false)
            {
                Directory.CreateDirectory(OutputFolder);
            }

            // Read the CSV column's header
            string strHeader = Reader.ReadLine();

            // Start splitting!
            int FileIndex = 0;

            do
            {
                // Update progress
                FileIndex += 1;
                if ((UpdateProgress != null))
                {
                    UpdateProgress.Invoke((FileIndex - 1) * LineCount);
                }

                // Check if the number of split files do not exceed the limit
                if ((MaxOutputFile < FileIndex) & (MaxOutputFile > 0))
                {
                    break;
                }

                // Create new file to store a piece of the CSV file
                string PiecePath = OutputFolder + "\\" + Path.GetFileNameWithoutExtension(FilePath) + "_" + FileIndex + Path.GetExtension(FilePath);
                using (StreamWriter Writer = new StreamWriter(PiecePath, false))
                {
                    Writer.AutoFlush = false;
                    Writer.WriteLine(strHeader);


                    // Read and write precise number of rows
                    for (int i = 0; i < LineCount; i++)
                    {
                        string s = Reader.ReadLine();
                        if ((s != null) & (_IsAbort = false))
                        {
                            Writer.WriteLine(s);
                        }
                        else
                        {
                            //Writer.Flush();
                            //Writer.Close();
                            break;
                        }
                    }

                    // flush and close the split file
                    //Writer.Flush();
                    //Writer.Close();
                }

            } while (true);

            Reader.Close();
        }

        private void browse_Button_Click(object sender, EventArgs e)
        {

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                csv_TextBox.Text = OFD.FileName.ToString();
            }
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            _IsAbort = true;
            this.Close();
        }

        private void splitNow_Button_Click(object sender, EventArgs e)
        {
            System.Threading.Thread th = new System.Threading.Thread(SplitIt);
            th.Start();
        }

        public void SplitIt()
        {

            //splitNow_Button.Enabled = false;
            //cancel_Button.Enabled = true;

            // Kick it off!
            try
            {
                //Split SplitCSV = new Split();

                //SplitCSV(csv_TextBox.Text, nol_NumericUpDown.Value, maxPieces_NumericUpDown.Value, UpdateProgress, _IsAbort);

                SplitCSV(csv_TextBox.Text, (int)nol_NumericUpDown.Value, (int)maxPieces_NumericUpDown.Value, UpdateProgress, _IsAbort);


                if (!_IsAbort)
                {
                    MessageBox.Show("Completed Successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _IsAbort = false;
                    MessageBox.Show("Split process aborted by user.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            } // end try
            catch (Exception e)
            {
                MessageBox.Show("Unable to split the CSV file. Reason: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            finally
            {
                //splitNow_Button.Enabled = true;
               // cancel_Button.Enabled = false;
            }


        }

        public void UpdateProgress(int CurrentLine)
        {
            lblStatus.Text = "Approximately " + CurrentLine.ToString() + " lines have been split.";
        }

    }
}
