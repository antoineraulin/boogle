using System;
using System.IO;
using System.Collections.Generic;

namespace Boogle
{
    public class Jeu
    {
        /// <summary>
        /// Création de nos valeurs du dictionnaire.
        /// </summary>
        /// <returns>une variable de type dictionnaa.</returns>
        static Dictionary<int, string[]> mondico()
        {
            Dictionary<int, string[]> result = new Dictionary<int, string[]>();
            string[] text = System.IO.File.ReadAllLines(@"Ressources\MotsPossibles.txt");
            for (int i = 0; i < text.Length; i += 2)
            {
                int res = Int32.Parse(text[i]);
                result.Add(res, text[i + 1].Split(' '));
            }
            return result;
        }
        /// <summary>
        /// Création des valeurs du plateu de jeu.
        /// </summary>
        /// <returns>une variable de type tableau de dés.</returns>
        static De[] board()
        {
            De[] result = new De[16];
            
            
            string[] text = System.IO.File.ReadAllLines(@"Ressources\Des.txt");

            for (int i = 0; i < text.Length; i++)
            {
                string[] subs = text[i].Split(';');
                char[] faces = new char[6];
                for (int j = 0; j < subs.Length; j++)
                {
                    faces[j] = char.Parse(subs[j]);
                }
                De de = new De(faces);
                result[i]=de;
            }
            return result;

        }
        static void Main(string[] args)
        {

        }
    }
}
