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
    public partial class TransactionHistoryArchive
    {
        #region Primitive Properties
    
        public virtual int TransactionID
        {
            get;
            set;
        }
    
        public virtual int ProductID
        {
            get;
            set;
        }
    
        public virtual int ReferenceOrderID
        {
            get;
            set;
        }
    
        public virtual int ReferenceOrderLineID
        {
            get;
            set;
        }
    
        public virtual System.DateTime TransactionDate
        {
            get;
            set;
        }
    
        public virtual string TransactionType
        {
            get;
            set;
        }
    
        public virtual int Quantity
        {
            get;
            set;
        }
    
        public virtual decimal ActualCost
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
    }
}
