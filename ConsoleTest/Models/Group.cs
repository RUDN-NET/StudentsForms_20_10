using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleTest.Models
{
    public class Group
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString() => $"[{Id}] {Name} (студентов: {Students.Count})";
    }
}
