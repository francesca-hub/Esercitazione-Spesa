using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_week1_Francesca_Dicugno
{
    public abstract class AbstractHandler: IHandler
    {
        private IHandler _nextHandler;

        public virtual string Handle(Spesa request)
        {
            if (_nextHandler != null)
                return _nextHandler.Handle(request);
            else
                return null;
        }

        public void LoadFromFile(Spesa spesa)
        {
            throw new NotImplementedException();
        }

        public void SaveFile(Spesa spesa)
        {
            throw new NotImplementedException();
        }

        public IHandler SetNext(IHandler next)
        {
            _nextHandler = next;

            return next;
        }
    }

    public interface IHandler
    {
        IHandler SetNext(IHandler next);

        string Handle(Spesa request);

    }
}



