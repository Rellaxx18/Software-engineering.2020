using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class ClassdRAKONID : Suchestvo
    {
        public ClassdRAKONID(string name, string pict, string info) : base(name, pict, info)
        {
            klass = "Драконид";
            //linkfriend = 
        }
        internal ClassdRAKONID():base()
        {

        }
         
        public override string fighting_methods()
        {
            return "Используйте серебро";
        }
        public override string immunity()
        {
            return "К оглушению, к ядам";
        }
    }
}
