using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paraAdaptivnayaverstka
{
    internal interface ICRUD
    {
        void  Create(string name, string description, DateTime date);
        List<Zapiska> Read(DateTime date);
        void  Update(string name, string description, string oldname);
        void  Delete(Zapiska zap);
    }
}
