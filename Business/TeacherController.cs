using System.Collections.Generic;
using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class TeacherController{

        private static Context context;

        public static void AddTeacher(){
            using(context = new Context()){
                Teacher newTeacher = new Teacher();
                newTeacher.ID = Guid.NewGuid();
                newTeacher.Name = RandomData.GetRandomName();
                newTeacher.Phone = RandomData.GetRandomPhoneNumber();
                newTeacher.Email = RandomData.GetRandomEmail();
                newTeacher.Fee = RandomData.GetRandomFee();
                newTeacher.Note = null;
                context.Teachers.Add(newTeacher);
                context.SaveChanges();
            }
        }

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

        public static void ClearEntries(){
            using(context = new Context()){
                while(context.Teachers.Count() > 0){

                    context.Teachers.Remove(context.Teachers.First());
                    context.SaveChanges();
                    
                }
            }
        }

        public static Course[] GetCoursesOfTeacher(Guid id){
            using(context = new Context()){
                return context.Courses.Where(x => context.Course_Teachers.Where(y => y.TeacherID == id).Any(y => y.CourseID == x.ID)).ToArray();
            }
        }

    }

}