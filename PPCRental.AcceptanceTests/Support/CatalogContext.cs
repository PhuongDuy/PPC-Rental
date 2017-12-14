namespace PPCRental.AcceptanceTests.Support

{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceDetails = new ReferenceDetailsList();
            
        }

        public ReferenceDetailsList ReferenceDetails { get; set; }
    }
}
