using System.Collections;
using MbUnit.Framework;
using Framework.Validation.Ssn;


namespace Validation.Tests
{
    /// <summary>
    ///This is a test class for SsnValidationLogicTest and is intended
    ///to contain all SsnValidationLogicTest Unit Tests
    ///</summary>
    [TestFixture, Parallelizable]
    public class SsnValidationLogicTest
    {

        [Test(), Parallelizable]
        public void ShouldThrowSsnFormatException()
        {
            var ex = Assert.Throws<InvalidSsnException>(() =>
                SsnValidationLogic.Validate(TestSsn.FormatInvalid));
            Assert.IsTrue(ex.Data.Contains(TestSsn.SsnFormatExceptionKey));
        }

        [Test(), Parallelizable]
        public void ShouldThrowSsnAreaNumberException()
        {
            //var ex = Assert.Throws<InvalidSsnException>(() => SsnValidationLogic.Validate("666011111"));
            var ex = Assert.Throws<InvalidSsnException>(() =>
                SsnValidationLogic.Validate(TestSsn.AreaNumberInvalid));
            foreach (DictionaryEntry validationResult in ex.Data)
            {
                if (validationResult.Key.ToString().Contains(TestSsn.SsnAreaNumberExceptionKey))
                {
                    Assert.AreEqual("The SSN area number \'666\' is not valid.", validationResult.Value);

                }
            }
        }

        [Test(), Parallelizable]
        public void ShouldThrowExceptionOnInvalidLowOddGroupNumber()
        {
            var ex = Assert.Throws<InvalidSsnException>(() => 
                SsnValidationLogic.Validate(TestSsn.InvalidLowOddGroupNumber));
            
            foreach (DictionaryEntry validationResult in ex.Data)
                {
                    if (validationResult.Key.ToString().Contains(TestSsn.SsnGroupNumberExceptionKey))
                    {
                        Assert.AreEqual("The SSN group number \'02\' is not valid.", validationResult.Value);
                    }

                }
        }

        [Test(), Parallelizable]
        public void ShouldThrowExceptionOnInvalidLowEvenGroupNumber()
        {
            var ex = Assert.Throws<InvalidSsnException>(() =>
                    SsnValidationLogic.Validate(TestSsn.InvalidLowEvenGroupNumber));
            //Key token {3} is for SsnGroupNumberException.
            Assert.IsTrue(ex.Data.Contains(TestSsn.SsnGroupNumberExceptionKey));
        }

        [Test(), Parallelizable]
        public void ShouldThrowExceptionOnInvalidHighOddGroupNumber()
        {
            var ex = Assert.Throws<InvalidSsnException>(() =>
                        SsnValidationLogic.Validate(TestSsn.InvalidHighOddGroupNumber));
            //Key token {3} is for SsnGroupNumberException.
            Assert.IsTrue(ex.Data.Contains(TestSsn.SsnGroupNumberExceptionKey));
        }

        [Test(), Parallelizable]
        public void ShouldThrowExceptionOnInvalidHighEvenGroupNumber()
        {
            var ex = Assert.Throws<InvalidSsnException>(() =>
                SsnValidationLogic.Validate(TestSsn.InvalidHighEvenGroupNumber));
            //Key token {3} is for SsnGroupNumberException.
            Assert.IsTrue(ex.Data.Contains(TestSsn.SsnGroupNumberExceptionKey));
        }

        [Test(), Parallelizable]
        public void ShouldNotThrowExceptionOnValidLowOddGroupNumber()
        {
            Assert.DoesNotThrow(() =>
                SsnValidationLogic.Validate(TestSsn.ValidLowOddGroupNumber));
        }

        [Test(), Parallelizable]
        public void ShouldNotThrowExceptionOnValidHighOddGroupNumber()
        {
            Assert.DoesNotThrow(() =>
                SsnValidationLogic.Validate(TestSsn.ValidHighOddGroupNumber));
        }

        [Test(), Parallelizable]
        public void ShouldNotThrowExceptionOnValidLowEvenGroupNumber()
        {
            Assert.DoesNotThrow(() =>
                SsnValidationLogic.Validate(TestSsn.ValidLowEvenGroupNumber));
        }

        [Test(), Parallelizable]
        public void ShouldNotThrowExceptionOnValidHighEvenGroupNumber()
        {
            Assert.DoesNotThrow(() =>
                SsnValidationLogic.Validate(TestSsn.ValidHighEvenGroupNumber));
        }




        /// <summary>
        /// To verify the area number SerialNumberException.
        /// </summary>
        [Test(), Parallelizable]
        public void ShouldThrowSsnSerialNumberException()
        {
            var ex = Assert.Throws<InvalidSsnException>(() =>
                SsnValidationLogic.Validate(TestSsn.SerialNumberInvalid));

            foreach (DictionaryEntry validationResult in ex.Data)
            {
                //validationResults.AddResult(new ValidationResult(message, currentTarget, errorKey, Tag, this));
                if (validationResult.Key.ToString().Contains(TestSsn.SsnSerialNumberExceptionKey))
                {
                    Assert.AreEqual("The SSN serial number \'0000\' is not valid.", validationResult.Value);
                }

            }

        }


        /// <summary>
        /// To verify the area number InvalidatedBySsa.
        /// </summary>
        [Test(), Parallelizable]
        public void ShouldThrowSsnInvalidatedBySsaException()
        {
            var ex = Assert.Throws<InvalidSsnException>(() =>
                    SsnValidationLogic.Validate(TestSsn.InvalidatedBySsa));
            foreach (DictionaryEntry validationResult in ex.Data)
            {
                if (validationResult.Key.ToString().Contains(TestSsn.SsnInvalidatedBySsaExceptionKey))
                {
                    Assert.AreSame(TestSsn.SsnInvalidatedBySsaException, validationResult.Value);
                }
            }
        }

        [Test, ThreadedRepeat(25)]
        public void IsValid_WithInvalidSsnFollowedByValidOne_ReturnsTrue()
        {
            Assert.Throws<InvalidSsnException>(() =>
                SsnValidationLogic.Validate(TestSsn.SerialNumberInvalid));

            Assert.DoesNotThrow(() => SsnValidationLogic.Validate(TestSsn.ValidLowOddGroupNumber));
        }


    }
}
