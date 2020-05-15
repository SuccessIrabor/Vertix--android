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
using Android.Support.V7.App;

namespace Vertix
{
    [Activity(Label = "SearchActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    [MetaData("android.app.searchable", Resource = "@xml/searchable")]
    [IntentFilter(new[] {Intent.ActionSearch})]
    public class SearchActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            HandleIntent(Intent);
        }

        protected override void OnNewIntent(Intent intent)
        {
            HandleIntent(intent);
            base.OnNewIntent(intent);
        }

        private void HandleIntent(Intent intent)
        {
            if (Intent.ActionSearch.Equals(intent.Action))
            {
                string query = intent.Extras.GetString(SearchManager.Query);
            }
        }
    }
}