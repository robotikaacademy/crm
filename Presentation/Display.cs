using System.Collections.Generic;
using crm.Business;
using System;

namespace crm.Presentation{
    
    public class Display{

        public Display(){

            RegistrationController.ClearEntries();
            ParentController.ClearEntries();
            ChildController.ClearEntries();
            CourseController.ClearEntries();
            TeacherController.ClearEntries();

            ParentController.AddParent();
            ChildController.AddChild();
            CourseController.AddCourse();
            TeacherController.AddTeacher();
            RegistrationController.Registration();

            List<Tuple<Guid, Guid>> registrations = RegistrationController.GetRegistrations();
            foreach(Tuple<Guid, Guid> reg in registrations) System.Console.WriteLine($"{reg.Item1}       {reg.Item2}");

        }

    }

}