using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_csharp.Proposals
{
    public class NewCounterProposal : Proposal
    {
        public NewCounterProposal(int counter)
        {
            Counter = counter;
        }

        public int Counter { get; private set; }
    }
}
