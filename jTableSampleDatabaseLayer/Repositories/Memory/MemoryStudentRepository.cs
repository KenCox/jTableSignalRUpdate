using System;
using System.Collections.Generic;
using System.Linq;

using Hik.JTable.Models;



namespace Hik.JTable.Repositories.Memory
{
    public class MemoryStudentRepository : IStudentRepository
    {
        private readonly MemoryDataSource _dataSource;

        public MemoryStudentRepository(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<Student> GetAllStudents()
        {
            return _dataSource.Students.OrderBy(s => s.Name).ToList();
        }

        public List<Student> GetStudents(int startIndex, int count, string sorting)
        {
            IEnumerable<Student> query = _dataSource.Students;

            //Sorting
            //This ugly code is used just for demonstration.
            //Normally, Incoming sorting text can be directly appended to an SQL query.
            if (string.IsNullOrEmpty(sorting) || sorting.Equals("Name ASC"))
            {
                query = query.OrderBy(p => p.Name);
            }
            else if (sorting.Equals("Name DESC"))
            {
                query = query.OrderByDescending(p => p.Name);
            }
            else if (sorting.Equals("Gender ASC"))
            {
                query = query.OrderBy(p => p.Gender);
            }
            else if (sorting.Equals("Gender DESC"))
            {
                query = query.OrderByDescending(p => p.Gender);
            }
            else if (sorting.Equals("CityId ASC"))
            {
                query = query.OrderBy(p => p.CityId);
            }
            else if (sorting.Equals("CityId DESC"))
            {
                query = query.OrderByDescending(p => p.CityId);
            }
            else if (sorting.Equals("BirthDate ASC"))
            {
                query = query.OrderBy(p => p.BirthDate);
            }
            else if (sorting.Equals("BirthDate DESC"))
            {
                query = query.OrderByDescending(p => p.BirthDate);
            }
            else if (sorting.Equals("IsActive ASC"))
            {
                query = query.OrderBy(p => p.IsActive);
            }
            else if (sorting.Equals("IsActive DESC"))
            {
                query = query.OrderByDescending(p => p.IsActive);
            }
            else
            {
                query = query.OrderBy(p => p.Name); //Default!
            }

            return count > 0
                       ? query.Skip(startIndex).Take(count).ToList() //Paging
                       : query.ToList(); //No paging
        }

        public List<Student> GetStudentsByFilter(string name, int cityId, int startIndex, int count, string sorting)
        {
            IEnumerable<Student> query = _dataSource.Students;

            //Filters
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (cityId > 0)
            {
                query = query.Where(p => p.CityId == cityId);
            }

            //Sorting
            //This ugly code is used just for demonstration.
            //Normally, Incoming sorting text can be directly appended to an SQL query.
            if (string.IsNullOrEmpty(sorting) || sorting.Equals("Name ASC"))
            {
                query = query.OrderBy(p => p.Name);
            }
            else if (sorting.Equals("Name DESC"))
            {
                query = query.OrderByDescending(p => p.Name);
            }
            else if (sorting.Equals("Gender ASC"))
            {
                query = query.OrderBy(p => p.Gender);
            }
            else if (sorting.Equals("Gender DESC"))
            {
                query = query.OrderByDescending(p => p.Gender);
            }
            else if (sorting.Equals("CityId ASC"))
            {
                query = query.OrderBy(p => p.CityId);
            }
            else if (sorting.Equals("CityId DESC"))
            {
                query = query.OrderByDescending(p => p.CityId);
            }
            else if (sorting.Equals("BirthDate ASC"))
            {
                query = query.OrderBy(p => p.BirthDate);
            }
            else if (sorting.Equals("BirthDate DESC"))
            {
                query = query.OrderByDescending(p => p.BirthDate);
            }
            else if (sorting.Equals("IsActive ASC"))
            {
                query = query.OrderBy(p => p.IsActive);
            }
            else if (sorting.Equals("IsActive DESC"))
            {
                query = query.OrderByDescending(p => p.IsActive);
            }
            else
            {
                query = query.OrderBy(p => p.Name); //Default!
            }

            return count > 0
                       ? query.Skip(startIndex).Take(count).ToList() //Paging
                       : query.ToList(); //No paging
        }

        public Student AddStudent(Student student)
        {
            student.StudentId = _dataSource.Students.Count > 0
                                    ? (_dataSource.Students[_dataSource.Students.Count - 1].StudentId + 1)
                                    : 1;
            _dataSource.Students.Add(student);
            return student;
        }

        public void UpdateStudent(Student student)
        {
            var foundStudent = _dataSource.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (foundStudent == null)
            {
                return;
            }

            foundStudent.Name = student.Name;
            foundStudent.EmailAddress = student.EmailAddress;
            foundStudent.Password = student.Password;
            foundStudent.Gender = student.Gender;
            foundStudent.BirthDate = student.BirthDate;
            foundStudent.CityId = student.CityId;
            foundStudent.About = student.About;
            foundStudent.Education = student.Education;
            foundStudent.IsActive = student.IsActive;
        }

        public void DeleteStudent(int studentId)
        {
            _dataSource.Students.RemoveAll(s => s.StudentId == studentId);
        }

        public int GetStudentCount()
        {
            return _dataSource.Students.Count;
        }


        public int GetStudentCountByFilter(string name, int cityId)
        {
            IEnumerable<Student> query = _dataSource.Students;

            //Filters
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (cityId > 0)
            {
                query = query.Where(p => p.CityId == cityId);
            }

            return query.Count();
        }
    }
}
