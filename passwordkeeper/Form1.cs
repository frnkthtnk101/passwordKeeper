using System.Windows.Forms;
using System.IO;
using System;
using System.Drawing.Printing;

namespace passwordkeeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
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
    }
}
