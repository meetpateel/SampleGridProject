using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace SampleGridProject.Models
{
    public class MonitorModel
    {
        public string MonitorId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public int? Price { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public string Quantity { get; set; }
        public IFormFile Image { get; set; }
    }
}