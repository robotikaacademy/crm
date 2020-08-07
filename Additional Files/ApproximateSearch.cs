using System.Linq;
using FuzzySharp;

namespace crm{
    
    public static class ApproximateSearch{

        public static string GetTopResult(string name, string[] collection){
            return Process.ExtractTop(name, collection, limit: 3).ToArray()[0].Value;
        }

    }

}