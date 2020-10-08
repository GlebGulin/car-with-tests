using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace cars.Controllers
{
    public class ModController : Controller
    {
        private readonly IModelService _modelService;
        public ModController(IModelService modelService)
        {
            _modelService = modelService;
        }
        [HttpGet]
        [Route("allmodels")]
        public IActionResult Index()
        {
            return Ok(_modelService.GetAllModels());


        }
        [HttpPost]
        [Route("newmodel")]
        public IActionResult NewModel([FromBody] Modelcar modelcar)
        {
            return Ok(_modelService.AddNewModel(modelcar));
        }
        [HttpGet("{id}")]
        [Route("newcar-by-id")]
        public IActionResult GetOneModel(int id)
        {
            return Ok(
               _modelService.GetModelById(id)
               );
        }

        [HttpPut]
        [Route("put-car")]
        public IActionResult Put([FromBody]Modelcar modelcar)
        {
            return Ok(
                _modelService.UpdateModel(modelcar));
        }
        [HttpDelete("{id}")]
        [Route("del-car")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _modelService.DeleteModel(id));
        }
    }
}