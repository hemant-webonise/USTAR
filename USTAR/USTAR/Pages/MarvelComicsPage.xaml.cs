using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using USTAR.Model;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace USTAR.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MarvelComicsPage : Page
    {
        public ObservableCollection<ComicBook> MarvelComics { get; set; }
        public ObservableCollection<Character> MarvelCharacters { get; set; }

        public MarvelComicsPage()
        {
            this.InitializeComponent();
            MarvelCharacters = new ObservableCollection<Character>();
            MarvelComics = new ObservableCollection<ComicBook>();
        }


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MyProgressRing.IsActive = true;
            MyProgressRing.Visibility = Visibility.Visible;

            while (MarvelCharacters.Count < 10)
            {
                Task t = MarvelFacade.PopulateMarvelCharactersAsync(MarvelCharacters);
                await t;
            }

            MyProgressRing.IsActive = false;
            MyProgressRing.Visibility = Visibility.Collapsed;
        }

        private async void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            MyProgressRing.IsActive = true;
            MyProgressRing.Visibility = Visibility.Visible;

            ComicDetailNameTextBlock.Text = "";
            ComicDetailDescriptionTextBlock.Text = "";
            ComicDetailImage.Source = null;

            var selectedCharacter = (Character)e.ClickedItem;

            DetailNameTextBlock.Text = selectedCharacter.name;
            DetailDescriptionTextBlock.Text = selectedCharacter.description;

            var largeImage = new BitmapImage();
            Uri uri = new Uri(selectedCharacter.thumbnail.large, UriKind.Absolute);
            largeImage.UriSource = uri;
            DetailImage.Source = largeImage;
            MarvelComics.Clear();


            await MarvelFacade.PopulateMarvelComicsAsync(
                        selectedCharacter.id,
                        MarvelComics);

            MessageDialog d = new MessageDialog("Passing to Marvel Character Page screen!"); await d.ShowAsync();


            MyProgressRing.IsActive = false;
            MyProgressRing.Visibility = Visibility.Collapsed;

        }

        private async void ComicsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedComic = (ComicBook)e.ClickedItem;
            MessageDialog d = new MessageDialog("Passing to Marvel Specific Book Page screen!"); await d.ShowAsync();
            Frame.Navigate(typeof(MarvelSpecificBookPage), selectedComic);

        }
    }
}

