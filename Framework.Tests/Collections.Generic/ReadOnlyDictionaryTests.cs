using MbUnit.Framework;
using System.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Framework.Collections.Generic.Tests
{
    /// <summary>
    /// ReadOnlyDictionary tests.
    /// </summary>
    [TestFixture]
    [Author("Philippe Truche", "c-ptruche@state.pa.us")]
    [Parallelizable(TestScope.All)]
    public class ReadOnlyDictionaryTests
    {
        /// <summary>
        /// Determines whether [is read only_ when invoked_ returns true].
        /// </summary>
        [Test]
        public void IsReadOnly_WhenInvoked_ReturnsTrue()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            Assert.IsTrue(dict.IsReadOnly);
        }

        #region Contains(KeyValuePair<TKey, TValue> item) tests
        /// <summary>
        /// Asserts that contains called with an existent key value pair returns true.
        /// </summary>
        [Test]
        public void Contains_ExistentKeyValuePair_ReturnsTrue()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");
            
            var dict = new ReadOnlyDictionary<string, string>(source);
            var kvp = new KeyValuePair<string, string>("key", "value");

            Assert.IsTrue(dict.Contains(kvp));
        }

        /// <summary>
        /// Asserts that contains called with a non-existent key value pair returns true.
        /// </summary>
        [Test]
        public void Contains_NonExistentKeyValuePair_ReturnsFalse()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            var kvp = new KeyValuePair<string, string>("wrong_key", "wrong_value");

            Assert.IsFalse(dict.Contains(kvp));
        }

        /// <summary>
        /// Asserts that contains called with a valid key value pair returns true.
        /// </summary>
        [Test]
        public void Contains_NullKeyValuePair_ThrowsException()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            var kvp = new KeyValuePair<string, string>();

            Assert.Throws<ArgumentNullException>(() => dict.Contains(kvp));
        }
        #endregion

        #region ContainsKey(TKey key) tests
        /// <summary>
        /// Asserts that contains called with an existent key value pair returns true.
        /// </summary>
        [Test]
        public void ContainsKey_ExistentKey_ReturnsTrue()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            var key = "key";

            Assert.IsTrue(dict.ContainsKey(key));
        }

        /// <summary>
        /// Asserts that contains called with a non-existent key value pair returns true.
        /// </summary>
        [Test]
        public void ContainsKey_NonExistentKey_ReturnsFalse()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            var key = "wrong_key";

            Assert.IsFalse(dict.ContainsKey(key));
        }

        /// <summary>
        /// Asserts that contains called with a valid key value pair returns true.
        /// </summary>
        [Test]
        public void ContainsKey_NullKey_ThrowsException()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            
            Assert.Throws<ArgumentNullException>(() => dict.ContainsKey(null));
        }
        #endregion

        #region Keys tests
        /// <summary>
        /// Asserts that adding an item to the Keys property throws an exception.
        /// </summary>
        [Test]
        public void Keys_AddingAnItem_ThrowsException()
        { 
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            Assert.Throws<NotSupportedException>(() => dict.Keys.Add("illegal"));
        }

        /// <summary>
        /// Asserts that removing an item from the Keys property throws an exception.
        /// </summary>
        [Test]
        public void Keys_RemovingAnItem_ThrowsException()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            Assert.Throws<NotSupportedException>(() => dict.Keys.Remove("illegal"));
        } 
        #endregion

        #region Values tests
        /// <summary>
        /// Asserts that adding an item to the Keys property throws an exception.
        /// </summary>
        [Test]
        public void Values_AddingAnItem_ThrowsException()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            Assert.Throws<NotSupportedException>(() => dict.Values.Add("illegal"));
        }

        /// <summary>
        /// Asserts that removing an item from the Keys property throws an exception.
        /// </summary>
        [Test]
        public void Values_RemovingAnItem_ThrowsException()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            Assert.Throws<NotSupportedException>(() => dict.Values.Remove("illegal"));
        }
        #endregion

        #region TryGetValue tests
        /// <summary>
        /// Tries the get value_ existent key_ returns value.
        /// </summary>
        [Test]
        public void TryGetValue_ExistentKey_ReturnsValue()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            string actualValue;
            dict.TryGetValue("key", out actualValue);
            Assert.AreEqual("value", actualValue);
        }

        /// <summary>
        /// Tries the get value_ existent key_ returns value.
        /// </summary>
        [Test]
        public void TryGetValue_NonExistentKey_DoesNotReturnValue()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            string actualValue;
            dict.TryGetValue("nonexistent", out actualValue);
            Assert.IsNull(actualValue);
        }
        #endregion

        /// <summary>
        /// Asserts that altering the contents of the source dictionary does
        /// alter the content of the ReadOnlyDictionary!  This is OK because the internal
        /// backing store is not exposed.
        /// </summary>
        [Test]
        public void ReadOnlyDictionary_IDictionaryReference_CanBeMutated()
        {
            var source = new Dictionary<string, string>();
            source.Add("key", "value");

            var dict = new ReadOnlyDictionary<string, string>(source);
            Assert.AreEqual("value", dict["key"]);

            source["key"] = "altered";
            Assert.AreEqual("altered", dict["key"]);
        }
    }
}
