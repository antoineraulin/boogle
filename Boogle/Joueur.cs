using System;
using System.Collections.Generic;

namespace Boogle
{
    public class Joueur
    {
        //Définition + on donne une valeur à la variable nom du joueur.

        private string name;
        /// <summary>
        /// Nom du joueur.
        /// </summary>
        /// <value>nouveau nom.</value>
        public string Name { get { return name; } set { name = value; } }
        //Définition + on donne une valeur à la variable score du joueur.
        private int score;
        /// <summary>
        /// Score du joueur.
        /// </summary>
        /// <value>nouveau score</value>
        public int Score { get { return score; } set { score = value; } }
        //Définition + on donne une valeur à la variable found du joueur.
        private List<string> found;
        /// <summary>
        /// Mots trouvés du joueur.
        /// </summary>
        /// <value>nouvelle liste de mots trouvés.</value>
        public List<string> Found { get { return found; } set { found = value; } }


        private List<string> database;
        /// <summary>
        /// Mot cités par le joueur.
        /// </summary>
        /// <value>nouvelle liste de mot cités.</value>
        public List<string> Database { get { return database; } set { database = value; } }
        /// <summary>
        /// Constructeur de la classe joueur.
        /// </summary>
        /// /// /// <param name="_name">variable de type chaîne de caractere correspondant au nom du joueur</param>
        /// <param name="_score">variable de type entier correspondant au score du joueur</param>
        /// <param name="_found">variable de type liste de chaîne de caractere correspondant aux mots trouvés du joueur</param>
        public Joueur(string _name, int _score)
        {
            score = _score;

            //Si le nom n'est pas null et n'est pas vide alors on le renvoie sinon on arrête et le joueur n'est pas créer.
            if (_name != null)
            {
                if (_name.Length != 0)
                {
                    name = _name;
                }
                else throw new ArgumentException("name ne peux être vide.");
            }
            else throw new ArgumentException("name ne peut être null.");
        }

        /// <summary>
        /// Test si le mot (en entré) a déjà été trouvé.
        /// </summary>
        /// <param name="mot">variable de type chaîne de caractere correspondant au mot entré par le joueur.</param>
        /// <param name="list">variable de type liste de chaîne de caractere.</param>
        /// <returns>vrai si le joueur a déjà trouvé le mot faux sinon.</returns>
        public bool Contain(string mot, List<string> list)
        {
            bool resul = false;
            //On passe à travers toute la liste de mots trouvés et on compare avec l'entrée, si la liste contient le mot alors on revoit vrai.
            foreach (string item in list)
            {
                if (item == mot)
                {
                    resul = true;
                }
            }
            return resul;
        }
        /// <summary>
        /// Ajoute le mot (en entré) à la liste des mots trouvés.
        /// </summary>
        /// <param name="mot">variable de type chaîne de caractere correspondant au mot entré par le joueur.</param>
        public void Add_Mot(string mot)
        {
            //Si le mot n'est pas contenu dans la liste de mots trouvés alors on l'ajoute dans la liste.
            if (!Contain(mot, Found))
            {
                Found.Add(mot);
            }
        }
        /// <summary>
        /// Test si le mot (en entré) a déjà été cité.
        /// </summary>
        /// <param name="mot">variable de type chaîne de caractere correspondant au mot entré par le joueur.</param>
        /// <returns>vrai si le joueur a déjà cité le mot faux sinon.</returns>
        public bool Mot_Cite(string mot)
        {
            bool resul = true;
            //Si le mot n'est pas contenu dans la liste de mots cités alors renvoit faux.
            if (!Contain(mot, Database))
            {
                resul = false;
            }
            return resul;
        }
        /// <summary>
        /// Description du joueur.
        /// </summary>
        /// <returns>une chaîne de caractere décrivant le joueur.</returns>
        public override string ToString()
        {
            
            string resul = $"Le joueur qui répond au nom de {Name} a un score de {Score} points et a trouvé les mots suivants : ";
            //On écrit chaque mot qui se trouve dans la liste des mots trouvés par le joueur.
            foreach(string item in Found)
            {
                resul+=$"{item}, ";
            }
            return resul;
        }

    }
}
