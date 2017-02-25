using System.Collections.Generic;
using Framework.Collections.Generic;
using MbUnit.Framework;
using Framework.Validation.Ssn;

namespace Validation.Tests
{
    [TestFixture]
    public class DefaultSsnHighNumberStorageProviderTests
    {
        [Test]
        public void LoadData_ReturnsNonEmptyDictionary()
        {
            var provider = new DefaultSsnHighNumberStorageProvider_Accessor();
            IDictionary<string, byte> data = provider.LoadData();

            Assert.IsNotEmpty(data);
        }

        [Test]
        public void LoadData_ReturnsReadOnlyDictionary()
        {
            var provider = new DefaultSsnHighNumberStorageProvider_Accessor();
            IDictionary<string, byte> data = provider.LoadData();

            Assert.IsInstanceOfType(typeof(ReadOnlyDictionary<string, byte>), data);
        }
    }
}
