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
    
    public partial class Polzovatel_napravlenie
    {
        public int ID_polzovatel_napravlenie { get; set; }
        public int ID_polzovatelya { get; set; }
        public int ID_napravlenie { get; set; }
    
        public virtual Napravleniya Napravleniya { get; set; }
        public virtual Polzovateli Polzovateli { get; set; }
    }
}