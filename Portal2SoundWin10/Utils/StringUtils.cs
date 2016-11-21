
namespace Portal2SoundWin10.Utils
{
    /// <summary>
    /// Utilitaire sur les chaines de caractères
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Met en majuscule la première lettre d'une chaine
        /// </summary>
        /// <param name="chaine">la chaine à modifier</param>
        /// <returns>la chaine modifier</returns>
        public static string FirstLetterUpper(string chaine)
        {
            return char.ToUpper(chaine[0])+chaine.Substring(1);
        }
    }
}
