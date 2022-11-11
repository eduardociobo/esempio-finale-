using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerSetteSegmenti
{
    class Program
    {
        static int origRow;
        static int origCol;

        static void Main(string[] args)
        {

            Console.WriteLine("Autore: Eduardo Ciobotaru Classe: 3G");
            int minuti;
            int secondi;
            string stInput;
            bool inputOK;
            string tuamamma;
            string tuasorella;

            //Controllo input minuti
            do
            {
                Console.Write("Input minuti ->");
                stInput = Console.ReadLine();
                inputOK = int.TryParse(stInput, out minuti);
                if (minuti < 0 || minuti > 60)
                    inputOK = false;
                if (!inputOK) Console.WriteLine("Input non valido! Riprova");
            } while (!inputOK);

            //Controllo input secondi
            do
            {
                Console.Write("input secondi -->");
                stInput = Console.ReadLine();
                inputOK = int.TryParse(stInput, out secondi);
                if (secondi < 0 || secondi > 60) inputOK = false;
                if (secondi == 0 && minuti == 0) inputOK = false;
                if (!inputOK) Console.WriteLine("Input non valido! Riprova");
            } while (!inputOK);

            Console.CursorVisible = false;
            //Ciclo timer
            while (minuti >= 0 && secondi >= 0)
            {
                if (secondi <= 0)
                {
                    minuti--;
                    secondi = 59;
                }
                else
                    secondi--;

                Console.Clear();
                origRow = Console.CursorTop;
                origCol = Console.CursorLeft;
                timer(minuti.ToString(), secondi.ToString());
                Thread.Sleep(1000);
            }
            Console.CursorVisible = true;
            Console.Beep(3000, 2000);
            Console.WriteLine("Premere un tasto per chiudere il programma");
            Console.ReadKey();
        }

        static void timer(string minuti, string secondi)
        {
            int cifra1, cifra2, cifra3, cifra4;
            if (int.Parse(secondi) <= 9)
                secondi = "0" + secondi;
            if (int.Parse(minuti) <= 9)
                minuti = "0" + minuti;
            cifra1 = int.Parse(minuti[0].ToString());
            cifra2 = int.Parse(minuti[1].ToString());
            cifra3 = int.Parse(secondi[0].ToString());
            cifra4 = int.Parse(secondi[1].ToString());

            numero(cifra1, 0);
            numero(cifra2, 12);
            segmento("■", 28, 5);
            segmento("■", 28, 8);
            numero(cifra3, 36);
            numero(cifra4, 48);
        }
        static void segmento(string carattere, int x, int y)
        {
            Console.SetCursorPosition(origCol + x, origRow + y);
            Console.Write(carattere);
        }

        static void numero(int cifra, int contatore)
        {
            int[][] numeri =
                {
                new int[] {1,1,1,1,1,1,0},
                new int[] {0,1,1,0,0,0,0},
                new int[] {1,1,0,1,1,0,1},
                new int[] {1,1,1,1,0,0,1},
                new int[] {0,1,1,0,0,1,1},
                new int[] {1,0,1,1,0,1,1},
                new int[] {1,0,1,1,1,1,1},
                new int[] {1,1,1,0,0,0,0},
                new int[] {1,1,1,1,1,1,1},
                new int[] {1,1,1,1,0,1,1}
            };
            //Segmento f
            if (numeri[cifra][5] == 1)
            {
                segmento("█", 0 + contatore, 1);
                segmento("█", 0 + contatore, 2);
                segmento("█", 0 + contatore, 3);
                segmento("█", 0 + contatore, 4);
                segmento("█", 0 + contatore, 5);
            }
            //Segmento E
            if (numeri[cifra][4] == 1)
            {
                segmento("█", 0 + contatore, 7);
                segmento("█", 0 + contatore, 8);
                segmento("█", 0 + contatore, 9);
                segmento("█", 0 + contatore, 10);
                segmento("█", 0 + contatore, 11);
            }
            //Segmento B
            if (numeri[cifra][1] == 1)
            {
                segmento("█", 7 + contatore, 1);
                segmento("█", 7 + contatore, 2);
                segmento("█", 7 + contatore, 3);
                segmento("█", 7 + contatore, 4);
                segmento("█", 7 + contatore, 5);
            }
            //Segmento C
            if (numeri[cifra][2] == 1)
            {
                segmento("█", 7 + contatore, 7);
                segmento("█", 7 + contatore, 8);
                segmento("█", 7 + contatore, 9);
                segmento("█", 7 + contatore, 10);
                segmento("█", 7 + contatore, 11);
            }
            //Segmento D
            if (numeri[cifra][3] == 1)
            {
                segmento("■", 1 + contatore, 12);
                segmento("■", 2 + contatore, 12);
                segmento("■", 3 + contatore, 12);
                segmento("■", 4 + contatore, 12);
                segmento("■", 5 + contatore, 12);
                segmento("■", 6 + contatore, 12);
            }
            //Segmento A
            if (numeri[cifra][0] == 1)
            {
                segmento("■", 1 + contatore, 0);
                segmento("■", 2 + contatore, 0);
                segmento("■", 3 + contatore, 0);
                segmento("■", 4 + contatore, 0);
                segmento("■", 5 + contatore, 0);
                segmento("■", 6 + contatore, 0);
            }
            //Segmento G
            if (numeri[cifra][6] == 1)
            {
                segmento("■", 1 + contatore, 6);
                segmento("■", 2 + contatore, 6);
                segmento("■", 3 + contatore, 6);
                segmento("■", 4 + contatore, 6);
                segmento("■", 5 + contatore, 6);
                segmento("■", 6 + contatore, 6);
            }
        }
    }
}
