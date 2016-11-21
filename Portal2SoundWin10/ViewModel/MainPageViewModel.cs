using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Windows.ApplicationModel.Resources;
using Portal2SoundWin10.Context;
using Portal2SoundWin10.Model;
using Portal2SoundWin10.Utils;

namespace Portal2SoundWin10.ViewModel
{
    /// <summary>
    /// Controleur de la page principale
    /// </summary>
    public sealed class MainPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Liste des personnages
        /// </summary>
        private ObservableCollection<Perso> _persoList;


        /// <summary>
        /// Propriété de la liste des personnages
        /// </summary>
        public ObservableCollection<Perso> PersoList
        {
            get { return _persoList; }
            set
            {
                if (_persoList == value) return;
                _persoList = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Constructeur (et chargement des informations des personnages dans le fichier xml)
        /// </summary>
        public MainPageViewModel()
        {
            PersoList = new ObservableCollection<Perso>();
            
            //chargement du fichier xml
            var loadedData = XDocument.Load(ContextStatic.PathDataPerso);

            foreach (var data in loadedData.Descendants("Perso"))
            {
                //Création du perso
                var perso = new Perso
                {
                    Id = (int)data.Attribute("id"),
                    Key = (string)data.Attribute("key"),
                    Nom = (string)data.Attribute("nom"),
                    Biographie = (string)data.Element("biographie"),
                    Logo = @"ms-appx:/rsc/img/logo" + StringUtils.FirstLetterUpper((string)data.Attribute("key")) + ".png",
                    LogoAperture = @"ms-appx:/rsc/img/logoAperture" + (string)data.Attribute("idLogo") + ".png",
                    SoundList = new ObservableCollection<Son>(),
                    SousCategories = new Dictionary<int, string>()
                };

                //ajout des sous catégories
                perso.SousCategories.Add(0, ResourceLoader.GetForCurrentView().GetString("sansCategorie"));
                foreach (var sousCategorie in data.Elements("listeCategorie").Descendants("categorie"))
                {
                    perso.SousCategories.Add((int)sousCategorie.Attribute("id"),(string)sousCategorie.Attribute("text"));
                }

                //ajout des sons
                foreach (var son in data.Elements("listeSon").Descendants("son"))
                {
                    perso.SoundList.Add(new Son
                    {
                        Id = (int)son.Attribute("id"),
                        Text = (string)son.Attribute("text"),
                        Raccourci = new Uri("ms-appx:///rsc/sound/" + (string)son.Attribute("raccourci")+ContextStatic.ExtensionSon),
                        Parent = perso,
                        IdSousCategories = (int)son.Attribute("categorie"),
                        SonCourt = (bool)son.Attribute("sonCourt")
                    });
                }

                PersoList.Add(perso);
            }
                
        }

        /// <summary>
        /// Retourne un son aléatoire dans la liste des persos
        /// </summary>
        /// <returns>le son</returns>
        public Son GetSonAleatoire()
        {
            var l = PersoList.SelectMany(perso => perso.SoundList).ToList();
            return l[new Random().Next(l.Count)];
        }

        #region INotiFyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
