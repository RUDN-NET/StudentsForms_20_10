using System;
using System.IO;
using System.Windows.Forms;

namespace StudentsForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            //var open_dialog = new OpenFileDialog
            //{
            //    Title = "Выбор файла данных",
            //    Filter = "csv-файлы (*.csv)|*.csv|Все файлы (*.*)|*.*"
            //};

            //if(open_dialog.ShowDialog() != DialogResult.OK) return;

            //MessageBox.Show(open_dialog.FileName);

            if (OpenStudentsDataFileDialog.ShowDialog() != DialogResult.OK) return;

            var file_name = OpenStudentsDataFileDialog.FileName;

            LoadStudentsFromFile(file_name);
        }

        private static void LoadStudentsFromFile(string FileName)
        {
            using (var reader = new StreamReader(FileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var components = line.Split(';');
                }
            }
        }
    }
}
