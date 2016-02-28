using System.Collections.Generic;

using Hik.JTable.Models;

namespace Hik.JTable.Repositories
{
    public interface IExamRepository
    {
        List<StudentExam> GetExamsOfStudent(int studentId);
        StudentExam AddExam(StudentExam exam);
        void UpdateExam(StudentExam exam);
        void DeleteExam(int studentExamId);
    }
}
