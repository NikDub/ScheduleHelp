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
    
    public partial class ChatLog
    {
        public int id { get; set; }
        public Nullable<int> userid { get; set; }
        public string command { get; set; }
        public string text { get; set; }
        public Nullable<System.DateTime> datetime { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
