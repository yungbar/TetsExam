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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private Base.ToursDataEntities MyBase;
        private Base.Tour ObjectTour;
        
        public AddWindow(Base.Tour ObjectTour)
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
            IsActualTourComboBox.ItemsSource = Core.BaseData.TableFlags.ToList();

            this.ObjectTour = ObjectTour;
            
            if (ObjectTour != null)
            {

                NameTourTextBox.Text = ObjectTour.Name;
                PriceTourTextBox.Text = ObjectTour.Price.ToString();
                IsActualTourComboBox.SelectedItem = Core.BaseData.TableFlags.FirstOrDefault(P => P.id == ObjectTour.IsActual);
                TicketCountTourTextBox.Text = ObjectTour.TicketCount.ToString();
                AddButton.Content = "Редактировать";
            }
            else
            { 
                
                AddButton.Content = "Добавить";
            }
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteInfo()) return;

            if (ObjectTour != null)
            {
                

                ObjectTour = Core.BaseData.Tour.FirstOrDefault(P => P.Id == ObjectTour.Id);

                ObjectTour.Name = NameTourTextBox.Text;
                ObjectTour.Price = Math.Round(decimal.Parse(PriceTourTextBox.Text), 3);
                ObjectTour.IsActual = IsActualTourComboBox.SelectedIndex+1;
                ObjectTour.TicketCount = int.Parse(TicketCountTourTextBox.Text);
            }
            else
            {
                var AddObject = new Base.Tour();
                AddObject.Name = NameTourTextBox.Text;
                AddObject.Price = Math.Round(decimal.Parse(PriceTourTextBox.Text), 3);
                AddObject.IsActual = IsActualTourComboBox.SelectedIndex + 1;
                AddObject.TicketCount = int.Parse(TicketCountTourTextBox.Text);
                Core.BaseData.Tour.Add(AddObject);
            }

            try
            {
                Core.BaseData.SaveChanges();
            }
            catch
            {

            }
            Close();
        }



        private bool DeleteInfo()
        {
            int error=0; 
            if (decimal.TryParse(PriceTourTextBox.Text, out decimal price))
            {
                error++;
            }
            if (error > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (MessageBox.Show("Вы точно хотите удалить?", "Внимание", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    Core.BaseData.Tour.Remove(ObjectTour);
                    Core.BaseData.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Прикол: {ex}", "Внимание", MessageBoxButton.OK);
                }
            }

            
            Close();
        }
    }
}
