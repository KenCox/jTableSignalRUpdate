using System.Collections.Generic;

using Hik.JTable.Models;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryDataSource
    {
        public List<City> Cities { get; private set; }
        public List<Student> Students { get; private set; }
        public List<Phone> Phones { get; private set; }
        public List<StudentExam> StudentExams { get; private set; }
        public List<Person> People { get; private set; }

        public MemoryDataSource()
        {
            Cities = new List<City>();
            Students = new List<Student>();
            Phones = new List<Phone>();
            StudentExams = new List<StudentExam>();
            People = new List<Person>();
        }
    }
}
