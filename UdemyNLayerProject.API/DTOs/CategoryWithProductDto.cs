using System.Collections.Generic;

namespace UdemyNLayerProject.API.DTOs
{
    public class CategoryWithProductDto : CategoryDto
    {
        public ICollection<ProductDto> Product { get; set; }
    }
}