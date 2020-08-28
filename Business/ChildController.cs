using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class ChildController{

        private static Context context;

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