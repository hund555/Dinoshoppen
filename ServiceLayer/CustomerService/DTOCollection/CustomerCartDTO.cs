using ServiceLayer.DinoService.DTOCollection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.CustomerService.DTOCollection
{
    public class CustomerCartDTO
    {
        public int CustomerId { get; set; }

        public int RabatId { get; set; }
        public int RabatProsent { get; set; }
        public string RabatName { get; set; }

        public ICollection<ListDinoDTO> MyProperty { get; set; }

        public int DinoId { get; set; } //FK
        public string DinoName { get; set; }
        public int Antal { get; set; }
        public double DinoPrice { get; set; }
        public double DinoTotalPrice { get; set; }

        public string PromotionName { get; set; }
        public string DietName { get; set; }

        public double TotalSum { get; set; }
    }
}
