using System;
using System.Collections.Generic;


namespace Framework.Validation.Ssn
{

    /// <summary>
    /// An implementation of <see cref="ISsnHighNumberStorageProvider"/> that uses ITASCA
    /// reference tables for storage.
    /// </summary>
    public sealed class SsnHighNumberReferenceTableProvider : ISsnHighNumberStorageProvider
    {

        private readonly Dictionary<string, byte> _ssnHighGroupNumbers = new Dictionary<string,byte>();

        /// <summary>
        /// SsnHighNumberReferenceTableProvider
        /// </summary>
        public SsnHighNumberReferenceTableProvider()
        {
            throw new NotImplementedException();
            //var itascaRefUtility = ItascaRefUtility.GetInstance();
            
            //const string SsaHighNumberReferenceTableName = "R01601";
            //Dictionary<string, string> refTableValues = itascaRefUtility.GetRefTableDictionary<string, string>(
            //    SsaHighNumberReferenceTableName, "KeyValue", "DisplayValue");
            
            //char[] charactersToTrim = new char[] { char.Parse("0") };
            //foreach (var entry in refTableValues)
            //{
            //    _ssnHighGroupNumbers.Add(entry.Key, byte.Parse(entry.Value.TrimStart(charactersToTrim), CultureInfo.InvariantCulture));
            //}
        }

        /// <summary>
        /// LoadData
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, byte> LoadData()
        {
            return _ssnHighGroupNumbers;
        }

    }
}