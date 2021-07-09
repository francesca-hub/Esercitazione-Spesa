using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_week1_Francesca_Dicugno
{
    public class ManagerHandler : AbstractHandler
    {
        public override string Handle(Spesa request)
        {
            if (request.Importo <= 400)
            {
                return $"La spesa è stata approvata dal manager";

            }
            else
                return base.Handle(request);
        }


    }
}