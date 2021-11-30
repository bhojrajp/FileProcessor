namespace FileProcessor
{
    /// <summary>
    /// Data model for input csv row
    /// </summary>
    public class Transaction_Model
    {   
        public string ISIN { get; set; }
        public string CFICode { get; set; }
        public string Venue { get; set; }
        public string ContractSize { get; set; }
    }
}
