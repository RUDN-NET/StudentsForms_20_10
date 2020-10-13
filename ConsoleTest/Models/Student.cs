using System.Xml.Serialization;

namespace ConsoleTest.Models
{
    public class Student
    {
        [XmlAttribute]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }

        public override string ToString() => $"[{Id}] {Surname} {FirstName} {Patronymic}";
    }
}
