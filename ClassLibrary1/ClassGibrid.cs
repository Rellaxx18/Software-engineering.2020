using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class ClassGibrid : Suchestvo
    {
        public ClassGibrid(string name, string pict, string info) : base(name, pict, info)
        {
            klass = "Гибрид";
        }
        internal ClassGibrid() : base()
        {

        }
        //public string Klass = "Гибрид";
        public override string fighting_methods()
        {
            return "Используйте масло против гибридов, знак квен"; 
        }
        public override string immunity()
        {
            return "К огню, к Аксию";
        }
    }
}
