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
    public partial class ProductModel
    {
        #region Primitive Properties
    
        public virtual int ProductModelID
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual string CatalogDescription
        {
            get;
            set;
        }
    
        public virtual string Instructions
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
    
        public virtual ICollection<Product> Products
        {
            get
            {
                if (_products == null)
                {
                    var newCollection = new FixupCollection<Product>();
                    newCollection.CollectionChanged += FixupProducts;
                    _products = newCollection;
                }
                return _products;
            }
            set
            {
                if (!ReferenceEquals(_products, value))
                {
                    var previousValue = _products as FixupCollection<Product>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProducts;
                    }
                    _products = value;
                    var newValue = value as FixupCollection<Product>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProducts;
                    }
                }
            }
        }
        private ICollection<Product> _products;
    
        public virtual ICollection<ProductModelIllustration> ProductModelIllustrations
        {
            get
            {
                if (_productModelIllustrations == null)
                {
                    var newCollection = new FixupCollection<ProductModelIllustration>();
                    newCollection.CollectionChanged += FixupProductModelIllustrations;
                    _productModelIllustrations = newCollection;
                }
                return _productModelIllustrations;
            }
            set
            {
                if (!ReferenceEquals(_productModelIllustrations, value))
                {
                    var previousValue = _productModelIllustrations as FixupCollection<ProductModelIllustration>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProductModelIllustrations;
                    }
                    _productModelIllustrations = value;
                    var newValue = value as FixupCollection<ProductModelIllustration>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProductModelIllustrations;
                    }
                }
            }
        }
        private ICollection<ProductModelIllustration> _productModelIllustrations;
    
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
    
        private void FixupProducts(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Product item in e.NewItems)
                {
                    item.ProductModel = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Product item in e.OldItems)
                {
                    if (ReferenceEquals(item.ProductModel, this))
                    {
                        item.ProductModel = null;
                    }
                }
            }
        }
    
        private void FixupProductModelIllustrations(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProductModelIllustration item in e.NewItems)
                {
                    item.ProductModel = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ProductModelIllustration item in e.OldItems)
                {
                    if (ReferenceEquals(item.ProductModel, this))
                    {
                        item.ProductModel = null;
                    }
                }
            }
        }
    
        private void FixupProductModelProductDescriptionCultures(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProductModelProductDescriptionCulture item in e.NewItems)
                {
                    item.ProductModel = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ProductModelProductDescriptionCulture item in e.OldItems)
                {
                    if (ReferenceEquals(item.ProductModel, this))
                    {
                        item.ProductModel = null;
                    }
                }
            }
        }

        #endregion
    }
}
