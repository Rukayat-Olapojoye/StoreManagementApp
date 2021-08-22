using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ManagementModels
{
    public class Product
    {
        [Required]
        public string Id { get; set; }
        public string storeProductId { get; set; }
         public string ProductName { get; set; }

        [JsonIgnore]
        public double Price { get; set; }

        public int Quantity { get; set; }


        //Navigation properties
      
        public Store storeProduct { get; set; }


    }
}