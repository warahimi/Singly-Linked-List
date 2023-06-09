using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Student
    {
        private int id; // 4 bytes
        private string name; // 12 bytes 
        private int age; // 4
        double GPA; // 8
        char letterGrade; // 2

        public Student()
        {
        }

        public Student(int id, string name, int age)
        {
            this.Id = id;
            this.name = name;
            this.age = age;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }
}
