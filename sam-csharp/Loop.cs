using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sam_csharp
{
    public class Loop
    {
        private readonly States.ReadyState _readyState;
        private readonly Presenters.MyPresenter _presenter;

        public Loop(States.ReadyState readyState, Presenters.MyPresenter presenter)
        {
            _readyState = readyState;
            _presenter = presenter;
        }

        /// <summary>
        /// Rendering:
        /// - all that is necessary for rendering should already have been computed in [render]
        /// - in a web page, we might simply use a templating engine to turn this into HTML
        /// - in a winforms app, the form could handle the representation
        /// </summary>
        /// <param name="model"></param>
        public void Display(Models.Model model)
        {
            if (_readyState.Current(model))
            {
                var repr = _readyState.Render(model);
                System.Console.WriteLine("counter: {0}", repr.Count);
                var nextAction = _readyState.Nap(model);
                if (nextAction != null)
                {
                    var proposal = nextAction.Propose(model);
                    _presenter.Present(model, proposal);
                    Display(model);
                }
            }
            else
                System.Console.WriteLine("Unreachable control state detected!");
        }

        public void DoLoop()
        {
            System.Console.WriteLine("Enter: I to increase, D to decrease, R to reset, or anything else to exit");
            var model = new Models.Model() { Counter = 0 }; // initial state of the model

            while (true)
            {
                var input = System.Console.ReadLine();
                if (input == "I")
                {
                    if (Actions.Actions.Incr.Enabled(model))
                    {
                        _presenter.Present(model, Actions.Actions.Incr.Propose(model));
                    }
                }
                else if (input == "D")
                {
                    if (Actions.Actions.Decr.Enabled(model))
                    {
                        _presenter.Present(model, Actions.Actions.Decr.Propose(model));
                    }
                }
                else if (input == "R")
                {
                    if (Actions.Actions.Reset.Enabled(model))
                    {
                        _presenter.Present(model, Actions.Actions.Reset.Propose(model));
                    }
                }
                else if (input == "K")
                {
                    if (Actions.Actions.Lookup.Enabled(model))
                    {
                        _presenter.Present(model, Actions.Actions.Lookup.Propose(model));
                    }
                }
                else
                {
                    // stop
                    break;
                }
                Display(model);
            }
        }
    }
}
