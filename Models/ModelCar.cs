using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Modelcar
    {
        [Key]
        public int Id { get; set; }
        public string ModelName { get; set; }
    }
}
