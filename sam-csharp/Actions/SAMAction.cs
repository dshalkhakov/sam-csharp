using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sam_csharp.Models;

namespace sam_csharp.Actions
{
    public abstract class SAMAction
    {
        public abstract bool Enabled(Models.Model model);
        public abstract Proposal Propose(Models.Model model);
    }

    public static class Actions
    {
        public static SAMAction Lookup = new LookupAction();
        public static SAMAction Incr = new IncrAction();
        public static SAMAction Decr = new DecrAction();
        public static SAMAction Reset = new ResetAction();
    }

    public class IncrAction : SAMAction
    {
        public override bool Enabled(Models.Model model)
        {
            return true; // increase is always OK
        }

        public override Proposal Propose(Models.Model model)
        {
            return new Proposals.NewCounterProposal(model.Counter + 1);
        }
    }

    public class DecrAction : SAMAction
    {
        public override bool Enabled(Models.Model model)
        {
            return model.Counter > 0;
        }

        public override Proposal Propose(Models.Model model)
        {
            return new Proposals.NewCounterProposal(model.Counter - 1);
        }
    }

    public class ResetAction : SAMAction
    {
        public override bool Enabled(Models.Model model)
        {
            return true;    // reset is always OK
        }

        public override Proposal Propose(Models.Model model)
        {
            return new Proposals.NewCounterProposal(0);
        }
    }

    public class LookupAction : SAMAction
    {
        public override bool Enabled(Model model)
        {
            return true;
        }

        public override Proposal Propose(Model model)
        {
            return new Proposals.NewRefData() { Key = 1 };
        }
    }
}
