using System;
namespace crm.Data.Models{

    public class Course{

        public Guid ID { get; set; }
        public string Name { get; set; }
	    public string AgeGroup { get; set; }
	    public DateTime DateStarted { get; set; }
	    public DateTime DateFinished { get; set; }
	    public int AvailablePlaces { get; set; }
	    public string Type { get; set; }

    }
    
}