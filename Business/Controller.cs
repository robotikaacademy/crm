using System.Collections.Generic;
using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class Controller{

        private static Context context;

        public static void AddParents(){
            using(context = new Context()){
                string[] names = System.IO.File.ReadLines("names.txt").Take(20).ToArray();
                foreach(string name in names){

                    Parent newParent = new Parent();
                    newParent.ID = Guid.NewGuid();
                    newParent.Name = name;
                    newParent.Phone = "";
                    newParent.Email = "";
                    newParent.Note = "";
                    context.Parent.Add(newParent);
                    context.SaveChanges();

                }
            }
        }

        public static List<string> GetParents(){
            using(context = new Context()){
                return context.Parent.Select(x => x.Name).ToList();
            }
        }

        public static void ClearEntries(){
            using(context = new Context()){
                while(context.Parent.ToList().Count > 0){

                    context.Parent.Remove(context.Parent.First());
                    context.SaveChanges();
                    
                }
            }
        }

    }

}