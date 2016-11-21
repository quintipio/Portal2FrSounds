using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Store;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    /// Page de lecture d'un son
    /// </summary>
    public sealed partial class LireSon
    {

        /// <summary>
        /// ViewModel
        /// </summary>
        public LireSonViewModel ViewModel { get; set; }

        /// <summary>
        /// pour la position de lecture du son
        /// </summary>
        private TimeSpan _position;

        /// <summary>
        /// Constructeur
        /// </summary>
        public LireSon()
        {
            InitializeComponent();

            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            timer.Tick += Ticktock;
            timer.Start();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel = new LireSonViewModel(e.Parameter as Son);
        }


        #region Boutons de base

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

        #region évènements du son
        private void SonElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            _position = SonElement.NaturalDuration.TimeSpan;
            SonProgressbar.Minimum = 0;
            SonProgressbar.Maximum = _position.TotalSeconds;
        }

        private void Ticktock(object sender, object e)
        {
            SonProgressbar.Value = SonElement.Position.TotalSeconds;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            SonElement.Play();
        }


        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            SonElement.Pause();
        }
        
        private void NextSon_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NextSound();
        }

        private void PreviousSon_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.PreviousSound();
        }

        
        private async void exportButton_Click(object sender, RoutedEventArgs e)
        {
            const string extensionChoisi = ContextStatic.ExtensionSon;
            var listeExtension = new List<string> { extensionChoisi };
            var fileSavePicker = new FileSavePicker
            {
                CommitButtonText = "OK",
                SuggestedFileName = ViewModel.SonALire.Text,
                SuggestedStartLocation = PickerLocationId.Downloads,
                DefaultFileExtension = extensionChoisi,
            };

            fileSavePicker.FileTypeChoices.Add(ViewModel.SonALire.Text, listeExtension);
            //mise en mémoire du fichier
            var fichierTmp = await fileSavePicker.PickSaveFileAsync();
            if (fichierTmp != null)
            {
                var storageFile = await StorageFile.GetFileFromApplicationUriAsync(ViewModel.SonALire.Raccourci);
                var buffer = await FileIO.ReadBufferAsync(storageFile);
                await FileIO.WriteBufferAsync(fichierTmp, buffer);
            }
        }
        #endregion


     }
}
