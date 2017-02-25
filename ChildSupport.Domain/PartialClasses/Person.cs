using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

/*using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;*/
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace ChildSupport.Domain
{
    [MetadataType(typeof(PersonMetadata))]
    //[Serializable()]
    public partial class Person
    {
        class PersonMetadata
        {
            [NotNullValidator]
            [RegexValidator("^[a-zA-Z]", ErrorMessage = "Only alphabets are allowed.")]            
            public string FirstName
            {
                get;
                set;
            }

            [NotNullValidator(ErrorMessage = "Date is required.")]
            [RegexValidator(@"^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$", ErrorMessage = "Please enter data in mm/dd/yyyy format.")]            
            public virtual System.DateTime ModifiedDate
            {
                get;
                set;
            }

            [NotNullValidator(ErrorMessage = "Email is required.")]
            [StringLengthValidator(200, ErrorMessage = "Email must be 200 characters or less.")]
            [RegexValidator(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
            public string Email { get; set; }
        }
    }
}
