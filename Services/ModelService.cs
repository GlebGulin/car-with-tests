using Binding;
using Microsoft.EntityFrameworkCore;
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
        bool AddNewModel(Modelcar modelcar);
        Modelcar GetModelById(int id);
        bool UpdateModel(Modelcar modelcar);
        bool DeleteModel(int id);

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
        public bool AddNewModel(Modelcar modelcar)
        {
            try
            {
                _db.Add(modelcar);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
        public Modelcar GetModelById(int id)
        {
            var result = new Modelcar();
            try
            {
                result = _db.modelcars.Single(x => x.Id.Equals(id));
            }
            catch (System.Exception)
            {

            }
            return result;
        }
        public bool UpdateModel(Modelcar modelcar)
        {
            try
            {

                var originalModel = _db.modelcars.Single(x => x.Id == modelcar.Id);

                originalModel.ModelName = modelcar.ModelName;
                _db.Update(originalModel);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
        public bool DeleteModel(int id)
        {
            try
            {
                _db.Entry(new Modelcar { Id = id }).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;


        }
    }
}