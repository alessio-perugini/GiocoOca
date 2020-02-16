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
    
    class Metodi
    {
        static String cronologia="";
        static Random objRandom = new Random();

        public static void Crea_Tabellone(String[] _Tabellone)
        {
            int j=0, i, N=90;

            for(i = 0; i < N; i++) //Ripulisce il tabellone
            {
                _Tabellone[i] = "";
            }

            j = objRandom.Next(90);

            while((j<=11)&&(j>=85))//Genera la trappola ritorna al via tra la 11 e la 85 casella
            {
                j = objRandom.Next(90);
            }

            _Tabellone[j] = "Ritorna al via";

            for (i = 0; i < 3; i++) //Genera la trappola stai fermo di 1 giro
            {
                j = objRandom.Next(90);
                while ((_Tabellone[j] != "") && (j>= 89) && (j==0))
                {
                    j = objRandom.Next(90);                   
                }
                _Tabellone[j] = "Fermo un giro";
            }//Fine For

            for (i = 0; i < 3; i++)//Genera 3 trappole vai avanti di 3
            {
                j = objRandom.Next(90);
                while ((_Tabellone[j] != "") && (j >= 89) && (j == 0))
                {
                    j = objRandom.Next(90);
                }
                _Tabellone[j] = "Avanti di 3";
            }//Fine For

            for (i = 0; i < 3; i++)//Genera 3 trappole vai indietro di 3 di 1 giro
            {
                j = objRandom.Next(90);
                while ((_Tabellone[j] != "") && (_Tabellone[j-3] == "Avanti di 3") && (j >= 89) && (j == 0))
                {
                    j = objRandom.Next(90);
                }
                _Tabellone[j] = "Indietro di 3";
            }//Fine For
        }//Fine Crea_Tabellone

        static public void Ins_Giocatore(ref String _Player, ref int _pos)
        {
            Console.Write("Inserisci il tuo nickname: ");
            _Player = Console.ReadLine();
            _pos = 0;
        }

        static public void Dado(ref String _Player, ref int _pos, ref bool _AutoPlay, ref bool _Togli_Round_Precedenti, ref String _Colore)
        {
            if(_AutoPlay)//Se c'è il gioco automatico mostra lo spazio sennò viene tutto attaccato
            {
                #region Mostra_risultato_Con_lo_spazio
                int Dado1, Dado2, Totale_Lancio;
                //Genera le random dei dadi
                Dado1 = objRandom.Next(6) + 1;
                Dado2 = objRandom.Next(6) + 1;
                //Somma il valore dei dadi e lo aggiunge alla posizione corrente
                Totale_Lancio = Dado1 + Dado2;
                _pos = _pos + Totale_Lancio;
                //In base al giocatore cambia il colore dell'output(è dichiarato in principale case 'D' prima di chiamare questa procedura
                #region Cambia_Colore_Output
                switch (_Colore)
                {
                    case "Green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "Magenta":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "Cyan":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                }
                #endregion
                //Mostra il valore dei dadi
                Console.WriteLine(_Player + " ha ottenuto: " + Dado1 + " con il primo dado");
                Console.WriteLine(_Player + " ha ottenuto: " + Dado2 + " con il secondo dado");
                Console.WriteLine(_Player + " avanza di " + Totale_Lancio + " caselle e raggiunge la casella " + _pos);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Gray;
                #endregion
            }
            else//Altrimenti mostra senza lo spazio
            {
                #region Mostra_risultato_senza_spazio
                int Dado1, Dado2, Totale_Lancio;
                //Genera le random dei dadi
                Dado1 = objRandom.Next(6) + 1;
                Dado2 = objRandom.Next(6) + 1;
                //Somma il valore dei dadi e lo aggiunge alla posizione corrente
                Totale_Lancio = Dado1 + Dado2;
                _pos = _pos + Totale_Lancio;
                //se il round è diverso dal primo allora svuota la cronologia precedente cos' mostra sempre l'ultimo round e non i precedenti
                if (_Togli_Round_Precedenti)
                {
                    cronologia = "";
                    _Togli_Round_Precedenti = false;
                }
                //In base al giocatore cambia il colore dell'output(è dichiarato in principale case 'D' prima di chiamare questa procedura
                #region Cambia_Colore_Output
                switch (_Colore)
                {
                    case "Green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "Magenta":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "Cyan":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                }
                #endregion
                //Mostra il valore dei dadi
                    Console.WriteLine(_Player + " ha ottenuto: " + Dado1 + " con il primo dado");
                    cronologia = cronologia + (_Player + " ha ottenuto: " + Dado1 + " con il primo dado" + "\n");
                    Console.WriteLine(_Player + " ha ottenuto: " + Dado2 + " con il secondo dado");
                    cronologia = cronologia + (_Player + " ha ottenuto: " + Dado2 + " con il secondo dado" + "\n");
                    Console.WriteLine(_Player + " avanza di " + Totale_Lancio + " casellee raggiunge la casella " + _pos);
                    cronologia = cronologia + (_Player + " avanza di " + Totale_Lancio + " casellee raggiunge la casella " + _pos + "\n");
                    cronologia = cronologia + ("\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                #endregion
            }
        
        }
        static public String Cronologia_Round()
        {
            return cronologia;
        }

        static public void Controllo(String[] _Tabellone, ref String _Player, ref int _Pos, ref bool _Fermo, ref bool _AutoPlay, ref String _Colore)
        {
            #region Cambia_Colore_Output
            switch (_Colore)
            {
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "Cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }
            #endregion
            if (_Pos < 90) //Se la posizione<90 allora controlla i trigger
            {
                if (_Tabellone[_Pos] == "Fermo un giro")
                {
                    Console.WriteLine(_Player + " trova una casella trappola e deve rimanere fermo 1 giro!");
                    cronologia = cronologia + (_Player + " trova una casella trappola e deve rimanere fermo 1 giro!" + "\n");
                    cronologia = cronologia + ("\n");
                    Console.WriteLine("");
                    _Fermo = true;
                }
                if (_Tabellone[_Pos] == "Ritorna al via")
                {
                    _Pos = 0;
                    Console.WriteLine(_Player + " trova una casella trappola e torna al via");
                    cronologia = cronologia + (_Player + " trova una casella trappola e torna al via" + "\n");
                    cronologia = cronologia + ("\n");
                    Console.WriteLine("");
                }
                if (_Tabellone[_Pos] == "Avanti di 3")
                {
                    _Pos = _Pos + 3;
                    Console.WriteLine(_Player + " trova un trigger e avanza di 3 caselle e dalla casella " + (_Pos - 3) + " arriva alla casella " + _Pos);
                    cronologia = cronologia + (_Player + " trova un trigger e avanza di 3 caselle e dalla casella " + (_Pos - 3) + " arriva alla casella " + _Pos + "\n");
                    cronologia = cronologia + ("\n");
                    Console.WriteLine("");
                }
                if (_Tabellone[_Pos] == "Indietro di 3")
                {
                    _Pos = _Pos - 3;
                    Console.WriteLine(_Player + " trova una casella trappola e torna indietro di 3 caselle e dalla casella " + (_Pos + 3) + " arriva alla casella " + _Pos);
                    cronologia = cronologia + (_Player + " trova una casella trappola e torna indietro di 3 caselle e dalla casella " + (_Pos + 3) + " arriva alla casella " + _Pos + "\n");
                    cronologia = cronologia + ("\n");
                    Console.WriteLine("");
                }
            }
            else //Se la posizione è >= 90 HA VINTOOOOOO :D
            {
                if (_AutoPlay) //Se c'è il gioco automatico non fa lampeggiare il vincitore sennò non si può vedere la cronologia della partita
                {
                    Console.WriteLine(_Player + " HA VINTO!!!!!!!!!!!!!!");
                    _AutoPlay = false;
                    Console.ReadKey();
                    Console.Clear();
                    cronologia = "";//Pulisco l'eventuale cronologia delle trappole
                }
                else
                {
                    Vincitore(ref _Player);
                    cronologia = "";
                }
            }//Fine if(_Pos < 90)
            Console.ForegroundColor = ConsoleColor.Gray;
        }//Fine Controllo

        public static void Vincitore(ref String _Player)
        {
            bool Lampeggio_infinito = false; //true=lampeggio infinito, false=si ferma dopo qualche secondo
            bool Ferma=false; //Serve per far completare 1 volta l'incremento e 1 il decremento poi ferma il lampeggio
            int _j = 0; int _i = 37;//Inizializzo e dichiaro i contatori la i è per il suono la j per l'effetto lampeggiante
            if (Lampeggio_infinito)
            {
                #region Lampeggio_infinito
                while ((_i <= 4767))//Cicla quando la _i<=4767
                    {
                        if (_i < 4637)
                        {
                            _i += 200;//Incrementa il suono
                        }
                        else
                        {
                            for (_i = _i; _i >= 237; _i -= 200)//Decrementa il suono
                            {
                                Lampeggia(ref _j, ref _Player);
                                Console.Beep(_i, 100);
                                Console.WriteLine(_i);
                            }
                        }
                        Lampeggia(ref _j, ref _Player);
                        Console.Beep(_i, 100);
                    }
                    #endregion
            }
            else
            {
                #region Lampeggio_non_infinito
                while ((_i <= 4767) && (!Ferma))//Cicla quando la _i<=4767
                    {
                        if (_i < 4637)
                        {
                            _i += 200;//Incrementa il suono
                        }
                        else
                        {
                            for (_i = _i; _i >= 237; _i -= 200)//Decrementa il suono
                            {
                                Lampeggia(ref _j, ref _Player);
                                Console.Beep(_i, 100);
                                Console.WriteLine(_i);
                            }
                            Ferma = true;
                        }
                        Lampeggia(ref _j, ref _Player);
                        Console.Beep(_i, 100);
                    }
                    #endregion
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Premere un tasto per continaure...");
            Console.ReadKey();
            Console.Clear();            
        }
        public static void Lampeggia(ref int _j, ref String _Player)
        {
            if (_j == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(_Player + " HA VINTO!!!!!!!!!!!!!!");
                _j--;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(_Player + " HA VINTO!!!!!!!!!!!!!!");
                _j++;
            }
        }
    }
}
