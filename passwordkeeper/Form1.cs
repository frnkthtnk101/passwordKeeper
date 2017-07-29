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
            richTextBox1.Text = decryptor.Decrypt_data(path);
            this.Text = Path.GetFileName(path);
        }

        private string getpath()
        {
            throw new NotImplementedException();
        }
    }
}
