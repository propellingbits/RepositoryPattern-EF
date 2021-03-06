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
    public partial class ProductPhoto
    {
        #region Primitive Properties
    
        public virtual int ProductPhotoID
        {
            get;
            set;
        }
    
        public virtual byte[] ThumbNailPhoto
        {
            get;
            set;
        }
    
        public virtual string ThumbnailPhotoFileName
        {
            get;
            set;
        }
    
        public virtual byte[] LargePhoto
        {
            get;
            set;
        }
    
        public virtual string LargePhotoFileName
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
    
        public virtual ICollection<ProductProductPhoto> ProductProductPhotoes
        {
            get
            {
                if (_productProductPhotoes == null)
                {
                    var newCollection = new FixupCollection<ProductProductPhoto>();
                    newCollection.CollectionChanged += FixupProductProductPhotoes;
                    _productProductPhotoes = newCollection;
                }
                return _productProductPhotoes;
            }
            set
            {
                if (!ReferenceEquals(_productProductPhotoes, value))
                {
                    var previousValue = _productProductPhotoes as FixupCollection<ProductProductPhoto>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProductProductPhotoes;
                    }
                    _productProductPhotoes = value;
                    var newValue = value as FixupCollection<ProductProductPhoto>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProductProductPhotoes;
                    }
                }
            }
        }
        private ICollection<ProductProductPhoto> _productProductPhotoes;

        #endregion
        #region Association Fixup
    
        private void FixupProductProductPhotoes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ProductProductPhoto item in e.NewItems)
                {
                    item.ProductPhoto = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ProductProductPhoto item in e.OldItems)
                {
                    if (ReferenceEquals(item.ProductPhoto, this))
                    {
                        item.ProductPhoto = null;
                    }
                }
            }
        }

        #endregion
    }
}
