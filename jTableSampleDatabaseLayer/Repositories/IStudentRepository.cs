using System.Collections.Generic;

using Hik.JTable.Models;

namespace Hik.JTable.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        List<Student> GetStudents(int startIndex, int count, string sorting);
        List<Student> GetStudentsByFilter(string name, int cityId, int startIndex, int count, string sorting);
        Student AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
        int GetStudentCount();
        int GetStudentCountByFilter(string name, int cityId);
    }
}
