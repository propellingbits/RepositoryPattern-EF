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
    public partial class Vendor
    {
        #region Primitive Properties
    
        public virtual int BusinessEntityID
        {
            get { return _businessEntityID; }
            set
            {
                if (_businessEntityID != value)
                {
                    if (BusinessEntity != null && BusinessEntity.BusinessEntityID != value)
                    {
                        BusinessEntity = null;
                    }
                    _businessEntityID = value;
                }
            }
        }
        private int _businessEntityID;
    
        public virtual string AccountNumber
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual byte CreditRating
        {
            get;
            set;
        }
    
        public virtual bool PreferredVendorStatus
        {
            get;
            set;
        }
    
        public virtual bool ActiveFlag
        {
            get;
            set;
        }
    
        public virtual string PurchasingWebServiceURL
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
    
        public virtual BusinessEntity BusinessEntity
        {
            get { return _businessEntity; }
            set
            {
                if (!ReferenceEquals(_businessEntity, value))
                {
                    var previousValue = _businessEntity;
                    _businessEntity = value;
                    FixupBusinessEntity(previousValue);
                }
            }
        }
        private BusinessEntity _businessEntity;
    
        public virtual ICollection<ProductVendor> ProductVendors
        {
            get
            {
                if (_productVendors == null)
                {
                    var newCollection = new FixupCollection<ProductVendor>();
                    newCollection.CollectionChanged += FixupProductVendors;
                    _productVendors = newCollection;
                }
                return _productVendors;
            }
            set
            {
                if (!ReferenceEquals(_productVendors, value))
                {
                    var previousValue = _productVendors as FixupCollection<ProductVendor>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProductVendors;
                    }
                    _productVendors = value;
                    var newValue = value as FixupCollection<ProductVendor>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProductVendors;
                    }
                }
            }
        }
        private ICollection<ProductVendor> _productVendors;
    
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders
        {
            get
            {
                if (_purchaseOrderHeaders == null)
                {
                    var newCollection = new FixupCollection<PurchaseOrderHeader>();
                    newCollection.CollectionChanged += FixupPurchaseOrderHeaders;
                    _purchaseOrderHeaders = newCollection;
                }
                return _purchaseOrderHeaders;
            }
            set
            {
                if (!ReferenceEquals(_purchaseOrderHeaders, value))
                {
                    var previousValue = _purchaseOrderHeaders as FixupCollection<PurchaseOrderHeader>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupPurchaseOrderHeaders;
                    }
                    _purchaseOrderHeaders = value;
                    var newValue = value as FixupCollection<PurchaseOrderHeader>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupPurchaseOrderHeaders;
                    }
                }
            }
        }
        private ICollection<PurchaseOrderHeader> _purchaseOrderHeaders;

        #endregion
        #region Association Fixup
    
        private void FixupBusinessEntity(BusinessEntity previousValue)
        {
            if (previousValue != null && ReferenceEquals(previousValue.Vendor, this))
            {
                previousValue.Vendor = null;
            }
    
            if (BusinessEntity != null)
            {
                BusinessEntity.Vendor = this;
                if (BusinessEntityID != BusinessEntity.BusinessEntityID)
                {
                    BusinessEntityID = BusinessEntity.BusinessEntityID;
                }
            }
        }
    
        private void FixupProductVendors(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProductVendor item in e.NewItems)
                {
                    item.Vendor = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ProductVendor item in e.OldItems)
                {
                    if (ReferenceEquals(item.Vendor, this))
                    {
                        item.Vendor = null;
                    }
                }
            }
        }
    
        private void FixupPurchaseOrderHeaders(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (PurchaseOrderHeader item in e.NewItems)
                {
                    item.Vendor = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (PurchaseOrderHeader item in e.OldItems)
                {
                    if (ReferenceEquals(item.Vendor, this))
                    {
                        item.Vendor = null;
                    }
                }
            }
        }

        #endregion
    }
}
