using SensoriAttuatori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControlloTemperatura
{
    class Program
    {
        static void Main(string[] args)
        {
            bool chiusuraConsole = false;
            int i = 0;
            DevInterface interfac = new DevInterface();
            avvio(interfac);
            do
            {
                //interfac.Xcmd = Console.ReadLine();
                if (interfac.Xcmd.Equals("S"))
                {
                    pulsanteS(interfac);
                }
                if (interfac.Xcmd.Equals("F"))
                {
                    break;
                }
                if (interfac.Xcmd.Equals("V"))
                {
                    pulsanteV(interfac);
                }
                i++;
                System.Threading.Thread.Sleep(1000);
            } while (i > 0);


            /* interfac.Xcmd = "s";    // Istanziamo la variabile Xcmd 
            
            interfac.AttivaMotore();
            interfac.AttivaRefrigeratore();
            int i = 0;
            bool ventolaAttiva = false;
            do {
                Console.WriteLine("Temperatura motore " + interfac.DammiTemperaturaMotore());
                Console.WriteLine("Temperatura refrigeratore " + interfac.DammiTemperaturaRefrigeratore());
                i++;
                if (interfac.DammiTemperaturaMotore() > 80.00)
                {
                    if (ventolaAttiva == false)
                    {
                        interfac.AttivaVentolaPerMotore();
                        ventolaAttiva = true;
                    }
                }
                else {
                       interfac.DisattivaVentolaPerMotore();
                       ventolaAttiva = false;
                     }
              
                System.Threading.Thread.Sleep(1000);
            } while (i>0);
            //interfac.StopMotore();*/
        }

        private static void pulsanteV(DevInterface interfac)
        {

            Console.WriteLine("Temperatura corrente del Motore " + interfac.DammiTemperaturaMotore());
            Console.WriteLine("Temperatura corrente del Refrigeratore " + interfac.DammiTemperaturaMotore());
            if ()
            {
                Console.WriteLine("Lo stato è ATTIVO!");
                Console.WriteLine("Il refrigeratore è attivo!");
            }
            else
            {
                Console.WriteLine("Il refrigeratore è spento!");
            }
            if ( == true)
            {
                Console.WriteLine("Il motore è attivo!");
            }
            else
            {
                Console.WriteLine("Il motore è spento!");
            }
        }

        private static void pulsanteS(DevInterface interfac)
        {
            //bool attivaRefrigeratore = false;
            //if (attivaRefrigeratore == false){


                interfac.AttivaRefrigeratore();
                controlloTemperaturaRefrigeratore(interfac);


            // attivaRefrigeratore = true;}      
            //return controlloTemperaturaRefrigeratore(interfac);
        }

        private static bool controlloTemperaturaRefrigeratore(DevInterface interfac)
        {
            bool nelRange=interfac.DammiTemperaturaRefrigeratore()=(-25.25) && interfac.DammiTemperaturaRefrigeratore() >= (-23.25);
            if (nelRange)
            {
                interfac.AttivaMotore();
                nelRange = true;
            }
            else
            {
                nelRange = false;
            }
            if(interfac.DammiTemperaturaRefrigeratore() > (-25.25))
            {
                interfac.SpegniRefrigeratore();
                nelRange = false;
            }

            return nelRange;
        }
        /*
        private static void AvvioMotore(DevInterface interfac)
        {
            
            if (controlloTemperaturaRefrigeratore(interfac)==false)
            {
                interfac.AttivaMotore();
                //bool attivaMotore = true;
            }
            
            //return attivaMotore;
        }
        */
        public static void avvio(DevInterface interfac)
        {
            interfac.Init();
        }
    }
}
