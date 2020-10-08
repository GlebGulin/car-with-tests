using cars.Controllers;
using Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Xunit;

using Binding;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace App.Tests
{
    public class CarsControllerTest
    {
        CarsController _carsController;
        IModelService _imodelService;
        ICarService _icarService;
        CarsDBContext _db;
        public CarsControllerTest()
        {
            _icarService = new CarService(_db);
            _imodelService = new ModelService(_db);
            _carsController = new CarsController(_icarService, _imodelService);
        }
        [Fact]
        public void Get_WhenCalled_ResultNotNull()
        {
            var okResult = _carsController.Index();
            Assert.NotNull(okResult);
        }
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {

            var notFoundResult = _carsController.GetOneCar(4);

            Assert.IsType<OkObjectResult>(notFoundResult);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {

            var testCar = new Car()
            {
                Id = 444,
                Colour = "gold",
                Price = 12,
                Quantity = 3,
                ModelcarId = 3

            };
            var createdResponse = _carsController.NewCar(testCar);
            Assert.IsType<OkObjectResult>(createdResponse);
        }
        [Fact]
        public void Remove_ReturnsNotFoundResponse()
        {

            var okResponse = _carsController.Delete(3);
            
            Assert.IsType<OkObjectResult>(okResponse);
        }
    }
}
