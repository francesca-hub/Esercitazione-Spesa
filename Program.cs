using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Esercitazione_week1_Francesca_Dicugno
{
    class Program
    {
        public static List<Spesa> spesa = new List<Spesa>();
        public static IEnumerable<Spesa> spesaApprovata;
        public static IEnumerable<Spesa> spesaNonApprovata;
        static void Main(string[] args)
        {
            Console.WriteLine("------------ESERCITAZIONE----------");
 

            #region File watcher

            FileSystemWatcher fsw = new();

            fsw.Path = @"C:\Temp\watch";
            fsw.Filter = "*.txt";
            fsw.NotifyFilter = NotifyFilters.LastWrite
                | NotifyFilters.LastAccess
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;
            fsw.EnableRaisingEvents = true;

            fsw.Created += Fsw_Created;


            Console.WriteLine("Premi '0' per uscire");
            while (Console.Read() != '0') ;

            #endregion


            #region Chain
            var manager = new ManagerHandler();
            var operationalMan = new OperationalManHandler();
            var ceo = new CeoHandler();

            manager.SetNext(operationalMan).SetNext(operationalMan).SetNext(ceo);
            
                
                foreach (var item in spesa)
                {
                Console.WriteLine($"{item.DettaglioSpesa()}");
                    Console.WriteLine("Chi approva la spesa?");

                    var result = manager.Handle(item);

                if (result != null)
                {
                    Console.WriteLine($"Livello di approvazione: {result}");
                    item.Livello = result;
                    item.Approvata = true;
                }
                else
                {
                    Console.WriteLine($"Spesa non approvata!");
                    item.Livello = null;
                    item.Approvata = false;
                }
                #endregion
            }
            #region Factory

            spesaApprovata = spesa.Where(item => item.Approvata == true);
            spesaNonApprovata = spesa.Where(item => item.Approvata == false);
            foreach (var item in spesaApprovata)
            {
                Categoria categoria = item.Categoria;
                ImportoRimborsato tipoRimborso;

                tipoRimborso = FactoryImp.GetImporto(categoria);

                item.ImportoRimborsato = tipoRimborso.CalcolaImportoRimborsato(item);

                
            }



            #endregion

            #region SaveFile

            try
            {
                if (!Directory.Exists(@"C:\Temp\watch"))
                {
                    Directory.CreateDirectory(@"C:\Temp\watch");
                }

                StreamWriter writer = File.CreateText(@"C:\Temp\watch\spese_elaborate.txt");

                foreach (var item in spesaApprovata)
                {
                    writer.WriteLine(item.DettaglioApprovazione());
                }
                foreach (var item in spesaNonApprovata)
                {
                    writer.WriteLine(item.DettaglioApprovazione());
                }
                writer.Flush();
                writer.Close();
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($" I/O Error: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Errore Generico: {ex.Message}");
            }
            #endregion

         
            }




        private static void Fsw_Created(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine($"=== New File Created: {e.Name} ===");

                var reader = File.OpenText(e.FullPath);
                Spesa spesa1 = new();
                string line = spesa1.DettaglioSpesa();
                while ((line = reader.ReadLine()) != null)
                    Console.WriteLine(line);
                Console.WriteLine("==== End of Content ===");
            }
        }
    }
