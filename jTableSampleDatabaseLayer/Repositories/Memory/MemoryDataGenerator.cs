using System;
using System.Collections.Generic;
using System.Text;

using Hik.JTable.Models;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryDataGenerator
    {
        private readonly Random _rnd = new Random();

        public MemoryDataSource Generate(int studentCount)
        {
            var dataSource = new MemoryDataSource();

            //BASE DATA
            var personNames = GeneratePersonNames();
            var courseNames = GenerateCourseNames();
            var examDegrees = GenerateExamDegrees();

            //CITIES
            dataSource.Cities.AddRange(
                new[]
                {
                    new City {CityId = 1, CityName = "Adana"},
                    new City {CityId = 2, CityName = "Ankara"},
                    new City {CityId = 3, CityName = "Athens"},
                    new City {CityId = 4, CityName = "Beijing"},
                    new City {CityId = 5, CityName = "Berlin"},
                    new City {CityId = 6, CityName = "Bursa"},
                    new City {CityId = 7, CityName = "İstanbul"},
                    new City {CityId = 8, CityName = "London"},
                    new City {CityId = 9, CityName = "Madrid"},
                    new City {CityId = 10, CityName = "Mekke"},
                    new City {CityId = 11, CityName = "New York"},
                    new City {CityId = 12, CityName = "Paris"},
                    new City {CityId = 13, CityName = "Samsun"},
                    new City {CityId = 14, CityName = "Trabzon"},
                    new City {CityId = 15, CityName = "Volos"}
                });
            
            //STUDENTS
            for (int i = 0; i < studentCount; i++)
            {
                var nameIndex = _rnd.Next(personNames.Length);
                var surnameIndex = _rnd.Next(personNames.Length);
                var student = new Student
                {
                    Name = personNames[nameIndex].Name + " " + personNames[surnameIndex].Surname,
                    EmailAddress =
                        personNames[nameIndex].Name.ToLower() + "." +
                        personNames[surnameIndex].Surname.ToLower() + "@jtable.org",
                    Gender = personNames[nameIndex].Gender,
                    CityId = dataSource.Cities[_rnd.Next(dataSource.Cities.Count)].CityId,
                    BirthDate = new DateTime(_rnd.Next(1940, 2005), _rnd.Next(1, 13), _rnd.Next(1, 29)),
                    StudentId = (i + 1),
                    IsActive = (_rnd.Next(100) > 20),
                    Education = _rnd.Next(1, 4)
                };
                dataSource.Students.Add(student);
                
                //PHONES
                AddPhonesToStudent(dataSource, student);

                //EXAMS
                AddExamsToStudent(dataSource, student, courseNames, examDegrees);
            }

            //PEOPLE
            dataSource.People.AddRange(
                new List<Person>
                {
                    new Person {PersonId = 1, Name = "George Orwell", Age = 27},
                    new Person {PersonId = 2, Name = "Douglas Adams", Age = 42},
                    new Person {PersonId = 3, Name = "Isaac Asimov", Age = 26},
                    new Person {PersonId = 3, Name = "Dan Brown", Age = 39},
                    new Person {PersonId = 4, Name = "Thomas More", Age = 65}
                });

            return dataSource;
        }

        private void AddPhonesToStudent(MemoryDataSource dataSource, Student student)
        {
            var phoneCount = _rnd.Next(2, 7);
            for (var j = 0; j < phoneCount; j++)
            {
                var phoneId = dataSource.Phones.Count > 0
                                  ? dataSource.Phones[dataSource.Phones.Count - 1].PhoneId + 1
                                  : 1;

                dataSource.Phones.Add(new Phone
                {
                    PhoneId = phoneId,
                    StudentId = student.StudentId,
                    Number = GenerateRandomPhoneNumber(),
                    PhoneType = _rnd.Next(1, 4)
                });
            }
        }

        private void AddExamsToStudent(MemoryDataSource dataSource, Student student, string[] courseNames, string[] examDegrees)
        {
            var examCount = _rnd.Next(4, 10);
            for (var j = 0; j < examCount; j++)
            {
                var studentExamId = dataSource.StudentExams.Count > 0
                  ? dataSource.StudentExams[dataSource.StudentExams.Count - 1].StudentExamId + 1
                  : 1;

                dataSource.StudentExams.Add(
                    new StudentExam
                    {
                        StudentExamId = studentExamId,
                        StudentId = student.StudentId,
                        CourseName = courseNames[_rnd.Next(courseNames.Length)],
                        Degree = examDegrees[_rnd.Next(examDegrees.Length)],
                        ExamDate = new DateTime(_rnd.Next(2008, 2012), _rnd.Next(1, 13), _rnd.Next(1, 29))
                    });
            }
        }

        private static PersonNameSurname[] GeneratePersonNames()
        {
            return new[]
                             {
                                 new PersonNameSurname {Name = "Halil", Surname = "Kalkan", Gender = "M"},
                                 new PersonNameSurname {Name = "Karen", Surname = "Asimov", Gender = "F"},
                                 new PersonNameSurname {Name = "Neo", Surname = "Gates", Gender = "M"},
                                 new PersonNameSurname {Name = "Trinity", Surname = "Lafore", Gender = "F"},
                                 new PersonNameSurname {Name = "Morpheus", Surname = "Maalouf", Gender = "M"},
                                 new PersonNameSurname {Name = "Suzanne", Surname = "Hayyam", Gender = "F"},
                                 new PersonNameSurname {Name = "Georghe", Surname = "Richards", Gender = "M"},
                                 new PersonNameSurname {Name = "Steeve", Surname = "Orwell", Gender = "M"},
                                 new PersonNameSurname {Name = "Agatha", Surname = "Jobs", Gender = "F"},
                                 new PersonNameSurname {Name = "Stephan", Surname = "Christie", Gender = "M"},
                                 new PersonNameSurname {Name = "Andrew", Surname = "Hawking", Gender = "M"},
                                 new PersonNameSurname {Name = "Nicole", Surname = "Brown", Gender = "F"},
                                 new PersonNameSurname {Name = "Thomas", Surname = "Garder", Gender = "M"},
                                 new PersonNameSurname {Name = "Oktay", Surname = "More", Gender = "M"},
                                 new PersonNameSurname {Name = "Paulho", Surname = "Anar", Gender = "M"},
                                 new PersonNameSurname {Name = "Carl", Surname = "Sagan", Gender = "M"},
                                 new PersonNameSurname {Name = "Daniel", Surname = "Radcliffe", Gender = "F"},
                                 new PersonNameSurname {Name = "Rupert", Surname = "Grint", Gender = "M"},
                                 new PersonNameSurname {Name = "David", Surname = "Yates", Gender = "M"},
                                 new PersonNameSurname {Name = "Hercules", Surname = "Poirot", Gender = "M"},
                                 new PersonNameSurname {Name = "Christopher", Surname = "Paolini", Gender = "M"},
                                 new PersonNameSurname {Name = "Walter", Surname = "Isaacson", Gender = "M"},
                                 new PersonNameSurname {Name = "Arda", Surname = "Turan", Gender = "M"},
                                 new PersonNameSurname {Name = "Jeniffer", Surname = "Anderson", Gender = "F"},
                                 new PersonNameSurname {Name = "Stephenie", Surname = "Mayer", Gender = "F"},
                                 new PersonNameSurname {Name = "Dan", Surname = "Brown", Gender = "M"},
                                 new PersonNameSurname {Name = "Clara", Surname = "Clayton", Gender = "F"},
                                 new PersonNameSurname {Name = "Emmett", Surname = "Brown", Gender = "M"},
                                 new PersonNameSurname {Name = "Marty", Surname = "Mcfly", Gender = "M"},
                                 new PersonNameSurname {Name = "Jane", Surname = "Fuller", Gender = "F"},
                                 new PersonNameSurname {Name = "Douglas", Surname = "Hall", Gender = "M"},
                                 new PersonNameSurname {Name = "Tom", Surname = "Jones", Gender = "M"},
                                 new PersonNameSurname {Name = "Lora", Surname = "Adams", Gender = "F"},
                                 new PersonNameSurname {Name = "Andy", Surname = "Garcia", Gender = "M"},
                                 new PersonNameSurname {Name = "Amin", Surname = "Collins", Gender = "M"},
                                 new PersonNameSurname {Name = "Elmander", Surname = "Sokrates", Gender = "M"},
                                 new PersonNameSurname {Name = "Austin", Surname = "Cleeve", Gender = "F"},
                                 new PersonNameSurname {Name = "Audrey", Surname = "Cole", Gender = "F"},
                                 new PersonNameSurname {Name = "Bella", Surname = "Clark", Gender = "F"},
                                 new PersonNameSurname {Name = "Burley", Surname = "Pugy", Gender = "M"},
                                 new PersonNameSurname {Name = "Charles", Surname = "Quiney", Gender = "M"}
                             };
        }

        private static string[] GenerateCourseNames()
        {
            return new[]
                   {
                       "Mathematics",
                       "Physics",
                       "Chemistry",
                       "Introduction to Programming I",
                       "Introduction to Programming II",
                       "Microcomputers",
                       "Probability",
                       "Fuzzy logic",
                       "Neural network",
                       "Experts systems",
                       "History",
                       "Data structures",
                       "Differential Equations",
                       "Lineer Algebra",
                       "Object oriented programming",
                       "Computer graphics",
                       "Artificial Intelligence",
                       "Foreign Language",
                       "Operating Systems",
                       "Database",
                       "Data communication",
                       "Finite-state machines",
                       "Compiler design",
                       "Computer vision",
                       "Computer networks I",
                       "Computer networks II",
                       "Wireless communication",
                       "Digital signal processing",
                       "Optimization",
                       "Robotics",
                       "Data mining"
                   };
        }

        private static string[] GenerateExamDegrees()
        {
            return new[]
                   {
                       "AA",
                       "BA",
                       "BB",
                       "CB",
                       "CC",
                       "DC",
                       "DD",
                       "FF"
                   };
        }

        private string GenerateRandomPhoneNumber()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append(_rnd.Next(0, 10).ToString());
            }

            return sb.ToString();
        }

        private class PersonNameSurname
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
        }
    }
}
