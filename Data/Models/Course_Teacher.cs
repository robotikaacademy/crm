using System;
namespace crm.Data.Models{

    public class Course_Teacher{

        public Guid ID { get; set; }
        public Guid CourseID { get; set; }
        public Guid TeacherID { get; set; }

    }
    
}