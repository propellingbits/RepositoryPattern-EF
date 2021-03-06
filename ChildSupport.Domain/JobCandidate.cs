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
    public partial class JobCandidate
    {
        #region Primitive Properties
    
        public virtual int JobCandidateID
        {
            get;
            set;
        }
    
        public virtual Nullable<int> BusinessEntityID
        {
            get { return _businessEntityID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_businessEntityID != value)
                    {
                        if (Employee != null && Employee.BusinessEntityID != value)
                        {
                            Employee = null;
                        }
                        _businessEntityID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _businessEntityID;
    
        public virtual string Resume
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
    
        public virtual Employee Employee
        {
            get { return _employee; }
            set
            {
                if (!ReferenceEquals(_employee, value))
                {
                    var previousValue = _employee;
                    _employee = value;
                    FixupEmployee(previousValue);
                }
            }
        }
        private Employee _employee;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupEmployee(Employee previousValue)
        {
            if (previousValue != null && previousValue.JobCandidates.Contains(this))
            {
                previousValue.JobCandidates.Remove(this);
            }
    
            if (Employee != null)
            {
                if (!Employee.JobCandidates.Contains(this))
                {
                    Employee.JobCandidates.Add(this);
                }
                if (BusinessEntityID != Employee.BusinessEntityID)
                {
                    BusinessEntityID = Employee.BusinessEntityID;
                }
            }
            else if (!_settingFK)
            {
                BusinessEntityID = null;
            }
        }

        #endregion
    }
}
