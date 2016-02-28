using System.Collections.Generic;
using System.Linq;

using Hik.JTable.Models;

namespace Hik.JTable.Repositories.Memory
{
    public class MemoryCityRepository : ICityRepository
    {
        private readonly MemoryDataSource _dataSource;

        public MemoryCityRepository(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<City> GetAllCities()
        {
            return _dataSource.Cities.OrderBy(c => c.CityName).ToList();
        }
    }
}
