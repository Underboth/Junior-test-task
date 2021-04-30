using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_task.Views;

namespace Test_task.Models.InputTableWindowModels
{
    class CreateTable
    {
        public CreateTable()
        {
            if ((Data.RKK_File_Path != null) && (Data.Appeal_File_Path != null))
            {
                TableWindow taskWindow = new TableWindow();
                taskWindow.Show();
            }
            else
            {
                ErrorMessege Error = new ErrorMessege();
                Error.Show();
            }
        }
    }
}
