using System.ComponentModel.DataAnnotations;

namespace Hik.JTable.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }
    }
}