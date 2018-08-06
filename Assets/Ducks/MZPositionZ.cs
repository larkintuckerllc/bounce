namespace Com.Larkintuckerllc.Bounce
{
    public class MZPositionZ : Singleton<MZPositionZ>
    {
        public static int InitialState = 0;

        public static int Reducer(int state, Action action)
        {
            switch (action.Type)
            {
                case Provider.Actions.MZ_POSITION_Z_SET:
                    return action.PayloadInt;
                default:
                    return state;
            }
        }

        public static int MZPositionZGet(State state)
        {
            return state.MZPositionZ;
        }

        protected MZPositionZ() { }

        public Action MZPositionZSet(int mZPositionZ)
        {
            return new Action(Provider.Actions.MZ_POSITION_Z_SET, mZPositionZ);
        }
    }
}
