using System;
using System.Collections.Generic;

namespace StateMachine
{
    public static class StateData
    {
        private static Dictionary<string, Object> Store = new Dictionary<string, object>();

        public static void Add(string key, Object value)
        {
            Store[key] = value;
        }

        public static Object Get(string key)
        {
            Object value;
            Store.TryGetValue(key, out value);

            return value;
        }
    }
}
