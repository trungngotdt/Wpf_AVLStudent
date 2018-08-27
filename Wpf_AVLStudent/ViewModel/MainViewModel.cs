using FizzWare.NBuilder;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LinqToExcel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

        
        private string idDelete;
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
        //private readonly int HorizontalMarging = 50;
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
        public double WidthGridBST
        {
            get => widthGridBST;
            set
            {
                widthGridBST = value;
                RaisePropertyChanged("WidthGridBST");
            }
        }
        public double HeightGridBST
        {
            get => heightGridBST;
            set
            {
                heightGridBST = value;
                RaisePropertyChanged("HeightGridBST");
            }
        }

        #region Update
        public string IdUpdate
        {
            get => idUpdate;
            set
            {
                idUpdate = value;
                RaisePropertyChanged("IdUpdate");
            }
        }
        public string NameUpdate
        {
            get => nameUpdate;
            set
            {
                nameUpdate = value;
                RaisePropertyChanged("NameUpdate");
            }
        }
        public string AvgMarkUpdate
        {
            get => avgMarkUpdate;
            set
            {
                avgMarkUpdate = value;
                RaisePropertyChanged("AvgMarkUpdate");
            }
        }
        public string AccumulationCreditUpdate
        {
            get => accumulationCreditUpdate;
            set
            {
                accumulationCreditUpdate = value;
                RaisePropertyChanged("AccumulationCreditUpdate");
            }
        }
        public DateTime BirthDayUpdate
        {
            get => birthDayUpdate; set
            {
                birthDayUpdate = value;
                RaisePropertyChanged("BirthDayUpdate");
            }
        }
        public bool IsToggleBtnUpdate
        {
            get => isToggleBtnUpdate;
            set
            {
                isToggleBtnUpdate = value;
                RaisePropertyChanged("IsToggleBtnUpdate");
            }
        }
        public bool IsTxbUpdateStudent
        {
            get => isTxbUpdateStudent;
            set
            {
                isTxbUpdateStudent = value;
                RaisePropertyChanged("IsTxbUpdateStudent");
            }
        }
        public bool IsTxbUpdateName
        {
            get => isTxbUpdateName;
            set
            {
                isTxbUpdateName = value;
                RaisePropertyChanged("IsTxbUpdateName");
            }
        }
        public bool IsTxbUpdateAvgMark
        {
            get => isTxbUpdateAvgMark;
            set
            {
                isTxbUpdateAvgMark = value;
                RaisePropertyChanged("IsTxbUpdateAvgMark");
            }
        }
        public bool IsDpkUpdateBirthDay
        {
            get => isDpkUpdateBirthDay;
            set
            {
                isDpkUpdateBirthDay = value;
                RaisePropertyChanged("IsDpkUpdateBirthDay");
            }
        }
        public bool IsTxbUpdateAccumulationCredit
        {
            get => isTxbUpdateAccumulationCredit;
            set
            {
                isTxbUpdateAccumulationCredit = value;
                RaisePropertyChanged("IsTxbUpdateAccumulationCredit");
            }
        }
        #endregion

        #region Add
        public string Id
        {
            get => id;
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        public string AvgMark
        {
            get => avgMark;
            set
            {
                avgMark = value;
                RaisePropertyChanged("AvgMark");
            }
        }
        public string AccumulationCredit
        {
            get => accumulationCredit;
            set
            {
                accumulationCredit = value;
                RaisePropertyChanged("AccumulationCredit");
            }
        }
        public DateTime BirthDay
        {
            get => birthDay;
            set
            {
                birthDay = value;
                RaisePropertyChanged("BirthDay");
            }
        }

        public bool IsTxbIdAdd
        {
            get => isTxbIdAdd; set
            {
                isTxbIdAdd = value;
                RaisePropertyChanged("IsTxbIdAdd");
            }
        }
        public bool IsTxbNameAdd
        {
            get => isTxbNameAdd;
            set
            {
                isTxbNameAdd = value;
                RaisePropertyChanged("IsTxbNameAdd");
            }
        }
        public bool IsTxbAvgMarkAdd
        {
            get => isTxbAvgMarkAdd;
            set
            {
                isTxbAvgMarkAdd = value;
                RaisePropertyChanged("IsTxbAvgMarkAdd");
            }
        }
        public bool IsTxbAccumulationCreditAdd
        {
            get => isTxbAccumulationCreditAdd;
            set
            {
                isTxbAccumulationCreditAdd = value;
                RaisePropertyChanged("IsTxbAccumulationCreditAdd");
            }
        }
        public bool IsDpkBirthDayAdd
        {
            get => isDpkBirthDayAdd;
            set
            {
                isDpkBirthDayAdd = value;
                RaisePropertyChanged("IsDpkBirthDayAdd");
            }
        }
        public bool IsCkbAddArray
        {
            get
            {
                ChangeStateTxbAdd(isCkbAddArray);
                return isCkbAddArray;
            }
            set => isCkbAddArray = value;
        }
        #endregion

        #region Delete
        public string IdDelete
        {
            get => idDelete;
            set
            {
                idDelete = value;
                RaisePropertyChanged("IdDelete");
            }
        }


        public bool IsTxbDeleteNode
        {
            get => isTxbDeleteNode;
            set
            {
                isTxbDeleteNode = value;
                RaisePropertyChanged("IsTxbDeleteNode");
            }
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

        #endregion
                
        #region GenerateData

        public bool IsRdbSuperLeft
        {
            get => isRdbSuperLeft;
            set
            {
                isRdbSuperLeft = value;
                RaisePropertyChanged("IsRdbSuperLeft");
            }
        }
        public bool IsRdbSuperRight
        {
            get => isRdbSuperRight; set
            {
                isRdbSuperRight = value;
                RaisePropertyChanged("IsRdbSuperRight");
            }
        }
        public bool IsRdbNormal
        {
            get => isRdbNormal;
            set
            {
                isRdbNormal = value;
                RaisePropertyChanged("IsRdbNormal");
            }
        }

        #endregion

        #region Find
        public bool IsRdbFindId
        {
            get => isRdbFindId; set
            {
                isRdbFindId = value;
                RaisePropertyChanged("IsRdbFindId");
            }
        }
        public bool IsRdbFindName
        {
            get => isRdbFindName; set
            {
                isRdbFindName = value;
                RaisePropertyChanged("IsRdbFindName");
            }
        }
        public bool IsRdbFindAvgMark
        {
            get => isRdbFindAvgMark; set
            {
                isRdbFindAvgMark = value;
                RaisePropertyChanged("IsRdbFindAvgMark");
            }
        }
        public bool IsRdbFindAccumulationCredit
        {
            get => isRdbFindAccumulationCredit;
            set
            {
                isRdbFindAccumulationCredit = value;
                RaisePropertyChanged("IsRdbFindAccumulationCredit");
            }
        }
        public bool IsRdbFindBirthDay
        {
            get => isRdbFindBirthDay;
            set
            {
                isRdbFindBirthDay = value;
                RaisePropertyChanged("IsRdbFindBirthDay");
            }
        }
        public string TxbFindName
        {
            get => txbFindName;
            set
            {
                txbFindName = value;
                RaisePropertyChanged("TxbFindName");
            }
        }
        public string TxbFindAvgMark
        {
            get => txbFindAvgMark;
            set
            {
                txbFindAvgMark = value;
                RaisePropertyChanged("TxbFindAvgMark");
            }
        }
        public string TxbFindAccumulationCredit
        {
            get => txbFindAccumulationCredit;
            set
            {
                txbFindAccumulationCredit = value;
                RaisePropertyChanged("TxbFindAccumulationCredit");
            }
        }
        public DateTime DpkFindBirthDay
        {
            get => dpkFindBirthDay;
            set
            {
                dpkFindBirthDay = value;
                RaisePropertyChanged("DpkFindBirthDay");
            }
        }
        public string TxbFindId
        {
            get => txbFindId; set
            {
                txbFindId = value;
                RaisePropertyChanged("TxbFindId");
            }
        }

        #endregion

        public IUtilities GetUtilities { get => getUtilities; set => getUtilities = value; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ITree<Student> tree, IUtilities utilities)
        {
            this. HeightGridBST = 705;
            this.WidthGridBST = 1138.3333333333335;
            this.getUtilities = utilities;
            getUtilities.Tree = tree;
            getUtilities.WidthGridBST =this. WidthGridBST;
            getUtilities.VerticalMarging = this.VerticalMarging;
            getUtilities.HeightGridBST = this.HeightGridBST;

        }

        #region Command

        public ICommand BtnAddNodeClickCommand
        {
            get
            {
                return btnAddNodeClickCommand = new RelayCommand<UIElement>(async (p) =>
                 {
                     //Debug.WriteLine(Id.ToString());
                     
                     if (IsCkbAddArray)
                     {
                         StringBuilder builder = new StringBuilder();
                         var list = GetDataFromExcel();
                         for (int i = 0; i < list.Length; i++)
                         {
                             bool isAdd = await HelpCommandAddNodeAsync(p as Grid, list[i].Id.ToString(), list[i].Name, list[i].BirthDay, list[i].AvgMark.ToString(), list[i].AccumulationCredit.ToString());
                             if (isAdd==false)
                             {
                                 builder.Append(list[i].ToString() + "\n");
                                 continue;
                             }
                            
                             await Task.Delay(1000);
                         }
                         if (builder.Length != 0)
                         {
                             MessageBox.Show("We can't add : \n" + builder.ToString());
                         }
                         return;
                     }
                     await HelpCommandAddNodeAsync(p as Grid, Id, Name, BirthDay, AvgMark, AccumulationCredit);
                    
                 });
            }
        }

        private async Task<bool> HelpCommandAddNodeAsync(Grid grid,string id,string name,DateTime date,string avgmark,string accumulationcredit)
        {
            if ((id.Trim().Length == 0) || grid.Children.OfType<Button>().Where(pa => pa.Name.Equals($"Btn{id.ToString()}")).ToList().Count != 0)
            {
                MessageBox.Show($"We can't add {id.ToString()}");
                return false;
            }
            if (name == null || id == null || avgmark == null || accumulationcredit == null)
            {
                MessageBox.Show("We don't have enough data to add node!");
                return false;
            }
            var student = new Student(int.Parse(id), name, birthDay, float.Parse(avgmark), int.Parse(accumulationcredit));
            await GetUtilities.AddButtonGridAsync(grid, student);
            HeightGridBST = GetUtilities.HeightGridBST;
            WidthGridBST = GetUtilities.WidthGridBST;
            Tree = GetUtilities.Tree;
            return true;
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
                    if (students.Count==0 )
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
                            await HelpCommandDeleteAsync(p, list[i].Id.ToString());
                        }
                        return;
                    }
                    await HelpCommandDeleteAsync(p, IdDelete);
                });
            }
        }

        private async Task HelpCommandDeleteAsync(Grid grid, string id)
        {
            if ((id.Trim().Length==0) || (grid as Grid).Children.OfType<Button>().Where(pa => pa.Name.Equals($"Btn{id.ToString()}")).ToList().Count == 0)
            {
                MessageBox.Show($"We can't delete {id.ToString()}");
                return;
            }

            await GetUtilities.DeleteNodeInGridAsync(grid,int.Parse( id));
        }

        public ICommand BtnUpdateClickCommand
        {
            get
            {
                return btnUpdateClickCommand = new RelayCommand<Grid>(async (p) =>
                {
                    var studentUpdate = GetUtilities.Tree.FindNode(new Student(int.Parse(IdUpdate)))?.Data;
                    if (studentUpdate == null )
                    {
                        MessageBox.Show("We don't have this student!");
                        IsToggleBtnUpdate = false;
                        return;
                    }
                    if (IsToggleBtnUpdate == true)//State :Find the student
                    {
                        var button =GetUtilities.FindButtonInGrid(p, IdUpdate);
                        studentUpdate.Name = NameUpdate;
                        studentUpdate.BirthDay = BirthDayUpdate;
                        studentUpdate.AvgMark = int.Parse(AvgMarkUpdate);
                        studentUpdate.AccumulationCredit = int.Parse(AccumulationCreditUpdate);
                        ChangeStateTxbUpdate(false);
                        (await button).Item2.ToolTip = studentUpdate.ToString();
                    }
                    else//State :Update
                    {
                        NameUpdate = studentUpdate.Name;
                        AvgMarkUpdate = studentUpdate.AvgMark.ToString();
                        AccumulationCreditUpdate = studentUpdate.AccumulationCredit.ToString();
                        BirthDayUpdate = studentUpdate.BirthDay;
                        ChangeStateTxbUpdate(true);
                    }
                });
            }
        }

        public ICommand BtnTraversal
        {
            get
            {
                return btnTraversal = new RelayCommand<string>((p) =>
                {
                    var returnList = GetUtilities.Tree.GetType().GetMethod(p, new Type[] { }).Invoke(GetUtilities.Tree, new object[] { });
                    ShowMessBoxTraversal(returnList as List<string>, p);
                });
            }
        }

        public ICommand BtnGenerateData
        {
            get
            {                
                return btnGenerateData = new RelayCommand<UIElement>(async (p) =>
                {
                    StringBuilder builder = new StringBuilder();
                    List<Student> list = new List<Student>();
                    if (IsRdbNormal)
                    {
                        list = GetData(5);
                    }
                    else if (isRdbSuperLeft)
                    {
                        list = GetRandomData<Student>(5);
                        list.Reverse();
                    }
                    else if (IsRdbSuperRight)
                    {
                        list = GetRandomData<Student>(5);
                    }
                    else
                    {
                        MessageBox.Show("Don't have any choice");
                        return;
                    }
                    
                    for (int i = 0; i < list.Count(); i++)
                    {
                        if (list[i].Id<=0)
                        {
                            continue;
                        }
                        bool isAdd = await HelpCommandAddNodeAsync(p as Grid, list[i].Id.ToString(), list[i].Name, list[i].BirthDay, list[i].AvgMark.ToString(), list[i].AccumulationCredit.ToString());
                        if (isAdd == false)
                        {
                            builder.Append(list[i].ToString() + "\n");
                            continue;
                        }
                        /*
                        if ((p as Grid).Children.OfType<Button>().Where(pa => pa.Name.Equals($"Btn{list[i].Id.ToString()}")).ToList().Count != 0)
                        {
                            builder.Append(list[i].ToString() + "\n");
                            continue;
                        }
                        Debug.WriteLine(list[i]. Id.ToString());
                        student = new Student(list[i].Id, list[i].Name, list[i].BirthDay, list[i].AvgMark, list[i].AccumulationCredit);
                        await GetUtilities.AddButtonGridAsync(p as Grid, student);
                        */                    
                        await Task.Delay(1000);
                    }
                    if (builder.Length != 0)
                    {
                        MessageBox.Show("We can't add : \n" + builder.ToString());
                    }
                    return;
                });
            }
        }

        public ICommand BtnClear
        {
            get
            {
                return btnClear = new RelayCommand<UIElement>((p) =>
                {
                    (p as Grid).Children.Clear();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                });
            }
        }

        public ICommand ExpClearData
        {
            get
            {
                return expClearData = new RelayCommand<string>((p) =>
                {
                    this.GetType().GetMethod("ClearData" + p, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this, new object[] { });
                });
            }
        }
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
            Id = "";
            Name = "";
            AccumulationCredit = "";
            AvgMark = "";
            BirthDay = DateTime.Now;
        }

        private void ClearDataExpFind()
        {
            TxbFindId = "";
            TxbFindAvgMark = "";
            TxbFindName = "";
            TxbFindAccumulationCredit = "";
            DpkFindBirthDay = DateTime.Now;
            IsRdbFindAccumulationCredit = false;
            IsRdbFindAvgMark = false;
            IsRdbFindBirthDay = false;
            IsRdbFindId = false;
            IsRdbFindName = false;
        }

        private void ClearDataExpDelete()
        {
            IdDelete = "";
            IsCkbDeleteArray = false;
        }

        private void ClearDataExpUpdate()
        {
            IdUpdate = "";
            NameUpdate = "";
            AccumulationCreditUpdate = "";
            AvgMarkUpdate = "";
            BirthDayUpdate = DateTime.Now;
            ChangeStateTxbUpdate(false);

        }

        private void ClearDataExpGenerateData()
        {
            IsRdbNormal = false;
            IsRdbSuperLeft = false;
            IsRdbSuperRight = false;            
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
        }


        public void ChangeStateTxbAdd(bool isenable)
        {
            IsTxbIdAdd = !isenable;
            IsTxbAccumulationCreditAdd = !isenable;
            IsTxbNameAdd = !isenable;
            IsTxbAvgMarkAdd = !isenable;
            IsDpkBirthDayAdd = !isenable;
        }

        public void ChangeStateTxbUpdate(bool isenable)
        {
            IsToggleBtnUpdate = !isenable;
            IsTxbUpdateStudent = !isenable;
            IsTxbUpdateName = isenable;
            IsTxbUpdateAvgMark = isenable;
            IsTxbUpdateAccumulationCredit = isenable;
            IsDpkUpdateBirthDay = isenable;
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