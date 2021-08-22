using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ManagementModels
{
    public class Store

    {        
        [Required]
        public string Id{ get; set; }
        public string customersId { get; set; }
        public string StoreName { get; set; }
        public StoreType TypeOfStore { get; set; }
        public int NumofProducts { get; set; }
        public enum StoreType
        {
            Kiosk,
            Supermarket
        }

        //Navigation Properties
       
        public Customer customers { get; set; }
        public ICollection<Product> storeProducts { get; set; }


    }
}