using System;

namespace Boogle
{
    public class Jeu
    {
        static void Main(string[] args)
        {
            // todo
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
