//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace scheduleHelp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataPass
    {
        public int id { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<System.DateTime> datetime { get; set; }
        public string textstr { get; set; }
        public string status { get; set; }
        public Nullable<System.TimeSpan> time { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
