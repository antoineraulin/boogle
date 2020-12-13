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

        public bool Test_Plateau(string mot)
        {
            bool res = false;
            List<Position> startPositions = new List<Position>();
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
                if (CheckIfExists(mot, visited, 0, startPosition))
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
            return res;
        }

        public bool CheckIfExists(string word, Stack<Position> visited, int index, Position pos)
        {
            bool res = false;
            if(index == word.Length - 1){
                return true;
            } 
            Position nUp = new Position(pos.X - 1, pos.Y); // voisin du dessus
            Position nRight = new Position(pos.X, pos.Y + 1); // voisin de droite
            Position nDown = new Position(pos.X + 1, pos.Y); // voisin de dessous
            Position nLeft = new Position(pos.X, pos.Y - 1); // voisin de gauche
            Position nUpLeft = new Position(pos.X - 1, pos.Y - 1); // voisin de gauche au dessus
            Position nUpRight = new Position(pos.X - 1, pos.Y + 1); // voisin de droite au dessus
            Position nDownLeft = new Position(pos.X + 1, pos.Y - 1); // voisin de gauche en dessous
            Position nDownRight = new Position(pos.X + 1, pos.Y + 1); // voisin de droite en dessous
            List<Position> possibles = new List<Position>();
            if (nUp.X >= 0 && !visited.Contains(nUp) && finalBoard[nUp.X, nUp.Y] == word[index + 1])
            {
                possibles.Add(nUp);
            }
            if (nRight.Y < 4 && !visited.Contains(nRight) && finalBoard[nRight.X, nRight.Y] == word[index + 1])
            {
                possibles.Add(nRight);
            }
            if (nDown.X < 4 && !visited.Contains(nDown) && finalBoard[nDown.X, nDown.Y] == word[index + 1])
            {
                possibles.Add(nDown);
            }
            if (nLeft.Y >= 0 && !visited.Contains(nLeft) && finalBoard[nLeft.X, nLeft.Y] == word[index + 1])
            {
                possibles.Add(nLeft);
            }
            if (nUpLeft.X >= 0 && nUpLeft.Y >= 0 && !visited.Contains(nUpLeft) && finalBoard[nUpLeft.X, nUpLeft.Y] == word[index + 1])
            {
                possibles.Add(nUpLeft);
            }
            if (nUpRight.X >= 0 && nUpRight.Y < 4 && !visited.Contains(nUpRight) && finalBoard[nUpRight.X, nUpRight.Y] == word[index + 1])
            {
                possibles.Add(nUpRight);
            }
            if (nDownLeft.X < 4 && nDownLeft.Y >= 0 && !visited.Contains(nDownLeft) && finalBoard[nDownLeft.X, nDownLeft.Y] == word[index + 1])
            {
                possibles.Add(nDownLeft);
            }
            if (nDownRight.X < 4 && nDownRight.Y < 4 && !visited.Contains(nDownRight) && finalBoard[nDownRight.X, nDownRight.Y] == word[index + 1])
            {
                possibles.Add(nDownRight);
            }
            foreach (Position possible in possibles)
            {

                if (CheckIfExists(word, visited, index + 1, possible))
                {
                    res = true;
                    break;
                }
                else
                {
                    visited.Pop();
                }
            }
            return res;
        }
    }
}
