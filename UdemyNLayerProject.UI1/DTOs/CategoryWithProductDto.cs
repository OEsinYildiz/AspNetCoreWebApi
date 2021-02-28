using System.Collections.Generic;

namespace UdemyNLayerProject.UI.DTOs
{
    public class CategoryWithProductDto:CategoryDto
    {
        public ICollection<ProductDto> Product { get; set; }
    }
}