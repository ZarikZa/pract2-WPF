using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace paraAdaptivnayaverstka
{
    internal class Logic : ICRUD
    {
        public void Create(string name, string description, DateTime date)
        {
            var zapiskas = Converter.Jsonviser<List<Zapiska>>("practa2\\Zapiski.json")??new List<Zapiska>();
            Zapiska zapiska = new Zapiska(name, description, date);

            zapiskas.Add(zapiska);

            Converter.Jsonser(zapiskas, "practa2\\Zapiski.json");
        }      
        public List<Zapiska> Read(DateTime data)
        {
            var zapiskas = Converter.Jsonviser<List<Zapiska>>("practa2\\Zapiski.json");

            List<Zapiska> NujnieZapiski = new List<Zapiska>();
            if(zapiskas != null)
            {
                foreach(var item in zapiskas)
                {
                    if(data == item.DateVipol)
                    {
                        NujnieZapiski.Add(item);
                    }
                }
            }
            return NujnieZapiski;
        }      
        public void Update(string name, string description, string oldname)
        {
            var zapiskas = Converter.Jsonviser<List<Zapiska>>("practa2\\Zapiski.json");

            foreach (var item in zapiskas)
            {
                if (oldname == item.Name)
                {
                    item.Name = name;
                    item.Description = description;
                }
            }
            Converter.Jsonser(zapiskas, "practa2\\Zapiski.json");
        }      
        public void Delete(Zapiska zap)
        {
            var zapiskas = Converter.Jsonviser<List<Zapiska>>("practa2\\Zapiski.json");
            for (int i = 0; i < zapiskas.Count; i++)
            {
                if (zapiskas[i].Name == zap.Name && zapiskas[i].Description == zap.Description  && zapiskas[i].DateVipol == zap.DateVipol)
                {
                    zapiskas.Remove(zapiskas[i]);
                }
            }
            Converter.Jsonser(zapiskas, "practa2\\Zapiski.json");
        }
    }
}


