using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using USTAR.Pages.GotNuts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace USTAR.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GoNuts : Page
    {
        public GoNuts()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(DonutPage));
        }

        private void DonutButton_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(DonutPage));
        }

        private void CoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(CoffePage));
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(SchedulePage));
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(CompletePage));
        }
    }
}
