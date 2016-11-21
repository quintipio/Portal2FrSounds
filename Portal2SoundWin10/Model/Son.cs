using System;

namespace Portal2SoundWin10.Model
{
    /// <summary>
    /// Objet d'un son d'un personnage
    /// </summary>
    public class Son
    {
        /// <summary>
        /// Id de l'objet
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Texte à afficher pour représentr le son
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// raccourci vers le son
        /// </summary>
        public Uri Raccourci { get; set; }

        /// <summary>
        /// le personange appartenant
        /// </summary>
        public Perso Parent { get; set; }

        /// <summary>
        /// l'id de la sous categorie du personnage contenant ce son
        /// </summary>
        public int IdSousCategories { get; set; }

        /// <summary>
        /// Indique si c'est un son court ou long
        /// </summary>
        public bool SonCourt { get; set; }




        public override string ToString()
        {
            return Text;
        }


        private bool Equals(Son other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Son) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
