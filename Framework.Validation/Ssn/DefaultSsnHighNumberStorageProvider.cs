using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Framework.Collections.Generic;

namespace Framework.Validation.Ssn
{
    /// <summary>
    /// A default implementation of <see cref="ISsnHighNumberStorageProvider"/> that
    /// loads its data from an embedded resource.
    /// </summary>
    /// <remarks>
    /// The data used was published by the IRS as of October 2010.
    /// </remarks>
    internal sealed class DefaultSsnHighNumberStorageProvider : ISsnHighNumberStorageProvider
    {

        public IDictionary<string, byte> LoadData()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            using (var streamReader = new StreamReader(assembly.GetManifestResourceStream(
                Properties.Resources.SsaHighGroupNumberXml)))
            {
                var ssaHighNumbersData = XDocument.Load(streamReader);
                var ssaHighNumbersQuery = from entries in ssaHighNumbersData.Descendants("Entry")
                                          select new
                                          {
                                              AreaNumber = entries.Attribute("AreaNumber").Value,
                                              HighGroupNumber = entries.Attribute("HighGroupNumber").Value
                                          };

                IDictionary<string, byte> _ssnHighGroupNumbers = new Dictionary<string, byte>();
                char[] charactersToTrim = new char[] { char.Parse("0") };
                foreach (var entry in ssaHighNumbersQuery)
                {
                    _ssnHighGroupNumbers.Add(entry.AreaNumber, byte.Parse(entry.HighGroupNumber.TrimStart(charactersToTrim), CultureInfo.InvariantCulture));
                }

                IDictionary<string, byte> _ssnHighGroupNumbersReadOnly = new ReadOnlyDictionary<string, byte>(_ssnHighGroupNumbers);
                return _ssnHighGroupNumbersReadOnly;
            }           
        }
    }
}
