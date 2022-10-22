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
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.ChatLog = new HashSet<ChatLog>();
            this.DataPass = new HashSet<DataPass>();
            this.Subscribers = new HashSet<Subscribers>();
        }
    
        public int id { get; set; }
        public Nullable<int> rollid { get; set; }
        public Nullable<int> groupid { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string subgroup { get; set; }
        public Nullable<int> userTid { get; set; }
        public Nullable<bool> isOlder { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatLog> ChatLog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataPass> DataPass { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual Roles Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscribers> Subscribers { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}
