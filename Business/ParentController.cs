using System.Collections.Generic;
using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class ParentController{

        private static Context context;

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

        public static Guid GetParentID(string name){
            using(context = new Context()){
                return context.Parents.ToList().Find(x => x.Name == name).ID;
            }
        }

        public static string[] GetParents(){
            using(context = new Context()){
                return context.Parents.Select(x => x.Name).ToArray();
            }
        }

        public static void ClearEntries(){
            using(context = new Context()){
                while(context.Parents.Count() > 0){

                    context.Parents.Remove(context.Parents.First());
                    context.SaveChanges();
                    
                }
            }
        }

        public static string[] GetContactsOfParent(Guid id){
            using(context = new Context()){
                Parent parent = context.Parents.Find(id);
                return new string[]{parent.Phone, parent.Email};
            }
        }

    }

}