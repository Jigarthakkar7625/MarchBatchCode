//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyMVCWebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepartmentID
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentID()
        {
            this.EmpJimmies = new HashSet<EmpJimmy>();
        }
    
        public int DepartmentId1 { get; set; }
        public string DepartmentName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpJimmy> EmpJimmies { get; set; }
    }
}
