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
using Java.Security;

namespace Vertix
{
    [ContentProvider(new string[] { "com.Vertix.SearchSuggestProvider" }, Name = "com.Vertix.SearchSuggestProvider", Enabled = true, MultiProcess = true)]
    class SearchSuggestProvider : ContentProvider
    {
        public override int Delete(Android.Net.Uri uri, string selection, string[] selectionArgs)
        {
            throw new NotImplementedException();
        }

        public override string GetType(Android.Net.Uri uri)
        {
            return "text/plain";
        }

        public override Android.Net.Uri Insert(Android.Net.Uri uri, ContentValues values)
        {
            throw new NotImplementedException();
        }

        public override bool OnCreate()
        {
            return true;
        }

        public override ICursor Query(Android.Net.Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            /*
            Intent serviceIntent = new Intent(this, Vertix.SearchService.JavaType);
            ServiceConnection serviceConnection = new ServiceConnection();
            BindService(serviceIntent, serviceConnection, Bind.AutoCreate);
             */
            
            MatrixCursor cursor = new MatrixCursor(new string[] { Android.Provider.BaseColumns.Id, SearchManager.SuggestColumnText1, SearchManager.SuggestColumnIntentData }, 0);

            if (!string.IsNullOrWhiteSpace(selectionArgs[0]))
            {
                cursor.AddRow(new Java.Lang.Object[] { "0", "hello", "0/hello" });
                cursor.AddRow(new Java.Lang.Object[] { "1", "world", "1/world" });
            }

            return cursor;
        }

        public override int Update(Android.Net.Uri uri, ContentValues values, string selection, string[] selectionArgs)
        {
            throw new NotImplementedException();
        }
    }
}