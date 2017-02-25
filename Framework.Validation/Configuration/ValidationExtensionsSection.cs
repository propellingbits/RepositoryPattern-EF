using System.Configuration;

namespace Framework.Validation.Ssn.Configuration
{
    /// <summary>
    /// The configuration section used to specify the mappings 
    /// between repository interfaces and repository concrete types.
    /// </summary>
    public sealed class ValidationExtensionsSection : ConfigurationSection
    {
        /// <summary>
        /// Gets or sets the ssnHighNumberStorageProvider .
        /// </summary>
        [ConfigurationProperty("ssnValidator", IsRequired = false)]
        public SsnValidatorElement SsnValidator
        {
            get { return (SsnValidatorElement)base["ssnValidator"]; }
            set { this["ssnValidator"] = value; }
        }

    }
}
