using System.Collections.Generic;
using crm.Business;

namespace crm.Presentation{
    
    public class Display{

        public Display(){

            // Course_TeachersController.ClearEntries();
            // Child_ParentsController.ClearEntries();
            // RegistrationController.ClearEntries();
            // TeacherController.ClearEntries();
            // CourseController.ClearEntries();
            // ParentController.ClearEntries();
            // ChildController.ClearEntries();

            // for(int i = 0; i < 1000; i++){

            //     ChildController.AddChild();
            //     ParentController.AddParent();
            //     TeacherController.AddTeacher();

            // }

            // for(int i = 0; i < 100; i++)
            //     CourseController.AddCourse();

            // for(int i = 0; i < 1000; i++){

            //     try{
            //         RegistrationController.Registration();
            //     }
            //     catch(System.ArgumentException e){
            //         System.Console.WriteLine(e.Message);
            //     }
            //     try{
            //         Child_ParentsController.AddConnection();
            //     }
            //     catch(System.ArgumentException e){
            //         System.Console.WriteLine(e.Message);
            //     }
            //     try{
            //         Course_TeachersController.AddConnection();
            //     }
            //     catch(System.ArgumentException e){
            //         System.Console.WriteLine(e.Message);
            //     }

            // }

            // Phonetic/Approximate search
            // string[] results = Processing.Start("Rose", new string[]{"Rose", "Rose", "Raze", "Rome", "Remi"});
            // System.Console.WriteLine(string.Join(',', results));

            // List<crm.Data.Models.Child> children = ChildController.GetChildrenByName("Thomas");
            // foreach(crm.Data.Models.Child child in children)
            //     System.Console.WriteLine(child.Name);

            // var childrensCourses = RegistrationController.GetChildrensCourses();
            // foreach(var item in childrensCourses)
            // {
            //     System.Console.WriteLine(item.Item1);
            //     System.Console.WriteLine(item.Item2);
            //     foreach(var item2 in item.Item2)
            //     {
            //         System.Console.WriteLine(item2);
            //     }
            // }

            // var course = Course_TeachersController.GetCourseByTeacher("Joseph");
            // System.Console.WriteLine(course.Name);


            // DateTime dt= DateTime.Parse("2020-08-07");
            // string  s2=dt.ToString("yyyy-MM-dd");
            // DateTime dtnew = DateTime.Parse(s2);

            // var registration = RegistrationController.GetRegistrationByDate(dtnew);
            // System.Console.WriteLine(registration.Discount);

            var registration = RegistrationController.GetRegistrationByCourseName("Teaching da yung ones");
            System.Console.WriteLine(registration.Discount);

        }

    }

}