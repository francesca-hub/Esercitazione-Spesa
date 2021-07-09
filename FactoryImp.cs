using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_week1_Francesca_Dicugno
{
   public class FactoryImp
    {
        public static ImportoRimborsato GetImporto(Categoria categoria)
        {
            ImportoRimborsato rimborso = null;

            switch (categoria)
            {
                case (Categoria)0:
                    rimborso = new ImportoViaggio();
                    break;
                case (Categoria)1:
                    rimborso = new ImportoAlloggio();
                    break;
                case (Categoria)2:
                    rimborso = new ImportoVitto();
                    break;
                case (Categoria)3:
                    rimborso = new ImportoAltro();
                    break;
                default:
                    Console.WriteLine("Categoria inesistente");
                    break;
            }

            return rimborso;
        }
    }

    internal class ImportoAltro : ImportoRimborsato
    {
        public decimal CalcolaImportoRimborsato(Spesa spesa)
        {
           return ( spesa.Importo*10)/ 100;
        }
    }

    internal class ImportoVitto : ImportoRimborsato
    {
        public decimal CalcolaImportoRimborsato(Spesa spesa)
        {
            return (spesa.Importo * 70) / 100;
        }
    }

    internal class ImportoAlloggio : ImportoRimborsato
    {
        public decimal CalcolaImportoRimborsato(Spesa spesa)
        {
           return spesa.Importo;
        }
    }

    internal class ImportoViaggio : ImportoRimborsato
    {
        public decimal CalcolaImportoRimborsato(Spesa spesa)
        {
            return spesa.Importo + 50;
        }
    }
}
    
