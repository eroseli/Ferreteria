﻿namespace Api_Web_Ejemplo.Controllers.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        
        public Product() { }        
    }
}
