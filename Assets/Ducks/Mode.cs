namespace Com.Larkintuckerllc.Bounce
{
    public class Mode : Singleton<Mode>
    {
        public enum ModeEnum { Positioning, Scaling, Meshing };

        public static ModeEnum InitialState = ModeEnum.Positioning;

        public static ModeEnum Reducer(ModeEnum state, Action action)
        {
            switch (action.Type)
            {
                case Provider.Actions.MODE_SET:
                    return action.PayloadModeEnum;
                default:
                    return state;
            }
        }

        public static ModeEnum ModeGet(State state)
        {
            return state.Mode;
        }

        protected Mode() { }

        public Action ModeSet(ModeEnum mode)
        {
            return new Action(Provider.Actions.MODE_SET, mode);
        }
    }
}