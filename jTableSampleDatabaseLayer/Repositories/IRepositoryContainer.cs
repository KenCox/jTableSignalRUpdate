namespace Hik.JTable.Repositories
{
    public interface IRepositoryContainer
    {
        ICityRepository CityRepository { get; }
        IExamRepository ExamRepository { get; }
        IPersonRepository PersonRepository { get; }
        IPhoneRepository PhoneRepository { get; }
        IStudentRepository StudentRepository { get; }
    }
}
