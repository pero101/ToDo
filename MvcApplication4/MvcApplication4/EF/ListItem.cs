//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication4.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Priority { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
        public virtual Priority Priority1 { get; set; }
    }
}
