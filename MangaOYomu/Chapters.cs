//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MangaOYomu
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chapters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chapters()
        {
            this.Pages = new HashSet<Pages>();
        }
    
        public int ChaptersID { get; set; }
        public string Name { get; set; }
        public Nullable<int> MangaTitleID { get; set; }
    
        public virtual MangaTitle MangaTitle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pages> Pages { get; set; }
    }
}
