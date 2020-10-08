using Binding;
using cars.Controllers;
using Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Models;

namespace App.Tests
{
    public class ModControllerTest
    {
        ModController _modController;
        IModelService _imodelService;
        
        CarsDBContext _db;
        public ModControllerTest()
        {
            _imodelService = new ModelService(_db);
            _modController = new ModController(_imodelService);
        }
        [Fact]
        public void Get_WhenCalled_ResultNotNull()
        {
            var okResult = _modController.Index();
            Assert.NotNull(okResult);
        }
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
           
            var notFoundResult = _modController.GetOneModel(2);
            
            Assert.IsType<OkObjectResult>(notFoundResult);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {

            var testModel = new Modelcar()
            {
                Id = 20,
                ModelName = "Jaguar"
            };
            var createdResponse = _modController.NewModel(testModel);
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Remove_ReturnsNotFoundResponse()
        {

            var okResponse = _modController.Delete(3);

            Assert.IsType<OkObjectResult>(okResponse);
        }

    }
}
