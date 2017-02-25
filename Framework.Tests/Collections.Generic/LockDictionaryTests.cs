using System;
using System.Collections.Generic;
using Framework.Collections.Generic;
using MbUnit.Framework;

namespace Framework.Collections.Generic.Tests
{
    /// <summary>
    /// LockDictionary Tests
    /// Some tests are intended to be run multi-threaded to help ensure
    /// thread safety of the class, however, the tests passing does not
    /// mean the class is thread safe.  Our local machines can't seem to
    /// generate enough concurrent load to cause failures.
    /// </summary>
    [TestFixture]
    [Author("Adam Knudsen", "c-aknudsen@state.pa.us")]
    [Parallelizable(TestScope.All)]
    public class LockDictionaryTests
    {
        ILockDictionary<string> _lockDictionary;

        [FixtureSetUp]
        public void EstablishLockDictionaryToBeUsedInMultiThreadedTests()
        {
            _lockDictionary = new LockDictionary<string>();
        }

        [Test]
        [Row("keys")]
        [Row("do")]
        [Row("not")]
        [Row("matter")]
        [ThreadedRepeat(4)]
        public void GetLock_StringKeyExists_ReturnsSameObjectEachCall(string key)
        {
            object firstCallResult = _lockDictionary.GetLock(key);
            Assert.IsNotNull(firstCallResult, "Initial call to GetLock for this key failed.");
            object secondCallResult = _lockDictionary.GetLock(key);
            Assert.AreSame(firstCallResult, secondCallResult);
        }

        [Test]
        [Row("keys", "do")]
        [Row("not", "matter")]
        [Row("just", "need")]
        [Row("to be", "different")]
        [ThreadedRepeat(4)]
        public void GetLock_WithDifferentStringKeys_ReturnDifferentObjects(string firstKey, string secondKey)
        {
            object firstKeyCallResult = _lockDictionary.GetLock(firstKey);
            Assert.IsNotNull(firstKeyCallResult);
            object secondKeyCallResult = _lockDictionary.GetLock(secondKey);
            Assert.AreNotSame(firstKeyCallResult, secondKeyCallResult);
        }
                
        [Test]
        public void GetLock_IntegerKeyExists_ReturnsSameObjectEachCall()
        {
            const int ArbitraryKey = 12345;
            ILockDictionary<int> lockDictionary = new LockDictionary<int>();
            object firstCallResult = lockDictionary.GetLock(ArbitraryKey);
            Assert.IsNotNull(firstCallResult, "Initial call to GetLock for this key failed.");
            object secondCallResult = lockDictionary.GetLock(ArbitraryKey);
            Assert.AreSame(firstCallResult, secondCallResult);
        }
    }
}
