using System;
using System.Windows.Forms;

namespace StudentsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void HelloButton_Click(object sender, EventArgs e)
        {
            HelloButton.Text = "123";

            MessageBox.Show("Hello World!", "Привет!", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void HelloButton_OnMouseMove(object sender, MouseEventArgs e)
        {
            HelloButton.Text = string.Format("{0}:{1}", e.Location.X, e.Location.Y);
        }

        private void TimerControlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InformationTimer.Enabled = TimerControlCheckBox.Checked;
        }

        private void InformationTimer_Tick(object sender, EventArgs e)
        {
            InformationLabel.Text = DateTime.Now.ToString("HH:mm:ss.ffff");
        }
    }
}
