using FizzWare.NBuilder;
using LinqToExcel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_AVLStudent.Model;

namespace Wpf_AVLStudent.MyUtilities
{
    public class Helper:IHelper
    {
        #region Helper
        public void ShowMessBoxTraversal(List<string> list, string name)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                builder.Append(list[i]);
                builder.Append("\n");
            }
            MessageBox.Show(builder.ToString(), $"Traversal {name}", MessageBoxButton.OK);
        }
      
        public List<T> GetRandomData<T>(int size)
        {
            var list = Builder<T>.CreateListOfSize(size).Build().ToList();

            return list;
        }

        public List<Student> GetData(int size)
        {
            Random random = new Random();
            var list = GetRandomData<Student>(size);
            Parallel.ForEach(list, (item) =>
            {
                item.Id = item.Id - random.Next(0, 500) / 2 + random.Next(0, 500) + random.Next(0, 500) * 2;
                float mark = (random.Next(0, 10) / 1.0f) + 10.0f / (random.Next(0, 99) * 1.0f);
                item.AvgMark = float.Parse(String.Format("{0:0.00}", mark));
            });
            return list;
        }
        
        public Student[] GetDataFromExcel()
        {
            Student[] students;
            var open = new OpenFileDialog() { Filter = "Excel Workbook[97-2003] | *.xls|Excel Workbook|*.xlsx", ValidateNames = true };
            int i = 0;
            if (open.ShowDialog() == true)
            {
                string fileName = open.FileName;
                var excelFile = new ExcelQueryFactory(fileName);
                var dataExcel = from a in excelFile.Worksheet() select a;
                students = new Student[dataExcel.Count()];
                foreach (var a in dataExcel)
                {
                    try
                    {
                        var ID = a[0].Cast<int>();
                        var Name = a[1].Value.ToString();
                        var AvgMark = a[2].Cast<float>();
                        var AccumulationCredit = a[3].Cast<int>();
                        var BirthDay = a[4].Cast<DateTime>();
                        Student student = new Student(ID, Name, BirthDay, AvgMark, AccumulationCredit);
                        //tree.Insert(new Node<Student>(student));
                        students[i] = student;
                        i++;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        MessageBox.Show("Something wrong with data !Please try again !");
                    }
                }
                return students;
            }
            return null;
        }
        #endregion
    }
}
