using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Test_task.Models;
using Test_task.Models.TableWindowModels;
using SautinSoft.Document;
using SautinSoft.Document.Tables;

namespace Test_task.Views
{
    /// <summary>
    /// Логика взаимодействия для TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        BindingList<TableModel> TableList = new BindingList<TableModel>();

        private List<Persons> People = new List<Persons>();

        public SortedSet<string> NameSet = new SortedSet<string>();

        public string TextParser = Environment.CurrentDirectory.ToString() + "//TextParser";

        private Parser p = new Parser();
        public TableWindow()
        {
            InitializeComponent();
        }
        public void CountDoc(List<string> Data_List)
        {
            int Docs = 0;
            for (int i = 0; i < NameSet.Count; i++)
            {
                People.Add(new Persons((NameSet.ToList<string>())[i]));
            }


            for (int i = 0; i < Data_List.Count; i++)
            {

                if (!Data_List[i].Contains("(Отв.)"))
                {
                    Docs++;
                }
                else
                {
                    for (int j = 0; j < People.Count; j++)
                    {
                        if (People[j].Name + " (Отв.)" == Data_List[i])
                        {
                            People[j].CountDoc += Docs;
                            Docs = 0;
                        }
                    }
                }
            }
        }
        public void CountAppeal(List<string> Data_List)
        {
            int Docs = 0;
            for (int i = 0; i < NameSet.Count; i++)
            {
                People.Add(new Persons((NameSet.ToList<string>())[i]));
            }

            for (int i = 0; i < Data_List.Count; i++)
            {

                if (!Data_List[i].Contains("(Отв.)"))
                {
                    Docs++;
                }
                else
                {
                    for (int j = 0; j < People.Count; j++)
                    {
                        if (People[j].Name + " (Отв.)" == Data_List[i])
                        {
                            People[j].CountAppeal += Docs;
                            Docs = 0;
                        }
                    }
                }
            }
        }
        public void CreateTable()
        {


            for (int i = 0; i < NameSet.Count; i++)
            {
                TableList.Add(new TableModel()
                {
                    Id = i + 1,
                    Name = People[i].Name,
                    Appeal_Count = People[i].CountAppeal,
                    RKK_Count = People[i].CountDoc,
                    RKK_Plus_Appeal_Count = People[i].CountAppeal + People[i].CountDoc
                });
            }

            TableList.ToList<TableModel>();
            for (int i = 0; i < TableList.Count; i++)
            {
                for (int j = 0; j < TableList.Count; j++)
                {
                    if (TableList[i].Name == TableList[j].Name && i != j)
                    {
                        TableList[i].RKK_Count += TableList[j].RKK_Count;
                        TableList[i].Appeal_Count += TableList[j].Appeal_Count;
                        TableList[i].RKK_Plus_Appeal_Count += TableList[j].RKK_Plus_Appeal_Count;
                        TableList.Remove(TableList[j]);
                    }
                }
            }
        }
        public void ClearTextDoc()
        {
            FileStream fs = File.Open(TextParser, FileMode.Open, FileAccess.ReadWrite);
            fs.SetLength(0);
            fs.Close();
        }

        public void TableListReverse()
        {
            BindingList<TableModel> Temp = new BindingList<TableModel>();
            for (int i = 0; i < TableList.Count; i++)
            {
                Temp.Add(TableList[i]);
            }
            TableList.Clear();
            for (int i = Temp.Count - 1; i >= 0; i--)
            {
                TableList.Add(Temp[i]);
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (SortSelect.SelectedIndex == 0)
            {
                TableList.Clear();
                CreateTable();

            }
            if (SortSelect.SelectedIndex == 1)
            {
                QuickSorting.sortingRKK(TableList, 0, TableList.Count - 1);
                TableListReverse();
            }
            if (SortSelect.SelectedIndex == 2)
            {
                QuickSorting.sortingAppeal(TableList, 0, TableList.Count - 1);
                TableListReverse();

            }
            if (SortSelect.SelectedIndex == 3)
            {
                QuickSorting.sortingSum(TableList, 0, TableList.Count - 1);
                TableListReverse();

            }
            for (int i = 0; i < TableList.Count; i++)
            {
                TableList[i].Id = i + 1;
            }

        }

        private void ALLFILECOUNT_Loaded(object sender, RoutedEventArgs e)
        {
            int Sum = 0;
            for (int i = 0; i < TableList.Count; i++)
            {
                Sum += (int)TableList[i].RKK_Plus_Appeal_Count;
            }
            ALLFILECOUNT.Text = Sum.ToString();
        }

        private void ALLRKK_Loaded(object sender, RoutedEventArgs e)
        {
            int Sum = 0;
            for (int i = 0; i < TableList.Count; i++)
            {
                Sum += (int)TableList[i].RKK_Count;
            }
            ALLRKK.Text = Sum.ToString();
        }

        private void ALLAPPEALS_Loaded(object sender, RoutedEventArgs e)
        {
            int Sum = 0;
            for (int i = 0; i < TableList.Count; i++)
            {
                Sum += (int)TableList[i].Appeal_Count;
            }
            ALLAPPEALS.Text = Sum.ToString();
        }

        private void DATA_Loaded(object sender, RoutedEventArgs e)
        {
            DATA.Content = (DateTime.Now).ToString().Split(' ')[0];
        }
        #region Создание RTF файла
        private void CREATETXT_Click(object sender, RoutedEventArgs e)
        {

            FileInfo TableFile = new FileInfo("TableFile.rtf");

            DocumentCore dc = new DocumentCore();
            DocumentBuilder db = new DocumentBuilder(dc);
            db.TableFormat.PreferredWidth = new TableWidth(LengthUnitConverter.Convert(7, LengthUnit.Inch, LengthUnit.Point), TableWidthUnit.Point);
            db.CellFormat.Padding = new Padding(5, LengthUnit.Point);
            db.CellFormat.Borders.SetBorders(MultipleBorderTypes.Outside,BorderStyle.Single , SautinSoft.Document.Color.Black, 1);

            
            db.InsertCell();
            db.Write("№ п.п.");
            db.InsertCell();
            db.Write("Ответственный исполнитель\t");
            db.InsertCell();
            db.Write("Количество неисполненных входящих документов\t");
            db.InsertCell();
            db.Write("Количество неисполненных письменных обращений граждан\t");
            db.InsertCell();
            db.Write("Общее количество документов и обращений\t");
            db.EndRow();

            for (int i = 0; i < TableList.Count; i++)
            {
                db.InsertCell();
                db.Write(TableList[i].Id.ToString());
                db.InsertCell();
                db.Write(TableList[i].Name);
                db.InsertCell();
                db.Write(TableList[i].RKK_Count.ToString());
                db.InsertCell();
                db.Write(TableList[i].Appeal_Count.ToString());
                db.InsertCell();
                db.Write(TableList[i].RKK_Plus_Appeal_Count.ToString());
                db.EndRow();
            }
            db.EndTable();
            dc.Save(TableFile.FullName);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(TableFile.FullName) { UseShellExecute = true });

        }
        #endregion Создание
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            dgTableList.ItemsSource = TableList;

            CountDoc(p.parser(Data.RKK_File_Path, this));
            ClearTextDoc();
            CountAppeal(p.parser(Data.Appeal_File_Path, this));
            ClearTextDoc();
            CreateTable();

            for (int i = 0; i < TableList.Count - 1; i++)
            {
                Data.Temp.Add(TableList[i]);
            }
            Data.sWatch.Stop();
            this.PROGRAMM_TIME.Content = (("Время выполнения алгоритма: "+Data.sWatch.ElapsedMilliseconds).ToString()+" миллисекунд");
        } 
    }
}

