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
    public class ExpandableListModel
    {
        public string key;
        public List<string> children = new List<string>();

        // TODO: use map to generate list items in GenerateData->ListData
        public static Dictionary<string, string> map = new Dictionary<string, string>()
        {
            { "youtube", "Youtube" }
        };
        //

        public ExpandableListModel(string key)
        {
            this.key = key;
        }

        public ExpandableListModel(string key, List<string> children)
        {
            this.key = key;
            this.children = children;
        }

        public static void GenerateData(ref ExpandableListModel[] ListData, Context context)
        {
            string apps = context.GetString(Resource.String.apps_header);

            ListData = new ExpandableListModel[1] {
                new ExpandableListModel(apps, new List<string>() {
                    context.GetString(Resource.String.youtube)
                })
            };
        }
    }
}