using System;

namespace Boogle
{
    public class Outils
    {

        #region PUBLIC

        
        /// <summary>
        /// Mettre ce qui se trouve entre ¨¨ en couleur.
        /// </summary>
        /// <param name="data">variable de type chaîne de caractere : le texte dans lequel se trouve la partie que vous voulez mettre en couleur.</param>
        /// <param name="color">variable de type couleur : la couleur que vous choisissez.</param>
        /// <param name="ln">variable de type bool : retour à la ligne (vraie par défaut)</param>
        public static void ColorPrint(string data, System.ConsoleColor color, bool ln = true)
        {
            //On initialise les couleurs de la console en "par défaut".
            Console.ResetColor();
            //On crée un tableau de string en séparant le texte en entrée à chaque ¨¨.
            string[] datas = data.Split("¨");
            //On passe à travers le tableau.
            for (int i = 0; i < datas.Length; i += 2)
            {
                //On écrit dans la console le contenu du tableau.
                Console.Write(datas[i]);
                //Si on ne dépasse pas les bornes du tableau.
                if (i + 1 <datas.Length)
                {
                    //On met la couleur de l'écriture dans la console en couleur en entrée.
                    Console.ForegroundColor = color;
                    //On écrit notre mot.
                    Console.Write(datas[i + 1]);
                    //On remet les couleurs par défaut.
                    Console.ResetColor();
                }
            }
            //Si ln est vraie.
            if (ln)
            {
                //retour à la ligne.
                Console.WriteLine();
            }
            //On remet les couleurs par défaut.
            Console.ResetColor();
        }

        /// <summary>
        /// Affiche dans la console trois bloc, en haut de la console le texte top, puis le middle et le bottom
        /// </summary>
        /// <param name="top">variable de type chaîne de caractere :bloc de texte qui se trouvera en haut de la console.</param>
        /// <param name="middle">variable de type chaîne de caractere :bloc de texte qui se trouvera au milieu de la console.</param>
        /// <param name="bottom">variable de type chaîne de caractere :bloc de texte qui se trouvera en bas de la console.</param>
        /// <param name="bottomLn">variable de type booléen :retour à la ligne (vraie par défaut)</param>
        public static void Draw(string top = "", string middle = "", string bottom = "", bool bottomLn = true)
        {
            //On remet les couleurs par défaut.
            Console.Clear();
            //On utilise la fonction colorPrint avec un string top en entrée et la couleur rouge.
            ColorPrint(top, ConsoleColor.Red);
            //Retour à la ligne.
            Console.WriteLine();
            //On écrit le bloc du milieu.
            Console.WriteLine(middle);
            //Retour à la ligne.
            Console.WriteLine();
            //Si bottomLn vrai alors on écrit le bloc du bas avec un retour à la ligne.
            if (bottomLn) Console.WriteLine(bottom);
            //Sinon on écrit juste le bloc du bas.
            else Console.Write(bottom);
        }
        
        /// <summary>
        /// Permet de redessiner dans la console la première ligne
        /// </summary>
        /// <param name="old">variable de type position : position du curseur avant qu'on ne mette à jour la ligne.</param>
        /// <param name="text">variable de type chaîne de caractere : texte.</param>
        /// <param name="color">variable de type couleur : la couleur que vous choisissez.(vert par défaut)</param>
        public static void ReDrawTop(Position old,string text = "", System.ConsoleColor color = ConsoleColor.Green)
        {
            //On place le curseur en haut à gauche de la console.
            Console.SetCursorPosition(0,0);
            //On utilisa la fonction ColorPrint sur le texte en entrée, la couleur en entrée et pas de retour à la ligne.
            ColorPrint(text, color, ln:false);
            //On replace la curseur à l'ancienne position.
            Console.SetCursorPosition(old.X, old.Y);
        }

        /// <summary>
        /// Permet de redessiner le plateau en mettant en surbrillance les lettres que le joueur à potentiellement utilisé pour trouvé le mot.
        /// </summary>
        /// <param name="old">variable de type position : position du curseur avant qu'on ne mette à jour la ligne.</param>
        /// <param name="board">variable de type Plateau : le plateau de jeu</param>
        /// <param name="color">variable de type couleur : la couleur que vous choisissez.(vert par défaut)</param>
        public static void ReDrawBoard(Position old,Plateau board, System.ConsoleColor color = ConsoleColor.Green){
            string[] boardTxt = board.ToString().Split("\n");
            for (int i = 0; i < boardTxt.Length; i++)
            {
                Console.SetCursorPosition(0,2+i);
                for (int j = 0,k=0; j < boardTxt[i].Length && k < 4; j+=2,k++)
                {
                    Position pos = new Position(i,k);
                    if(board.Visited.Contains(pos)){
                        ColorPrint($"¨{boardTxt[i][j]}¨ ", color, ln:false);
                    }else{
                        Console.Write(boardTxt[i][j]+" ");
                    }
                }
            }
            Console.SetCursorPosition(old.X, old.Y);
            

        }

        
        



        #endregion

    }
}