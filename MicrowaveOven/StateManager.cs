using System;
using System.Collections.Generic;

namespace MicrowaveOven
{
    public class StateManager: Dictionary<MicrowaveTrigger, Action>
    {
        public void Register(MicrowaveTrigger microwaveTrigger, Action unitAction)
        {
            this[microwaveTrigger] += unitAction;
        }

        public void ExecuteAction(MicrowaveTrigger microwaveTrigger)
        {
            this[microwaveTrigger]?.Invoke();
        }

    }
}
