using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf_AVLStudent.Model;

namespace Wpf_AVLStudent.MyUtilities
{
    public interface IUtilities
    {
        ITree<Student> Tree { get ; set ; }
        int VerticalMarging { get; set ; }
        double WidthGridBST { get; set; }
        double HeightGridBST { get ; set ; }

        /// <summary>
        /// To calculate new position and button will be added to Grid
        /// </summary>
        /// <param name="p">this is a grid which will be add a button</param>
        /// <param name="student"></param>
        Task AddButtonGridAsync(UIElement p, Student student);

        /// <summary>
        /// Function for btnFindNodeClickCommand
        /// It will find a node-button in grid and draw a circle around button 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="grid"></param>
        void FindNodeInGrid(Node<Student> node, UIElement grid);

        /// <summary>
        /// Delete the student ( id is <paramref name="nodeDelete"/> ) in <paramref name="grid"/>
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="nodeDelete"></param>
        Task DeleteNodeInGridAsync(Grid grid, int nodeDelete);

        /// <summary>
        /// Find the Button in grid  - async
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="match">name of the button</param>
        /// <returns></returns>
        Task<Tuple<List<Task>, Button>> FindButtonInGrid(Grid grid, object match);
    }
}
