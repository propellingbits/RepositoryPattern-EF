using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Framework.Validation.Validators;
using MbUnit.Framework;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Validation.Tests
{

    [TestFixture(), Parallelizable()]
    public class CollectionCountValidatorTests
    {

        [Test()]

        public void DoValidate_WithinBounds_IsValid()
        {
            CollectionCountValidator validator = new CollectionCountValidator(upperBound: 10);
            ValidationResults results = validator.Validate(GetCollection(numberOfItems: 2));

            Assert.IsTrue(results.IsValid);
            Assert.AreEqual(0, results.Count);

        }

        [Test()]

        public void DoValidate_OverUpperBound_ReturnsExpectedMessage()
        {
            CollectionCountValidator validator = new CollectionCountValidator(upperBound: 1);
            ValidationResults results = validator.Validate(GetCollection(numberOfItems: 2));

            string expectedMessage = "System.Collections.Generic.List`1[System.Object] on property TestProperty should contain between 0 (Ignore) and 1 (Inclusive) elements, but it contains 2 elements.";
            string actualMessage = results.Single(x => (x.Validator) is CollectionCountValidator).Message;

            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(expectedMessage, actualMessage);

        }

        [Test()]

        public void DoValidate_UnderLowerBound_ReturnsExpectedMessage()
        {
            CollectionCountValidator validator = new CollectionCountValidator(5, 10);
            ValidationResults results = validator.Validate(GetCollection(numberOfItems: 2));

            string expectedMessage = "System.Collections.Generic.List`1[System.Object] on property TestProperty should contain between 5 (Inclusive) and 10 (Inclusive) elements, but it contains 2 elements.";
            string actualMessage = results.Single(x => (x.Validator) is CollectionCountValidator).Message;

            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(expectedMessage, actualMessage);

        }

        [Test()]

        public void DoValidate_NegatedWithinBounds_ReturnsExpectedMessage()
        {
            CollectionCountValidator validator = new CollectionCountValidator(5, 10, true);
            ValidationResults results = validator.Validate(GetCollection(numberOfItems: 7));

            string expectedMessage = "System.Collections.Generic.List`1[System.Object] on property TestProperty should contain fewer than 5 (Inclusive) or more than 10 (Inclusive) elements, but it contains 7 elements.";
            string actualMessage = results.Single(x => (x.Validator) is CollectionCountValidator).Message;

            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(expectedMessage, actualMessage);

        }

        [Test()]

        public void DoValidate_NegatedOverUpperBound_IsValid()
        {
            CollectionCountValidator validator = new CollectionCountValidator(5, 10, true);
            ValidationResults results = validator.Validate(GetCollection(numberOfItems: 11));

            Assert.IsTrue(results.IsValid);
            Assert.AreEqual(0, results.Count);

        }

        [Test()]

        public void DoValidate_NegatedUnderLowerBound_IsValid()
        {
            CollectionCountValidator validator = new CollectionCountValidator(5, 10, true);
            ValidationResults results = validator.Validate(GetCollection(numberOfItems: 4));

            Assert.IsTrue(results.IsValid);
            Assert.AreEqual(0, results.Count);

        }

        [Test()]

        public void DoValidate_CustomMessageTemplate_ReturnsExpectedMessage()
        {
            string messageTemplate = "The collection should contain no more than {4} elements, but it contains {6} elements.";

            CollectionCountValidator validator = new CollectionCountValidator(0, RangeBoundaryType.Inclusive, 2, RangeBoundaryType.Inclusive, messageTemplate);
            ValidationResults results = validator.Validate(GetCollection(numberOfItems: 3));

            string expectedMessage = "The collection should contain no more than 2 elements, but it contains 3 elements.";
            string actualMessage = results.Single(x => (x.Validator) is CollectionCountValidator).Message;

            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(expectedMessage, actualMessage);

        }

        private static ICollection GetCollection(int numberOfItems)
        {

            List<object> theCollection = new List<object>(numberOfItems);

            for (int counter = 1; counter <= numberOfItems; counter++)
            {
                theCollection.Add(new object());
            }

            return theCollection;

        }
    }
}