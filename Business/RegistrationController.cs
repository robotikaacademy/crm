using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class RegistrationController{

        private static Context context;

        public static Tuple<Guid, Guid>[] GetRegistrations(){
            using(context = new Context()){
                return context.Registrations.Select(x => new Tuple<Guid, Guid>(x.ChildID, x.CourseID)).ToArray();
            }
        }

        public static Registration GetRegistrationByDate(DateTime searchDate){
            using(context = new Context()){
                return context.Registrations.Where(x => x.RegistrationDate == searchDate).FirstOrDefault();
            }
        }

        //има повече от един курс трябва да връща лист!
        public static Registration GetRegistrationByCourseName(string name){
            using(context = new Context()){
                Guid courseId = CourseController.GetCourseByName(name).ID;
                return context.Registrations.Where(x => x.CourseID == courseId).FirstOrDefault();
            }
        }

        //не работи още ххаххха
        public static System.Collections.Generic.List<Tuple<Guid, string, System.Collections.Generic.List<string>>> GetChildrensCourses (){
            using(context = new Context()){
                System.Collections.Generic.List<Tuple<Guid, string, System.Collections.Generic.List<string>>> childrensCourses = new System.Collections.Generic.List<Tuple<Guid, string, System.Collections.Generic.List<string>>>();
                //context.Registrations.Select(x => )
                foreach(var item in context.Registrations){

                    Guid childId = item.ChildID;
                    var childName = ChildController.GetChildById(childId).Name;
                    System.Collections.Generic.List<string> childsCourses = new System.Collections.Generic.List<string>();

                    foreach(var item1 in context.Registrations){

                        if(item1.ChildID == childId){
                            childsCourses.Add(CourseController.GetCourseById(item1.CourseID).Name);
                        }

                    }

                    var childAndCourses = Tuple.Create(childId, childName, childsCourses);
                    childrensCourses.Add(childAndCourses);

                }

                return childrensCourses;
            }
        }


        public static void PayTaks(Guid id){
            using(context = new Context()){
                context.Registrations.Find(id).Paid = true;
                context.SaveChanges();
            }
        }

        // Statistics

        public static Child[] GetChildrenRegisteredInTimePeriod(DateTime start, DateTime end){
            using(context = new Context()){
                return context.Children.Where(x => context.Registrations.Where(y => y.RegistrationDate > start && y.RegistrationDate < end).Any(y => y.ChildID == x.ID)).ToArray();
            }
        }

        public static Registration[] GetTaksesPaidInTimePeriod(DateTime start, DateTime end){
            using(context = new Context()){
                return context.Registrations.Where(x => x.RegistrationDate > start && x.RegistrationDate < end && x.Paid).ToArray();
            }
        }

        public static Registration[] GetTaksesNotPaidInTimePeriod(DateTime start, DateTime end){
            using(context = new Context()){
                return context.Registrations.Where(x => x.RegistrationDate > start && x.RegistrationDate < end && !x.Paid).ToArray();
            }
        }

        public static Registration[] RemindForTaks(){
            using(context = new Context()){
                return context.Registrations.Where(x => !x.Paid && (x.RegistrationDate.Day + 3 == DateTime.Now.Day || x.RegistrationDate.Day + 7 == DateTime.Now.Day)).ToArray();
            }
        }

        public static Course[] GetCoursesWithRegisteredChildrenAndWithoutTeachers(){
            using(context = new Context()){
                return context.Courses.Where(x => x.AvailablePlaces < 12 && !context.Course_Teachers.Any(y => y.CourseID == x.ID)).ToArray();
            }
        }

    }

}