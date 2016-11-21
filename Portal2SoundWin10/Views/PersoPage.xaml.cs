using System;
using Windows.ApplicationModel.Store;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Portal2SoundWin10.Context;
using Portal2SoundWin10.Model;
using Portal2SoundWin10.ViewModel;

namespace Portal2SoundWin10.Views
{
    /// <summary>
    /// Page de la liste des sons d'un personnage
    /// </summary>
    public sealed partial class PersoPage
    {
        /// <summary>
        /// ViewModel
        /// </summary>
        public PersoPageViewModel ViewModel;

        /// <summary>
        /// Constructeur
        /// </summary>
        public PersoPage()
        {
            InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel = new PersoPageViewModel(e.Parameter as Perso);

        }

        #region évènements appBarButton
        private async void RateButton_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + CurrentApp.AppId));
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
        #endregion

        private void SelectMusic_OnClick(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(LireSon),((Button)sender).Tag as Son);
        }

        private void organisationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedValue = ((ComboBox)sender).SelectedValue;
            if (selectedValue != null)
            {
                ViewModel.SelectedTri = (Liste)selectedValue;
                ViewModel.ChangeCategorieTri();
            }
        }
    }
}
