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
    public partial class Shift
    {
        #region Primitive Properties
    
        public virtual byte ShiftID
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual System.TimeSpan StartTime
        {
            get;
            set;
        }
    
        public virtual System.TimeSpan EndTime
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
    
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories
        {
            get
            {
                if (_employeeDepartmentHistories == null)
                {
                    var newCollection = new FixupCollection<EmployeeDepartmentHistory>();
                    newCollection.CollectionChanged += FixupEmployeeDepartmentHistories;
                    _employeeDepartmentHistories = newCollection;
                }
                return _employeeDepartmentHistories;
            }
            set
            {
                if (!ReferenceEquals(_employeeDepartmentHistories, value))
                {
                    var previousValue = _employeeDepartmentHistories as FixupCollection<EmployeeDepartmentHistory>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupEmployeeDepartmentHistories;
                    }
                    _employeeDepartmentHistories = value;
                    var newValue = value as FixupCollection<EmployeeDepartmentHistory>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupEmployeeDepartmentHistories;
                    }
                }
            }
        }
        private ICollection<EmployeeDepartmentHistory> _employeeDepartmentHistories;

        #endregion
        #region Association Fixup
    
        private void FixupEmployeeDepartmentHistories(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (EmployeeDepartmentHistory item in e.NewItems)
                {
                    item.Shift = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (EmployeeDepartmentHistory item in e.OldItems)
                {
                    if (ReferenceEquals(item.Shift, this))
                    {
                        item.Shift = null;
                    }
                }
            }
        }

        #endregion
    }
}