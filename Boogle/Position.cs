using System;
using System.Collections.Generic;

namespace Boogle
{
    public class Position : IEquatable<Position> // permet de determiner si deux instances de Position sont égales dans une liste avec List<Position>.Contains()
    {
        #region PRIVATE

        // définition des variables privées
        private int _x, _y; //_x pour la ligne et _y pour la colonne

        #endregion

        #region PUBLIC

        /// <summary>
        /// Constructeur de la classe Position
        /// </summary>
        /// <param name="x">Ligne</param>
        /// <param name="y">Colonne</param>
        public Position(int x, int y)
        {
            _y = y;
            _x = x;
        }

        #region getters & setters

        public int X { get => _x; }
        public int Y { get => _y; }

        #endregion

        /// <summary>
        ///  Retourne une chaîne de caractères qui décrit la position
        /// </summary>
        /// <returns>un string : (x,y) avec x la ligne et y la colonne</returns>
        public string toString()
        {
            return $"({_x},{_y})";
        }

        /// <summary>
        ///  teste si 2 positions sont égales. On dit que 2 positions sont identiques si elles ont la même ligne et la même colonne 
        /// </summary>
        /// <param name="pos">un objet position de type Position</param>
        /// <returns>true si les collones et les lignes sont égales</returns>

        public bool Equals(Position other)         // Requis par IEquatable<Position>
        {
            return other.X == _x && other.Y == _y;
        }

        #endregion



    }
}