using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    abstract public class Suchestvo
    {
        public List <string> linkfriend;
        public List <string> linkenemy;
        public string NameSush { get; set; }
        public string PictSush { get; set; }
        public string InfoSuch { get; set; }
        public string DopFightMet { get; set; } = "";
        public string klass;

        internal Suchestvo()
        {
        }
        public Suchestvo(string name, string pict, string info)
        {
            NameSush = name;
            PictSush = pict;
            InfoSuch = info;
        }

        public abstract string fighting_methods();
        public abstract string immunity();

        public string getKlass()
        {
            return klass;
        }
        public void setklass(string kl)
        {
            klass = kl;
        }
        public void addlinkfriend (List <string> ab)
        {
            linkfriend = ab;
        }
        public void addlinkenemy(List<string> ab)
        {
            linkenemy = ab;
        }
        public List<string> getfriend()
        {
            return linkfriend;
        }
        public List<string> getenemy()
        {
            return linkenemy;
        }
    }
}
