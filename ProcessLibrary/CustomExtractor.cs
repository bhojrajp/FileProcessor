using System;

namespace ProcessLibrary
{
    /// <summary>
    /// CustomExtractor class provide methods to extract values from complex values
    /// </summary>
    public static class CustomExtractor
    {
        #region GetPriceMultiplier

        /// <summary>
        /// This static method will extract the price multiplier from AlgoParams filed in input csv
        /// </summary>
        /// <param name="inputString">string</param>
        /// <returns>string</returns>
        public static string GetPriceMultiplier(string inputString)
        {
            string multiplier = string.Empty;

            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException("inputstring is null or empty");
            }

            string[] stringValues = inputString.Split(new char[] { '|' });

            string priceMultiplier = stringValues[4];
            multiplier = priceMultiplier.Split(new char[] { ':' })[1].ToString().Trim();
            return multiplier;
        }
        #endregion
    }
}
