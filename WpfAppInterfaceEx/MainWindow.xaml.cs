using ConsoleAppInterfaceEx.Data;
using ConsoleAppInterfaceEx.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppInterfaceEx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly PeopleService _peopleService;
        public MainWindow()
        {
            InitializeComponent();
            _peopleService = new PeopleService(new FilePeopleRepo());
            LoadPeopleIntoGrid();
        }

        void LoadPeopleIntoGrid()
        {
            peopleGrid.ItemsSource = _peopleService.GetPeople();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _peopleService.Create(NewFirstName.Text, NewLastName.Text);
            NewFirstName.Text = string.Empty;
            NewLastName.Text = string.Empty;
            CollectionViewSource.GetDefaultView(peopleGrid.ItemsSource).Refresh();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if(_peopleService.Remove(Guid.Parse(RemoveId.Text)))
            {
                RemoveId.Text = string.Empty;
                CollectionViewSource.GetDefaultView(peopleGrid.ItemsSource).Refresh();
            }
        }
    }
}
