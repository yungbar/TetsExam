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

namespace TourProject.xaml
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Base.ToursDataEntities MyBase;
        private Base.Users user;
        
        public Window1(Base.Users user)
        {
            InitializeComponent();
            try
            {
                MyBase = new Base.ToursDataEntities();
            }
            catch
            {
                MessageBox.Show("Подключение к бд не произвдено", "предупреждение", MessageBoxButton.OK);

            }
            this.user = user;
            Visible();
            ToursElementComboBox.ItemsSource= Core.BaseData.Type.ToList();

            RefershWindow();
        }

        private void Visible()
        {
            if (user.Role == 1) RowDefenition1.Height = new GridLength(100);
            else RowDefenition1.Height = new GridLength(0);
        }

        private void NextWindowButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow(null);
            addWindow.ShowDialog();
            RefershWindow();
        }

        private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.ShowDialog();
            RefershWindow();
            Close();
        }

        private void ObjectListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ObjectTour = new Base.Tour();
            ObjectTour = (Base.Tour)ObjectListBox.SelectedItem;
            AddWindow addWindow = new AddWindow(ObjectTour);
            addWindow.Show();
            RefershWindow();
        }

        private void RefershWindow()
        {
            ObjectListBox.ItemsSource = Core.BaseData.Tour.ToList();
        }
    }
}
