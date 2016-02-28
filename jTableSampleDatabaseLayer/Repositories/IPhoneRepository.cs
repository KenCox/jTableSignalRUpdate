using System.Collections.Generic;

using Hik.JTable.Models;

namespace Hik.JTable.Repositories
{
    public interface IPhoneRepository
    {
        List<Phone> GetPhonesOfStudent(int studentId);
        Phone AddPhone(Phone phone);
        void UpdatePhone(Phone phone);
        void DeletePhone(int phoneId);
    }
}
