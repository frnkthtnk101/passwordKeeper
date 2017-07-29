using System.Windows.Forms;
using System.IO;
using System;

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
            Encryption decryptor = new Encryption();
            setstage(decryptor.Decrypt_data(path), Path.GetFileName(path));
            decryptor.Dispose();

        }
        private void regularFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = getpath();
            setstage(File.ReadAllText(path), Path.GetFileName(path));
        }

        private void setstage(string content, string filename)
        {
            richTextBox1.Text = content;
            this.Text = filename;
        }

        private string getpath()
        {
            throw new NotImplementedException();
        }


    }
}
