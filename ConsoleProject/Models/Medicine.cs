using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
    public class Medicine : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string CreatedDate { get; set; }

        public Medicine(string name, decimal price, int categoryId, int userId, string createdDate)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
            UserId = userId;
            CreatedDate = createdDate;
        }
    }

}
