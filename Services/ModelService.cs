using Binding;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface IModelService
    {
        IEnumerable<Modelcar> GetAllModels();
    }
    public class ModelService : IModelService
    {
        public readonly CarsDBContext _db;
        public ModelService(CarsDBContext db)
        {
            _db = db;
        }
        public IEnumerable<Modelcar> GetAllModels()
        {
            var result = new List<Modelcar>();
            try
            {
                result = _db.modelcars.ToList();


            }
            catch (System.Exception)
            {

            }
            return result;
        }
    }
}