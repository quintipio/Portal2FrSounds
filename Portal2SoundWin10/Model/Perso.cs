using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Portal2SoundWin10.Model
{
    /// <summary>
    /// Modélise un des personnages de l'appli
    /// </summary>
    public class Perso
    {
        /// <summary>
        /// l'Id du personnage
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// le nom clé pour le personnage
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// le nom du personnage
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// les sous catégories disponibles pour chaque perso
        /// </summary>
        public Dictionary<int,string> SousCategories { get; set; } 

        /// <summary>
        /// la biographie du personnage
        /// </summary>
        public string Biographie { get; set; }

        /// <summary>
        /// la liste des sons du personnage
        /// </summary>
        public ObservableCollection<Son> SoundList { get; set; }
        
        /// <summary>
        /// chemin du logo à afficher pour le perso
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Chemin du logo Apterture Science
        /// </summary>
        public string LogoAperture { get; set; }



        public override string ToString()
        {
            return Nom;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Perso) obj);
        }

        private bool Equals(Perso other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
