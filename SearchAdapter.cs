using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Vertix
{
    class SearchAdapter : CursorAdapter
    {
        Context context;

        public SearchAdapter(Activity context, ICursor cursor) 
            : base(context, cursor) 
        {
            this.context = context;
        }

        public override void BindView(View view, Context context, ICursor cursor)
        {
            //View v = view.FindViewById<>();
            //v.text = "";
        }

        public override View NewView(Context context, ICursor cursor, ViewGroup parent)
        {
            return LayoutInflater.FromContext(context).Inflate(Resource.Layout.list_item, parent, false);
        }
    }
}