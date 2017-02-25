using System;
using System.Configuration;
using MbUnit.Framework;
using Moq;
using Framework.Validation.Ssn;
using Framework.Validation.Ssn.Configuration;


namespace Validation.Tests
{
    /// <summary>
    /// Test fixtures focused on configuration (thus impacts other tests dependent on the config file).
    /// </summary>
    /// <remarks>
    /// Dependency on SsnValidatorTest test fixture is there to cause tests on the 
    /// SsnValidatorTest fixture to run first.  This is a terrible way to address the
    /// issue of config file dependency, but it works for now.
    /// </remarks>
    [TestFixture, DependsOn(typeof(SsnValidatorTest))]
    public class SsnHighGroupNumbersTests
    {
        [FixtureSetUp]
        public void FixtureSetup()
        {
            ResetConfigFile();
        }

        [FixtureTearDown]
        public void FixtureTearDown()
        {
            ResetConfigFile();
        }

        private static void ResetConfigFile()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.Sections["validation.extensions"] != null)
            {
                config.Sections.Remove("validation.extensions");
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("validation.extensions");
            }
        }

        [Test, Parallelizable]
        public void SsnHighGroupNumbers_PrivateConstructor_AcceptsAlternativeProvider()
        {
            var mock = new Mock<ISsnHighNumberStorageProvider>();
            var a = new SsnHighGroupNumbers_Accessor(mock.Object);

            Assert.AreSame(mock.Object, SsnHighGroupNumbers_Accessor._ssnHighNumberStorageProvider);
        }

        [Test, Parallelizable]
        public void SsnHighGroupNumbers_WithoutProviderSetInConfig_DefaultsToBuiltInProvider()
        {
            var defaultSsnHighNumberStorageProvider = new DefaultSsnHighNumberStorageProvider_Accessor();
            SsnHighGroupNumbers_Accessor.Initialize();

            Assert.IsInstanceOfType(defaultSsnHighNumberStorageProvider.Target.GetType(),
                SsnHighGroupNumbers_Accessor._ssnHighNumberStorageProvider);
        }

        [Test, Parallelizable]
        public void SsnHighGroupNumbers_WithProviderSetInConfig_SetsProviderToSpecifiedOne()
        {
            const string ValidProviderString = "Validation.Tests.TestSsnHighNumberStorageProvider, Validation.Tests";
            var element = new SsnValidatorElement { SsnHighNumberStorageProvider = ValidProviderString };
            ValidationExtensionsSection section = new ValidationExtensionsSection { SsnValidator = element };

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.Sections["validation.extensions"] != null) config.Sections.Remove("validation.extensions");
            config.Sections.Add("validation.extensions", section);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("validation.extensions");

            SsnHighGroupNumbers_Accessor.Initialize();

            Assert.IsInstanceOfType(typeof(TestSsnHighNumberStorageProvider),
                SsnHighGroupNumbers_Accessor._ssnHighNumberStorageProvider);

            // Clean up
            config.Sections.Remove("validation.extensions");
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("validation.extensions");
        }

        [Test]
        public void SsnHighGroupNumbers_WithInvalidProviderAssemblyName_ThrowsExceptionWithExpectedMessage()
        {
            const string InvalidProviderString = "Validation.Tests.TestSsnHighNumberStorageProvider, AssemblyNameInvalid";
            var element = new SsnValidatorElement { SsnHighNumberStorageProvider = InvalidProviderString };
            ValidationExtensionsSection section = new ValidationExtensionsSection { SsnValidator = element };

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.Sections["validation.extensions"] != null) config.Sections.Remove("validation.extensions");
            config.Sections.Add("validation.extensions", section);
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("validation.extensions");

            CauseSingletonToBeInstantiatedIfDoesNotExistYet();

            Assert.Throws<TypeLoadException>(() => SsnHighGroupNumbers_Accessor.Initialize(),
                    "Unable to load type Validation.Tests.TestSsnHighNumberStorageProvider from assembly file AssemblyNameInvalid.dll. " +
                    "Make sure the type's full name is accurate and that the assembly exists and can be resolved.");

            // Clean up
            config.Sections.Remove("validation.extensions");
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("validation.extensions");
        }

        [Test]
        public void SsnHighGroupNumbers_WithInvalidProviderTypeName_ThrowsExceptionWithExpectedMessage()
        {
            const string InvalidProviderString = "Validation.Tests.DoesNotExist, Validation.Tests";
            var element = new SsnValidatorElement { SsnHighNumberStorageProvider = InvalidProviderString };
            ValidationExtensionsSection section = new ValidationExtensionsSection { SsnValidator = element };

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.Sections["validation.extensions"] != null) config.Sections.Remove("validation.extensions");
            config.Sections.Add("validation.extensions", section);
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("validation.extensions");

            CauseSingletonToBeInstantiatedIfDoesNotExistYet();

            Assert.Throws<TypeLoadException>(() => SsnHighGroupNumbers_Accessor.Initialize(),
                "Unable to load type Validation.Tests.DoesNotExist from assembly file Validation.Tests.dll. " +
                "Make sure the type's full name is accurate and that the assembly exists and can be resolved.");

            // Clean up
            config.Sections.Remove("validation.extensions");
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("validation.extensions");
        }

        private static void CauseSingletonToBeInstantiatedIfDoesNotExistYet()
        {
            try
            {
                SsnHighGroupNumbers_Accessor.Initialize();
            }
            catch
            {
                // if this test is run first, the TypeLoadException is an inner exception to a TypeInitializationException because of the
                // static constructor of the class being tested.
                // To prevent issues with this test running alongside with other tests, we called SsnHighGroupNumbers_Accessor.Initialize()
                // and just ignored the TypeLoadException.  We can then call the Assert.Throws below and check that we get the
                // expected TypeLoadException regardless of the execution context.
            }
        }
    }
}