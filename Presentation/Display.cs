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

            //     if(new System.Random().Next(2) == 1)
            //         RegistrationController.PayTaks(new crm.Data.Context().Registrations.ToArray()[new crm.Data.Context().Registrations.Count() - 1].ID);

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

            // var registration = RegistrationController.GetRegistrationByCourseName("Teaching da yung ones");
            // System.Console.WriteLine(registration.Discount);


            // Statistics

            // var children = RegistrationController.GetChildrenRegisteredInTimePeriod(new System.DateTime(2020, 1, 1), new System.DateTime(2021, 1, 1));
            // foreach(var child in children)
            //     System.Console.WriteLine($"{child.ID}       {child.Name}");
            // System.Console.WriteLine(children.Length);

            // var paid = RegistrationController.GetTaksesPaidInTimePeriod(new System.DateTime(2020, 1, 1), new System.DateTime(2021, 1, 1));
            // foreach(double taks in paid)
            //     System.Console.WriteLine(taks);
            // System.Console.WriteLine(paid.Length);

            // var notPaid = RegistrationController.GetTaksesNotPaidInTimePeriod(new System.DateTime(2020, 1, 1), new System.DateTime(2021, 1, 1));
            // foreach(double taks in notPaid)
            //     System.Console.WriteLine(taks);
            // System.Console.WriteLine(notPaid.Length);

            // var reminders = RegistrationController.RemindForTaks();
            // foreach(var registration in reminders)
            //     System.Console.WriteLine($"{registration.ChildID} duljish {registration.Amount} be tupak");
            // System.Console.WriteLine(reminders.Length);

            // var coursesWithoutTeacher = RegistrationController.GetCoursesWithRegisteredChildrenAndWithoutTeachers();
            // foreach(var course in coursesWithoutTeacher)
            //     System.Console.WriteLine($"{course.Name}    {course.AvailablePlaces}");
            // System.Console.WriteLine(coursesWithoutTeacher.Length);

            
            // Parent contacts

            // var contacts = ParentController.GetContactsOfParent(ParentController.GetParentID(ParentController.GetParents()[0]));
            // System.Console.WriteLine($"{contacts[0]}        {contacts[1]}");

            // var courses = CourseController.GetOnGoingCourses();
            // CourseController.ExtractToCSV(courses);
            // foreach(var course in courses)
            //     System.Console.WriteLine(course.Name);
            // System.Console.WriteLine(courses.Length);

        }

    }

}