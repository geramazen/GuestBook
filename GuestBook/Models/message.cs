//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GuestBook.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class message
    {
        public int MID { get; set; }
        public string Descreption { get; set; }
        public Nullable<int> PID { get; set; }
        public Nullable<int> User_ID { get; set; }
    
        public virtual user user { get; set; }
    }
}
