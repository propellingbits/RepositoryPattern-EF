using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Reflection;

namespace Framework.Tests
{
    [TestFixture]
    [Author("Pradeep", "c-ppanthul@state.pa.us")]
    public class UnhandledExceptionTests
    {
        [Test] // there is already an FxCop rule for this check. But making sure that this is also enforced in unit tests.
        public void ImplementsStandardConstructors()
        {
            UnhandledException ex = new UnhandledException();

            // Assert that all the 3 constructors are implemented
            ConstructorInfo[] constructors = ex.GetType().GetConstructors(BindingFlags.Instance | BindingFlags.Public);

            Assert.GreaterThanOrEqualTo(constructors.Length, 3);

            foreach (ConstructorInfo item in constructors)
            {
                ParameterInfo[] parameters = item.GetParameters();
                
                Assert.LessThanOrEqualTo(parameters.Length, 2);

                if (parameters.Length == 1)
                {
                    Assert.AreEqual(typeof(String), parameters[0].ParameterType);
                }

                if (parameters.Length == 2)
                {
                    Assert.AreEqual(typeof(String), parameters[0].ParameterType);
                    Assert.AreEqual(typeof(Exception), parameters[1].ParameterType);
                }
            }

        }

        [Test]
        public void ReturnsCorrectDefaultErrorNumber()
        {
            UnhandledException ex = new UnhandledException();
            Assert.AreEqual(ex.ErrorNumber, 80112);
        }

        [Test] // Not so bright test
        public void ReturnsNonEmptyDetailedMessage()
        {
            UnhandledException ex = new UnhandledException();
            Assert.IsNotEmpty(ex.DetailedMessage);
        }

        [Test]
        public void ThrowsOnNullInnerException()
        {
            Assert.Throws(typeof(ArgumentNullException), new Gallio.Common.Action(delegate() { new UnhandledException(string.Empty, null); }));
        }

    }
}
