using crm.Data.Models;
using System.Linq;
using crm.Data;
using System;

namespace crm.Business{
    
    static class Child_ParentsController{

        private static Context context;

        public static void AddConnection(){
            using(context = new Context()){
                Child_Parents newConnection = new Child_Parents();
                newConnection.ID = Guid.NewGuid();
                newConnection.ChildId = RandomData.GetRandomChildID();
                newConnection.ParentId = RandomData.GetRandomParentID();
                if(context.Child_Parents.ToList().Any(x => x.ChildId == newConnection.ChildId && x.ParentId == newConnection.ParentId))
                    throw new ArgumentException("Connection already exists");
                context.Child_Parents.Add(newConnection);
                context.SaveChanges();
            }
        }

        public static void ClearEntries(){
            using(context = new Context()){
                while(context.Child_Parents.Count() > 0){

                    context.Child_Parents.Remove(context.Child_Parents.First());
                    context.SaveChanges();
                    
                }
            }
        }

    }

}