using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Boogle
{
    public class Jeu
    {
        #region GLOBAL VARIABLES

        static List<Joueur> players = new List<Joueur>();

        #endregion
        /// <summary>
        /// Création de nos valeurs du dictionnaire.
        /// </summary>
        /// <returns>une variable de type dictionnaire.</returns>
        static Dictionary<int, string[]> mondico()
        {
            //Initialisation de la variable dictionnary.
            Dictionary<int, string[]> result = new Dictionary<int, string[]>();
            //On crée un tableau de string à partir des lignes du fichier "MotsPossibles.txt".
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\antoi\Documents\boogle\Ressources\MotsPossibles.txt");
            //On passe à travers le tableau de string de deux en deux.
            for (int i = 0; i < text.Length; i += 2)
            {
                //Le fichier est construit de façon à ce que chaque ligne impaire est un chiffre.
                //Donc on transforme le string qui contient un chiffre en variable entière.
                int res = Int32.Parse(text[i]);
                //On ajoute dans notre dictionnary le chiffre qu'on récupère de la transformation.
                //et le tableau de string qui correspond aux mots de longueur du chiffre.
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
            //On crée un tableau de dés de taille 16.
            //Parce que y a 16 dés sur le plateau.
            De[] result = new De[16];
            //On crée un tableau de string à partir des lignes du fichier "Des.txt".
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\antoi\Documents\boogle\Ressources\Des.txt");
            //On passe à travers le tableau de string.
            for (int i = 0; i < text.Length; i++)
            {
                //On sépare les lignes du fichier à chaque point virgule.
                string[] subs = text[i].Split(';');
                //On crée un tableau de charactères de taille 6.
                //PArce qu'il y a 6 faces dans un dé.
                char[] faces = new char[6];
                //On passe à travers notre tableau séparé.
                for (int j = 0; j < subs.Length; j++)
                {
                    //On ajoute les faces du dé en prenant soin de les transformant en char.
                    //Car le constructeur de dé prend un tableau de char en entrée.
                    faces[j] = char.Parse(subs[j]);
                }
                //On crée le dé avec notre tableau.
                De de = new De(faces);
                result[i] = de;

            }
            return result;

        }
        /// <summary>
        /// Renvoie le score des joueurs, cite le premier et le dernier.
        /// </summary>
        static void LeaderBoard()
        {
            //Taille de la liste de joueur.
            int c = players.Count;
            //Tri des joueurs en fonctions de leurs scores.
            players.Sort((player1, player2) => player1.CompareTo(player2));
            //On passe à travers toute la liste triée.
            foreach (Joueur item in players)
            {
                //On affiche le nom du joueur et son score.
                Console.WriteLine(item.Name + ": " + item.Score);
            }
            //Petite phrase de fin assez réconfortante.
            Outils.ColorPrint("Bien joué à : ¨" + players[0].Name + "¨ pour vous avoir tout explosé.", ConsoleColor.Yellow);
            Outils.ColorPrint("Une petite pensée à : ¨" + players[c - 1].Name + "¨ qui n'a vraiment pas été à la hauteur.", ConsoleColor.Red);
        }
        /// <summary>
        /// Affiche le menu de sélection.
        /// </summary>
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Bienvenue dans le menu du jeu dont on ne prononce pas le nom.\n"
                                + "\n\t 1: Saisir le nom des joueurs de la partie."
                                + "\n\t 2: Saisir la durée d'un tour."
                                + "\n\t 3: Commencer la partie."
                                + "\n\t 4: Commencer la partie contre l'IA."
                             );
            Outils.ColorPrint($"\t CTRL-C: ¨Quitter¨\n", ConsoleColor.Red);
            Console.Write("Veuillez saisir le chiffre correspondant à votre sélection s.v.p. > ");
        }

        static void Main(string[] args)
        {



            int hours = 0;
            int minutes = 0;
            int seconds = 120;
            while (true)
            {
                Plateau Board = new Plateau(board());
                Dictionnaire dico = new Dictionnaire(mondico(), Langues.FR);
                Menu();
                int n;
                while (!int.TryParse(Console.ReadLine(), out n))
                {

                    Console.WriteLine("Saisir le NOMBRE correspondant à votre sélection :");
                }
                switch (n)
                {
                    //Menu changement de nom des joueurs.
                    case 1:
                        Console.WriteLine("Combien de joueur voulez vous inscire ?");
                        int l;
                        while (!int.TryParse(Console.ReadLine(), out l))
                        { Console.WriteLine("Saisir le NOMBRE correspondant à votre sélection :"); }
                        for (int i = 0; i < l; i++)
                        {
                            Console.WriteLine("Saisir le nom du joueur");
                            string name = Console.ReadLine();
                            Joueur j = new Joueur(name);
                            players.Add(j);
                        }



                        Console.WriteLine("Bonjour ");
                        foreach (Joueur item in players)
                        {
                            Console.Write(item + ", ");
                        }
                        Console.WriteLine(", bienvenue dans le jeu Boggle codé par \n Antoine Raulin et Regnault Erwan");
                        break;


                    //Menu changement de durée d'une partie.
                    case 2:
                        int p;
                        Console.WriteLine("Vous souhaitez saisir (par défaut une partie dure 2min) :"
                                            + "\n\t 11: des heures ?"
                                            + "\n\t 12: des minutes ?"
                                            + "\n\t 13: des secondes ?");
                        Console.Write("Veuillez saisir le chiffre correspondant à votre sélection s.v.p. > ");
                        while (!int.TryParse(Console.ReadLine(), out p))
                        { Console.WriteLine("Saisir le NOMBRE correspondant à votre sélection :"); }
                        switch (p)
                        {
                            case 11:
                                do { Console.WriteLine("Saisissez le nombre d'heures d'un tour :"); }
                                while (!int.TryParse(Console.ReadLine(), out hours));
                                do { Console.WriteLine("Saisissez le nombre de minutes d'un tour :"); }
                                while (!int.TryParse(Console.ReadLine(), out minutes));
                                do
                                {
                                    Console.WriteLine("Saisissez le nombre de secondes d'un tour :");
                                } while (!int.TryParse(Console.ReadLine(), out seconds) || seconds % 2 != 0);
                                break;

                            case 12:
                                do { Console.WriteLine("Saisissez le nombre de minutes d'un tour :"); }
                                while (!int.TryParse(Console.ReadLine(), out minutes));
                                do
                                {
                                    Console.WriteLine("Saisissez le nombre de secondes d'un tour :");
                                } while (!int.TryParse(Console.ReadLine(), out seconds) || seconds % 2 != 0);
                                break;

                            case 13:
                                do
                                {
                                    Console.WriteLine("Saisissez le nombre de secondes d'un tour :");
                                } while (!int.TryParse(Console.ReadLine(), out seconds) || seconds % 2 != 0);
                                break;
                        }
                        break;

                    //Partie en 1V1.
                    case 3:
                        //Créations des deux joueurs si ils n'existent pas déjà
                        if (players.Count == 0)
                        {
                            players.Add(new Joueur("Alice"));
                            players.Add(new Joueur("Bob"));
                        }


                        //On crée la durée d'un tour pour un joueur.
                        TimeSpan duration = new TimeSpan(hours, minutes, seconds) / players.Count;
                        for (int i = 0; i < players.Count; i++)
                        {
                            //On prend l'heure actuelle.
                            DateTime now = DateTime.Now;

                            //Création et affichage du plateau.
                            Board = new Plateau(board());


                            //Création du dico.

                            Console.WriteLine("C'est au tour de " + players[i].Name + " de jouer.");
                            System.Threading.Thread.Sleep(1000);
                            Outils.Draw(top: "", middle: Board.ToString(), bottom: "");
                            TimerThread thread = new TimerThread(player: players[i], duree: (int)duration.TotalSeconds);
                            Thread thr = new Thread(new ThreadStart(thread.thread));
                            thr.Start();

                            //Tant qu'on a pas atteint la fin du tour.
                            while (DateTime.Now <= now + duration)
                            {
                                //On demande saisir le mot que le joueur a trouvé.
                                Console.Write("> ");
                                string found = Console.ReadLine();

                                //Si on a pas dépassé le temps du tour.
                                if (DateTime.Now <= now + duration)
                                {
                                    //Si le mot est contenu dans le dico et que le chemin est correct.
                                    if (dico.Contains(found) && Board.Test_Plateau(found))
                                    {

                                        DateTime nowR = DateTime.Now;
                                        TimeSpan remaining = ((now + duration) - nowR);
                                        //On ajoute le mot dans la liste des mots trouvés par le joueur.
                                        players[i].Add_Mot(found);


                                        Outils.ReDrawBoard(new Position(Console.CursorLeft, Console.CursorTop), Board);
                                    }
                                    //Sinon cela veut dire que le mot n'est pas valide.
                                    else
                                    {
                                        Console.WriteLine("Le score n'avance pas car le mot suivant " + found + " n'est pas valide.");

                                    }
                                }



                            }
                        }
                        //On appelle le tableau des scores.
                        LeaderBoard();
                        Console.WriteLine("Appuyez sur entrée pour passer à la suite.");
                        Console.ReadLine();


                        break;

                    //Partie contre l'IA.
                    case 4:
                        //Création du dico.

                        //Même principe qu'au-dessus pour le tour du joueur.
                        if (players.Count == 0)
                        {
                            players.Add(new Joueur("Alice"));
                            players.Add(new Joueur("Bob"));
                        }


                        //On crée la durée d'un tour pour un joueur.
                        duration = new TimeSpan(hours, minutes, seconds) / 2;
                        for (int i = 0; i < players.Count; i++)
                        {
                            //On prend l'heure actuelle.
                            DateTime now = DateTime.Now;

                            //Création et affichage du plateau.
                            Board = new Plateau(board());



                            Console.WriteLine("C'est au tour de " + players[i].Name + " de jouer.");
                            System.Threading.Thread.Sleep(1000);
                            Outils.Draw(top: "", middle: Board.ToString(), bottom: "");
                            TimerThread thread = new TimerThread(player: players[i], duree: (int)duration.TotalSeconds);
                            Thread thr = new Thread(new ThreadStart(thread.thread));
                            thr.Start();

                            //Tant qu'on a pas atteint la fin du tour.
                            while (DateTime.Now <= now + duration)
                            {
                                //On demande saisir le mot que le joueur a trouvé.
                                Console.Write("> ");
                                string found = Console.ReadLine();

                                //Si on a pas dépassé le temps du tour.
                                if (DateTime.Now <= now + duration)
                                {
                                    //Si le mot est contenu dans le dico et que le chemin est correct.
                                    if (dico.Contains(found) && Board.Test_Plateau(found))
                                    {

                                        DateTime nowR = DateTime.Now;
                                        TimeSpan remaining = ((now + duration) - nowR);
                                        //On ajoute le mot dans la liste des mots trouvés par le joueur.
                                        players[i].Add_Mot(found);
                                        Outils.ReDrawBoard(new Position(Console.CursorLeft, Console.CursorTop), Board);
                                    }
                                    //Sinon cela veut dire que le mot n'est pas valide.
                                    else
                                    {
                                        Console.WriteLine("Le score n'avance pas car le mot suivant " + found + " n'est pas valide.");

                                    }
                                }



                            }
                        }


                        //On crée l'IA.
                        Board = new Plateau(board());

                        IA iA = new IA(Board, dico);
                        DateTime nowIA = DateTime.Now;
                        players.Add(iA.Player);
                        TimerThread threadIA = new TimerThread(player: iA.Player, duree: (int)duration.TotalSeconds);
                        Thread thrIA = new Thread(new ThreadStart(threadIA.thread));
                        thrIA.Start();
                        while (DateTime.Now <= nowIA + duration)
                        {
                            string found = iA.Play();
                            Console.WriteLine($"> {found}");
                            //L'IA joue.

                            //On refait la même choque que pour la partie normale.
                            if (DateTime.Now <= nowIA + duration)
                            {
                                if (dico.Contains(found) && Board.Test_Plateau(found))
                                {
                                    iA.Player.Add_Mot(found);
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Le score n'avance pas car le mot suivant " + found + " n'est pas valide.");

                                }
                                Outils.ReDrawBoard(new Position(Console.CursorLeft, Console.CursorTop), Board);
                                System.Threading.Thread.Sleep(2000);
                            }

                        }
                        //On appelle le tableau des scores.
                        LeaderBoard();
                        Console.WriteLine("Appuyez sur entrée pour passer à la suite.");
                        Console.ReadLine();
                        break;



                }
            }
        }
    }


    /// <summary>
    /// Thread pour l'affichage du score et du timer en haut de la console
    /// </summary>
    public class TimerThread
    {
        private Joueur _player;
        private int _duree;

        public TimerThread(Joueur player, int duree = 60)
        {
            _player = player;
            _duree = duree;
        }

        /// <summary>
        /// La fonction qui est éxecuté dans un thread
        /// </summary>
        /// On utilise un thread à part pour ne pas que le Console.Readline() nous empêche de mettre à jour l'affichage.
        /// </remarks>
        public void thread()
        {
            bool stop = false;
            while (!stop)
            {
                // Si le temps est écoulé on arrête le thread.
                if (_duree == 0)
                {
                    stop = true;
                }
                else if (_duree < 10)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Outils.ReDrawTop(new Position(Console.CursorLeft, Console.CursorTop), text: $"{_player.Name} | Score : {_player.Score} | Temps restant : ¨{_duree}s¨    ", color: ConsoleColor.Red);
                        System.Threading.Thread.Sleep(200);
                        Outils.ReDrawTop(new Position(Console.CursorLeft, Console.CursorTop), text: $"{_player.Name} | Score : {_player.Score} | Temps restant :           ");
                        System.Threading.Thread.Sleep(200);
                    }
                }
                else
                {
                    Outils.ReDrawTop(new Position(Console.CursorLeft, Console.CursorTop), text: $"{_player.Name} | Score : {_player.Score} | Temps restant : ¨{_duree}s   ¨");
                    System.Threading.Thread.Sleep(1000);
                }
                _duree--;

            }
            Console.WriteLine("Le tours est terminé. Appuyez sur entrée.");
        }
    }
}