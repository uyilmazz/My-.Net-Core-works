using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CarDetailDto : IDto
    {
        public string Carname { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public double DailyPrice { get; set; }
    }
}
