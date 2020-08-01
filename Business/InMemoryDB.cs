using System.Collections.Generic;
using crm.Data.Models;

namespace crm.Business{

    public class InMemoryDB{

        public InMemoryDB():base(){}

        public List<Registration> Registration { get; set; } = new List<Registration>();

    }

}