using System.Collections.Generic;
using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class TeacherController{

        private static Context context;

        public static Guid GetTeacherID(string name){
            using(context = new Context()){
                return context.Teachers.ToList().Find(x => x.Name == name).ID;
            }
        }
        
        public static string[] GetTeachers(){
            using(context = new Context()){
                return context.Teachers.Select(x => x.Name).ToArray();
            }
        }

        public static Course[] GetCoursesOfTeacher(Guid id){
            using(context = new Context()){
                return context.Courses.Where(x => context.Course_Teachers.Where(y => y.TeacherID == id).Any(y => y.CourseID == x.ID)).ToArray();
            }
        }

    }

}