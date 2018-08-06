namespace Com.Larkintuckerllc.Bounce
{
    public class MZScaleX : Singleton<MZScaleX>
    {
        public static int InitialState = 100;

        public static int Reducer(int state, Action action)
        {
            switch (action.Type)
            {
                case Provider.Actions.MZ_SCALE_X_SET:
                    return action.PayloadInt;
                default:
                    return state;
            }
        }

        public static int MZScaleXGet(State state)
        {
            return state.MZScaleX;
        }

        protected MZScaleX() { }

        public Action MZScaleXSet(int mZScaleX)
        {
            return new Action(Provider.Actions.MZ_SCALE_X_SET, mZScaleX);
        }
    }
}
