using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class ClassNEW : Suchestvo
    {
        //public string klass;
        public string Fighting_metods;
        public string immunity1;
        public ClassNEW(string name, string pict, string info) : base(name, pict, info)
        {

        }
        internal ClassNEW() : base()
        {

        }
        //public void setklass(string kl)
        //{
        //    klass = kl;
        //}
        public void setFightm(string FM)
        {
            Fighting_metods = FM;
        }
        public void setImmun(string IM)
        {
            immunity1 = IM;
        }
        public override string fighting_methods()
        {
            return Fighting_metods;
        }
        public override string immunity()
        {
            return immunity1;
        }
        //public string getKlass()
        //{
        //    return Klass;
        //}
    }
}
