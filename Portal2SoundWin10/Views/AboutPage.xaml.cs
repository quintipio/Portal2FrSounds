using Windows.UI.Xaml.Navigation;
using Portal2SoundWin10.Context;

namespace Portal2SoundWin10.Views
{
    /// <summary>
    /// Page a propos de....
    /// </summary>
    public sealed partial class AboutPage
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        public AboutPage()
        {
            InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            AppNomAppTextBlock.Text = ContextStatic.NomAppli;
            VersionTextBlock.Text = ContextStatic.Version;
            DeveloppeurTextBlock.Text = ContextStatic.Developpeur;
        }
    }
}
