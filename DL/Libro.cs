//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Libro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Libro()
        {
            this.AutorLibroes = new HashSet<AutorLibro>();
        }
    
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string AñoPublicacion { get; set; }
        public Nullable<int> IdEditorial { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AutorLibro> AutorLibroes { get; set; }
        public virtual Editorial Editorial { get; set; }
    }
}
