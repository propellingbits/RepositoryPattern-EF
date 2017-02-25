//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ChildSupport.Domain
{
    public partial class PersonPhone
    {
        #region Primitive Properties
    
        public virtual int BusinessEntityID
        {
            get { return _businessEntityID; }
            set
            {
                if (_businessEntityID != value)
                {
                    if (Person != null && Person.BusinessEntityID != value)
                    {
                        Person = null;
                    }
                    _businessEntityID = value;
                }
            }
        }
        private int _businessEntityID;
    
        public virtual string PhoneNumber
        {
            get;
            set;
        }
    
        public virtual int PhoneNumberTypeID
        {
            get { return _phoneNumberTypeID; }
            set
            {
                if (_phoneNumberTypeID != value)
                {
                    if (PhoneNumberType != null && PhoneNumberType.PhoneNumberTypeID != value)
                    {
                        PhoneNumberType = null;
                    }
                    _phoneNumberTypeID = value;
                }
            }
        }
        private int _phoneNumberTypeID;
    
        public virtual System.DateTime ModifiedDate
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual Person Person
        {
            get { return _person; }
            set
            {
                if (!ReferenceEquals(_person, value))
                {
                    var previousValue = _person;
                    _person = value;
                    FixupPerson(previousValue);
                }
            }
        }
        private Person _person;
    
        public virtual PhoneNumberType PhoneNumberType
        {
            get { return _phoneNumberType; }
            set
            {
                if (!ReferenceEquals(_phoneNumberType, value))
                {
                    var previousValue = _phoneNumberType;
                    _phoneNumberType = value;
                    FixupPhoneNumberType(previousValue);
                }
            }
        }
        private PhoneNumberType _phoneNumberType;

        #endregion
        #region Association Fixup
    
        private void FixupPerson(Person previousValue)
        {
            if (previousValue != null && previousValue.PersonPhones.Contains(this))
            {
                previousValue.PersonPhones.Remove(this);
            }
    
            if (Person != null)
            {
                if (!Person.PersonPhones.Contains(this))
                {
                    Person.PersonPhones.Add(this);
                }
                if (BusinessEntityID != Person.BusinessEntityID)
                {
                    BusinessEntityID = Person.BusinessEntityID;
                }
            }
        }
    
        private void FixupPhoneNumberType(PhoneNumberType previousValue)
        {
            if (previousValue != null && previousValue.PersonPhones.Contains(this))
            {
                previousValue.PersonPhones.Remove(this);
            }
    
            if (PhoneNumberType != null)
            {
                if (!PhoneNumberType.PersonPhones.Contains(this))
                {
                    PhoneNumberType.PersonPhones.Add(this);
                }
                if (PhoneNumberTypeID != PhoneNumberType.PhoneNumberTypeID)
                {
                    PhoneNumberTypeID = PhoneNumberType.PhoneNumberTypeID;
                }
            }
        }

        #endregion
    }
}