using System.Collections.Generic;
using System.Linq;

using Hik.JTable.Models;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryPersonRepository : IPersonRepository
    {
        private readonly MemoryDataSource _dataSource;

        public MemoryPersonRepository(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<Person> GetAllPeople()
        {
            return _dataSource.People.OrderBy(p => p.Name).ToList();
        }

        public Person AddPerson(Person person)
        {
            person.PersonId = _dataSource.People.Count > 0 ? (_dataSource.People[_dataSource.People.Count - 1].PersonId + 1) : 1;
            _dataSource.People.Add(person);
            return person;
        }

        public void UpdatePerson(Person person)
        {
            var foundPerson = _dataSource.People.Find(p => p.PersonId == person.PersonId);
            if (foundPerson == null)
            {
                return;
            }

            foundPerson.Name = person.Name;
            foundPerson.Age = person.Age;
        }

        public void DeletePerson(int personId)
        {
            _dataSource.People.RemoveAll(person => person.PersonId == personId);
        }
    }
}
