﻿using System.ComponentModel.DataAnnotations;

namespace UdemyNLayerProject.UI.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required] public string Name { get; set; }
    }
}