using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Test_task.Models
{
    class TableModel
    {
        private int _Id;
        private string _Name;
        private int _RKK_Count;
        private int _Appeal_Count;
        private int _RKK_Plus_Appeal_Count;
        private int _SumAllRKK;
        private int _SumAllAppeals;
        private int _SumAllRKKPlusAppeals;


        public int SumAllRKK
        {
            get { return _SumAllRKK; }
            set
            {
                if (value is int) { _SumAllRKK = +value; }
                else { _SumAllRKK = 0; }
            }
        }
        public int SumAllAppeals
        {
            get { return _SumAllAppeals; }
            set
            {
                if (value is int) { _SumAllAppeals += value; }
                else { _SumAllAppeals = 0; }
            }
        }
        public int SumAllRKKPlusAppeals
        {
            get { return _SumAllRKKPlusAppeals; }
            set
            {
                if (value is int) { _SumAllRKKPlusAppeals += value; }
                else { _SumAllRKK = 0; }
            }
        }
        public int Id
        {
            get { return _Id; }
            set
            {
                if (value is int) { _Id = value; }
                else { _Id = 0; }
            }
        }
        public int RKK_Count
        {
            get { return _RKK_Count; }
            set
            {
                if (value is int) { _RKK_Count = value; }
                else { _RKK_Count = 0; }
            }
        }
        public int Appeal_Count
        {
            get { return _Appeal_Count; }
            set
            {
                if (value is int) { _Appeal_Count = value; }
                else { _Appeal_Count = 0; }
            }
        }
        public int RKK_Plus_Appeal_Count
        {
            get { return _RKK_Plus_Appeal_Count; }
            set
            {
                if (value is int) { _RKK_Plus_Appeal_Count = value; }
                else { _RKK_Plus_Appeal_Count = 0; }
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value is string) { _Name = value; }
                else { _Name = "Ошибка типа данных"; }
            }
        }



    }
}
