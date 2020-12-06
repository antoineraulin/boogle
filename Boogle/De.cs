using System;

namespace Boogle
{
    public class De
    {

        #region PRIVATE

        private char[] _faces;

        #endregion

        #region PUBLIC

        /// <summary>
        /// Objet Dé. Permet de créer un dé.
        /// </summary>
        /// <param name="faces">un tableau de char comprenant les 6 faces du dé</param>
        public De(char[] faces)
        {
            if (faces == null)
            {
                // On génére une erreur par rapport aux arguments passé en paramètre de la méthode.
                // throw arrête la méthode, ce qui suit ne sera pas exectué.
                throw new ArgumentException("faces ne peut être null");
            }
            if (faces.Length != 6)
            {
                throw new ArgumentException("faces doit nécessairement avoir une taille de 6");
            }
            _faces = faces;
        }

        #region PUBLIC METHODS

        /// <summary>
        /// Tire au hasard une lettre parmi les 6 du dé.
        /// </summary>
        /// <param name="random">Objet de type Random global</param>
        /// <returns>une lettre parmi les 6 du dé de façon aléatoire.</returns>
        public char Roll(Random random)
        {
            int index = random.Next(0, 6); // un index aléatoire parmis les 6 faces du dé.
            return _faces[index]; // on renvoie le char situé sur le dé à l'index.
        }

        /// <summary>
        /// Déscription du dé.
        /// </summary>
        /// <returns>Une chaîne de caractères qui décrit un dé</returns>
        public override string ToString()
        {
            string res = "faces du dé :";
            for (int i = 0; i < 6; i++)
            {
                res += $"\n{i+1} : {_faces[i]}";
            }
            return res;
        }

        #endregion

        #region PUBLIC GETTERS & SETTERS


        /// <summary>
        /// Tableau de char des 6 faces du dé.
        /// </summary>
        /// <value>Nouvelles faces du dé.</value>
        public char[] Faces { get { return _faces; } set { _faces = value; } }

        #endregion

        #endregion
    }
}
