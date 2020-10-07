using Binding;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    
        public interface ICarService
        {
            IEnumerable<Car> GetAllCars();
            bool AddNewCar(Car car);
            Car GetById(int id);
            bool UpdateCar(Car car);
            bool DeleteCar(int id)
        }
        public class CarService: ICarService
        {
            public readonly CarsDBContext _db;
            public CarService(CarsDBContext db)
            {
                _db = db;
            }
            public IEnumerable<Car> GetAllCars()
            {
                var result = new List<Car>();
                try
                {
                    result = _db.cars.ToList();


                }
                catch (System.Exception)
                {

                }
                return result;
            }
            
            public bool AddNewCar(Car car)
            {
            try
                {
                    _db.Add(car);
                    _db.SaveChanges();
                }
                catch (System.Exception)
                {
                    return false;
                }
                return true;
            }
            public Car GetById(int id)
            {
            var result = new Car();
                try
                {
                    result = _db.cars.Single(x => x.Id.Equals(id));
                }
                catch (System.Exception)
                {
                    
                }
                return result;
            }
            public bool UpdateCar(Car car)
            {
            try
                {

                    var originalModel = _db.cars.Single(x => x.Id == car.Id);

                    originalModel.Price = car.Price;

                    originalModel.DateTimeNewCar = new DateTime();
                    originalModel.Quantity = car.Quantity;
                    originalModel.ModelcarId = car.ModelcarId;
                    _db.Update(originalModel);
                    _db.SaveChanges();
                }
                catch (System.Exception)
                {
                    return false;
                }
                return true;
            }
            public bool DeleteCar(int id)
            {
            try
            {
                _db.Entry(new Car { Id = id }).State = EntityState.Deleted;
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
