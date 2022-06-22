using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    [Table("customerMaster")]
    public class CustomerMaster
    {
        [Key]
        public string customerID { get; set; }
        #nullable enable
        public string? customerName { get; set; }
        public string? customerEmail { get; set; }
        public string? customerMobile { get; set; }
        public string? customerAddress { get; set; }
        public string? customerCity { get; set; }
        public string? customerState { get; set; }
        public string? customerCountry { get; set; }
        public DateTime? customerDOB { get; set; }
        public string? customerGender { get; set; }
        public string? facebookProfile { get; set; }
        public string? googleProfile { get; set; }
        public byte? isMobileVerified { get; set; }
        public byte? isEmailVerified { get; set; }
        public DateTime? datecreated { get; set; }
        public string? createdIP { get; set; }
        public DateTime? datemodified { get; set; }
        public string? modifiedIP { get; set; }
        public byte? isActive { get; set; }
        public string? profilePhoto { get; set; }
        public string? customerPasswd { get; set; }
        public string? source { get; set; }
    }
}
