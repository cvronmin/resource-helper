using System;
using System.Collections.Generic;
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

namespace EntityTextureCreator
{
    /// <summary>
    /// Processing.xaml 的互動邏輯
    /// </summary>
    public partial class Processing : Window
    {
        public Processing(String main)
        {
            InitializeComponent();
            lblMain.Content = main;
        }
        public void changeStatus(String status) {
            Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                lblStatus.Content = status;
            }));
        }
    }
}
