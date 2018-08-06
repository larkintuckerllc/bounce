namespace Com.Larkintuckerllc.Bounce
{
    public class MZPositionX : Singleton<MZPositionX>
    {
        public static int InitialState = 0;

        public static int Reducer(int state, Action action)
        {
            switch (action.Type)
            {
                case Provider.Actions.MZ_POSITION_X_SET:
                    return action.PayloadInt;
                default:
                    return state;
            }
        }

        public static int MZPositionXGet(State state)
        {
            return state.MZPositionX;
        }

        protected MZPositionX() { }

        public Action MZPositionXSet(int mZPositionX)
        {
            return new Action(Provider.Actions.MZ_POSITION_X_SET, mZPositionX);
        }
    }
}
