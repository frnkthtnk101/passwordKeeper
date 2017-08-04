using System.Windows.Forms;
using System.IO;
using System;
using System.Drawing.Printing;
using System.Collections.Generic;

namespace passwordkeeper
{
    public partial class Form1 : Form
    {
        private Stack<string> _textboxhistory;
        public Form1()
        {
            _textboxhistory = new Stack<string>();
            InitializeComponent();
            
        }

        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            richTextBox1.Text = "";
            this.Text = "new file";
        }

        private void encryptedFileToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            string path = getpath();
            if (!string.IsNullOrEmpty(path))
            {
                Encryption decryptor = new Encryption();
                setstage(decryptor.Decrypt_data(path), Path.GetFileName(path));
                decryptor.Dispose();
            }

        }
        private void regularFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = getpath();
            if (!String.IsNullOrEmpty(path))
            {
                setstage(File.ReadAllText(path), Path.GetFileName(path));
            }
        }

        private void setstage(string content, string filename)
        {
            if (!string.IsNullOrEmpty(content))
            {
                richTextBox1.Text = content;
                this.Text = filename;
            }
        }

        private string getpath()
        {
            OpenFileDialog o = new OpenFileDialog();
            if(o.ShowDialog() == DialogResult.OK)
            {
                return o.FileName;
            }
            else
            {
                return default(string);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            if(s.ShowDialog() == DialogResult.OK)
            {
                Encryption encryptor = new Encryption();
                this.Text = Path.GetFileName(s.FileName);
                encryptor.Encrypt_data(richTextBox1.Text, s.FileName);
                encryptor.Dispose();

            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            if (s.ShowDialog() == DialogResult.OK)
            {
                Encryption encryptor = new Encryption();
                this.Text = Path.GetFileName(s.FileName);
                encryptor.Encrypt_data(richTextBox1.Text, s.FileName);
                encryptor.Dispose();

            }
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e , System.Drawing.Printing.PrintPageEventArgs t)
        {
            throw new NotImplementedException();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new System.Drawing.Font("Arial", 40, System.Drawing.FontStyle.Regular), System.Drawing.Brushes.Black, 12, 12);
        }

        private void richTextBox1_textChanged(object sender, EventArgs e)
        {
            _textboxhistory.Push(richTextBox1.Text);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(_textboxhistory.Count == 0)
            {
                richTextBox1.Text = "";
            }
            else
            {
                _textboxhistory.Pop();
                if (_textboxhistory.Count > 0)
                    richTextBox1.Text = _textboxhistory.Pop();
                else
                    richTextBox1.Text = "";
            }
        }

        private void RichTextBox1_ONKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && (e.Control))
            {
                if (_textboxhistory.Count == 0)
                {
                    richTextBox1.Text = "";

                }
                else
                {
                    richTextBox1.Text = _textboxhistory.Pop();
                }
            }
        }
    }
}
