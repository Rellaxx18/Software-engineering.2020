using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class ClassOgr : Suchestvo
    {
        public ClassOgr(string name, string pict, string info) : base(name, pict, info)
        {
            klass = "Огр";
        }
        internal ClassOgr():base()
        {

        }
        public override string fighting_methods()
        {
            return "Используйте яды";
        }
        public override string immunity()
        {
            return "К кровотечению, к оглушению";
        }
    }
}
