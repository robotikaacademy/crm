using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{

    static class AdminController{

        private static Context context;


        // Add an entry to a given table

        public static void AddChild(){
            using(context = new Context()){
                Child newChild = new Child();
                newChild.ID = Guid.NewGuid();
                newChild.Name = RandomData.GetRandomName();
                newChild.BirthDate = RandomData.GetRandomBirthDate();
                newChild.Note = null;
                context.Children.Add(newChild);
                context.SaveChanges();
            }
        }

        public static void CreateRegistration(){
            using(context = new Context()){

                Registration newRegistration = new Registration();
                newRegistration.ID = Guid.NewGuid();

                // Checks if the course has any space left
                Course theCourse = CourseController.GetCourseById(RandomData.GetRandomCourseID());
                newRegistration.CourseID = theCourse.ID;
                if(theCourse.AvailablePlaces == 0) throw new ArgumentException("No places left in the course");

                // Checks if the child is already in the course
                newRegistration.ChildID = RandomData.GetRandomChildID();
                if(context.Registrations.ToList().Any(x => x.CourseID == theCourse.ID && x.ChildID == newRegistration.ChildID)) throw new ArgumentException("Child already in the course");

                context.Courses.ToList().Find(x => x.ID == theCourse.ID).AvailablePlaces--;
                newRegistration.Amount = RandomData.GetRandomAmount();
                newRegistration.Paid = false;
                newRegistration.Discount = RandomData.GetRandomDiscount();
                newRegistration.RegistrationDate = DateTime.Now;
                newRegistration.Note = null;

                context.Registrations.Add(newRegistration);
                context.SaveChanges();

            }
        }
        
        public static void AddConnectionChildParent(){
            using(context = new Context()){
                Child_Parents newConnection = new Child_Parents();
                newConnection.ID = Guid.NewGuid();
                newConnection.ChildId = RandomData.GetRandomChildID();
                newConnection.ParentId = RandomData.GetRandomParentID();
                if(context.Child_Parents.ToList().Any(x => x.ChildId == newConnection.ChildId && x.ParentId == newConnection.ParentId))
                    throw new ArgumentException("Connection already exists");
                context.Child_Parents.Add(newConnection);
                context.SaveChanges();
            }
        }
        
        public static void AddConnectionCourseTeacher(){
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

        public static void AddParent(){
            using(context = new Context()){
                Parent newParent = new Parent();
                newParent.ID = Guid.NewGuid();
                newParent.Name = RandomData.GetRandomName();
                newParent.Phone = RandomData.GetRandomPhoneNumber();
                newParent.Email = RandomData.GetRandomEmail();
                newParent.Note = null;
                context.Parents.Add(newParent);
                context.SaveChanges();
            }
        }

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


        // Removes a single entry in a given table

        public static void RemoveChild(string name){
            using(context = new Context()){
                context.Children.Remove(context.Children.ToList().Find(x => x.Name == ApproximateSearch.GetTopResult(name, context.Children.Select(y => y.Name).ToArray())));
                context.SaveChanges();
            }
        }
        
        public static void RemoveRegistration(Guid childID, Guid courseID){
            using(context = new Context()){
                context.Registrations.Remove(context.Registrations.ToList().Find(x => x.ChildID == childID && x.CourseID == courseID));
                context.SaveChanges();
            }
        }
        
        public static void RemoveChildParent(Guid childID, Guid parentID){
            using(context = new Context()){
                context.Child_Parents.Remove(context.Child_Parents.ToList().Find(x => x.ChildId == childID && x.ParentId == parentID));
                context.SaveChanges();
            }
        }
        
        public static void RemoveCourseTeacher(Guid teacherID, Guid courseID){
            using(context = new Context()){
                context.Course_Teachers.Remove(context.Course_Teachers.ToList().Find(x => x.TeacherID == teacherID && x.CourseID == courseID));
                context.SaveChanges();
            }
        }
        
        public static void RemoveCourse(string name){
            using(context = new Context()){
                context.Courses.Remove(context.Courses.ToList().Find(x => x.Name == ApproximateSearch.GetTopResult(name, context.Courses.Select(y => y.Name).ToArray())));
                context.SaveChanges();
            }
        }
        
        public static void RemoveParent(string name){
            using(context = new Context()){
                context.Parents.Remove(context.Parents.ToList().Find(x => x.Name == ApproximateSearch.GetTopResult(name, context.Parents.Select(y => y.Name).ToArray())));
                context.SaveChanges();
            }
        }
        
        public static void RemoveTeacher(string name){
            using(context = new Context()){
                context.Teachers.Remove(context.Teachers.ToList().Find(x => x.Name == ApproximateSearch.GetTopResult(name, context.Teachers.Select(y => y.Name).ToArray())));
                context.SaveChanges();
            }
        }


        // Clears all entries in a given table

        public static void ClearChildren(){
            using(context = new Context()){
                while(context.Children.Count() > 0){
                    context.Children.Remove(context.Children.First());
                    context.SaveChanges();                    
                }
            }
        }

        public static void ClearRegistrations(){
            using(context = new Context()){
                while(context.Registrations.Count() > 0){
                    context.Registrations.Remove(context.Registrations.First());
                    context.SaveChanges();                    
                }
            }
        }

        public static void ClearChildToParent(){
            using(context = new Context()){
                while(context.Child_Parents.Count() > 0){
                    context.Child_Parents.Remove(context.Child_Parents.First());
                    context.SaveChanges();                    
                }
            }
        }

        public static void ClearCourseToTeacher(){
            using(context = new Context()){
                while(context.Course_Teachers.Count() > 0){
                    context.Course_Teachers.Remove(context.Course_Teachers.First());
                    context.SaveChanges();
                }
            }
        }

        public static void ClearCourses(){

            using(context = new Context())
                while(context.Courses.Count() > 0){
                    context.Courses.Remove(context.Courses.First());
                    context.SaveChanges();
                }
        }

        public static void ClearParents(){
            using(context = new Context()){
                while(context.Parents.Count() > 0){
                    context.Parents.Remove(context.Parents.First());
                    context.SaveChanges();
                }
            }
        }

        public static void ClearTeachers(){
            using(context = new Context()){
                while(context.Teachers.Count() > 0){
                    context.Teachers.Remove(context.Teachers.First());
                    context.SaveChanges();                    
                }
            }
        }
        
        
    }

}