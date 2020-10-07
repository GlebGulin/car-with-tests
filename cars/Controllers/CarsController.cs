using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace cars.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _service;
        private readonly IModelService _modelService;
        public CarsController(ICarService service, IModelService modelService)
        {
            _modelService = modelService;
            _service = service;
        }
        [HttpGet]
        [Route("allcars")]
        public IActionResult Index()
        {
            return Ok((_service.GetAllCars(), _modelService.GetAllModels()));

            
        }
        [HttpPost]
        [Route("newcar")]
        public IActionResult NewCar()
        {
            return View();
        }
        [HttpGet]
        [Route("newcar-by-id")]
        public IActionResult GetOneCar()
        {
            return View();
        }
        public IActionResult DeleteCar()
        {
            return View();
        }
    }
}