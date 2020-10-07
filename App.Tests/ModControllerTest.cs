using Binding;
using cars.Controllers;
using Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Xunit;

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
    }
}
