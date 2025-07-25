//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBank.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Administrator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Administrator()
        {
            this.AdminLOG = new HashSet<AdminLOG>();
        }

        [Required(ErrorMessage = "This Line Can't Be Null")]
        public int ID { get; set; }
        [Required(ErrorMessage = "This Line Can't Be Null")]
        public string FName { get; set; }
        [Required(ErrorMessage = "This Line Can't Be Null")]
        public string LName { get; set; }
        public string FromCountry { get; set; }
        [Required(ErrorMessage = "This Line Can't Be Null")]
        public long Phone { get; set; }
        [Required(ErrorMessage = "This Line Can't Be Null")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",ErrorMessage ="Please Enter a Valid Email Format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This Line Can't Be Null")]
        public string Pwrd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdminLOG> AdminLOG { get; set; }
    }
}
