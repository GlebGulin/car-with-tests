using cars.Controllers;
using Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Xunit;

using Binding;

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
    }
}
