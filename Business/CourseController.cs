using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class CourseController{

        private static Context context;

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