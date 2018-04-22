
using System.Collections.Generic;
using Wpf_AVLStudent.Model;

namespace Wpf_AVLStudent.MyUtilities
{
    public interface IHelper
    {
        void ShowMessBoxTraversal(List<string> list, string name);

        List<T> GetRandomData<T>(int size);

        List<Student> GetData(int size);

        Student[] GetDataFromExcel();
    }
}
