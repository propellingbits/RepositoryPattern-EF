using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Reflection;

namespace Framework.Tests.Exceptions
{
    [TestFixture]
    [Author("Pradeep", "c-ppanthul@state.pa.us")]
    public class UnhandledMscorlibExceptionTests
    {
        [Test] // there is already an FxCop rule for this check. But making sure that this is also enforced in unit tests.
        public void ImplementsStandardConstructors()
        {
            UnhandledMscorlibException ex = new UnhandledMscorlibException();

            // Assert that all the 3 constructors are implemented
            ConstructorInfo[] constructors = ex.GetType().GetConstructors(BindingFlags.Instance | BindingFlags.Public);

            Assert.GreaterThanOrEqualTo(constructors.Length, 3);

            Array.ForEach(constructors, item =>
            {
                ParameterInfo[] parameters = item.GetParameters();
                Assert.LessThanOrEqualTo(parameters.Length, 2);
                if (parameters.Length == 1)
                    Assert.AreEqual(typeof(String), parameters[0].ParameterType);
                if (parameters.Length == 2)
                {
                    Assert.AreEqual(typeof(String), parameters[0].ParameterType);
                    Assert.AreEqual(typeof(Exception), parameters[1].ParameterType);
                }
            });

        }

        [Test]
        public void ReturnsCorrectDefaultErrorNumber()
        {
            UnhandledMscorlibException ex = new UnhandledMscorlibException();
            Assert.AreEqual(ex.ErrorNumber, 80112);
        }

        [Test] 
        public void ReturnsNonEmptyDetailedMessage()
        {
            UnhandledMscorlibException ex = new UnhandledMscorlibException();
            Assert.IsNotEmpty(ex.DetailedMessage);
        }

        [Test]
        public void ThrowsOnNullInnerException()
        {  
            Assert.Throws(typeof(ArgumentNullException), new Gallio.Common.Action(delegate() { new UnhandledMscorlibException(string.Empty, null); }));
        }


        [Test]
        public void ProcessesReflectionTypeLoadException()
        {
            ReflectionTypeLoadException exception = new ReflectionTypeLoadException(new Type[]{typeof(string), typeof(Object )},new Exception[]{new NullReferenceException(), new InvalidCastException ()});
            UnhandledMscorlibException ex = new UnhandledMscorlibException("Typeload exception", exception);
            Assert.IsNotEmpty(ex.HelpLink);
            Assert.IsNotEmpty(ex.DetailedMessage);
            Assert.AreEqual(80114, ex.ErrorNumber);
            Assert.Contains(ex.ToString(), "NullReferenceException");
            Assert.Contains(ex.ToString(), "InvalidCastException");
        }
    }
}
