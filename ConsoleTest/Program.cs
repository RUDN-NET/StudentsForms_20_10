using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using ConsoleTest.Models;

namespace ConsoleTest
{
    class Program
    {
        private const string __DataFileName = @"Data\students.csv";

        static void Main(string[] args)
        {
            var students = LoadStudentsFromFile(__DataFileName);

            var group = new Group
            {
                Id = 1,
                Name = "T-34-tr-2"
            };

            group.Students.AddRange(students);

            const string xml_file = "StudentGroups.xml";

            var groups = LoadStudentsFromXml(xml_file);

            const string new_xml_file = "StudentGroups_new.xml";
            SaveStudentsToXml(new_xml_file, groups);

            var groups2 = LoadStudentsFromXml2(xml_file);

            //Console.ReadLine();
        }

        private static Group[] LoadStudentsFromXml2(string FileName)
        {
            var groups = new List<Group>();

            var xml = XDocument.Load(FileName);

            var decanat = xml.Root;

            foreach (var group_xml in decanat.Descendants("Group"))
            {
                var group = new Group
                {
                    Id = (int)group_xml.Attribute("Id"), 
                    Name = (string)group_xml.Attribute("Name")
                };
                groups.Add(group);

                foreach (var student_xml in group_xml.Descendants("Student"))
                    group.Students.Add(
                        new Student
                        {
                            Id = (int) student_xml.Attribute("Id"),
                            Surname = (string) student_xml.Element("Surname"),
                            FirstName = (string) student_xml.Element("FirstName"),
                            Patronymic = (string) student_xml.Element("Patronymic"),
                        });
            }

            return groups.ToArray();
        }

        private static void SaveStudentsToXml(string FileName, Group[] Groups)
        {
            var xml_doc = new XmlDocument();

            var decanat_node = xml_doc.CreateElement("Decanat");
            xml_doc.AppendChild(decanat_node);

            foreach (var group in Groups)
            {
                var group_node = xml_doc.CreateElement("Group");
                var group_id = xml_doc.CreateAttribute("Id");
                group_id.Value = group.Id.ToString();
                group_node.Attributes.Append(group_id);
                var group_name = xml_doc.CreateAttribute("Name");
                group_name.Value = group.Name;
                group_node.Attributes.Append(group_name);

                decanat_node.AppendChild(group_node);

                foreach (var student in group.Students)
                {
                    var student_node = xml_doc.CreateElement("Student");

                    var student_id = xml_doc.CreateAttribute("Id");
                    student_id.Value = student.Id.ToString();
                    student_node.Attributes.Append(student_id);

                    var student_surname = xml_doc.CreateElement("Surname");
                    student_surname.InnerText = student.Surname;
                    student_node.AppendChild(student_surname);

                    var student_firstname = xml_doc.CreateElement("FirstName");
                    student_firstname.InnerText = student.FirstName;
                    student_node.AppendChild(student_firstname);

                    var student_patronymic = xml_doc.CreateElement("Patronymic");
                    student_patronymic.InnerText = student.Patronymic;
                    student_node.AppendChild(student_patronymic);

                    group_node.AppendChild(student_node);
                }
            }

            xml_doc.Save(FileName);
        }

        private static Group[] LoadStudentsFromXml(string FileName)
        {
            var groups = new List<Group>();

            var xml_doc = new XmlDocument();
            xml_doc.Load(FileName);

            var decanat_node = xml_doc.DocumentElement;

            foreach (XmlElement group_node in decanat_node.ChildNodes)
            {
                var group_id = group_node.Attributes["Id"].Value;
                var group_name = group_node.Attributes["Name"].Value;

                var group = new Group
                {
                    Id = int.Parse(group_id),
                    Name = group_name
                };

                groups.Add(group);

                foreach (XmlElement student_node in group_node.ChildNodes)
                {
                    var student_id = student_node.Attributes["Id"].Value;
                    var student_surname = student_node
                       .GetElementsByTagName("Surname")[0].InnerText;
                    var student_firstname = student_node
                       .GetElementsByTagName("FirstName")[0].InnerText;
                    var student_patronymic = student_node
                       .GetElementsByTagName("Patronymic")[0].InnerText;

                    var student = new Student
                    {
                        Id = int.Parse(student_id),
                        Surname = student_surname,
                        FirstName = student_firstname,
                        Patronymic = student_patronymic,
                    };

                    group.Students.Add(student);
                }
            }

            return groups.ToArray();
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
    }
}
