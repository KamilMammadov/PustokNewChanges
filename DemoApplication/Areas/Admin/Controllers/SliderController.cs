using DemoApplication.Areas.Admin.ViewModels.Slider;
using DemoApplication.Contracts.File;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/slider")]
    public class SliderController : Controller
    {
        private readonly DataContext _dataContext;

        private readonly IFileService _fileService;

        public SliderController(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        [HttpGet("list",Name ="admin-slider-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.Sliders.Select(s => new ListViewModel(s.Id, s.MainTitle
                , s.Content,
                _fileService.GetFileUrl(s.BackgroundİmageInFileSystem, UploadDirectory.Slider),
                s.Button,
                s.ButtonRedirectUrl,
                s.Order,
                s.CreatedAt)).ToListAsync();
                
            return View(model);
        }

        [HttpGet("add",Name ="admin-slider-add")]
        public async Task<IActionResult> AddAsync()
        {
            return View();
        }
        [HttpPost("add", Name = "admin-slider-add")]
        public async Task<IActionResult> Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var imageNameInSystem = await _fileService.UploadAsync(model!.Backgroundİmage, UploadDirectory.Slider);

            AddSlider(model.Backgroundİmage!.FileName, imageNameInSystem);

            return RedirectToRoute("admin-slider-list");


            void AddSlider(string imageName, string imageNameInSystem)
            {
                var slider = new Slider
                {
                    MainTitle = model.MainTitle,
                    Content = model.Content,
                    Backgroundİmage = imageName,
                    BackgroundİmageInFileSystem = imageNameInSystem,
                    Button = model.Button,
                    ButtonRedirectUrl = model.ButtonRedirectUrl,
                    Order = model.Order,
                    CreatedAt = DateTime.Now,
                };

                _dataContext.Sliders.Add(slider);

                _dataContext.SaveChanges();
            }
        }

        [HttpPost("delete/{id}", Name = "admin-slider-delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var slider = await _dataContext.Sliders.FirstOrDefaultAsync(b => b.Id == id);
            if (slider is null)
            {
                return NotFound();
            }
            await _fileService.DeleteAsync(slider.BackgroundİmageInFileSystem, UploadDirectory.Slider);
            _dataContext.Sliders.Remove(slider);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-slider-list");
        }
    }
}
