namespace Com.Larkintuckerllc.Bounce
{
    public class TouchY : Singleton<TouchY>
    {
        public static int InitialState = 0;

        public static int Reducer(int state, Action action)
        {
            switch (action.Type)
            {
                case Provider.Actions.TOUCH_Y_SET:
                    return action.PayloadInt;
                default:
                    return state;
            }
        }

        public static int TouchYGet(State state)
        {
            return state.TouchY;
        }

        protected TouchY() { }

        public Action TouchYSet(int touchY)
        {
            return new Action(Provider.Actions.TOUCH_Y_SET, touchY);
        }
    }
}
