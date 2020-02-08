using DapperTest.SQLDataAccessDemo.Models;
using System.Collections.Generic;
using System.Windows;

namespace DapperTest.SQLDataAccessDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> people = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
            UpdateBinding();
        }

        private void UpdateBinding()
        {
            listBoxPeopleFound.ItemsSource = people;
            listBoxPeopleFound.DisplayMemberPath = "FullInfo";
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            people =db.GetPeople(textBoxLastName.Text);
            UpdateBinding();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            db.InsertPerson(textBoxAddFirstName.Text, textBoxAddLastName.Text, textBoxAddEmail.Text);


            textBoxAddFirstName.Text = "";
            textBoxAddLastName.Text = "";
            textBoxAddEmail.Text = "";
        }
    }
}
