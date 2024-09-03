using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Application.Dto
{
    public class CategoryItem
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public CategoryItem(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
}
