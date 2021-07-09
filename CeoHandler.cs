using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_week1_Francesca_Dicugno
{
  public  class CeoHandler:AbstractHandler
    {
        public override string Handle(Spesa request)
        {
            if (request.Importo > 1000 && request.Importo <= 2500)
            {
                return $"La spesa è stata approvata dal CEO";
            }
            else
                return base.Handle(request);
        }
    }
}
