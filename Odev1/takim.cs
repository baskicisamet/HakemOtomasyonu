//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Odev1
{
    using System;
    using System.Collections.Generic;
    
    public partial class takim
    {
        public long t_id { get; set; }
        public string t_adi { get; set; }
        public long l_id { get; set; }
        public long s_id { get; set; }
    
        public virtual lig lig { get; set; }
        public virtual sporsalonu sporsalonu { get; set; }
    }
}