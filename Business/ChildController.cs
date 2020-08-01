using System.Collections.Generic;
using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class ChildController{

        private static Context context;

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

        public static Guid GetChildID(string name){
            using(context = new Context()){
                return context.Children.ToList().Find(x => x.Name == name).ID;
            }
        }
        
        public static List<string> GetChildren(){
            using(context = new Context()){
                return context.Children.Select(x => x.Name).ToList();
            }
        }

        public static void ClearEntries(){
            using(context = new Context()){
                while(context.Children.ToList().Count > 0){

                    context.Children.Remove(context.Children.First());
                    context.SaveChanges();
                    
                }
            }
        }

    }

}