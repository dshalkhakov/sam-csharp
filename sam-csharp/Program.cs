using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_csharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var loop = new Loop(new States.ReadyState(), new Presenters.MyPresenter());
            loop.DoLoop();
        }
    }
}
