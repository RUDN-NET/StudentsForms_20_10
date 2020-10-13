using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Models
{
    class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString() => $"[{Id}] {Name} (студентов: {Students.Count})";
    }
}
