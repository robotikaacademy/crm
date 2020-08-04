using System.Diagnostics;

namespace crm{

    public class StartProcess{

        public string Start(string name){

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\Krash\AppData\Local\Programs\Python\Python38\python.exe";

            string script = "\"D:/Programs/Solutions/My Projects/crm/Additional Files/ApproximateMatching.py\"";
            psi.Arguments = $"{script} {name}";

            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;

            string errors = "", results = "";
            using(var process = Process.Start(psi)){
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            string topResult = results.Split('\'')[1];
            return topResult;

        }

    }

}