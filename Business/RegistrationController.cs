using System.Collections.Generic;
using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class RegistrationController{

        private static Context context;
        private static InMemoryDB imdb = new InMemoryDB();

        public static void Registration(){
            using(context = new Context()){
                Registration newRegistration = new Registration();
                List<string> childrenNames = ChildController.GetChildren();
                List<string> courseNames = CourseController.GetCourses();
                newRegistration.ID = Guid.NewGuid();
                newRegistration.ChildID = ChildController.GetChildID(childrenNames[new Random().Next(childrenNames.Count)]);
                newRegistration.CourseID = CourseController.GetCourseID(courseNames[new Random().Next(courseNames.Count)]);
                newRegistration.Amount = RandomData.GetRandomAmount();
                newRegistration.Discount = RandomData.GetRandomDiscount();
                newRegistration.RegistrationDate = DateTime.Now;
                newRegistration.Note = null;
                // imdb.Registration.Add(newRegistration);
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
                while(context.Registrations.ToList().Count > 0){

                    // System.Console.WriteLine(imdb.Registration.First().ID);
                    // imdb.Registration.Remove(imdb.Registration.First());
                    context.Registrations.Remove(context.Registrations.First());
                    context.SaveChanges();
                    
                }
            }
        }

    }

}