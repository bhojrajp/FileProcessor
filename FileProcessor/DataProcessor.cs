using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Linq;

namespace FileProcessor
{
    public class DataProcessor
    {
        #region private members
        private string _inputFilePath = string.Empty;
        private string _destinationFilePath = System.Environment.CurrentDirectory + @"\Output";
        private List<Transaction_Model> _records = null;
        #endregion
        
        #region Constructor
        public DataProcessor(string intputFilePath)
        {
            this._inputFilePath = intputFilePath;
        }
        #endregion

        #region PerformDataExtraction

        /// <summary>
        /// PerformDataExtraction reads data from input csv file 
        /// and creates a file in destination folder after processing records
        /// </summary>
        public void PerformDataExtraction()
        {
            LoadTransactionRecords();

            if (_records != null && _records.Count > 0)
            {
                ExportProcessedDataToCsv();
            }
            else
            {
                Console.WriteLine("No data to process...");
            }

        } 

        #endregion

        #region helper methods

        /// <summary>
        /// ExportProcessedDataToCsv creates a outputcsv file in destination folder
        /// </summary>
        private void ExportProcessedDataToCsv()
        {
            if (!Directory.Exists(_destinationFilePath))
            {
                Directory.CreateDirectory(_destinationFilePath);
            }
            string outPutfileName = string.Format("{0}{1}.csv", "DataExtractor_Example_Output", DateTime.Now.ToString("MMddyyyymmss"));
            using (StreamWriter streamWriter = new StreamWriter(_destinationFilePath + "\\" + outPutfileName))
            using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(_records);
            }
        }

        /// <summary>
        /// Read input csv file and creates list of Transaction_Model 
        /// </summary>
        private void LoadTransactionRecords()
        {            
            using (StreamReader streamReader = new StreamReader(this._inputFilePath))
            using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                csvReader.Context.RegisterClassMap<Transaction_Model_Map>();

                //Read once to skip the first row of csv, because headers are specified in second row
                csvReader.Read();

                _records = csvReader.GetRecords<Transaction_Model>().ToList();
            }
           
        } 

        #endregion

    }
}
