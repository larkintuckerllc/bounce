using System;

namespace Com.Larkintuckerllc.Bounce
{
    public class Action
    {
        public Provider.Actions Type { get; private set; }

        public bool PayloadBool { get; private set; }

        public int PayloadInt { get; private set; }

        public Mode.ModeEnum PayloadModeEnum { get; private set; }

        public Triplet PayloadTriplet { get; private set; }

        public Action(Provider.Actions type)
        {
            this.Type = type;
        }

        public Action(Provider.Actions type, bool payload)
        {
            this.Type = type;
            this.PayloadBool = payload;
        }

        public Action(Provider.Actions type, int payload)
        {
            this.Type = type;
            this.PayloadInt = payload;
        }

        public Action(Provider.Actions type, Mode.ModeEnum payload)
        {
            this.Type = type;
            this.PayloadModeEnum = payload;
        }

        public Action(Provider.Actions type, Triplet payload)
        {
            this.Type = type;
            this.PayloadTriplet = payload;
        }

        public Action(Action<Action<Action>> function)
        {
            this.Type = Provider.Actions.THUNK;
            function(Provider.Dispatch);
        }

        public Action(Action<Action<Action>, Func<State>> function)
        {
            this.Type = Provider.Actions.THUNK;
            function(Provider.Dispatch, Provider.GetState);
        }

    }
}