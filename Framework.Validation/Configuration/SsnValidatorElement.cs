using System;
using System.Configuration;

namespace Framework.Validation.Ssn.Configuration
{
    /// <summary>
    /// Defines the SsnValidatorElement.
    /// </summary>
    [Serializable]
    public class SsnValidatorElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the name used by the Enterprise Library Logging
        /// Application Block tracing statements within the repository.
        /// </summary>
        [ConfigurationProperty("ssnHighNumberStorageProvider", IsRequired = true)]
        public string SsnHighNumberStorageProvider
        {
            get { return (string)this["ssnHighNumberStorageProvider"]; }
            set { this["ssnHighNumberStorageProvider"] = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SsnValidatorElement"/> class.
        /// </summary>
        public SsnValidatorElement() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="SsnValidatorElement"/> class.
        /// </summary>
        /// <param name="ssnHighNumberStorageProvider">The SSN high number storage provider.</param>
        public SsnValidatorElement(string ssnHighNumberStorageProvider)
        {
            this.SsnHighNumberStorageProvider = ssnHighNumberStorageProvider;
        }
    }
}
