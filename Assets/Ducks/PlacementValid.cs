namespace Com.Larkintuckerllc.Bounce
{
    public class PlacementValid : Singleton<PlacementValid>
    {
        public static bool InitialState = false;

        public static bool Reducer(bool state, Action action)
        {
            switch (action.Type)
            {
                case Provider.Actions.PLACEMENT_VALID_SET:
                    return action.PayloadBool;
                default:
                    return state;
            }
        }

        public static bool PlacementValidGet(State state)
        {
            return state.PlacementValid;
        }

        protected PlacementValid() { }

        public Action PlacementValidSet(bool placementValid)
        {
            return new Action(Provider.Actions.PLACEMENT_VALID_SET, placementValid);
        }
    }
}
