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
    
    public partial class Tipi_meropriatiya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipi_meropriatiya()
        {
            this.Meropriyatiye_tip_Meropriyatiya_napravleniye = new HashSet<Meropriyatiye_tip_Meropriyatiya_napravleniye>();
        }
    
        public int ID_tip_meroproatiya { get; set; }
        public string Tip_meropriatiya { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Meropriyatiye_tip_Meropriyatiya_napravleniye> Meropriyatiye_tip_Meropriyatiya_napravleniye { get; set; }
    }
}