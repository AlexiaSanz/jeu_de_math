using System;

namespace jeu_de_math
{
    class Program
    {
        static Random aleatoire = new Random();
        static void JouerPartie(int NOMBRE_MIN, int NOMBRE_MAX, int nbVies, int nbQuestions)
        {
            int points = 0;
            int moyenne = nbQuestions / 2;

            for (int j = 0; j < nbQuestions; j++)
            {
                if (!PoserQuestion(NOMBRE_MIN, NOMBRE_MAX))
                {
                    nbVies--;

                    if (nbVies == 0)
                    {
                        Console.WriteLine($"GAME OVER");
                        Console.WriteLine($"Votre score : {points} points");
                        break;
                    }

                    Console.WriteLine($"Il vous reste {nbVies} vies");
                    Console.WriteLine();
                }
                else
                {
                    points++;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Votre score : {points} points");

            if (points == nbQuestions)
            {
                Console.WriteLine("Bravo !");
            }
            else if(points == 0)
            {
                Console.WriteLine("Il est urgent de réviser !");
            }
            else if (points >= moyenne)
            {
                Console.WriteLine("Bien joué");
            }
            else
            {
                Console.WriteLine("Continuez à vous entrainer");
            }
        }

        private static bool PoserQuestion(int NOMBRE_MIN, int NOMBRE_MAX)
        {
            operations operations = (operations) aleatoire.Next(0, 3);
            int a = aleatoire.Next(NOMBRE_MIN, NOMBRE_MAX + 1);
            int b = aleatoire.Next(NOMBRE_MIN, NOMBRE_MAX + 1);
            int resultAddition;
            string ennonce;
           
            

            switch (operations)
            {
                case jeu_de_math.operations.Multiplication:
                    resultAddition = a * b;
                    ennonce = $"{a} x {b} = ";
                    break;
                case jeu_de_math.operations.addition:
                    resultAddition = a + b;
                    ennonce = $"{a} + {b} = ";
                    break;
                case jeu_de_math.operations.soustraction:
                    resultAddition = a - b;
                    ennonce = $"{a} - {b} = ";
                    break;
                case jeu_de_math.operations.division:
                    resultAddition = a / b;
                    ennonce = $"{a} / {b} = ";
                    break;
                default:
                    resultAddition = 0;
                    ennonce = "0";
                    break;
            }
            int reponseInt = SaisirNonbre(ennonce);

            if (reponseInt != resultAddition)
            {
                Console.WriteLine($"Faux ! La réponse était : {resultAddition}");
                return false;
            }

            Console.WriteLine("Bonne réponse !");
            return true;
           
        }

        private static int SaisirNonbre(string message)
        {
            int reponseInt;
            while (true)
            {
                Console.Write(message);
                string reponse = Console.ReadLine();

                try
                {
                    reponseInt = int.Parse(reponse);
                    break;
                }
                catch
                {
                    Console.WriteLine("Erreur, vous devez entrer un nombre");
                }
            }

            return reponseInt;
        }

        static void Main(string[] args)
        {
            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 10;
            const int nbVies = 5;
            const int nbQuestions = 10;
            
           

            JouerPartie(NOMBRE_MIN, NOMBRE_MAX, nbVies, nbQuestions);

           
        }
    }
}
