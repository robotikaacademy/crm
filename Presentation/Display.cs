using crm.Business;

namespace crm.Presentation{
    
    public class Display{

        public Display(){

            Course_TeachersController.ClearEntries();
            Child_ParentsController.ClearEntries();
            RegistrationController.ClearEntries();
            TeacherController.ClearEntries();
            CourseController.ClearEntries();
            ParentController.ClearEntries();
            ChildController.ClearEntries();

            for(int i = 0; i < 1000; i++){

                ChildController.AddChild();
                ParentController.AddParent();
                TeacherController.AddTeacher();

            }

            for(int i = 0; i < 100; i++)
                CourseController.AddCourse();

            for(int i = 0; i < 1000; i++){

                try{
                    RegistrationController.Registration();
                }
                catch(System.ArgumentException e){
                    System.Console.WriteLine(e.Message);
                }
                try{
                    Child_ParentsController.AddConnection();
                }
                catch(System.ArgumentException e){
                    System.Console.WriteLine(e.Message);
                }
                try{
                    Course_TeachersController.AddConnection();
                }
                catch(System.ArgumentException e){
                    System.Console.WriteLine(e.Message);
                }

            }

            // Phonetic/Approximate search
            StartProcess process = new StartProcess();
            string result = process.Start("Rose");
            System.Console.WriteLine(result);

        }

    }

}