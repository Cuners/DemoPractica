//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DEmoPrac.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Napravleniya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Napravleniya()
        {
            this.Meropriyatiye_tip_Meropriyatiya_napravleniye = new HashSet<Meropriyatiye_tip_Meropriyatiya_napravleniye>();
            this.Polzovatel_napravlenie = new HashSet<Polzovatel_napravlenie>();
        }
    
        public int ID_napravlenia { get; set; }
        public string Napravlenie { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meropriyatiye_tip_Meropriyatiya_napravleniye> Meropriyatiye_tip_Meropriyatiya_napravleniye { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Polzovatel_napravlenie> Polzovatel_napravlenie { get; set; }
    }
}
