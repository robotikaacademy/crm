using System;
namespace crm.Data.Models{

    public class Teacher{

        public Guid ID { get; set; }
        public string Name { get; set; }
	    public string Phone { get; set; }
	    public string Email { get; set; }
	    public int Fee { get; set; }
	    public string Note { get; set; }

    }
    
}