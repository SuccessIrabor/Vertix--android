using System;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Vertix;
using Xamarin.Essentials;

namespace Vertix
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    [MetaData("android.app.searchable", Resource = "@xml/searchable")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener,
        ExpandableListView.IOnGroupClickListener, ExpandableListView.IOnChildClickListener
    {
        ExpandableListView ListView;
        ExpandableListAdapter ListAdapter;
        ExpandableListModel[] ListData;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            //
            ExpandableListModel.GenerateData(ref ListData, this);
            ListView = (ExpandableListView)this.FindViewById<Android.Widget.ExpandableListView>(Resource.Id.apps);


            ListAdapter = new ExpandableListAdapter(this, ListData, ListView);
            ListView.SetAdapter(ListAdapter);

            ListView.SetOnGroupClickListener(this);
            ListView.SetOnChildClickListener(this);
            //

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
        }

        public bool OnGroupClick(ExpandableListView parent, View clickedView, int groupPosition, long id)
        {
            return false;
        }

        public bool OnChildClick(ExpandableListView parent, View clickedView, int groupPosition, int childPosition, long id)
        {
            if (this.ListData[groupPosition].children[childPosition] != null)
            {
                parent.CollapseGroup(groupPosition);
                OnBackPressed();
            }

            return false;
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);

            SearchManager searchManager = (SearchManager) GetSystemService(Context.SearchService);

            menu.FindItem(Resource.Id.search).SetActionView(Resource.Layout.searchview);

            //Android.Widget.SearchView searchView = (Android.Widget.SearchView) menu.FindItem(Resource.Id.search).ActionView;

            //SearchView searchView = FindViewById<SearchView>(Resource.Id.search);

            IMenuItem search = menu.FindItem(Resource.Id.search);
            Android.Support.V7.Widget.SearchView searchView = search.ActionView.JavaCast<Android.Support.V7.Widget.SearchView>();

            searchView.SetSearchableInfo(searchManager.GetSearchableInfo(ComponentName));

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            //if (id == Resource.Id.action_settings)
            //{
            //    return true;
            //}

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.apps)
            {
                // TODO: expand
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

