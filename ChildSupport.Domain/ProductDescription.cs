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
    public partial class ProductDescription
    {
        #region Primitive Properties
    
        public virtual int ProductDescriptionID
        {
            get;
            set;
        }
    
        public virtual string Description
        {
            get;
            set;
        }
    
        public virtual System.Guid rowguid
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
    
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures
        {
            get
            {
                if (_productModelProductDescriptionCultures == null)
                {
                    var newCollection = new FixupCollection<ProductModelProductDescriptionCulture>();
                    newCollection.CollectionChanged += FixupProductModelProductDescriptionCultures;
                    _productModelProductDescriptionCultures = newCollection;
                }
                return _productModelProductDescriptionCultures;
            }
            set
            {
                if (!ReferenceEquals(_productModelProductDescriptionCultures, value))
                {
                    var previousValue = _productModelProductDescriptionCultures as FixupCollection<ProductModelProductDescriptionCulture>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProductModelProductDescriptionCultures;
                    }
                    _productModelProductDescriptionCultures = value;
                    var newValue = value as FixupCollection<ProductModelProductDescriptionCulture>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProductModelProductDescriptionCultures;
                    }
                }
            }
        }
        private ICollection<ProductModelProductDescriptionCulture> _productModelProductDescriptionCultures;

        #endregion
        #region Association Fixup
    
        private void FixupProductModelProductDescriptionCultures(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProductModelProductDescriptionCulture item in e.NewItems)
                {
                    item.ProductDescription = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ProductModelProductDescriptionCulture item in e.OldItems)
                {
                    if (ReferenceEquals(item.ProductDescription, this))
                    {
                        item.ProductDescription = null;
                    }
                }
            }
        }

        #endregion
    }
}
