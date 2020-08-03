using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class Course_TeachersController{

        private static Context context;

        public static void AddConnection(){
            using(context = new Context()){
                Course_Teacher newConnection = new Course_Teacher();
                newConnection.ID = Guid.NewGuid();
                newConnection.TeacherID = RandomData.GetRandomTeacherID();
                newConnection.CourseID = RandomData.GetRandomCourseID();
                if(context.Course_Teachers.ToList().Any(x => x.TeacherID == newConnection.TeacherID && x.CourseID == newConnection.CourseID))
                    throw new ArgumentException("Connection already exists");
                context.Course_Teachers.Add(newConnection);
                context.SaveChanges();
            }
        }

        public static void ClearEntries(){
            using(context = new Context()){
                while(context.Course_Teachers.Count() > 0){

                    context.Course_Teachers.Remove(context.Course_Teachers.First());
                    context.SaveChanges();
                    
                }
            }
        }

    }

}