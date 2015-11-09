using System;
using Windows.UI.Xaml.Controls;

namespace USTAR.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        //We can not use var out the method so we had to use the reall data type esle var would to work 
        //Note : var would'nt work here
        Windows.Storage.ApplicationDataContainer localSettings;

        public WelcomePage()
        {
            this.InitializeComponent();
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            UpdateLocalSetting();
        }

        private void UpdateLocalSetting()
        {
            // Read data from a simple setting
            object value = localSettings.Values["Test"];
            if (value == null)
            {
                // No data
                Display.Text = "NO DATA";
            }
            else
            {
                // Access data in value
                Display.Text = value.ToString();
                DisplayPerson.Label = value.ToString();
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {          

           
            // Create a simple setting
            localSettings.Values["Test"] = Name.Text;                      
        }

        private void ClearData(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Delete a simple setting
            localSettings.Values.Remove("Test");
        }

        private void Update(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            UpdateLocalSetting();
        }
    }
}
