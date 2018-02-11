using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_csharp.States
{
    public class ReadyState : State
    {
        public override bool Current(Models.Model model)
        {
            return true;
        }

        public override Actions.SAMAction Nap(Models.Model model)
        {
            return null;
        }

        public override StateRepr Render(Models.Model model)
        {
            return new StateRepr() { RefData = model.RefData, Count = model.Counter.ToString() };
        }
    }
}
