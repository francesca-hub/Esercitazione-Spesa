using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_week1_Francesca_Dicugno
{
   public class OperationalManHandler:AbstractHandler
    {
        public override string Handle(Spesa request)
        {
            if (request.Importo >= 401 && request.Importo <= 1000)
            {
                return $"La spesa è stata approvata dall'operational manager";
                
            }
            else
                return base.Handle(request);
        }
    }
}
