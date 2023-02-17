using DAL.EF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PublisherDTO
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public List<BookDTO3> Books { get; set; }

    }

    public class PublisherDTO2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PublisherDTO3
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
    }

}
