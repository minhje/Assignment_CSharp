using System.Collections.ObjectModel;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<string> _items = [];
        

        public MainPage()
        {
            InitializeComponent(); // FÅR EJ TAS BORT!
            List_ContactList.ItemsSource = _items;
        }

        private void Button_Add_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Entry_FirstName.Text))
            {
                _items.Add(Entry_FirstName.Text);
                Entry_FirstName.Text = string.Empty;
            }

        }
    }

}
