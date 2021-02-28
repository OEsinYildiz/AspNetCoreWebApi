using System.ComponentModel.DataAnnotations;

namespace UdemyNLayerProject.UI.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Stock araligi yanlis girilmistir.")]
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}