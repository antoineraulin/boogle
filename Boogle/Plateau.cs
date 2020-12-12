using System;

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
        private char[] upperValue;
        /// <summary>
        /// Valeur supérieure.
        /// </summary>
        /// <value>nouveau charactere.</value>
        public char[] UpperValue { get { return upperValue; } set { upperValue = value; } }
        /// <summary>
        /// Constructeur de Plateau;
        /// </summary>
        /// <param name="_board">variable de type tableau de dés correspondant au différends dés du plateau de jeu.</param>
        public Plateau(De[] _board)
        {
            Random r = new Random();

            if (_board != null)
            {
                if (_board.Length != 0)
                {
                    if (_board.Length == 16)
                    {
                        board = _board;
                        for (int i = 0; i < board.Length; i++)
                        {
                            upperValue[i] = board[i].Roll(r);
                        }
                    }
                }
            }


        }
        public override string ToString()
        {

            string resul = "";
            for (int i = 0; i < 16; i++)
            {

                resul += $"{upperValue[i]}" + " ";
                if (i % 4 == 0)
                {
                    resul += "\n";
                }

            }
            return resul;


        }
    }
}
