using System.Collections.Generic;
using Framework.Validation.Ssn;


namespace Validation.Tests
{
    public class TestSsnHighNumberStorageProvider : ISsnHighNumberStorageProvider
    {
        /// <summary>
        /// Returns an empty dictionary.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, byte> LoadData()
        {
            return new Dictionary<string, byte>();
        }
    }
}
