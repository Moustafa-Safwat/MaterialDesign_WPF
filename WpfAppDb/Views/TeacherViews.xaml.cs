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
using WpfAppDb.ViewModels.Interfaces;

namespace WpfAppDb.Views
{
    /// <summary>
    /// Interaction logic for TeacherViews.xaml
    /// </summary>
    public partial class TeacherViews : Window
    {
        public TeacherViews(ITeacherViewModel teacherViewModel)
        {
            InitializeComponent();
            this.DataContext = teacherViewModel;
        }
    }
}
