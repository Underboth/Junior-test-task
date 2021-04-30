using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace Test_task.Models.InputTableWindowModels
{
    class SelectPath
    {
        public string Path;
        public string FileName;

        public SelectPath()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            file.Filter = "Text files (*.txt)|*.txt";
            if (file.ShowDialog() == true)
                FileName = System.IO.Path.GetFileName(file.FileName);
            Path = file.FileName;
        }
           
    }
}
