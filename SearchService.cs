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
    [Service]
    class SearchService : Service
    {
        public static Java.Lang.Class JavaType { 
            get { 
                return Java.Lang.Class.FromType(typeof(SearchService)); 
            } 
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public string GetSuggestion(string partialQuery)
        {
            string[] projection = {
                //_ID,
                //partialQuery
            };

            return "";
        }

        public void GetResult(string query)
        {

        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            return base.OnStartCommand(intent, flags, startId);
        }

        public override IBinder OnBind(Intent intent)
        {
            // TODO: keep track of bound components here
            return new SearchServiceBinder(this);
        }

        public override bool OnUnbind(Intent intent)
        {
            return base.OnUnbind(intent);
        }

        public override void OnRebind(Intent intent)
        {
            base.OnRebind(intent);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}