namespace Com.Larkintuckerllc.Bounce
{
    public class TouchX : Singleton<TouchX>
    {
        public static int InitialState = 0;

        public static int Reducer(int state, Action action)
        {
            switch (action.Type)
            {
                case Provider.Actions.TOUCH_X_SET:
                    return action.PayloadInt;
                default:
                    return state;
            }
        }

        public static int TouchXGet(State state)
        {
            return state.TouchX;
        }

        protected TouchX() { }

        public Action TouchXSet(int touchX)
        {
            return new Action(Provider.Actions.TOUCH_X_SET, touchX);
        }
    }
}