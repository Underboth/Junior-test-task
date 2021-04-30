using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task.Models;

namespace Test_task.Models
{
    static class Data
    {
        public static string Appeal_File_Path;
        public static string RKK_File_Path;
        public static BindingList<TableModel> Temp = new BindingList<TableModel>();
        public static Stopwatch sWatch = new Stopwatch();
    }
}
