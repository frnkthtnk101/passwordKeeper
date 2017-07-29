using System.Windows.Forms;

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
    }
}
