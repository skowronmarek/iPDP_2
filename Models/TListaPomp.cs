using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace iPDP.Models
{    
    public class TListaPomp
    {
        public IList<TPompa> fLista = new List<TPompa>();
        //public static IList<TPompa> fLista = new List<TPompa>(); // statyczna dostepna w caly

        public IEnumerable<TPompa> Lista
        {
            get
            {
                return fLista;
            }
        }

        public void AddPompa(TPompa Pompa)
        {
            fLista.Add(Pompa);
        }

    }


}
