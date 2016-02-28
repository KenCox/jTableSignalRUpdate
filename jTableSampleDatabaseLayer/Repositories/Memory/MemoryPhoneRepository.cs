using System.Collections.Generic;
using System.Linq;

using Hik.JTable.Models;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryPhoneRepository : IPhoneRepository
    {
        private readonly MemoryDataSource _dataSource;

        public MemoryPhoneRepository(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<Phone> GetPhonesOfStudent(int studentId)
        {
            return _dataSource.Phones.Where(p => p.StudentId == studentId).ToList();
        }

        public Phone AddPhone(Phone phone)
        {
            phone.PhoneId = _dataSource.Phones.Count > 0 ? (_dataSource.Phones[_dataSource.Phones.Count - 1].PhoneId + 1) : 1;
            _dataSource.Phones.Add(phone);
            return phone;
        }

        public void UpdatePhone(Phone phone)
        {
            var foundPhone = _dataSource.Phones.FirstOrDefault(p => p.PhoneId == phone.PhoneId);
            if (foundPhone == null)
            {
                return;
            }

            foundPhone.Number = phone.Number;
            foundPhone.PhoneType = phone.PhoneType;
        }

        public void DeletePhone(int phoneId)
        {
            _dataSource.Phones.RemoveAll(p => p.PhoneId == phoneId);
        }
    }
}
