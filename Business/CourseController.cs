using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class CourseController{

        private static Context context;

        public static void AddCourse(){

            using(context = new Context()){

                Course newCourse = new Course();
                newCourse.ID = Guid.NewGuid();
                newCourse.Type = RandomData.GetRandomCourseType();
                newCourse.Name = RandomData.GetRandomCourseName(newCourse.Type);
                newCourse.AgeGroup = RandomData.GetRandomAgeGroup();
                newCourse.DateStarted = RandomData.GetRandomStartDate();
                newCourse.DateFinished = newCourse.DateStarted.AddMonths(3);
                newCourse.AvailablePlaces = 12;
                context.Courses.Add(newCourse);
                context.SaveChanges();

            }

        }

        private static string[] GetCoursesNames(){

            using(context = new Context())
                return context.Courses.Select(x => x.Name).ToArray();

        }

        public static Course GetCourseByName(string name){

            using(context = new Context())
                return context.Courses.ToList().Find(x => x.Name == ApproximateSearch.GetTopResult(name, GetCoursesNames()));
     
        }

        public static Course GetCourseById(Guid id){

            using(context = new Context())
                return context.Courses.Find(id);

        }
        
        public static void ClearEntries(){

            using(context = new Context())
                while(context.Courses.Count() > 0){

                    context.Courses.Remove(context.Courses.First());
                    context.SaveChanges();
                    
                }

        }

        public static Course[] GetOnGoingCourses(int[] startFilter=null, int[] endFilter=null){
            
            using(context = new Context()){

                Course[] filteredCourses = context.Courses.Where(x => x.DateStarted <= DateTime.Now && x.DateFinished >= DateTime.Now).ToArray();
                if(startFilter != null)
                    filteredCourses = filteredCourses.Where(x => x.DateStarted >= new DateTime(startFilter[0], startFilter[1], startFilter[2])).ToArray();
                if(endFilter != null)
                    filteredCourses = filteredCourses.Where(x => x.DateFinished <= new DateTime(endFilter[0], endFilter[1], endFilter[2])).ToArray();
                return filteredCourses;

            }

        }

        public static Child[] GetChildrenRegisteredForTheCourse(Guid id){

            using(context = new Context())
                return context.Children.Where(x => context.Registrations.Where(y => y.CourseID == id).Any(y => y.ChildID == x.ID)).ToArray();

        }

        public static Course[] GetCoursesByType(string type){

            using(context = new Context())
                return context.Courses.Where(x => x.Type == type).ToArray();

        }

        public static void ExtractToCSV(Course[] courses){

            using(context = new Context())
                using(System.IO.StreamWriter writer = new System.IO.StreamWriter("ExportedFiles/file.csv"))
                    using(CsvHelper.CsvWriter csv = new CsvHelper.CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
                        csv.WriteRecords(courses);
        
        }

    }

}