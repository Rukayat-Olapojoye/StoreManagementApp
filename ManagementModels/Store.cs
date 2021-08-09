namespace ManagementModels
{
    public class Store
    {
        public string StoreOwner { get; set; }
        public string StoreID { get; set; }
        public string StoreName { get; set; }
        public StoreType TypeOfStore { get; set; }
        public int NumofProducts { get; set; }
        public enum StoreType
        {
            Kiosk,
            Supermarket
        }


    }
}