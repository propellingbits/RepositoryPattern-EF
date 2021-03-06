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
    public partial class CreditCard
    {
        #region Primitive Properties
    
        public virtual int CreditCardID
        {
            get;
            set;
        }
    
        public virtual string CardType
        {
            get;
            set;
        }
    
        public virtual string CardNumber
        {
            get;
            set;
        }
    
        public virtual byte ExpMonth
        {
            get;
            set;
        }
    
        public virtual short ExpYear
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
    
        public virtual ICollection<PersonCreditCard> PersonCreditCards
        {
            get
            {
                if (_personCreditCards == null)
                {
                    var newCollection = new FixupCollection<PersonCreditCard>();
                    newCollection.CollectionChanged += FixupPersonCreditCards;
                    _personCreditCards = newCollection;
                }
                return _personCreditCards;
            }
            set
            {
                if (!ReferenceEquals(_personCreditCards, value))
                {
                    var previousValue = _personCreditCards as FixupCollection<PersonCreditCard>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPersonCreditCards;
                    }
                    _personCreditCards = value;
                    var newValue = value as FixupCollection<PersonCreditCard>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPersonCreditCards;
                    }
                }
            }
        }
        private ICollection<PersonCreditCard> _personCreditCards;
    
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders
        {
            get
            {
                if (_salesOrderHeaders == null)
                {
                    var newCollection = new FixupCollection<SalesOrderHeader>();
                    newCollection.CollectionChanged += FixupSalesOrderHeaders;
                    _salesOrderHeaders = newCollection;
                }
                return _salesOrderHeaders;
            }
            set
            {
                if (!ReferenceEquals(_salesOrderHeaders, value))
                {
                    var previousValue = _salesOrderHeaders as FixupCollection<SalesOrderHeader>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupSalesOrderHeaders;
                    }
                    _salesOrderHeaders = value;
                    var newValue = value as FixupCollection<SalesOrderHeader>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupSalesOrderHeaders;
                    }
                }
            }
        }
        private ICollection<SalesOrderHeader> _salesOrderHeaders;

        #endregion
        #region Association Fixup
    
        private void FixupPersonCreditCards(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PersonCreditCard item in e.NewItems)
                {
                    item.CreditCard = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (PersonCreditCard item in e.OldItems)
                {
                    if (ReferenceEquals(item.CreditCard, this))
                    {
                        item.CreditCard = null;
                    }
                }
            }
        }
    
        private void FixupSalesOrderHeaders(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (SalesOrderHeader item in e.NewItems)
                {
                    item.CreditCard = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (SalesOrderHeader item in e.OldItems)
                {
                    if (ReferenceEquals(item.CreditCard, this))
                    {
                        item.CreditCard = null;
                    }
                }
            }
        }

        #endregion
    }
}
