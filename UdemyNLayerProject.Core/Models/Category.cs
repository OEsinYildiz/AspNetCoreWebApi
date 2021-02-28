using System.Collections.Generic;

namespace UdemyNLayerProject.Core.Models
{
    public class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}