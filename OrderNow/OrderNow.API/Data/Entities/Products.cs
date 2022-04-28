﻿namespace OrderNow.API.Data
{
    public class Products : EntityBase
    {    

        public string Name { get; set; }
        public string Description { get; set; }
        public string URLImage { get; set; } //Imagen grande
        public string URLIcon { get; set; } //Imagen Chica
        public decimal Price { get; set; } = 0;
        public float Stock { get; set; }
        public bool Status { get; set; } //Activo-Inactivo
        public Businesses Business { get; set; }

        public List<ProductOptions> OptionsList { get; set; }
        public float Score { get; set; }
        public UInt64 Qualification { get; set; }

    }

  
}
