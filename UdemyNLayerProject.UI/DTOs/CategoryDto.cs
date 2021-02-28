using System.ComponentModel.DataAnnotations;

namespace UdemyNLayerProject.UI.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alani bos gecilemez.")] 
        public string Name { get; set; }
    }
}