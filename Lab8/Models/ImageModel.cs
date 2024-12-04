using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab8.Models;

public class ImageModel
{
    public string? FileName {get; set;}
    [Required]
    [DisplayName("Description")]
    public string Description {get; set;}
    [Required]
    [DisplayName("Image File")]
    public IFormFile File {get; set;}
}