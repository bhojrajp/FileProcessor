using System.Globalization;
using CsvHelper.Configuration;
using ProcessLibrary;

namespace FileProcessor
{
    /// <summary>
    /// Map configuration for Transaction_Model
    /// </summary>
    public sealed class Transaction_Model_Map:ClassMap<Transaction_Model>
    {
        #region Constructor
        public Transaction_Model_Map()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(t => t.ContractSize).Ignore();
            Map(t => t.ContractSize).Convert(data => CustomExtractor.GetPriceMultiplier(data.Row.GetField("AlgoParams")));
        } 
        #endregion
    }
}
