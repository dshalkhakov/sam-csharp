using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_csharp.Presenters
{
    public class MyPresenter : Presenter<Models.Model>
    {
        public override void Present(Models.Model model, Proposal proposal)
        {
            if (proposal is Proposals.NewCounterProposal)
            {
                var p = (Proposals.NewCounterProposal)proposal;
                model.Counter = p.Counter;
            }
            else if (proposal is Proposals.NewRefData)
            {
                var p = (Proposals.NewRefData)proposal;
                model.RefKey = p.Key;
                model.RefData = p.Key.ToString();
            }
        }
    }
}
