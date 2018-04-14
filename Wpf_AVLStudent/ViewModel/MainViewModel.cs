using FizzWare.NBuilder;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LinqToExcel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wpf_AVLStudent.Model;
using Wpf_AVLStudent.MyUtilities;

namespace Wpf_AVLStudent.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Property
        private ITree<Student> tree;
        private IUtilities getUtilities;

        public ITree<Student> Tree { get => tree; set => tree = value; }
        private string name;
        private string avgMark;
        private string accumulationCredit;
        private DateTime birthDay = DateTime.Now;
        private string id;

        private string nameUpdate;
        private string avgMarkUpdate;
        private string accumulationCreditUpdate;
        private DateTime birthDayUpdate = DateTime.Now;
        private string idUpdate;

        private string txbFindName;
        private string txbFindAvgMark;
        private string txbFindAccumulationCredit;
        private DateTime dpkFindBirthDay = DateTime.Now;
        private string txbFindId;

        private int numbeFind;
        private int numBeDelete;
        private bool isRdbFindId;
        private bool isRdbFindName;
        private bool isRdbFindAvgMark;
        private bool isRdbFindAccumulationCredit;
        private bool isRdbFindBirthDay;
        private bool isRdbSuperLeft;
        private bool isRdbSuperRight;
        private bool isRdbNormal;
        private bool isTxbDeleteNode;
        private bool isTxbUpdateStudent = true;
        private bool isToggleBtnUpdate;
        private bool isTxbUpdateName;
        private bool isTxbUpdateAvgMark;
        private bool isTxbUpdateAccumulationCredit;
        private bool isDpkUpdateBirthDay;
        private bool isTxbIdAdd;
        private bool isTxbNameAdd;
        private bool isTxbAvgMarkAdd;
        private bool isTxbAccumulationCreditAdd;
        private bool isDpkBirthDayAdd;
        private bool isCkbAddArray = false;
        private bool isCkbDeleteArray = false;
        private readonly int VerticalMarging = 100;
        private readonly int HorizontalMarging = 50;
        private double heightGridBST;
        private double widthGridBST;

        private ICommand btnAddNodeClickCommand;
        private ICommand btnFindNodeClickCommand;
        private ICommand btnDeleteNodeClickCommand;
        private ICommand btnUpdateClickCommand;
        private ICommand btnTraversal;
        private ICommand btnGenerateData;
        private ICommand btnClear;
        private ICommand expClearData;

        public string IdUpdate { get => idUpdate; set => idUpdate = value; }
        public string NameUpdate { get => nameUpdate; set => nameUpdate = value; }
        public string AvgMarkUpdate { get => avgMarkUpdate; set => avgMarkUpdate = value; }
        public string AccumulationCreditUpdate { get => accumulationCreditUpdate; set => accumulationCreditUpdate = value; }
        public DateTime BirthDayUpdate { get => birthDayUpdate; set => birthDayUpdate = value; }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string AvgMark { get => avgMark; set => avgMark = value; }
        public string AccumulationCredit { get => accumulationCredit; set => accumulationCredit = value; }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }

        public int NumbeFind { get => numbeFind; set => numbeFind = value; }
        public int NumBeDelete { get => numBeDelete; set => numBeDelete = value; }
        public double WidthGridBST
        {
            get => widthGridBST;
            set
            {
                widthGridBST = value;
                RaisePropertyChanged("WidthGridBST");
            }
        }
        public double HeightGridBST { get => heightGridBST; set { heightGridBST = value; RaisePropertyChanged("HeightGridBST"); } }

        public bool IsTxbDeleteNode { get => isTxbDeleteNode; set => isTxbDeleteNode = value; }
        public bool IsToggleBtnUpdate { get => isToggleBtnUpdate; set => isToggleBtnUpdate = value; }
        public bool IsTxbUpdateStudent { get => isTxbUpdateStudent; set => isTxbUpdateStudent = value; }
        public bool IsTxbUpdateName { get => isTxbUpdateName; set => isTxbUpdateName = value; }
        public bool IsTxbUpdateAvgMark { get => isTxbUpdateAvgMark; set => isTxbUpdateAvgMark = value; }
        public bool IsDpkUpdateBirthDay { get => isDpkUpdateBirthDay; set => isDpkUpdateBirthDay = value; }
        public bool IsTxbUpdateAccumulationCredit { get => isTxbUpdateAccumulationCredit; set => isTxbUpdateAccumulationCredit = value; }
        public bool IsCkbAddArray
        {
            get
            {
                ChangeStateTxbAdd(isCkbAddArray);
                return isCkbAddArray;
            }
            set => isCkbAddArray = value;
        }
        public bool IsCkbDeleteArray
        {
            get
            {
                ChangeStateTxbDelete(isCkbDeleteArray);
                return isCkbDeleteArray;
            }
            set => isCkbDeleteArray = value;
        }
        public bool IsTxbIdAdd { get => isTxbIdAdd; set => isTxbIdAdd = value; }
        public bool IsTxbNameAdd { get => isTxbNameAdd; set => isTxbNameAdd = value; }
        public bool IsTxbAvgMarkAdd { get => isTxbAvgMarkAdd; set => isTxbAvgMarkAdd = value; }
        public bool IsTxbAccumulationCreditAdd { get => isTxbAccumulationCreditAdd; set => isTxbAccumulationCreditAdd = value; }
        public bool IsDpkBirthDayAdd { get => isDpkBirthDayAdd; set => isDpkBirthDayAdd = value; }
        public bool IsRdbSuperLeft { get => isRdbSuperLeft; set => isRdbSuperLeft = value; }
        public bool IsRdbSuperRight { get => isRdbSuperRight; set => isRdbSuperRight = value; }
        public bool IsRdbNormal { get => isRdbNormal; set => isRdbNormal = value; }
        public bool IsRdbFindId { get => isRdbFindId; set => isRdbFindId = value; }
        public bool IsRdbFindName { get => isRdbFindName; set => isRdbFindName = value; }
        public bool IsRdbFindAvgMark { get => isRdbFindAvgMark; set => isRdbFindAvgMark = value; }
        public bool IsRdbFindAccumulationCredit { get => isRdbFindAccumulationCredit; set => isRdbFindAccumulationCredit = value; }
        public bool IsRdbFindBirthDay { get => isRdbFindBirthDay; set => isRdbFindBirthDay = value; }
        public string TxbFindName { get => txbFindName; set => txbFindName = value; }
        public string TxbFindAvgMark { get => txbFindAvgMark; set => txbFindAvgMark = value; }
        public string TxbFindAccumulationCredit { get => txbFindAccumulationCredit; set => txbFindAccumulationCredit = value; }
        public DateTime DpkFindBirthDay { get => dpkFindBirthDay; set => dpkFindBirthDay = value; }
        public string TxbFindId { get => txbFindId; set => txbFindId = value; }
        public IUtilities GetUtilities { get => getUtilities; set => getUtilities = value; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ITree<Student> tree, IUtilities utilities)
        {

            this.getUtilities = utilities;
            getUtilities.Tree = tree;
            HeightGridBST = 705;
            WidthGridBST = 1138.3333333333335;
            getUtilities.WidthGridBST = WidthGridBST;
            getUtilities.VerticalMarging = VerticalMarging;
            getUtilities.HeightGridBST = HeightGridBST;

        }

        #region Command

        public ICommand BtnAddNodeClickCommand
        {
            get
            {
                return btnAddNodeClickCommand = new RelayCommand<UIElement>(async (p) =>
                 {

                     Student student;
                     if (IsCkbAddArray)
                     {
                         StringBuilder builder = new StringBuilder();
                         var list = GetDataFromExcel();
                         for (int i = 0; i < list.Length; i++)
                         {
                             if ((p as Grid).Children.OfType<Button>().Where(pa => pa.Name.Equals($"Btn{list[i].Id.ToString()}")).ToList().Count != 0)
                             {
                                 builder.Append(list[i].ToString() + "\n");
                                 continue;
                             }
                             student = new Student(list[i].Id, list[i].Name, list[i].BirthDay, list[i].AvgMark, list[i].AccumulationCredit);
                             await GetUtilities.AddButtonGridAsync(p as Grid, student);
                             await Task.Delay(1000);
                         }
                         if (builder.Length != 0)
                         {
                             MessageBox.Show("We can't add : \n" + builder.ToString());
                         }
                         return;
                     }
                     if ((Id.Trim().Length == 0) || (p as Grid).Children.OfType<Button>().Where(pa => pa.Name.Equals($"Btn{Id.ToString()}")).ToList().Count != 0)
                     {
                         MessageBox.Show($"We can't add {Id.ToString()}");
                         return;
                     }
                     student = new Student(int.Parse(Id), Name, BirthDay, float.Parse(AvgMark), int.Parse(AccumulationCredit));
                     await GetUtilities.AddButtonGridAsync(p as Grid, student);
                     HeightGridBST = GetUtilities.HeightGridBST;
                     WidthGridBST = GetUtilities.WidthGridBST;
                 });
            }
        }

        public ICommand BtnFindNodeClickCommand
        {
            get
            {
                return btnFindNodeClickCommand = new RelayCommand<object[]>((p) =>
                {

                    string propertyContent = "";
                    var propertyName = (p[1] as WrapPanel).Children.OfType<RadioButton>().Where(r => r.IsChecked == true && r.Name.StartsWith("RdbFind")).FirstOrDefault()?.Name.Substring(7);
                    if (propertyName == null)
                    {
                        MessageBox.Show("Don't have any choice!");
                        return;
                    }
                    propertyContent = (p[1] as WrapPanel).Children.OfType<TextBox>().Where(t => t.IsEnabled).FirstOrDefault().Text;

                    List<Student> students = GetUtilities.Tree.ToList().Where(pr => pr.GetType().GetProperty(propertyName).GetValue(pr, null).ToString().Equals(propertyContent)).ToList();
                    if (students == null)
                    {
                        MessageBox.Show("Don't have this student");
                        return;
                    }
                    for (int i = 0; i < students.Count; i++)
                    {
                        GetUtilities.FindNodeInGrid(new Node<Student>(students[i]), p[0] as Grid);
                    }
                });
            }
        }

        public ICommand BtnDeleteNodeClickCommand
        {
            get
            {
                return btnDeleteNodeClickCommand = new RelayCommand<Grid>(async (p) =>
                {

                    if (IsCkbDeleteArray)
                    {
                        var list = GetDataFromExcel();
                        for (int i = 0; i < list.Length; i++)
                        {
                            await HelpCommandDeleteAsync(p, list[i].Id);
                        }
                        return;
                    }
                    await HelpCommandDeleteAsync(p, NumBeDelete);
                });
            }
        }

        private async Task HelpCommandDeleteAsync(Grid grid, int id)
        {
            if ((id == null) || (grid as Grid).Children.OfType<Button>().Where(pa => pa.Name.Equals($"Btn{id.ToString()}")).ToList().Count == 0)
            {
                MessageBox.Show($"We can't delete {id.ToString()}");
                return;
            }

            await GetUtilities.DeleteNodeInGridAsync(grid, NumBeDelete);
        }
        public ICommand BtnUpdateClickCommand { get { return btnUpdateClickCommand; } }

        public ICommand BtnTraversal { get { return btnTraversal; } }

        public ICommand BtnGenerateData { get { return btnGenerateData; } }

        public ICommand BtnClear { get { return btnClear; } }

        public ICommand ExpClearData { get { return expClearData; } }
        #endregion
        #region Helper
        void ShowMessBoxTraversal(List<string> list, string name)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                builder.Append(list[i]);
                builder.Append("\n");
            }
            MessageBox.Show(builder.ToString(), $"Traversal {name}", MessageBoxButton.OK);
        }

        private void ClearDataExpAdd()
        {
            IsCkbAddArray = false;
            RaisePropertyChanged("IsCkbAddArray");
            Id = "";
            Name = "";
            AccumulationCredit = "";
            AvgMark = "";
            BirthDay = DateTime.Now;
            ChangeContentTxbAdd();
        }

        private void ClearDataExpFind()
        {
            TxbFindId = "";
            TxbFindAvgMark = "";
            TxbFindName = "";
            TxbFindAccumulationCredit = "";
            DpkFindBirthDay = DateTime.Now;
            ChangeContentTxbFind();
            IsRdbFindAccumulationCredit = false;
            IsRdbFindAvgMark = false;
            IsRdbFindBirthDay = false;
            IsRdbFindId = false;
            IsRdbFindName = false;
            ChangeStateRdbFind();
        }

        private void ClearDataExpDelete()
        {
            NumBeDelete = 0;
            IsCkbDeleteArray = false;
            RaisePropertyChanged("NumBeDelete");
            RaisePropertyChanged("IsCkbDeleteArray");
        }

        private void ClearDataExpUpdate()
        {
            IdUpdate = "";
            NameUpdate = "";
            AccumulationCreditUpdate = "";
            AvgMarkUpdate = "";
            BirthDayUpdate = DateTime.Now;
            ChangeContentTxbUpdate();
            ChangeStateTxbUpdate(false);

        }

        private void ClearDataExpGenerateData()
        {
            IsRdbNormal = false;
            IsRdbSuperLeft = false;
            IsRdbSuperRight = false;
            RaisePropertyChanged("IsRdbSuperRight");
            RaisePropertyChanged("IsRdbSuperLeft");
            RaisePropertyChanged("IsRdbNormal");
        }

        private List<T> GetRandomData<T>(int size)
        {
            var list = Builder<T>.CreateListOfSize(size).Build().ToList();

            return list;
        }

        private List<Student> GetData(int size)
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

        public void ChangeStateTxbDelete(bool isenable)
        {
            IsTxbDeleteNode = !isenable;
            RaisePropertyChanged("IsTxbDeleteNode");
        }

        private void ChangeStateRdbFind()
        {
            RaisePropertyChanged("IsRdbFindId");
            RaisePropertyChanged("IsRdbFindAvgMark");
            RaisePropertyChanged("IsRdbFindName");
            RaisePropertyChanged("IsRdbFindAccumulationCredit");
            RaisePropertyChanged("IsRdbFindBirthDay");
        }

        private void ChangeContentTxbAdd()
        {
            RaisePropertyChanged("Id");
            RaisePropertyChanged("AvgMark");
            RaisePropertyChanged("Name");
            RaisePropertyChanged("AccumulationCredit");
            RaisePropertyChanged("BirthDay");
        }

        private void ChangeContentTxbFind()
        {
            RaisePropertyChanged("TxbFindId");
            RaisePropertyChanged("TxbFindAvgMark");
            RaisePropertyChanged("TxbFindName");
            RaisePropertyChanged("TxbFindAccumulationCredit");
            RaisePropertyChanged("DpkFindBirthDay");
        }

        public void ChangeContentTxbUpdate()
        {
            RaisePropertyChanged("IdUpdate");
            RaisePropertyChanged("AvgMarkUpdate");
            RaisePropertyChanged("NameUpdate");
            RaisePropertyChanged("AccumulationCreditUpdate");
            RaisePropertyChanged("BirthDayUpdate");
        }

        public void ChangeStateTxbAdd(bool isenable)
        {
            IsTxbIdAdd = !isenable;
            IsTxbAccumulationCreditAdd = !isenable;
            IsTxbNameAdd = !isenable;
            IsTxbAvgMarkAdd = !isenable;
            IsDpkBirthDayAdd = !isenable;
            RaisePropertyChanged("IsTxbIdAdd");
            RaisePropertyChanged("IsTxbAvgMarkAdd");
            RaisePropertyChanged("IsTxbNameAdd");
            RaisePropertyChanged("IsTxbAccumulationCreditAdd");
            RaisePropertyChanged("IsDpkBirthDayAdd");
        }

        public void ChangeStateTxbUpdate(bool isenable)
        {
            IsToggleBtnUpdate = !isenable;
            IsTxbUpdateStudent = !isenable;
            IsTxbUpdateName = isenable;
            IsTxbUpdateAvgMark = isenable;
            IsTxbUpdateAccumulationCredit = isenable;
            IsDpkUpdateBirthDay = isenable;
            RaisePropertyChanged("IsTxbUpdateStudent");
            RaisePropertyChanged("IsTxbUpdateAvgMark");
            RaisePropertyChanged("IsTxbUpdateName");
            RaisePropertyChanged("IsTxbUpdateAccumulationCredit");
            RaisePropertyChanged("IsDpkUpdateBirthDay");
            RaisePropertyChanged("IsToggle");
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
        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}