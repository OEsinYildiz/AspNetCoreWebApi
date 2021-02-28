using System.Collections.Generic;

namespace UdemyNLayerProject.UI.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public int Status { get; set; }
        public List<string> Errors { get; set; }
    }
}