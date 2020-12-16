using System;
using System.Collections.Generic;

namespace Boogle
{
    public class Plateau
    {
        //Définition + on donne une valeur à la variable board.
        private De[] board;

        /// <summary>
        /// Plateau de dés.
        /// </summary>
        /// <value>nouveau tableau de dés.</value>
        public De[] Board { get { return board; } set { board = value; } }

        //Définition + on donne une valeur à la variable upper value.
        private char[,] finalBoard = new char[4, 4];

        /// <summary>
        /// Valeur supérieure.
        /// </summary>
        /// <value>nouveau charactere.</value>
        public char[,] FinalBoard { get { return finalBoard; } set { finalBoard = value; } }

        private Stack<Position> _visited = new Stack<Position>();

        public Stack<Position> Visited { get { return _visited; }}
        /// <summary>
        /// Constructeur de Plateau;
        /// </summary>
        /// <param name="_board">variable de type tableau de dés correspondant au différends dés du plateau de jeu.</param>
        public Plateau(De[] _board)
        {
            Random r = new Random();
            //On fait les verif pour savoir si notre entrée correspond à ceux qu'on veut.
            if (_board != null)
            {
                if (_board.Length != 0)
                {
                    if (_board.Length == 16)
                    {
                        //Si les tailles sont bonnes alors on envoie.
                        board = _board;
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                finalBoard[i, j] = board[i * 4 + j].Roll(r);
                            }
                        }
                    }
                }
            }


        }
        /// <summary>
        /// Description du plateau.
        /// </summary>
        /// <returns>variable de type string affichant le plateaude jeu.</returns>
        public override string ToString()
        {

            string resul = "";
            //On passe à travers tout le tableau.
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //On entre les valeurs dans un string.
                    resul += $"{finalBoard[i, j]}" + " ";

                }
                resul += "\n";
            }
            return resul;


        }

        /// <summary>
        /// Test si le mot est sur le plateau et respecte les contraintes.
        /// </summary>
        /// <param name="mot">Le mot à tester.</param>
        /// <returns>True si le mot a été trouvé</returns>
        public bool Test_Plateau(string mot)
        {
            bool res = false;
            List<Position> startPositions = new List<Position>();
            // on cherche tout les points de départ possibles du mot sur le plateau.
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    char checkChar = finalBoard[i, j];
                    char first = mot[0];
                    if (checkChar == mot[0])
                    {
                        startPositions.Add(new Position(i, j));
                    }
                }
            }
            Stack<Position> visited = new Stack<Position>();

            foreach (Position startPosition in startPositions)
            {
                visited.Push(startPosition);
                if (CheckIfExists(mot, visited, startPosition))
                {
                    res = true;
                    break;
                }
                else
                {
                    if(visited.Count != 0) visited.Pop();
                    else break;
                }
            }
            _visited = visited;
            return res;
        }

        /// <summary>
        /// Test si un mot est possible sur la grille en récursif.
        /// </summary>
        /// <param name="word">Le mot a tester</param>
        /// <param name="visited">Liste des positions visitées</param>
        /// <param name="pos">Position actuelle sur le plateau</param>
        /// <returns>True si le mot a été trouvé</returns>
        public bool CheckIfExists(string word, Stack<Position> visited, Position pos)
        {
            bool res = false;
            if(visited.Count == word.Length){
                return true;
            } 
            // on créé toutes les directions d'observations
            Position nUp = new Position(pos.X - 1, pos.Y); // voisin du dessus
            Position nRight = new Position(pos.X, pos.Y + 1); // voisin de droite
            Position nDown = new Position(pos.X + 1, pos.Y); // voisin de dessous
            Position nLeft = new Position(pos.X, pos.Y - 1); // voisin de gauche
            Position nUpLeft = new Position(pos.X - 1, pos.Y - 1); // voisin de gauche au dessus
            Position nUpRight = new Position(pos.X - 1, pos.Y + 1); // voisin de droite au dessus
            Position nDownLeft = new Position(pos.X + 1, pos.Y - 1); // voisin de gauche en dessous
            Position nDownRight = new Position(pos.X + 1, pos.Y + 1); // voisin de droite en dessous

            // liste des positions qui ne sont pas en dehors du plateau, qui n'ont pas déjà été visité et dont la lettre correspond à la lettre suivante du mot.
            List<Position> possibles = new List<Position>();
            if (nUp.X >= 0 && !visited.Contains(nUp) && finalBoard[nUp.X, nUp.Y] == word[visited.Count])
            {
                possibles.Add(nUp);
            }
            if (nRight.Y < 4 && !visited.Contains(nRight) && finalBoard[nRight.X, nRight.Y] == word[visited.Count])
            {
                possibles.Add(nRight);
            }
            if (nDown.X < 4 && !visited.Contains(nDown) && finalBoard[nDown.X, nDown.Y] == word[visited.Count])
            {
                possibles.Add(nDown);
            }
            if (nLeft.Y >= 0 && !visited.Contains(nLeft) && finalBoard[nLeft.X, nLeft.Y] == word[visited.Count])
            {
                possibles.Add(nLeft);
            }
            if (nUpLeft.X >= 0 && nUpLeft.Y >= 0 && !visited.Contains(nUpLeft) && finalBoard[nUpLeft.X, nUpLeft.Y] == word[visited.Count])
            {
                possibles.Add(nUpLeft);
            }
            if (nUpRight.X >= 0 && nUpRight.Y < 4 && !visited.Contains(nUpRight) && finalBoard[nUpRight.X, nUpRight.Y] == word[visited.Count])
            {
                possibles.Add(nUpRight);
            }
            if (nDownLeft.X < 4 && nDownLeft.Y >= 0 && !visited.Contains(nDownLeft) && finalBoard[nDownLeft.X, nDownLeft.Y] == word[visited.Count])
            {
                possibles.Add(nDownLeft);
            }
            if (nDownRight.X < 4 && nDownRight.Y < 4 && !visited.Contains(nDownRight) && finalBoard[nDownRight.X, nDownRight.Y] == word[visited.Count])
            {
                possibles.Add(nDownRight);
            }

            //on créer autant de branches qu'il y a de possibilité, si on rencontre un cul de sac le système récursif permet de revenir en arrière.
            foreach (Position possible in possibles)
            {
                visited.Push(possible);
                if (CheckIfExists(word, visited, possible))
                {
                    res = true;
                    break;
                }
                else
                {
                    // La branche qu'on a testé n'a pas été concluente, on revient en arrière.
                    visited.Pop();
                }
            }
            return res;
        }
    }
}
