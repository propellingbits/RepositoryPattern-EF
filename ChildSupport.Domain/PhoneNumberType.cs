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
    public partial class PhoneNumberType
    {
        #region Primitive Properties
    
        public virtual int PhoneNumberTypeID
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual System.DateTime ModifiedDate
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<PersonPhone> PersonPhones
        {
            get
            {
                if (_personPhones == null)
                {
                    var newCollection = new FixupCollection<PersonPhone>();
                    newCollection.CollectionChanged += FixupPersonPhones;
                    _personPhones = newCollection;
                }
                return _personPhones;
            }
            set
            {
                if (!ReferenceEquals(_personPhones, value))
                {
                    var previousValue = _personPhones as FixupCollection<PersonPhone>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPersonPhones;
                    }
                    _personPhones = value;
                    var newValue = value as FixupCollection<PersonPhone>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPersonPhones;
                    }
                }
            }
        }
        private ICollection<PersonPhone> _personPhones;

        #endregion
        #region Association Fixup
    
        private void FixupPersonPhones(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PersonPhone item in e.NewItems)
                {
                    item.PhoneNumberType = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (PersonPhone item in e.OldItems)
                {
                    if (ReferenceEquals(item.PhoneNumberType, this))
                    {
                        item.PhoneNumberType = null;
                    }
                }
            }
        }

        #endregion
    }
}
