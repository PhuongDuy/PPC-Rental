namespace PPCRental.AcceptanceTests.Support

{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceBooks = new ReferenceDetailsList();
            
        }

        public ReferenceDetailsList ReferenceBooks { get; set; }
    }
}
