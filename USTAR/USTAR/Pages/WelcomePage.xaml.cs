using Windows.UI.Xaml.Controls;

namespace USTAR.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            DisplayPerson.Label = "Hemant";
            Display.Text = Name.Text;
        }
    }
}
