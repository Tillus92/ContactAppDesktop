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
using ContactAppDesktop.Classes;
using SQLite;

namespace ContactAppDesktop
{
    /// <summary>
    /// Interaktionslogik für Verwaltung.xaml
    /// </summary>
    public partial class Verwaltung : Window
    {
        public Contact contact; 
        public Verwaltung(Contact contact)
        {
            
            InitializeComponent();
            this.contact = contact;
            Name.Text = contact.Name;
            Phone.Text = contact.Phone;
            Email.Text = contact.Email;
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.dataBasePath))
            {
                con.CreateTable<Contact>();
                con.Delete(contact);
            }


            Close(); 
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = Name.Text;
            contact.Phone = Phone.Text;
            contact.Email = Email.Text; 

            using(SQLiteConnection con = new SQLiteConnection(App.dataBasePath))
            {
                con.CreateTable<Contact>();
                con.Update(contact); 
            }
            Close();
        }
    }
}
