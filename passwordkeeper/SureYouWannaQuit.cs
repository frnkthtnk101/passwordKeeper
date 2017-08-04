using System;
using System.Windows.Forms;

namespace passwordkeeper
{
    public partial class SureYouWannaQuit : Form
    {
        public SureYouWannaQuit()
        {
            InitializeComponent();
        }

        private void yes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
