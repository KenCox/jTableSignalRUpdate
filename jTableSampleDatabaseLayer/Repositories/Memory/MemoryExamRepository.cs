using System.Collections.Generic;
using System.Linq;

using Hik.JTable.Models;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryExamRepository : IExamRepository
    {
        private readonly MemoryDataSource _dataSource;

        public MemoryExamRepository(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        
        public List<StudentExam> GetExamsOfStudent(int studentId)
        {
            return _dataSource.StudentExams.Where(e => e.StudentId == studentId).ToList();
        }

        public StudentExam AddExam(StudentExam exam)
        {
            exam.StudentExamId = _dataSource.StudentExams.Count > 0 ? (_dataSource.StudentExams[_dataSource.StudentExams.Count - 1].StudentExamId + 1) : 1;
            _dataSource.StudentExams.Add(exam);
            return exam;
        }

        public void UpdateExam(StudentExam exam)
        {
            var foundExam = _dataSource.StudentExams.FirstOrDefault(e => e.StudentExamId == exam.StudentExamId);
            if (foundExam == null)
            {
                return;
            }

            foundExam.CourseName = exam.CourseName;
            foundExam.Degree = exam.Degree;
            foundExam.ExamDate = exam.ExamDate;
        }

        public void DeleteExam(int studentExamId)
        {
            _dataSource.StudentExams.RemoveAll(e => e.StudentExamId == studentExamId);
        }
    }
}
