﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Models;

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
        public IActionResult NewCar([FromBody] Car car)
        {
            return Ok(_service.AddNewCar(car));
        }
        [HttpGet("{id}")]
        [Route("newcar-by-id")]
        public IActionResult GetOneCar(int id)
        {
            return Ok(
               _service.GetById(id)
               );
        }

        [HttpPut]
        [Route("put-car")]
        public IActionResult Put([FromBody]Car car)
        {
            return Ok(
                _service.UpdateCar(car));
        }
        [HttpDelete("{id}")]
        [Route("del-car")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _service.DeleteCar(id));
        }
    }
}