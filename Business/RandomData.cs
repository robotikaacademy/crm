using System.Linq;
using crm.Data;
using System;

namespace crm.Business{

    public static class RandomData{

        public static string GetRandomName(){

            string[] names = System.IO.File.ReadAllLines("Additional Files/names.txt");
            return names[new Random().Next(names.Length)];

        }

        public static DateTime GetRandomBirthDate(bool isChild=true){

            int[] date = new int[3];

            if(isChild) date[0] = new Random().Next(DateTime.Now.Year - 18, DateTime.Now.Year - 4);
            else date[0] = new Random().Next(DateTime.Now.Year - 50, DateTime.Now.Year - 20);

            
            date[1] = new Random().Next(1, 13);
            if((date[1] % 2 == 0 && date[1] < 7) || (date[1] % 2 == 1 && date[1] > 7))
                if(date[1] == 2)
                    if(DateTime.IsLeapYear(date[0])) date[2] = new Random().Next(1, 30);
                    else date[2] = new Random().Next(1, 29);
                else date[2] = new Random().Next(1, 31);
            else date[2] = new Random().Next(1, 32);

            return new DateTime(date[0], date[1], date[2]);

        }

        //Make it generate more realistic phone numbers(maybe include country codes)
        public static string GetRandomPhoneNumber(){

            string phoneNumber = "";

            while(new Context().Parents.ToList().Any(x => x.Phone == phoneNumber) || new Context().Teachers.ToList().Any(x => x.Phone == phoneNumber)){

                phoneNumber = "08" + (char)(new Random().Next(7, 10) + '0');
                for(int i = 0; i < 7; i++) phoneNumber += (char)(new Random().Next(10) + '0');

            }
            
            return phoneNumber;
            
        }

        public static string GetRandomEmail(){

            string[] domains = { "hotmail.com", "gmail.com", "aol.com", "mail.com" , "mail.kz", "yahoo.com", "abv.bg"};
            string email = "";
            
            while(new Context().Parents.ToList().Any(x => x.Email == email) || new Context().Teachers.ToList().Any(x => x.Email == email)) email = GenerateEmailName() + '@' + domains[new Random().Next(domains.Length)];

            return email;

        }

        private static string GenerateEmailName(int n=10){
            
            char[] characters = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            string name = "";
            for(int i = 0; i < n; i++) name += characters[new Random().Next(characters.Length)];
            return name;

        }

        public static string GetRandomCourseName(string type=""){
            
            string[] courseNames = {"Lego", "Teaching da yung ones", "MBOT!"};
            if(type.Contains("Lego")) return courseNames[0];
            if(type.Contains("Little")) return courseNames[1];
            if(type.Contains("MBOT")) return courseNames[2];
            return courseNames[new Random().Next(courseNames.Length)];

        }

        public static string GetRandomCourseType(){

            string[] courseTypes = {"Lego robotics", "Little engineers", "MBOT"};
            return courseTypes[new Random().Next(courseTypes.Length)];
            
        }

        public static string GetRandomAgeGroup(){

            string[] ageGroups = {"5-6yo", "7-8yo", "9-12yo", "13-16yo", "17-18yo"};
            return ageGroups[new Random().Next(ageGroups.Length)];
            
        }

        public static DateTime GetRandomStartDate(){

            int[] date = new int[3];

            date[0] = new Random().Next(DateTime.Now.Year, DateTime.Now.Year + 3);

            
            date[1] = new Random().Next(1, 13);
            if((date[1] % 2 == 0 && date[1] < 7) || (date[1] % 2 == 1 && date[1] > 7))
                if(date[1] == 2)
                    if(DateTime.IsLeapYear(date[0])) date[2] = new Random().Next(1, 30);
                    else date[2] = new Random().Next(1, 29);
                else date[2] = new Random().Next(1, 31);
            else date[2] = new Random().Next(1, 32);

            return new DateTime(date[0], date[1], date[2]);

        }

        public static int GetRandomFee(int lowerEnd=20, int higherEnd=200){
            return new Random().Next(lowerEnd, higherEnd + 1);
        }

        //Maybe make it generate random floating point amounts
        public static double GetRandomAmount(int lowerEnd=20, int higherEnd=60){
            return new Random().Next(lowerEnd, higherEnd + 1);
        }

        public static string GetRandomDiscount(){

            string[] discounts = {"Big", "Medium", "Small"};
            return discounts[new Random().Next(discounts.Length)];

        }

        public static Guid GetRandomChildID(){
            using(Context context = new Context()){
                return context.Children.ToList()[new Random().Next(context.Children.ToList().Count)].ID;
            }
        }

        public static Guid GetRandomParentID(){
            using(Context context = new Context()){
                return context.Parents.ToList()[new Random().Next(context.Parents.ToList().Count)].ID;
            }
        }

        public static Guid GetRandomTeacherID(){
            using(Context context = new Context()){
                return context.Teachers.ToList()[new Random().Next(context.Teachers.ToList().Count)].ID;
            }
        }

        public static Guid GetRandomCourseID(){
            using(Context context = new Context()){
                return context.Courses.ToList()[new Random().Next(context.Courses.ToList().Count)].ID;
            }
        }

    }

}