using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml.Data;
using Portal2SoundWin10.Model;

namespace Portal2SoundWin10.ViewModel
{
    /// <summary>
    /// Structure pour lister dans la comboBox les différentes méthodes de tri
    /// </summary>
    public struct Liste
    {
        /// <summary>
        /// l'id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// le nom
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="id">l'id</param>
        /// <param name="nom">le nom</param>
        public Liste(int id, string nom) : this()
        {
            Id = id;
            Nom = nom;
        }

        public override string ToString()
        {
            return Nom;
        }

        public override bool Equals(object obj)
        {
            if (obj is Liste)
            {
                return ((Liste)obj).Id.Equals(Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode()*Nom.GetHashCode();
        }
    }


    /// <summary>
    /// Object pour regrouper les listes de son
    /// </summary>
    /// <typeparam name="T">le type des objets listé</typeparam>
    public class GroupInfoList<T> : List<object>
    {
        /// <summary>
        /// le nom du groupe
        /// </summary>
        public object Key { get; set; }

        /// <summary>
        /// la liste des objets
        /// </summary>
        /// <returns>la liste</returns>
        public new IEnumerator<object> GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }



    /// <summary>
    /// Controleur de la page des personnages
    /// </summary>
    public sealed class PersoPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// le personnage sélectionné
        /// </summary>
        private Perso _persoSelected;

        /// <summary>
        /// Propriété du personnage sélectionné
        /// </summary>
        public Perso PersoSelected
        {
            get { return _persoSelected; }
            set
            {
                if (_persoSelected != null && _persoSelected.Equals(value)) return;
                _persoSelected = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// liste des modes de tri disponible
        /// </summary>
        public ObservableCollection<Liste> MethodeTriCollection { get; set; }


        /// <summary>
        /// l'id de la méthode de tri sélectionné
        /// </summary>
        private Liste _selectedTri;

        /// <summary>
        /// propriété de l'id de la méthode de tri sélectionné
        /// </summary>
        public Liste SelectedTri
        {
            get { return _selectedTri; }
            set { _selectedTri = value; 
                OnPropertyChanged(); }
        }

        /// <summary>
        /// la liste des sons à afficher
        /// </summary>
        private CollectionViewSource _sonCollection;

        /// <summary>
        /// Propriété de la liste des sons à afficher
        /// </summary>
        public CollectionViewSource SonCollection
        {
            get { return _sonCollection; }
            set
            {
                _sonCollection = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="perso">le personnage sélectionné</param>
        public PersoPageViewModel(Perso perso)
        {
            MethodeTriCollection = new ObservableCollection<Liste>
            {
                new Liste(1,ResourceLoader.GetForCurrentView().GetString("AucunTri")),
                new Liste(2,ResourceLoader.GetForCurrentView().GetString("TriParTemps")),
                new Liste(3,ResourceLoader.GetForCurrentView().GetString("TriParCategorie"))
            };

            PersoSelected = perso;
            SonCollection = new CollectionViewSource {IsSourceGrouped = true};
            SelectedTri = MethodeTriCollection[0];
            ChangeCategorieTri();
        }

        /// <summary>
        /// Tri les groupes de son en fonction du mode sélectionné
        /// </summary>
        /// <returns>la liste des sons groupés</returns>
        private List<GroupInfoList<Son>> TrierSon()
        {
            var res = new List<GroupInfoList<Son>>();
            switch (SelectedTri.Id)
            {
                //aucun tri précis
                case 1:
                    var groupDef = new GroupInfoList<Son> { Key = ResourceLoader.GetForCurrentView().GetString("toutLesSons") };
                    groupDef.AddRange(PersoSelected.SoundList);
                    res.Add(groupDef);
                    break;

                //tri par son court et son long
                case 2:
                    var groupeTempsCourt = new GroupInfoList<Son> { Key = ResourceLoader.GetForCurrentView().GetString("SonCourt") };
                    var groupeTempsLong = new GroupInfoList<Son> { Key = ResourceLoader.GetForCurrentView().GetString("SonLong") };

                    foreach (var son in PersoSelected.SoundList)
                    {
                        if (son.SonCourt)
                        {
                            groupeTempsCourt.Add(son);
                        }
                        else
                        {
                            groupeTempsLong.Add(son);
                        }
                    }
                    res.Add(groupeTempsCourt);
                    res.Add(groupeTempsLong);
                    break;

                //tri par catégorie
                case 3:
                    foreach (var categorie in PersoSelected.SousCategories)
                    {
                        var categorie1 = categorie;
                        var groupe = new GroupInfoList<Son> { Key = categorie1.Value };
                        groupe.AddRange(PersoSelected.SoundList.Where(son => son.IdSousCategories == categorie1.Key));
                        if (groupe.Count > 0)
                        {
                            res.Add(groupe);
                        }
                    }
                    break;
            }
            return res;
        }

        /// <summary>
        /// Méthode à utiliser lors du changement de catégorie
        /// </summary>
        public void ChangeCategorieTri()
        {
            SonCollection.Source = TrierSon();
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
