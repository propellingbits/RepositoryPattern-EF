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
    public partial class ProductReview
    {
        #region Primitive Properties
    
        public virtual int ProductReviewID
        {
            get;
            set;
        }
    
        public virtual int ProductID
        {
            get { return _productID; }
            set
            {
                if (_productID != value)
                {
                    if (Product != null && Product.ProductID != value)
                    {
                        Product = null;
                    }
                    _productID = value;
                }
            }
        }
        private int _productID;
    
        public virtual string ReviewerName
        {
            get;
            set;
        }
    
        public virtual System.DateTime ReviewDate
        {
            get;
            set;
        }
    
        public virtual string EmailAddress
        {
            get;
            set;
        }
    
        public virtual int Rating
        {
            get;
            set;
        }
    
        public virtual string Comments
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
    
        public virtual Product Product
        {
            get { return _product; }
            set
            {
                if (!ReferenceEquals(_product, value))
                {
                    var previousValue = _product;
                    _product = value;
                    FixupProduct(previousValue);
                }
            }
        }
        private Product _product;

        #endregion
        #region Association Fixup
    
        private void FixupProduct(Product previousValue)
        {
            if (previousValue != null && previousValue.ProductReviews.Contains(this))
            {
                previousValue.ProductReviews.Remove(this);
            }
    
            if (Product != null)
            {
                if (!Product.ProductReviews.Contains(this))
                {
                    Product.ProductReviews.Add(this);
                }
                if (ProductID != Product.ProductID)
                {
                    ProductID = Product.ProductID;
                }
            }
        }

        #endregion
    }
}
