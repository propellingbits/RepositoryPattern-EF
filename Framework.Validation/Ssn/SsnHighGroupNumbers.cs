using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Framework.Validation.Ssn.Configuration;


namespace Framework.Validation.Ssn
{
    /// <summary>
    /// A singleton class that contains the SSN high group numbers.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1052:StaticHolderTypesShouldBeSealed", 
        Justification="Needed to make this class a singleton so as to be able to inject providers for testing purposes.")]
    public class SsnHighGroupNumbers
    {
        private static ISsnHighNumberStorageProvider _ssnHighNumberStorageProvider;
        private static IDictionary<string, byte> _ssnHighGroupNumbers;

        /// <summary>
        /// Static constructor.  Defaults to obtaining the SSN high numbers from an embedded resource, unless
        /// an <see cref="ISsnHighNumberStorageProvider"/> is specified in configuration.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline",
            Justification = "Performance traded off for better error message if failure in static constructor.")]
        static SsnHighGroupNumbers()
        {
            Initialize();
        }

        private static void Initialize()
        {
            var config = (ValidationExtensionsSection)ConfigurationManager.GetSection(Properties.Resources.ValidationExtensions);
            if (config == null)
                _ssnHighNumberStorageProvider = new DefaultSsnHighNumberStorageProvider();
            else
            {
                var ssnValidatorConfig = config.SsnValidator as SsnValidatorElement;
                if (ssnValidatorConfig == null || String.IsNullOrEmpty(ssnValidatorConfig.SsnHighNumberStorageProvider))
                    _ssnHighNumberStorageProvider = new DefaultSsnHighNumberStorageProvider();
                else
                {
                    Type ssnHighNumberStorageProviderType = Type.GetType(ssnValidatorConfig.SsnHighNumberStorageProvider);
                    if (ssnHighNumberStorageProviderType == null)
                    {
                        int separatorLocation = ssnValidatorConfig.SsnHighNumberStorageProvider.IndexOf(',');
                        string typeFullName  = ssnValidatorConfig.SsnHighNumberStorageProvider.Substring(0, separatorLocation);
                        string dllName = String.Format(CultureInfo.InvariantCulture, "{0}.dll",
                            ssnValidatorConfig.SsnHighNumberStorageProvider.Substring(separatorLocation + 2));                        
                        throw new TypeLoadException(String.Format(CultureInfo.InvariantCulture, 
                            "Unable to load type {0} from assembly file {1}. Make sure the type's full name is accurate and that the assembly exists and can be resolved.", 
                            typeFullName, dllName));
                    }
                    else _ssnHighNumberStorageProvider = (ISsnHighNumberStorageProvider)Activator.CreateInstance(ssnHighNumberStorageProviderType, true);
                }
            }
            _ssnHighGroupNumbers = _ssnHighNumberStorageProvider.LoadData();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SsnHighGroupNumbers"/> class.
        /// </summary>
        private SsnHighGroupNumbers()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SsnHighGroupNumbers"/> class, for testing purposes only.
        /// </summary>
        /// <param name="ssnHighNumberStorageProvider">The SSN high number storage provider.</param>

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private SsnHighGroupNumbers(ISsnHighNumberStorageProvider ssnHighNumberStorageProvider)
        {
            if (ssnHighNumberStorageProvider == null)
                throw new ArgumentNullException("ssnHighNumberStorageProvider", "ssnHighNumberStorageProvider is null.");
            _ssnHighNumberStorageProvider = ssnHighNumberStorageProvider;
        }

        /// <summary>
        /// Given an area number, returns the current highest group as published by the SSA.
        /// </summary>
        /// <param name="areaNumber"></param>
        public static Byte GetHighGroupNumbers(String areaNumber)
        {
            if (_ssnHighGroupNumbers.Count > 0 && !String.IsNullOrEmpty(areaNumber) && _ssnHighGroupNumbers.ContainsKey(areaNumber))
            {
                return _ssnHighGroupNumbers[areaNumber];
            }

            //0 is a invalid group number
            return 0;
        }

        /// <summary>
        /// AreaNumberExists
        /// </summary>
        /// <param name="areaNumber"></param>
        /// <returns></returns>
        public static Boolean AreaNumberExists(String areaNumber)
        {
            //AAA = AREA Number, where Min(AAA) = 001, Max(AAA) = 772, and 666 is excluded.
            Int16 intAreaNumber = Int16.Parse(areaNumber, CultureInfo.InvariantCulture);
            return (intAreaNumber >= 1 && intAreaNumber <= 772 && intAreaNumber != 666);
        }
    }
}