using System;
using Framework.Validation.Validators;
using MbUnit.Framework;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Validation.Tests
{

    [TestFixture(), Parallelizable()]
    public class IgnoreNullPropertyComparisonValidatorTests
    {


        [Test()]

        public void Validate_NullProperty_IsValid()
        {
            TestObject testObj = new TestObject();
            Assert.IsNull(testObj.EndDate);

            ValidationResults results = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate(testObj);
            Assert.AreEqual(0, results.Count);
            Assert.IsTrue(results.IsValid);

        }

        [Test()]

        public void Validate_EndDateGTBeginDate_IsValid()
        {
            TestObject testObj = new TestObject { EndDate = DateTime.UtcNow.AddDays(1) };

            ValidationResults results = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate(testObj);
            Assert.AreEqual(0, results.Count);
            Assert.IsTrue(results.IsValid);

        }

        [Test()]

        public void Validate_EndDateLTBeginDate_IsValid()
        {
            TestObject testObj = new TestObject { EndDate = DateTime.UtcNow.AddDays(-1) };

            ValidationResults results = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate(testObj);
            Assert.AreEqual(1, results.Count);
            Assert.IsFalse(results.IsValid);

        }


        public class TestObject
        {

            private System.DateTime _beginDate = DateTime.Now;
            public System.DateTime BeginDate
            {
                get { return _beginDate; }
                set { _beginDate = value; }
            }

            private Nullable<DateTime> _endDate;

            [IgnoreNullPropertyComparisonValidator("BeginDate", ComparisonOperator.GreaterThan)]
            public Nullable<DateTime> EndDate
            {
                get { return _endDate; }
                set { _endDate = value; }
            }

        }

    }
}