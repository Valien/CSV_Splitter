using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace CSVSplitter
{
    public partial class CSVSplitterForm : Form
    {

        public CSVSplitterForm()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        public delegate void UpdateProgressSub(int CurrentLine);
        OpenFileDialog OFD = new OpenFileDialog();
        string OutputFolder;

        // Count lines in CSV
        static int CountCSVLines(string f)
        {
            int count = 0;
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }
                return count;
            }
        }
        // Browse file button
        string countResult;

        private void browse_Button_Click(object sender, EventArgs e)
        {
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                csv_TextBox.Text = OFD.FileName.ToString();
                // counting how many lines are in the CSV file initially 
                countResult = CountCSVLines(OFD.FileName.ToString()).ToString("N0");
                lblStatus.Text = "There are " + countResult + " lines in this CSV file.";
            }
        }

        // Start button
        private void splitNow_Button_Click(object sender, EventArgs e)
        {
            // Making sure someone actually inputs a file to be split.
            if (csv_TextBox.Text.Length == 0)
            {
                MessageBox.Show("Please input a .CSV file before splitting.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                backgroundWorker1.CancelAsync();
                splitNow_Button.Enabled = true;
            }
            else
            {
                if (backgroundWorker1.IsBusy != true)
                {
                    backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
                    backgroundWorker1.RunWorkerAsync();
                    splitNow_Button.Enabled = false;
                    cancel_Button.Enabled = true;
                }
            }
        }

        // Cancel button
        private void cancel_Button_Click(object sender, EventArgs e)
        {

            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
                splitNow_Button.Enabled = true;
            }
        }

        private void SplitCSV(string FilePath, int LineCount, int MaxOutputFile, Action<int> UpdateProgress)
        //private void SplitCSV(string FilePath, int LineCount, int MaxOutputFile, Action<int> UpdateProgress, bool IsAbort)
        {
            // variables
            int parse;

            //BackgroundWorker worker =  as BackgroundWorker;

            // Validate first
            //if (LineCount < 100) throw new Exception("Number of lines must be more than 100.");

            // Open the CSV file for reading
            StreamReader Reader = new StreamReader(FilePath);

            // Create the output directory
            OutputFolder = FilePath + "_Pieces";
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
                        if (s != null)
                        {
                            Writer.WriteLine(s);
                            //Int32.TryParse(countResult, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out parse);
                            if (Int32.TryParse(countResult, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out parse))
                            {
                                //double p = (double)i / parse;
                                //UpdateProgress((int)p);
                                //backgroundWorker1.ReportProgress((int)p);
                                int progress = parse / 10;
                                for (int pr = progress; pr < parse; pr+=progress)
                                {
                                    UpdateProgress((int)pr);
                                }
                            }
                            //worker.ReportProgress(i * 10);
                        }
                        else
                        {
                            Writer.Flush();
                            //Writer.Close();

                            break;
                        }
                    }

                    // flush and close the split file
                    Writer.Flush();
                    Writer.Close();
                }


                //lblStatus.Text = LineCount + " and " + countResult;
            } while (true);

            Reader.Close();
        }

        //public void SplitIt()
        //{
        //    // Kick it off!
        //    try
        //    {
        //        //SplitCSV(csv_TextBox.Text, nol_NumericUpDown.Value, maxPieces_NumericUpDown.Value, UpdateProgress, _IsAbort);
        //        SplitCSV(csv_TextBox.Text, (int)nol_NumericUpDown.Value, (int)maxPieces_NumericUpDown.Value);
        //    } // end try
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Unable to split the CSV file. Reason: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //public void UpdateProgress(int CurrentLine)
        //{
        //    lblStatus.Text = "Approximately " + CurrentLine.ToString() + " lines have been split.";
        //}

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //for (int i = 0; i <= 100; i++)
            //{
            //    Thread.Sleep(100);
            //    backgroundWorker1.ReportProgress(i);
            //}
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < maxPieces_NumericUpDown.Value; i++)//CountCSVLines(OFD.FileName.ToString())
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    //SplitIt();
                    try
                    {
                        SplitCSV(csv_TextBox.Text, (int)nol_NumericUpDown.Value, (int)maxPieces_NumericUpDown.Value, backgroundWorker1.ReportProgress);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to split the CSV file. Reason: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //throw;
                        //lblStatus.Text = "Unable to split the CSV file. Reason: " + ex.Message + MessageBoxIcon.Warning;
                    }
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            // few ideas to show the progress -- count total # of lines and return progress based on each block of lines completed
            // count current progress of lines and show progress that way.
            // take - linecount / total lines (50K/135K) * 100 = 37%) -- return that result?

            //lblStatus.Text = (e.ProgressPercentage.ToString() + "%");
            //lblStatus.Text = "Hello World!";
            //if (e.UserState != null)
            //{
            //    SplitFileMessage msg = (SplitFileMessage)e.UserState;

            //    if (msg.MessageType == SplitFileMessage.MSG_TYPE_ERR)
            //    {
            //        throw new Exception(msg.Message);
            //    }
            //    else
            //    {
            //        this.lblStatus.Text += msg.Message + Environment.NewLine;
            //    }
            //}
            progressBar1.Value = e.ProgressPercentage;
            //this.Text = e.ProgressPercentage.ToString();
            //progressBar1.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                lblStatus.Text = "Split Canceled.";
                cancel_Button.Enabled = false;
            }
            else if (e.Error != null)
            {
                lblStatus.Text = "Error: " + e.Error.Message;
            }
            else
            {
                lblStatus.Text = "Split complete! Your files are located here: " + OutputFolder;
                splitNow_Button.Enabled = true;
            }

        }
    }

    //
    public class SplitFileMessage
    {
        public const int MSG_TYPE_INFO = 1;
        public const int MSG_TYPE_ERR = 2;

        private int _MessageType;

        public int MessageType
        {
            get { return _MessageType; }
            set { _MessageType = value; }
        }

        private string _Message;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        public SplitFileMessage(int MessageType, string Message)
        {
            this.MessageType = MessageType;
            this.Message = Message;
        }
    }
}
