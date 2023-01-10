using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace tombola_per_natale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //generatire numeri
            Random rnd = new Random();

            //cartella 
            Console.SetCursorPosition(0, 20);
            int numero = 0;
            int[,] MatricePrimaria = new int[9, 11];
            int[,] Cartella = new int[3, 9];

            // Popolamento matrice primaria
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    MatricePrimaria[i, j] = numero++;
                }
            }
            MatricePrimaria[8, 10] = 90;

            //Rimescolamento Matrice Primaria riga per riga
            RimescolaMatricePerRiga(MatricePrimaria);

            // Creazione cartella grezza
            // Scansione delle singole righe della matrice primaria
            for (int riga = 0; riga < 9; riga++)
            {
                int colonnaMatrice = 0;
                int rigaCartella = 0;
                int colonnaCartella = riga;

                // Analisi colonne matrice primaria
                do
                {
                    while (MatricePrimaria[riga, colonnaMatrice] == 0)
                    {
                        colonnaMatrice++;
                    }
                    Cartella[rigaCartella, colonnaCartella] = MatricePrimaria[riga, colonnaMatrice];
                    rigaCartella++;
                    colonnaMatrice++;
                    if (rigaCartella == 3)
                    {
                        break;
                    }
                } while (rigaCartella < 3);
            }

            OrdinaColonne(Cartella);

            NormalizzaCartella(Cartella);

            StampaCartella(Cartella);

            void NormalizzaCartella(int[,] Matrice)
            {
                // Toglie a caso tre numeri per riga

                int zeri = 0;
                int tmp = 0;

                for (int riga = 0; riga < Matrice.GetLength(0); riga++)
                {
                    while (zeri < 4)
                    {
                        tmp = rnd.Next(0, 9);
                        if (Matrice[riga, tmp] != 0)
                        {
                            Matrice[riga, tmp] = 0;
                            zeri++;
                        }
                    }
                    zeri = 0;
                }

                return;
            }

            void OrdinaColonne(int[,] Matrice)
            {

                for (int colonna = 0; colonna < Matrice.GetLength(1); colonna++)
                {
                    bool scambio = true;
                    int tmp = 0;
                    while (scambio)
                    {
                        scambio = false;
                        for (int riga = 0; riga < Matrice.GetLength(0) - 1; riga++)
                        {
                            if ((riga + 1 < Matrice.GetLength(1)) && Matrice[riga, colonna] > Matrice[riga + 1, colonna])
                            {
                                tmp = Matrice[riga, colonna];
                                Matrice[riga, colonna] = Matrice[riga + 1, colonna];
                                Matrice[riga + 1, colonna] = tmp;
                                scambio = true;
                            }
                        }
                    }
                }
                return;
            }


            void StampaCartella(int[,] Matrice)
            {
                int righe = Matrice.GetLength(0);
                int colonne = Matrice.GetLength(1);

                for (int i = 0; i < righe; i++)
                {
                    Console.Write("|");
                    for (int j = 0; j < colonne; j++)
                    {
                        if (Matrice[i, j] != 0)
                            Console.Write(" {0, 2} |", Matrice[i, j]);
                        else
                            Console.Write("    |");
                    }
                    Console.WriteLine();
                    Console.WriteLine("+--------------------------------------------+");
                }
            }

            void RimescolaMatricePerRiga(int[,] Matrice)
            {

                int tmp = 0;
                int righe = Matrice.GetLength(0);

                for (int riga = 0; riga < righe; riga++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        int indexA = rnd.Next(0, 6);
                        int indexB = rnd.Next(6, 11);
                        tmp = Matrice[riga, indexA];
                        Matrice[riga, indexA] = Matrice[riga, indexB];
                        Matrice[riga, indexB] = tmp;
                    }
                }

                return;
            }
            //tabellone
            List<int> numbers = Enumerable.Range(1, 91).ToList();

            for (int t = 0; t < 90; t++)
            {
                int a = rnd.Next(numbers.Count);

                Thread.Sleep(1000);
                if (a == 10 || a == 20 || a == 30 || a == 40 || a == 50 || a == 60 || a == 70 || a == 80 || a == 90)
                {
                    Console.SetCursorPosition(18, ((a / 10) - 1));
                    Console.WriteLine(a);
                }
                else
                {
                    int b = a - ((a / 10) * 10);
                    int c = ((b * 2) - 2);
                    int d = a / 10;
                    Console.SetCursorPosition(c, d);
                    Console.WriteLine(a);
                }
                numbers.RemoveAt(a);
            }
           
        }
    }
}

