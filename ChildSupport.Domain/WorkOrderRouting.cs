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
    public partial class WorkOrderRouting
    {
        #region Primitive Properties
    
        public virtual int WorkOrderID
        {
            get { return _workOrderID; }
            set
            {
                if (_workOrderID != value)
                {
                    if (WorkOrder != null && WorkOrder.WorkOrderID != value)
                    {
                        WorkOrder = null;
                    }
                    _workOrderID = value;
                }
            }
        }
        private int _workOrderID;
    
        public virtual int ProductID
        {
            get;
            set;
        }
    
        public virtual short OperationSequence
        {
            get;
            set;
        }
    
        public virtual short LocationID
        {
            get { return _locationID; }
            set
            {
                if (_locationID != value)
                {
                    if (Location != null && Location.LocationID != value)
                    {
                        Location = null;
                    }
                    _locationID = value;
                }
            }
        }
        private short _locationID;
    
        public virtual System.DateTime ScheduledStartDate
        {
            get;
            set;
        }
    
        public virtual System.DateTime ScheduledEndDate
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> ActualStartDate
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> ActualEndDate
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> ActualResourceHrs
        {
            get;
            set;
        }
    
        public virtual decimal PlannedCost
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> ActualCost
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
    
        public virtual Location Location
        {
            get { return _location; }
            set
            {
                if (!ReferenceEquals(_location, value))
                {
                    var previousValue = _location;
                    _location = value;
                    FixupLocation(previousValue);
                }
            }
        }
        private Location _location;
    
        public virtual WorkOrder WorkOrder
        {
            get { return _workOrder; }
            set
            {
                if (!ReferenceEquals(_workOrder, value))
                {
                    var previousValue = _workOrder;
                    _workOrder = value;
                    FixupWorkOrder(previousValue);
                }
            }
        }
        private WorkOrder _workOrder;

        #endregion
        #region Association Fixup
    
        private void FixupLocation(Location previousValue)
        {
            if (previousValue != null && previousValue.WorkOrderRoutings.Contains(this))
            {
                previousValue.WorkOrderRoutings.Remove(this);
            }
    
            if (Location != null)
            {
                if (!Location.WorkOrderRoutings.Contains(this))
                {
                    Location.WorkOrderRoutings.Add(this);
                }
                if (LocationID != Location.LocationID)
                {
                    LocationID = Location.LocationID;
                }
            }
        }
    
        private void FixupWorkOrder(WorkOrder previousValue)
        {
            if (previousValue != null && previousValue.WorkOrderRoutings.Contains(this))
            {
                previousValue.WorkOrderRoutings.Remove(this);
            }
    
            if (WorkOrder != null)
            {
                if (!WorkOrder.WorkOrderRoutings.Contains(this))
                {
                    WorkOrder.WorkOrderRoutings.Add(this);
                }
                if (WorkOrderID != WorkOrder.WorkOrderID)
                {
                    WorkOrderID = WorkOrder.WorkOrderID;
                }
            }
        }

        #endregion
    }
}
