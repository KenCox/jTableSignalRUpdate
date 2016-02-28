namespace Hik.JTable.Repositories.Memory
{
    public class MemoryRepositoryContainer : IRepositoryContainer
    {
        private readonly MemoryDataSource _dataSource;

        public MemoryRepositoryContainer(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public ICityRepository CityRepository
        {
            get { return new MemoryCityRepository(_dataSource); }
        }

        public IExamRepository ExamRepository
        {
            get { return new MemoryExamRepository(_dataSource); }
        }

        public IPersonRepository PersonRepository
        {
            get { return new MemoryPersonRepository(_dataSource); }
        }

        public IPhoneRepository PhoneRepository
        {
            get { return new MemoryPhoneRepository(_dataSource); }
        }

        public IStudentRepository StudentRepository
        {
            get { return new MemoryStudentRepository(_dataSource); }
        }
    }
}
