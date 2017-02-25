using MbUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Collections;
using System.Configuration;

namespace Framework.Collections.Tests
{
    /// <summary>
    /// ReadOnlyDictionary tests.
    /// </summary>
    [TestFixture]
    [Author("Adam Knudsen", "c-aknudsen@state.pa.us")]
    public class ConfigurationElementCollectionExtensionsTests
    {
        [Test]
        public void ToIDictionary_NullCollection_ThrowsException()
        {
            ArgumentNullException expectedException = Assert.Throws<ArgumentNullException>(()
                                        => ConfigurationElementCollectionExtensions.ToIDictionary<string, ConfigurationElement>(null
                                                                                                                 , "notReleventToCurrentTest"));
            Assert.AreEqual("thatConfigurationElementCollection", expectedException.ParamName);
        }

        [Test]
        public void ToIDictionary_NullConfigElementKey_ThrowsException()
        {
            ArgumentNullException expectedException = Assert.Throws<ArgumentNullException>(()
                                        => ConfigurationElementCollectionExtensions.ToIDictionary<string, ConfigurationElement>(new TestConfigurationElementCollection()
                                                                                                                 , null));
            Assert.AreEqual("nameOfConfigElementKey", expectedException.ParamName);
        }

        [Test]
        public void ToIDictionary_EmptyCollection_ReturnsEmptyDictionary()
        {
            IDictionary<string, TestConfigurationElement> resultDictionary 
                                        = ConfigurationElementCollectionExtensions.ToIDictionary<string
                                                                                               , TestConfigurationElement>(
                                                                                                        new TestConfigurationElementCollection()
                                                                                                        , "notReleventToCurrentTest");
            const int ExpectingNoItemsInDictionary = 0;
            Assert.AreEqual<int>(ExpectingNoItemsInDictionary, resultDictionary.Count);
    
        }

        [Test]
        [Row(1)]
        [Row(10)]
        public void ToIDictionary_NormalCollection_ReturnsCorrectDictionary(int quantityOfElementsInConfigCollection)
        {
            TestConfigurationElementCollection testConfigCollection = new TestConfigurationElementCollection(quantityOfElementsInConfigCollection);
            ConsoleOut(testConfigCollection);
            IDictionary<string, TestConfigurationElement> resultDictionary
                                        = ConfigurationElementCollectionExtensions.ToIDictionary<string
                                                                                               , TestConfigurationElement>(
                                                                                                        testConfigCollection
                                                                                                        , TestConfigurationElement.KeyPropertyName);
            ConsoleOut(resultDictionary);
            Assert.AreEqual<int>(quantityOfElementsInConfigCollection, resultDictionary.Count);

        }

        [Test]
        [ExpectedException(typeof(ConfigurationErrorsException), "had a null value for the key field")]
        public void ToIDictionary_ElementInCollectionHasNullForNamedKey_ThrowsException()
        {
            TestConfigurationElementCollection testConfigCollection = new TestConfigurationElementCollection("arbitraryKey", null);
            ConsoleOut(testConfigCollection);

            const string IntentionallyUsingValueAsKeyToGetCollectionToAllowNulls = TestConfigurationElement.SomeValuePropertyName;
            ConfigurationElementCollectionExtensions.ToIDictionary<string
                                                                   , TestConfigurationElement>(
                                                                            testConfigCollection
                                                                            , IntentionallyUsingValueAsKeyToGetCollectionToAllowNulls);
        }

        [Test]
        [ExpectedException(typeof(ConfigurationErrorsException), "did not have Property Information for the key field")]
        public void ToIDictionary_NamedKeyIsNotAPropertyInElement_ThrowsException()
        {
            TestConfigurationElementCollection testConfigCollection = new TestConfigurationElementCollection("arbitraryKey", "arbitraryValue");
            ConsoleOut(testConfigCollection);

            const string NameOfPropertyThatDoesNotExistOnConfigElement = "nonExistingProperty";
            ConfigurationElementCollectionExtensions.ToIDictionary<string
                                                                   , TestConfigurationElement>(
                                                                            testConfigCollection
                                                                            , NameOfPropertyThatDoesNotExistOnConfigElement);
        }

        [Test]
        [ExpectedException(typeof(ConfigurationErrorsException), "that type did not match the requested type")]
        public void ToIDictionary_KeyTypeMismatch_ThrowsException()
        {
            TestConfigurationElementCollection testConfigCollection = new TestConfigurationElementCollection("arbitraryKey", "arbitraryValue");
            ConsoleOut(testConfigCollection);

            ConfigurationElementCollectionExtensions.ToIDictionary<int
                                                                   , TestConfigurationElement>(
                                                                            testConfigCollection
                                                                            , TestConfigurationElement.KeyPropertyName);
        }

        private void ConsoleOut(ICollection collection)
        {
            if (collection == null)
            {
                Console.WriteLine("Collection is null");
            }
            else
            {
                Console.WriteLine("Collection has {0} items", collection.Count.ToString());
                foreach (object item in collection)
                {
                    Console.WriteLine(" -> {0}", item.ToString());
                }
            }
        }

        private void ConsoleOut(IDictionary<string, TestConfigurationElement> dictionary)
        {
            if (dictionary == null)
            {
                Console.WriteLine("Dictionary is null");
            }
            else
            {
                Console.WriteLine("Dictionary has {0} items", dictionary.Count.ToString());
                foreach (object item in dictionary)
                {
                    Console.WriteLine(" -> {0}", item.ToString());
                }
            }
        }
    }

    internal class TestConfigurationElementCollection
        : ConfigurationElementCollection
    {
        public TestConfigurationElementCollection(){ }
        public TestConfigurationElementCollection(string keyForOnlyElementInCollection, string valueForOnlyElementInCollection)
        {
            TestConfigurationElement testConfigElement = new TestConfigurationElement(keyForOnlyElementInCollection);
            testConfigElement.SomeValue = valueForOnlyElementInCollection;
            this.BaseAdd(testConfigElement);
            
        }
        public TestConfigurationElementCollection(int quantityOfElementsToAutoAddIntoConfigCollection)
        {
            for (int i = 0; i < quantityOfElementsToAutoAddIntoConfigCollection; i++ )
            {
                TestConfigurationElement currentConfigElement = new TestConfigurationElement(string.Format("Element {0}", i.ToString()));
                currentConfigElement.SomeValue = string.Format("Value {0}", i.ToString());
                this.BaseAdd(currentConfigElement);
            }
            
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TestConfigurationElement)element).Key;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TestConfigurationElement(string.Empty);
        }

    }
    internal class TestConfigurationElement
        : ConfigurationElement
    {
        internal const string KeyPropertyName = "keyPropertyName";
        internal const string SomeValuePropertyName = "someValuePropertyName";

        public TestConfigurationElement(string key)
        {
            this.Properties.Add(new ConfigurationProperty( KeyPropertyName,typeof(string),""));
            this.SetPropertyValue(this.Properties[KeyPropertyName], key, true);
            this.Properties.Add(new ConfigurationProperty(SomeValuePropertyName, typeof(string), null));
        }
        public string Key
        {
            get { return (string)this.ElementInformation.Properties[KeyPropertyName].Value; } 
        }
        public string SomeValue
        {
            get { return (string)this.ElementInformation.Properties[SomeValuePropertyName].Value; }
            set { this.SetPropertyValue(this.Properties[SomeValuePropertyName], value, true); }
        }
        public override string ToString()
        {
            return string.Format("TestConfigurationElement with Key '{0}' and SomeValue '{1}'", this.Key, this.SomeValue);
        }

    }
}
