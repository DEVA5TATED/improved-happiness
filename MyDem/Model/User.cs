//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyDem.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int user_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> reader_id { get; set; }
        public Nullable<int> employee_id { get; set; }
        public int role_id { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Reader Reader { get; set; }
        public virtual Role Role { get; set; }
    }
}
