using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_task.Views;

namespace Test_task.Models.TableWindowModels
{
    class Parser
    {
        public List<string> parser(string Path, TableWindow window)
        {
            StreamReader Reader = new StreamReader(Path);
            string File_data = Reader.ReadToEnd();
            Reader.Close();
            string[] Temp = File_data.Split(new char[] { ' ', '\r', '\n', ';' });
            StreamWriter FileWriter = new StreamWriter(window.TextParser);
            List<string> File_List = Temp.ToList<string>();

            for (int i = File_List.Count - 1; i > 0; i--)
            {
                if ((File_List[i] == "") || (File_List[i] == ";"))
                {
                    File_List.RemoveAt(i);

                }
            }
            int len = File_List.Count;

            for (int i = 0; i < File_List.Count; i++)
            {
                if (i + 1 < File_List.Count)
                {
                    if (File_List[i + 1].Contains("."))
                    {
                        if (i + 2 < File_List.Count)
                        {
                            if (File_List[i + 2].Contains("(Отв.)"))
                            {
                                window.NameSet.Add(File_List[i] + " " + File_List[i + 1]);
                                File_List[i] = File_List[i] + " " + File_List[i + 1] + " " + File_List[i + 2];
                                File_List.RemoveAt(i + 1);
                                File_List.RemoveAt(i + 1);

                            }
                            else
                            {
                                window.NameSet.Add(File_List[i] + " " + File_List[i + 1]);
                                File_List[i] = File_List[i] + " " + File_List[i + 1];
                                File_List.RemoveAt(i + 1);
                                File_List[i].Replace(";", "");
                            }
                        }
                    }
                    else
                    {
                        if (i + 3 < File_List.Count)
                        {
                            if (File_List[i + 3].Contains("(Отв.)"))
                            {
                                window.NameSet.Add(File_List[i] + " " + File_List[i + 1][0] + "." + File_List[i + 2][0] + ".");
                                File_List[i] = File_List[i] + " " + File_List[i + 1][0] + "." + File_List[i + 2][0] + ". " + File_List[i + 3];
                                File_List.RemoveAt(i + 1);
                                File_List.RemoveAt(i + 1);
                                File_List.RemoveAt(i + 1);
                            }
                            else
                            {
                                window.NameSet.Add(File_List[i] + " " + File_List[i + 1][0] + "." + File_List[i + 2][0] + ".");
                                File_List[i] = File_List[i] + " " + File_List[i + 1][0] + "." + File_List[i + 2][0] + ".";
                                File_List.RemoveAt(i + 1);
                                File_List.RemoveAt(i + 1);
                            }
                        }
                    }
                }
            }
            //Проверка последних элементов на особые случаи
            if ((File_List[File_List.Count - 1].Contains('.')) && (File_List[File_List.Count - 1].Length == 4))
            {
                window.NameSet.Add(File_List[File_List.Count - 2] + " " + File_List[File_List.Count - 1]);
                File_List[File_List.Count - 2] += " " + File_List[File_List.Count - 1];
                File_List.RemoveAt(File_List.Count - 1);
            }

            foreach (string item in File_List)
            {
                FileWriter.WriteLine(item);
            }
            FileWriter.Close();

            return File_List;

        }
    }
}
