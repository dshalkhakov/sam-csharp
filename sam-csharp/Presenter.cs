using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_csharp
{
    public abstract class Presenter<M>
        where M : class
    {
        public abstract void Present(M model, Proposal proposal);
    }
}
