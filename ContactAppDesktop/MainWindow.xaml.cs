using ContactAppDesktop.Classes;
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
using SQLite; 

namespace ContactAppDesktop
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDatabase(); 

        }
        void ReadDatabase()
        {
            
           
            using (SQLiteConnection con = new SQLiteConnection(App.dataBasePath))
            {
                con.CreateTable<Contact>();
                contacts = (con.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();

            }
            if(contacts != null)
            {
                ContactListView.ItemsSource = contacts;
            }
        
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            ContactListView.ItemsSource = filteredList;
        }

     

        private void ContactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)ContactListView.SelectedItem;
          
            if(selectedContact != null)
            {
                Verwaltung verw = new Verwaltung(selectedContact);
                verw.ShowDialog();
                ReadDatabase();

            }
        }
    }
}
