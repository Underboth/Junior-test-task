using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_task.Models
{
    class Persons
    {
        public string _Name;
        public int _CountDoc;
        public int _CountAppeal;

        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }
        public int CountDoc
        {
            set { _CountDoc = value; }
            get { return _CountDoc; }
        }
        public int CountAppeal
        {
            set { _CountAppeal = value; }
            get { return _CountAppeal; }
        }

        public Persons(string Name, int CountDoc, int CountAppeal) { this.Name = Name; this.CountDoc = CountDoc; this.CountAppeal = CountAppeal; }
        public Persons(string Name) { this.Name = Name; }
        public Persons(int CountDoc, int CountAppeal) { this.CountDoc = CountDoc; this.CountAppeal = CountAppeal; }
    }
}

