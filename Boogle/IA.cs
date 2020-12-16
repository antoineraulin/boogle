using System;
using System.Collections.Generic;

namespace Boogle
{
    public class IA
    {
        #region PRIVATE

        private Joueur _player;
        private List<string> _founds = new List<string>();

        #endregion

        #region PUBLIC

        public IA(Plateau board, Dictionnaire dictionary)
        {
            _player = new Joueur("IA");
            Dictionary<int, string[]>.ValueCollection wordsCollection = dictionary.Dictionary.Values; // on récupère juste les valeurs du dictionnaire.
            List<string> wordsList = new List<string>();
            foreach (string[] _words in wordsCollection)
            {
                if(_words[0].Length >= 3) wordsList.AddRange(_words); // on ajoute à la list tout les mots d'une certaine longueur.
            }
            
            foreach (string word in wordsList)
            {
                if(board.Test_Plateau(word)) _founds.Add(word);
            }

            
        }

        public string Play(){
            Random rnd = new Random();
            int index = rnd.Next(0, _founds.Count);
            return _founds[index];
        }

        #region GETTERS 

        public Joueur Player { get { return _player; } }

        #endregion

        #endregion

    }
}
