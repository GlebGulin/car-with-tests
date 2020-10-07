using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Colour { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTimeNewCar { get; set; }
        public int ModelcarId { get; set; }
        [ForeignKey("ModelcarId")]
        public virtual Modelcar ModelOfCar { get; set; }
        public Car()
        {
            DateTimeNewCar = DateTime.Now;
        }
    }
}
