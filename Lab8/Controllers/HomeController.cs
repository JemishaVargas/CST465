using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab8.Models;
using Lab8.Repositories;
using Lab8.DataObjects;
using Microsoft.AspNetCore.OutputCaching;

namespace Lab8.Controllers;
[Route("")]
[Route("Home")]
public class HomeController : Controller
{
    private readonly IImageRepository _ImageRepo;

    public HomeController(IImageRepository imageRepo)
    {
        _ImageRepo = imageRepo;
    }
    [Route("")]
    [HttpGet("Index")]
    [OutputCache]
    public IActionResult Index()
    {
        return View(_ImageRepo.GetImages());
    }
    
    [HttpGet("AddImage")]
    public IActionResult AddImage()
    {
        return View(new ImageModel());
    }

    [HttpPost("AddImage")]
    public IActionResult AddImage(ImageModel model)
    {
        if(!ModelState.IsValid)
        {
            return View(model);
        }

        model.FileName = model.File.Name;
        byte[] fileData;
        using MemoryStream fileStream = new MemoryStream();
        model.File.CopyTo(fileStream);
        fileData = fileStream.ToArray();

        _ImageRepo.SaveImage(new DataObjects.ImageObject{
            FileName = model.FileName,
            FileData = fileData,
            Description = model.Description,
        });

        return RedirectToAction("Index");
    }

    [HttpGet("Image/{id}")]
    [ResponseCache(Duration=1800, Location = ResponseCacheLocation.Any, NoStore = false)]
    public IActionResult GetImage(int id)
    {
        return File(_ImageRepo.GetImageData(id), "image/jpeg");
    } 
}
