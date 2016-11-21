using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Store;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Portal2SoundWin10.Context;
using Portal2SoundWin10.Model;
using Portal2SoundWin10.ViewModel;

namespace Portal2SoundWin10.Views
{
    /// <summary>
    /// Page d'acceuil avec la liste des personnages
    /// </summary>
    public sealed partial class MainPage
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        public MainPageViewModel ViewModel;

        /// <summary>
        /// Constructeur
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainPageViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var perso = ((Button) sender).Tag as Perso;
            ((Frame)Window.Current.Content).Navigate(typeof(PersoPage),perso);
        }


        #region évènements appBarButton
        private async void RateButton_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store://review/?PFN=" + Package.Current.Id.FamilyName));
        }

        private async void BugsButton_Click(object sender, RoutedEventArgs e)
        {
            var mailto = new Uri("mailto:?to=" + ContextStatic.Support + "&subject=Bugs ou suggestions pour " + ContextStatic.NomAppli);
            await Launcher.LaunchUriAsync(mailto);
        }

        private void AppdButton_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(AboutPage));
        }

        private void AleatoireButton_Click(object sender, RoutedEventArgs e)
        {
                var son = ViewModel.GetSonAleatoire();
                ((Frame)Window.Current.Content).Navigate(typeof(LireSon), son);
        }
        #endregion



    }
}
