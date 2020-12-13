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
        /// <returns>une variable de type dictionnaire.</returns>
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
        /// Création des valeurs du plateau de jeu.
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
            // todo : remplacer, c'est juste pour les tests
            De[] des = {
                new De(new char[] { 'B', 'A', 'J', 'O', 'Q', 'M' }),
                new De(new char[] { 'R', 'A', 'L', 'E', 'S', 'C' }),
                new De(new char[] { 'L','I','B','A','R','T' }),
                new De(new char[] { 'T','O','K','U','E','N' }),
                new De(new char[] { 'R','O','F','I','A','X' }),
                new De(new char[] { 'A','V','E','Z','D','N' }),
                new De(new char[] { 'N','U','L','E','G','Y' }),
                new De(new char[] { 'M','E','D','A','P','C' }),
                new De(new char[] { 'S','U','T','E','L','P' }),
                new De(new char[] { 'H','E','F','S','I','E' }),
                new De(new char[] { 'R','O','M','A','S','I' }),
                new De(new char[] { 'G','I','N','E','V','T' }),
                new De(new char[] { 'R','U','E','I','L','W' }),
                new De(new char[] { 'R','E','N','I','S','H' }),
                new De(new char[] { 'T','I','E','A','A','O' }),
                new De(new char[] { 'D','O','N','E','S','T' }), };
            Plateau board = new Plateau(des);
            Console.WriteLine(board);
            Console.WriteLine(board.Test_Plateau(Console.ReadLine()));
        }
    }
}
