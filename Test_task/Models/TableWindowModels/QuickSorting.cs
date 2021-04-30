using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task.Models;

namespace Test_task.Models.TableWindowModels
{ 
    class QuickSorting
    {
        public static void sortingRKK(BindingList<TableModel> List, int first, int last)
        {
            double p = List[(last - first) / 2 + first].RKK_Count;
            TableModel temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (List[i].RKK_Count < p && i <= last) ++i;
                while (List[j].RKK_Count > p && j >= first) --j;
                if (i <= j)
                {
                    temp = List[i];
                    List[i] = List[j];
                    List[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) sortingRKK(List, first, j);
            if (i < last) sortingRKK(List, i, last);
        }

        public static void sortingAppeal(BindingList<TableModel> List, int first, int last)
        {
            double p = List[(last - first) / 2 + first].Appeal_Count;
            TableModel temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (List[i].Appeal_Count < p && i <= last) ++i;
                while (List[j].Appeal_Count > p && j >= first) --j;
                if (i <= j)
                {
                    temp = List[i];
                    List[i] = List[j];
                    List[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) sortingAppeal(List, first, j);
            if (i < last) sortingAppeal(List, i, last);
        }

        public static void sortingSum(BindingList<TableModel> List, int first, int last)
        {
            double p = List[(last - first) / 2 + first].RKK_Plus_Appeal_Count;
            TableModel temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (List[i].RKK_Plus_Appeal_Count < p && i <= last) ++i;
                while (List[j].RKK_Plus_Appeal_Count > p && j >= first) --j;
                if (i <= j)
                {
                    temp = List[i];
                    List[i] = List[j];
                    List[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) sortingSum(List, first, j);
            if (i < last) sortingSum(List, i, last);
        }
    }
}

