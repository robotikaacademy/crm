using System;
namespace crm.Data.Models{

    public class Registration{

        public Guid ID { get; set; }
        public Guid ChildID { get; set; }
	    public Guid CourseID { get; set; }
	    public float Amount { get; set; }
	    public string Discount { get; set; }
	    public DateTime RegistrationDate { get; set; }
	    public string Note { get; set; }

    }
    
}