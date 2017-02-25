using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;
using Framework.Collections.Generic;


namespace Framework.Validation.Ssn
{

    /// <summary>
    /// The SSN validation logic, as a singleton.
    /// </summary>
    public sealed class SsnValidationLogic : ISsnValidationLogic
    {
        /// <summary>
        /// A Regex for valid SSN format.
        /// </summary>
        private static readonly Regex regEx = new Regex(@"^([0-6]\d{2}|7([0-6]\d|7[012]))([ -]?)(?!00)\d\d\3\d{4}$");

        /// <summary>
        /// Dictionary&lt;byte, byte&gt; of SSN group numbers, sequenced as follows: odd numbers
        /// from 1 to 9, even numbers from 10 to 98, even numbers from 2 to 8, and odd
        /// numbers from 11 to 99.
        /// </summary>
        private static readonly Dictionary<byte, byte> _ssnGroupNumbers =
            new Dictionary<byte, byte>(99);

        private static readonly HashSet<String> _invalidatedSsns =
            new HashSet<String>() { "078051120" };

        /// <summary>
        /// For a given SSN number, contains one or more validation results.
        /// </summary>
        private static readonly SynchronizedDictionary<string, Dictionary<string, string>> _results =
            new SynchronizedDictionary<string, Dictionary<string, string>>();


        /// <summary>
        /// Calls <see cref="LoadSsnGroupNumbers"/> to initialize the class.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline",
         Justification = "The operation performed is dependent on the database.  Better to do it here should there be a runtime error.")]
        static SsnValidationLogic()
        {
            SsnValidationLogic.LoadSsnGroupNumbers();
        }

        /// <summary>
        /// Load the <see cref="_ssnGroupNumbers"/> dictionary with the sequence
        /// of group numbers as it is defined by the Social Security Administration.
        /// </summary>
        private static void LoadSsnGroupNumbers()
        {
            byte rank = 0;

            // Low Odd Group Numbers range defined as 01 <= X <= 09
            // This group is assigned FIRST by the SSA (01, 03, ..., 07, 09)
            for (byte i = 1; i <= 9; i += 2)
            {
                _ssnGroupNumbers.Add(i, ++rank);
            }

            // High Even Group Numbers range defined as 10 <= X <= 98
            // This group is assigned SECOND by the SSA (10, 12, ..., 96, 98)
            for (byte i = 10; i <= 98; i += 2)
            {
                _ssnGroupNumbers.Add(i, ++rank);
            }

            // Low Even Group Numbers range defined as 02 <= X <= 08
            // This group is assigned THIRD by the SSA (02, 04, ..., 06, 08)
            for (byte i = 2; i <= 8; i += 2)
            {
                _ssnGroupNumbers.Add(i, ++rank);
            }

            // High Odd Group Numbers range defined as 11 <= X <= 99
            // This group is assigned FOURTH by the SSA (11, 13, ..., 97, 99)
            for (byte i = 11; i <= 99; i += 2)
            {
                _ssnGroupNumbers.Add(i, ++rank);
            }
        }

        /// <summary>
        /// Private instance constructor to prevent construction of instances. This
        /// class is intended as a singleton.
        /// </summary>
        private SsnValidationLogic() { }

        /// <summary>
        /// Point of entry for the SSN validation logic.
        /// </summary>
        /// <param name="ssn">A social security number as a string.</param>
        /// <returns><value>true</value> if the SSN is valid.</returns>
        /// <exception cref="InvalidSsnException">Thrown if the SSN is not valid.</exception>
        public static void Validate(String ssn)
        {
            //Replace 
            String cleanedSsn = ssn.Replace(" ", "");
            cleanedSsn = cleanedSsn.Replace("-", "");

            //Set to default values.           
            bool _validSsnSerialNumber = false;
            bool _validSsnAreaNumber = false;
            bool _validSsnGroupNumber = false;
            bool _validSsnNotSsaInvalidated = false;

            if (_results.ContainsKey(cleanedSsn))
                RemoveResults(cleanedSsn);

            //Step 1: To make sure Ssn format.
            //if ssn having valid format go for below validations.
            if (ValidateSsnFormat(cleanedSsn))
            {
                //Step 2: Check for validated Area number.
                //Check for valid area number.
                if (ValidateSsnAreaNumber(cleanedSsn))
                {
                    _validSsnAreaNumber = true;

                    //Step 3: Check for validated group number.
                    //Check for valid group number.
                    if (ValidateSsnGroupNumber(cleanedSsn))
                    {
                        _validSsnGroupNumber = true;
                    }
                }


                //Step 4: Check for validateSsnNotSsaInvalidated 
                //dependent on both area and group numbers.
                if (_validSsnAreaNumber && _validSsnGroupNumber)
                {
                    if (ValidateSsnNotSsaInvalidated(cleanedSsn))
                    {
                        _validSsnNotSsaInvalidated = true;
                    }
                }

                //Step 2: Check for Serial number.
                //Check for Valid Serial number - independent
                if (ValidateSsnSerialNumber(cleanedSsn))
                {
                    _validSsnSerialNumber = true;
                }

            }


            //Step 5: Final step.
            //Return true or false based on the above.
            if (_validSsnSerialNumber &&
                _validSsnAreaNumber &&
                _validSsnGroupNumber &&
                _validSsnNotSsaInvalidated)
            {
                return;
            }
            else
            {
                if (_results.ContainsKey(cleanedSsn) && _results[cleanedSsn].Count > 0)
                    throw new InvalidSsnException(_results[cleanedSsn]);
                throw new InvalidSsnException();
            }


        }

        /// <summary>
        /// Uses the SsnHighGroupNumbers.AreaNumberExists method to determine whether the
        /// area number of the SSN is valid or not.
        /// </summary>
        /// <param name="ssn"></param>
        private static Boolean ValidateSsnAreaNumber(String ssn)
        {

            string areaNumber = ssn.Substring(0, 3);
            if (SsnHighGroupNumbers.AreaNumberExists(areaNumber)) return true;

            AddResults(ssn, "SSN:Area Number", String.Format(CultureInfo.InvariantCulture, SsnValidationResult.SsnAreaNumberException, areaNumber));
            return false;
        }

        /// <summary>
        /// Validates the format of the SSN provided using the regular expression pattern 
        /// Either 
        ///     first character - 0 to 6
        ///     next two characters - 0 to 9
        /// or
        ///     first character is 7
        ///     and either 
        ///         second character is 0 to 6
        ///         third character is 0 to 9
        ///     or
        ///         second character is 7
        ///         third character is either 0, 1, or 2
        /// fourth and fifth characters cannot be SPACE and DASH combination
        /// fourth and fifth characters cannot be 00
        /// fourth character is 0 to 9
        /// fifth character is 0 to 9
        /// sixth character is 0 to 9
        /// seventh character is 0 to 9
        /// eighth character is 0 to 9
        /// ninth character is 0 to 9
        /// 
        /// </summary>
        /// <param name="ssn"></param>
        private static Boolean ValidateSsnFormat(String ssn)
        {
            if (regEx.IsMatch(ssn)) return true;

            AddResults(ssn, "SSN:Format", SsnValidationResult.SsnFormatException);
            return false;
        }


        /// <summary>
        /// Uses the SsnHighGroupNumbers.GetHighGroupNumber() method to get the high group
        /// number for a given area number.  Uses the returned high group number to
        /// determine its rank as provided by the value of _ssnGroupNumbers and compare it
        /// to the rank of the group number of the SSN being validated.  The rank of the
        /// SSN's group number should be lower or equal to the rank of the high group
        /// number given the SSN's area number.
        /// </summary>
        /// <param name="ssn"></param>
        private static Boolean ValidateSsnGroupNumber(String ssn)
        {
            String ssnAreaNumber = ssn.Substring(0, 3);
            //Get the current group number from SsnHighGroupNumbers for the areaNumber
            byte areaNumberHighGroupNumber = SsnHighGroupNumbers.GetHighGroupNumbers(ssnAreaNumber);
            //Get the rank for the HighGroupNumbers of the areaNumber
            byte areaNumberRank = _ssnGroupNumbers[areaNumberHighGroupNumber];

            //Get the rank for given ssn group number
            byte ssnGroupNumber = byte.Parse(ssn.Substring(3, 2), CultureInfo.InvariantCulture);
            byte ssnGroupNumberRank = _ssnGroupNumbers[ssnGroupNumber];

            //Compare both ranks
            //If the given ssn rank is lower or equal to the area code rank.
            if (ssnGroupNumberRank <= areaNumberRank) return true;

            AddResults(ssn, "SSN:Group Number", 
                String.Format(CultureInfo.InvariantCulture, SsnValidationResult.SsnGroupNumberException, ssnGroupNumber));
            return false;
        }


        /// <summary>
        /// Determines whether or not the SSN has been invalidated by the
        /// Soical Security Administration.
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns></returns>
        private static bool ValidateSsnNotSsaInvalidated(String ssn)
        {
            if (SsnValidationLogic._invalidatedSsns.Contains(ssn))
            {
                AddResults(ssn, "SSN", SsnValidationResult.SsnInvalidatedBySsaException);
                return false;
            }

            return true;
        }


        /// <summary>
        /// Determines whether or not the SSN serial number is valid or not.
        /// </summary>
        /// <param name="ssn"></param>
        /// <returns></returns>
        private static Boolean ValidateSsnSerialNumber(String ssn)
        {
            var ssnSerialNumber = Int16.Parse(ssn.Substring(5, 4), CultureInfo.InvariantCulture);
            if (ssnSerialNumber >= 1 && ssnSerialNumber <= 9999) return true;

            AddResults(ssn, "SSN:Serial Number", 
                String.Format(CultureInfo.InvariantCulture, SsnValidationResult.SsnSerialNumberException, ssnSerialNumber));
            return false;
        }

        private static void AddResults(string ssn, string resultKey, string resultMessage)
        {
            if (_results.ContainsKey(ssn))
            {
                if (_results[ssn] == null) _results[ssn] = new Dictionary<string, string>();
            }
            else
            {
                _results.Add(ssn, new Dictionary<string, string>());
            }
            if (!_results[ssn].ContainsKey(resultKey))
                _results[ssn].Add(resultKey, resultMessage);
        }

        private static void RemoveResults(string ssn)
        {
            if (_results.ContainsKey(ssn))
                _results.Remove(ssn);
        }



        #region ISsnValidationLogic Members

        void ISsnValidationLogic.Validate(string ssn)
        {
            Validate(ssn);
        }

        #endregion
    }
}