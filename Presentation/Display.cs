using System.Collections.Generic;
using crm.Business;
using System;

namespace crm.Presentation{
    
    public class Display{

        public Display(){
            Controller.ClearEntries();
            Controller.AddParents();
            List<string> parents = Controller.GetParents();
            foreach(string parent in parents)
                System.Console.WriteLine(parent);
        }

    }

}