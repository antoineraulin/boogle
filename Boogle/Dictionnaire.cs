using System;
using System.Collections.Generic;

namespace Boogle
{
    public class Dictionnaire
    {
        #region PRIVATE

        private Dictionary<int, string[]> _dictionary;
        private string _lang;

        #endregion

        #region PUBLIC

        /// <summary>
        /// Constructeur de la classe Dictionnaire.
        /// </summary>
        /// <param name="dictionary">Dictionnaire de mots qui composent le dictionaire. Les clé du dictionary sont les tailles des mots qui sont dans les tableaux de mots associés</param>
        /// <param name="lang">Langue du dictionaire</param>
        public Dictionnaire(Dictionary<int, string[]> dictionary, string lang)
        {
            if(lang == null || dictionary == null){
                // On génére une erreur par rapport aux arguments passé en paramètre de la méthode.
                // throw arrête la méthode, ce qui suit ne sera pas exectué.
                throw new ArgumentException("Les paramètres ne peuvent être null");
            }
            if(dictionary.Count == 0){
                throw new ArgumentException("Le dictionaire ne peut être vide");
            }
            
            _lang = lang;
            _dictionary = dictionary;
        }

        /// <summary>
        /// Description du dictionnaire.
        /// </summary>
        /// <returns>Une description du dictionnaire en chaîne de caractères.</returns>
        public override string ToString()
        {
            string res = $"Contient {Count} mots de la langue : {_lang}.";
            foreach (KeyValuePair<int, string[]> item in _dictionary)
            {
                if (item.Value != null && item.Key != 0)
                {
                    res += $"\n\t{item.Value.Length} mots de longueur {item.Key}";
                }

            }
            return res;
        }

        /// <summary>
        /// Nombre de mots dans le dictionaire.
        /// </summary>
        public int Count
        {
            get
            {
                int res = 0;
                foreach (KeyValuePair<int, string[]> item in _dictionary)
                {
                    if (item.Value != null && item.Key != 0)
                    {
                        res += item.Key * item.Value.Length;
                    }

                }
                return res;
            }
        }


        /// <summary>
        /// Test si 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Contains(string word)
        {
            Dictionary<int, string[]>.ValueCollection wordsCollection = _dictionary.Values;
            List<string> wordsList = new List<string>();
            foreach (string[] _words in wordsCollection)
            {
                wordsList.AddRange(_words);
            }
            return wordsList.Contains(word);
        }

        #endregion
    }
}
