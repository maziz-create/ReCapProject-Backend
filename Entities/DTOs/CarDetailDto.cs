//using Core;
using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int carId { get; set; }
        public string carName { get; set; }
        public int brandId { get; set; }
        public string brandName { get; set; }
        public int colourId { get; set; }
        public string colourName { get; set; }
        public int modelYear { get; set; }
        public int dailyPrice { get; set; }
        public string description { get; set; }
        public List<string> imagePaths { get; set; }
    }
}
