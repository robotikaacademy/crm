using System.Collections.Generic;
using crm.Data.Models;
using System.Linq;
using FuzzySharp;
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
        
        private static string[] GetChildrenNames(){
            using(context = new Context()){
                return context.Children.Select(x => x.Name).ToArray();
            }
        }

        public static Child GetChildById(Guid id){
            using(context = new Context()){
                return context.Children.Find(id);
            }
        }

        public static void ClearEntries(){
            using(context = new Context()){
                while(context.Children.Count() > 0){

                    context.Children.Remove(context.Children.First());
                    context.SaveChanges();
                    
                }
            }
        }


        public static Parent[] GetParentsOfChild(Guid id){
            using(context = new Context()){
                return context.Parents.Where(x => context.Child_Parents.Where(y => y.ChildId == id).Any(y => y.ParentId == x.ID)).ToArray();
            }
        }

        public static Child[] SearchChildrenByName(string name){
            using(context = new Context()){
                return context.Children.Where(x => x.Name == ApproximateSearch.GetTopResult(name, GetChildrenNames())).ToArray();
            }
        }

    }

}