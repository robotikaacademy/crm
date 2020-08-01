using System;
namespace crm.Data.Models{

    public class Child_Parents{
        
        public Guid ID { get; set; }
        public Guid ChildId { get; set; }
        public Guid ParentId { get; set; }

    }
    
}