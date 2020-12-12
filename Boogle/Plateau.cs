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
            //On fait les verif pour savoir si notre entrée correspond à ceux qu'on veut.
            if (_board != null)
            {
                if (_board.Length != 0)
                {
                    if (_board.Length == 16)
                    {
                        //Si les tailles sont bonnes alors on envoie.
                        board = _board;
                        for (int i = 0; i < board.Length; i++)
                        {
                            //On envoie les faces superieures.
                            upperValue[i] = board[i].Roll(r);
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
            for (int i = 0; i < 16; i++)
            {
                //On entre les valeurs dans un string.
                resul += $"{upperValue[i]}" + " ";
                //Si c'est un multiple de 4 alors :
                if (i % 4 == 0)
                {
                    //On mets à la ligne.
                    resul += "\n";
                }

            }
            return resul;


        }
       
    }
}
