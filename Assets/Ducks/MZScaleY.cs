namespace Com.Larkintuckerllc.Bounce
{
    public class MZScaleZ : Singleton<MZScaleZ>
    {
        public static int InitialState = 100;

        public static int Reducer(int state, Action action)
        {
            switch (action.Type)
            {
                case Provider.Actions.MZ_SCALE_Z_SET:
                    return action.PayloadInt;
                default:
                    return state;
            }
        }

        public static int MZScaleZGet(State state)
        {
            return state.MZScaleZ;
        }

        protected MZScaleZ() { }

        public Action MZScaleZSet(int mZScaleZ)
        {
            return new Action(Provider.Actions.MZ_SCALE_Z_SET, mZScaleZ);
        }
    }
}
