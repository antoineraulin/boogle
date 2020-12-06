using System;

namespace Boogle
{
    public class Dictionnaire
    {
        #region PRIVATE
            
            string[] _words;

        #endregion

        #region PUBLIC
            
            public Dictionnaire(string[] words, string lang){
                lang = Langues.FR;
            }

        #endregion
    }
}
