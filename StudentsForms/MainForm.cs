using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using StudentsForms.Models;

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

            var students = LoadStudentsFromFile(file_name);

            StudentsList.Items.Clear();
            //foreach (var student in students)
            //    StudentsList.Items.Add(student);
            StudentsList.Items.AddRange(students);

        }

        private static Student[] LoadStudentsFromFile(string FileName)
        {
            var students = new List<Student>();

            using (var reader = new StreamReader(FileName))
            {
                if (!reader.EndOfStream)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var components = line.Split(';');

                    var student = new Student
                    {
                        Id = int.Parse(components[0]),
                        Surname = components[1],
                        FirstName = components[2],
                        Patronymic = components[3],
                    };

                    students.Add(student);
                }
            }

            return students.ToArray();
        }

        private void StudentsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var student_index = StudentsList.SelectedIndex;
            var list = (ListBox)sender;
            //var list2 = sender as ListBox;

            var student_index = list.SelectedIndex;

            if (student_index < 0)
            {
                StudentInfoLabel.Text = "";
                return;
            }

            var selected_student = (Student)list.Items[student_index];

            StudentInfoLabel.Text = $"{selected_student.Surname} {selected_student.FirstName} {selected_student.Patronymic}";
        }

        private void RemoveStudentButton_Click(object sender, EventArgs e)
        {
            var student_index = StudentsList.SelectedIndex;
            if (student_index < 0) return;
            StudentsList.Items.RemoveAt(student_index);
            StudentsList.SelectedIndex = student_index - 1;
        }

        private void CreateStudentButton_Click(object sender, EventArgs e)
        {
            var student_editor = new StudentEditorForm
            {
                Id = 0,
                Surname = $"Фамилия 0",
                FirstName = $"Имя 0",
                Patronymic = $"Отчество 0",
            };

            if(student_editor.ShowDialog() != DialogResult.OK) return;

            var student = new Student
            {
                Id = student_editor.Id,
                Surname = student_editor.Surname,
                FirstName = student_editor.FirstName,
                Patronymic = student_editor.Patronymic
            };

            StudentsList.Items.Add(student);
            StudentsList.SelectedIndex = StudentsList.Items.Count - 1;
        }

        private void StudentsList_DoubleClick(object sender, EventArgs e)
        {
            var student_index = StudentsList.SelectedIndex;
            if (student_index < 0) return;
            var selected_student = (Student)StudentsList.Items[student_index];

            var student_editor = new StudentEditorForm
            {
                Id = selected_student.Id,
                Surname = selected_student.Surname,
                FirstName = selected_student.FirstName,
                Patronymic = selected_student.Patronymic,
            };

            if (student_editor.ShowDialog() != DialogResult.OK) return;

            selected_student.Id = student_editor.Id;
            selected_student.Surname = student_editor.Surname;
            selected_student.FirstName = student_editor.FirstName;
            selected_student.Patronymic = student_editor.Patronymic;
        }
    }
}
