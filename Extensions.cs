using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Vertix
{
    public class Dictionary<TKey, TValue> : System.Collections.Generic.Dictionary<TKey, TValue>
    {
        public Dictionary()
        {
        }

        //
        // Summary:
        //     Returns the key for the specified value.
        //
        // Parameters:
        //   value:
        //     The key of the element to find.
        //
        //   args:
        //     Dummy variable which can be set to any value. This variable will be returned if no match is found.
        public TKey GetKey(TValue value, TKey args)
        {
            TKey[] keys = new TKey[this.Count];
            this.Keys.CopyTo(keys, 0);
            TValue result;
            TKey key = args;

            foreach (TKey k in keys)
            {
                this.TryGetValue(k, out result);
                if (result.Equals(value))
                {
                    key = k;
                    break;
                }
            }

            return key;
        }
    }
}