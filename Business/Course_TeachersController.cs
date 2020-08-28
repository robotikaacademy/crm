using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class Course_TeachersController{

        private static Context context;

        public static Course GetCourseByTeacher(string teacherName){
            using(context = new Context()){
                Guid teacherId = TeacherController.GetTeacherID(teacherName);
                Course_Teacher course_Teacher = context.Course_Teachers.Where(x => x.TeacherID == teacherId).FirstOrDefault();
                
                return CourseController.GetCourseById(course_Teacher.CourseID);
            }
        }

    }

}