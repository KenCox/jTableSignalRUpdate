using System.Collections.Generic;

using Hik.JTable.Models;

namespace Hik.JTable.Repositories
{
    public interface ICityRepository
    {
        List<City> GetAllCities();
    }
}