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
    public class ExpandableListAdapter : BaseExpandableListAdapter
    {
        public Context context;
        public ExpandableListModel[] exListData;
        public ExpandableListView exListView;

        public ExpandableListAdapter(Context context, ExpandableListModel[] groups, ExpandableListView expandableListView)
            : base()
        {
            this.context = context;
            this.exListData = groups;
            this.exListView = expandableListView;
        }

        public override int GroupCount
        {
            get
            {
                return this.exListData.Length;
            }
        }

        public override bool HasStableIds
        {
            get
            {
                return false;
            }
        }

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return this.exListData[groupPosition].children[childPosition];
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return exListData[groupPosition].children.Count;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            string text = (string)this.GetChild(groupPosition, childPosition);

            if (convertView == null)
            {
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.list_item, null);
            }

            TextView row = convertView.FindViewById<TextView>(Resource.Id.list_item);

            row.SetText(text, TextView.BufferType.Normal);

            return convertView;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return this.exListData[groupPosition].key;
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            string text = (string)GetGroup(groupPosition);

            if (convertView == null)
            {
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.list_group, null);
            }

            TextView header = convertView.FindViewById<TextView>(Resource.Id.list_group);

            header.SetText(text, TextView.BufferType.Normal);

            return convertView;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }
    }
}