using System.Collections.Generic;
using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class RegistrationController{

        private static Context context;

        public static void Registration(){
            using(context = new Context()){

                Registration newRegistration = new Registration();
                newRegistration.ID = Guid.NewGuid();

                // Checks if the course has any space left
                Course theCourse = CourseController.GetRandomCourse();
                newRegistration.CourseID = theCourse.ID;
                if(theCourse.AvailablePlaces == 0) throw new ArgumentException("No places left in the course");

                // Checks if the child is already in the course
                newRegistration.ChildID = ChildController.GetRandomChild().ID;
                if(context.Registrations.ToList().Any(x => x.CourseID == theCourse.ID && x.ChildID == newRegistration.ChildID)) throw new ArgumentException("Child already in the course");

                context.Courses.ToList().Find(x => x.ID == theCourse.ID).AvailablePlaces--;
                newRegistration.Amount = RandomData.GetRandomAmount();
                newRegistration.Discount = RandomData.GetRandomDiscount();
                newRegistration.RegistrationDate = DateTime.Now;
                newRegistration.Note = null;

                context.Registrations.Add(newRegistration);
                context.SaveChanges();

            }
        }

        public static List<Tuple<Guid, Guid>> GetRegistrations(){
            using(context = new Context()){
                return context.Registrations.Select(x => new Tuple<Guid, Guid>(x.ChildID, x.CourseID)).ToList();
            }
        }

        public static void ClearEntries(){
            using(context = new Context()){
                while(context.Registrations.Count() > 0){

                    context.Registrations.Remove(context.Registrations.First());
                    context.SaveChanges();
                    
                }
            }
        }

    }

}