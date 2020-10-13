using System;
using System.Windows.Forms;

namespace StudentsForms
{
    public partial class StudentEditorForm : Form
    {
        public int Id
        {
            get
            {
                return int.Parse(IdLabel.Text);
            }
            set
            {
                IdLabel.Text = value.ToString();
            }
        }

        public string Surname
        {
            get
            {
                return SurnameEdit.Text;
            }
            set
            {
                SurnameEdit.Text = value;
            }
        }

        public string FirstName
        {
            get
            {
                return FirstNameEdit.Text;
            }
            set
            {
                FirstNameEdit.Text = value;
            }
        }

        public string Patronymic
        {
            get
            {
                return PatronymicEdit.Text;
            }
            set
            {
                PatronymicEdit.Text = value;
            }
        }

        public StudentEditorForm()
        {
            InitializeComponent();
        }

        private void DialogButton_OnClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
