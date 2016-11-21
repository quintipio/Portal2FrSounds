using System.ComponentModel;
using System.Runtime.CompilerServices;
using Portal2SoundWin10.Model;

namespace Portal2SoundWin10.ViewModel
{
    /// <summary>
    /// Classe pour la vue de lecture des sons
    /// </summary>
    public sealed class LireSonViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// le son à lire
        /// </summary>
        private Son _sonALire;


        /// <summary>
        /// le son à lire
        /// </summary>
        public Son SonALire
        {
            get { return _sonALire; }
            private set
            {
                if (_sonALire != null && _sonALire.Equals(value)) return;
                _sonALire = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="sonALire">le son à lire</param>
        public LireSonViewModel(Son sonALire)
        {
            SonALire = sonALire;

        }

        /// <summary>
        /// choisi le son suivant du personnage
        /// </summary>
        public void NextSound()
        {
            if (SonALire.Parent.SoundList.IndexOf(SonALire) < SonALire.Parent.SoundList.Count-1)
            { 
                SonALire = SonALire.Parent.SoundList[SonALire.Parent.SoundList.IndexOf(SonALire) + 1];
            }
        }

        /// <summary>
        /// choisi le son précédent du personnage
        /// </summary>
        public void PreviousSound()
        {
            if (SonALire.Parent.SoundList.IndexOf(SonALire) > 0)
            {
                SonALire = SonALire.Parent.SoundList[SonALire.Parent.SoundList.IndexOf(SonALire) - 1];
            }
        }
        
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
