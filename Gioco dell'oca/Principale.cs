using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region crediti
//Realizzato da AlessioPerugini se ci sono altri programmi che iniziano con: #region crediti, significa che c'è qualche pirla che non sa copiare :-)
#endregion
namespace Gioco_dell_oca
{
    class Principale
    {
        static String[] Tabellone = new String[90];
        static int Pos1, Pos2, Pos3;
        static String Player1, Player2, Player3, Colore="";
        static bool Fermo1, Fermo2, Fermo3, AutoPlay, Togli_Round_Precedenti;

        static void Main(string[] args)
        {
            Console.Title = "Gioco dell'oca creato da Alessio Perugini";
            Menu();
        }

        static void Menu()
        {
            bool Creato = false;
            bool Show_Error = false;//Serve per non dover ripremere un'altro pulsante nel caso non si verifica l'errore altrimenti bisogna premere la scelta e un'altro pulsante prima di andare nel metodo selezionato
            Char scelta = ' ';

            while (scelta != 'Q')
            {
                Console.WriteLine("A - Crea il tabellone");
                Console.WriteLine("B - Inserisci i giocatori");
                Console.WriteLine("C - Simula una partita");
                Console.WriteLine("D - Gioca");
                Console.Write("Scelta: ");
                try
                {
                    scelta = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
                }
                catch(Exception eccezione)
                {
                    Console.WriteLine("Errore: " + eccezione);
                    Show_Error = true;
                }
                finally
                {
                    if (Show_Error)//mostra l'errore fino a quando non preme un pulsante e ripulisce la console
                    {
                        Show_Error = false; //resetto la variaibile sennò se uno sbaglia una volta siamo da capo a 12 :D
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                switch (scelta)
                {
                    #region case A
                    case 'A':
                        Console.Clear();
                        Metodi.Crea_Tabellone(Tabellone); //Crea tabellone
                        Creato = true;
                        Console.WriteLine("Tabellone creato con successo!!!");
                        
                        Console.Write("Premere un tasto per continuare...");
                        Console.ReadKey();
                        Console.Clear();
                        scelta = ' ';//Altrimenti se un utente preme invio dopo il mex d'errore rientra in A o alla lettera precedente
                        break;
                    #endregion
                    #region case B
                    case 'B':
                        Console.Clear();
                        //Inserisce i 3 giocatori
                        Console.ForegroundColor = ConsoleColor.Green;
                        Metodi.Ins_Giocatore(ref Player1, ref Pos1);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Metodi.Ins_Giocatore(ref Player2, ref Pos2);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Metodi.Ins_Giocatore(ref Player3, ref Pos3);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Clear();
                        scelta = ' ';
                        break;
                    #endregion
                    #region case C
                    case 'C':
                        Console.Clear();
                        AutoPlay = true;
                        Pos1 = 0; Pos2 = 0; Pos3 = 0; //Azzera le posizioni se si vuole rigiocare con i stessi giocatori
                        
                        if (Creato)
                        {
                            while ((Pos1 < 90) && (Pos2 < 90) && (Pos3 < 90)) //Esce dal ciclo quando 1 dei 3 player arriva a 90
                            {
                                if (!Fermo1) //Se non ha preso la trappola
                                {
                                    Colore = "Green";
                                    Metodi.Dado(ref Player1, ref Pos1, ref AutoPlay, ref Togli_Round_Precedenti, ref Colore); //Tira i dadi e esce il risultato
                                    Metodi.Controllo(Tabellone, ref Player1, ref Pos1, ref Fermo1, ref AutoPlay, ref Colore); //Controlla le trappole e se ha vinto
                                }
                                else
                                {
                                    Fermo1 = false;//Riabilita il gioco dopo 1 turno che sta fermo
                                }
                                if (Pos1 < 90)//Se la pos1 < 90 procede con il gioco altrimenti si ferma perchè il 1o giocatore ha vinto
                                {
                                    if (!Fermo2) //Se non ha preso la trappola
                                    {
                                        Colore = "Magenta";
                                        Metodi.Dado(ref Player2, ref Pos2, ref AutoPlay, ref Togli_Round_Precedenti, ref Colore); //Tira i dadi e esce il risultato
                                        Metodi.Controllo(Tabellone, ref Player2, ref Pos2, ref Fermo2, ref AutoPlay, ref Colore); //Controlla le trappole e se ha vinto
                                    }
                                    else
                                    {
                                        Fermo2 = false;//Riabilita il gioco dopo 1 turno che sta fermo
                                    }
                                    if (Pos2 < 90)//Se la pos2 < 90 procede con il gioco altrimenti si ferma perchè il 2o giocatore ha vinto
                                    {
                                        if (!Fermo3) //Se non ha preso la trappola
                                        {
                                            Colore = "Cyan";
                                            Metodi.Dado(ref Player3, ref Pos3, ref AutoPlay, ref Togli_Round_Precedenti, ref Colore); //Tira i dadi e esce il risultato
                                            Metodi.Controllo(Tabellone, ref Player3, ref Pos3, ref Fermo3, ref AutoPlay, ref Colore); //Controlla le trappole e se ha vinto
                                        }
                                        else
                                        {
                                            Fermo3 = false;//Riabilita il gioco dopo 1 turno che sta fermo
                                        }//FIne !Fermo3
                                    }//FIne pos2<90
                                }//Fine pos1<90
                            }//Fine While (Pos1 < 90) && (Pos2 < 90) && (Pos3 < 90)
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Per avviare una simulazione devi prima creare il tabellone!!!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("Premi un tasto per continuare...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        scelta = ' ';
                        Togli_Round_Precedenti = true;
                        Colore = "";
                        break;
                    #endregion
                    #region case D
                    case 'D':
                        Console.Clear();
                        Pos1 = 0; Pos2 = 0; Pos3 = 0; int Round = 0; //Azzera le posizioni se si vuole rigiocare con i stessi giocatori e il round
                        String cronologia = "";
                        Togli_Round_Precedenti = false;
                        Char scelta2 = 'A';
                        if(Creato)//Controlla se ha creato il tabellone
                        {
                            while ((Pos1 < 90) && (Pos2 < 90) && (Pos3 < 90) && (scelta2=='A')) //Esce dal ciclo quando 1 dei 3 player arriva a 90
                            {
                                if (!Fermo1) //Se non ha preso la trappola
                                {
                                    Colore = "Green";
                                    scelta2 = Scelta(Tabellone, ref Player1, ref Pos1, ref Fermo1, ref AutoPlay);
                                }
                                else
                                {
                                    Fermo1 = false;//Riabilita il gioco dopo 1 turno che sta fermo
                                }
                                if ((Pos1 < 90) && (scelta2=='A'))//Se la pos1 < 90 procede con il gioco altrimenti si ferma perchè il 1o giocatore ha vinto
                                {
                                    if (!Fermo2) //Se non ha preso la trappola
                                    {
                                        Colore = "Magenta";
                                        scelta2 = Scelta(Tabellone, ref Player2, ref Pos2, ref Fermo2, ref AutoPlay);
                                    }
                                    else
                                    {
                                        Fermo2 = false;//Riabilita il gioco dopo 1 turno che sta fermo
                                    }
                                    if ((Pos2 < 90) && (scelta2=='A'))//Se la pos2 < 90 procede con il gioco altrimenti si ferma perchè il 2o giocatore ha vinto
                                    {
                                        if (!Fermo3) //Se non ha preso la trappola
                                        {
                                            Colore = "Cyan";
                                            scelta2 = Scelta(Tabellone, ref Player3, ref Pos3, ref Fermo3, ref AutoPlay);
                                        }
                                        else
                                        {
                                            Fermo3 = false;//Riabilita il gioco dopo 1 turno che sta fermo
                                        }//FIne !Fermo3
                                    }//FIne pos2<90
                                }//Fine pos1<90
                                Round++;
                                if((scelta2!='Q')&&(Pos1<90)&&(Pos2<90)&&(Pos3<90))
                                {
                                    Console.WriteLine("Round" + Round + ":");
                                    Console.WriteLine(cronologia = Metodi.Cronologia_Round());
                                    Console.Write("Premi un tasto per continuare");
                                    Togli_Round_Precedenti = true;
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }//Fine While (Pos1 < 90) && (Pos2 < 90) && (Pos3 < 90)
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Prima di giocare devi creare il tabellone!!!");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("Premi un tasto per continuare...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        scelta = ' ';
                        break;                        
                    #endregion
                }//Fine scelta
            }//Fine While
        }//Fine menù

        static Char Scelta(String[] _Tabellone, ref String _Player, ref int _Pos, ref bool _Fermo, ref bool AutoPlay)
        {
            bool Show_Error = false;
            Char scelta2 = ' ';
            while ((scelta2 != 'Q') && (scelta2 != 'A'))
            {
                Console.WriteLine("Ora è il turno di: " + _Player);
                Console.WriteLine("A - Per tirare il dado");
                Console.WriteLine("Q - Per uscire dal gioco");
                Console.Write("Scelta: ");
                try
                {
                    scelta2 = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
                }
                catch (Exception eccezione)
                {
                    Console.WriteLine("Errore: " + eccezione);
                    Show_Error = true;
                }
                finally
                {
                    if (Show_Error)//mostra l'errore fino a quando non preme un pulsante e ripulisce la console
                    {
                        Show_Error = false; //resetto la variaibile sennò se uno sbaglia una volta siamo da capo a 12 :D
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else//Se non mostra il messaggio di errore ma la scelta non è ne A ne B gli fa apparire un messagio che lo avverte
                    { //di inserire una scelta valida.
                        #region Scelta_A_Q
                        if (scelta2 == 'A')
                        {
                            Console.Clear();
                            Metodi.Dado(ref _Player, ref _Pos, ref AutoPlay, ref Togli_Round_Precedenti, ref Colore); //Tira i dadi e esce il risultato
                            Metodi.Controllo(Tabellone, ref _Player, ref _Pos, ref _Fermo, ref AutoPlay, ref Colore); //Controlla le trappole e se ha vinto
                            Console.WriteLine("");
                            Console.Write("Premere invio per continaure...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (scelta2 == 'Q')
                        {

                        }
                        else//Serve per ripulire la console se la scelta è di 1 carattere ma non è A o Q
                        {
                            Console.Write("\"" + scelta2 + "\"" + " non è una scelta valida reinserisci la scelta giusta");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        #endregion
                    }                      
                }                
            }//FIne WHILE
            return scelta2;
        }//Fine scelta
    }//Fine Principale.cs
}//End namespace GiocoDellOca