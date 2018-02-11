using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_csharp
{
    /// type of(control) state:
    /// - whether the model is in this state
    /// - next-action computation (if any)
    /// - and rendering function
    /// next-action is meant for computing "automatic actions" (say happenning in response to user actions, periodically, etc.)
    public abstract class State
    {
        public abstract bool Current(Models.Model model);
        public abstract Actions.SAMAction Nap(Models.Model model);
        public abstract States.StateRepr Render(Models.Model model);
    }
}
