using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Widget;
using Android.Content.PM;
using Android.Support.V4.View;

namespace ToolBoxAPK
{
    [Activity(Label = "Launcher")]
    public class LaunchingActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Launching);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_action_nav_menu_holo_dark);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                drawerLayout.CloseDrawers();
                Intent intent;
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_encrypt:
                        intent = new Intent(this, typeof(EncryptActivity));
                        break;
                    case Resource.Id.nav_imgedit:
                        intent = new Intent(this, typeof(MainActivity));
                        break;
                    case Resource.Id.nav_namegen:
                        intent = new Intent(this, typeof(MonitorActivity));
                        break;
                    case Resource.Id.nav_phyqbank:
                        intent = new Intent(this, typeof(PhyQBankActivity));
                        break;
                    default:
                        return;
                }
                intent.AddFlags(ActivityFlags.ClearTask);
                intent.AddFlags(ActivityFlags.NewTask);
                StartActivity(intent);
            };
            Intent mainIntent = new Intent(Intent.ActionMain, null);
            mainIntent.AddCategory(Intent.CategoryLauncher);
            var packages = PackageManager.GetInstalledApplications(PackageInfoFlags.MetaData);
            packages.OrderBy(info => PackageManager.GetApplicationLabel(info)).ToList();
            var adapter = new AppAdapter(this, Resource.Layout.AppListFragment, packages.OrderBy(info => PackageManager.GetApplicationLabel(info)).ToList());
            listview = FindViewById<ListView>(Resource.Id.listView);
            listview.FastScrollEnabled = true;
            listview.Adapter = adapter;
            listview.ItemLongClick += (sender, e) => {
                ApplicationInfo info = ((AppAdapter)listview.Adapter).GetItem(e.Position);
                Intent launchIntent = PackageManager.GetLaunchIntentForPackage(info.PackageName);
                if (launchIntent != null)
                {
                    StartActivity(launchIntent);
                }
            };
            
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        Android.Support.V7.Widget.SearchView searchView;
        private ListView listview;

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menusearch, menu);

            var searchItem = menu.FindItem(Resource.Id.action_search);

            searchView = MenuItemCompat.GetActionView(searchItem).JavaCast<Android.Support.V7.Widget.SearchView>();

            searchView.QueryTextSubmit += (sender, args) =>
            {
                ((AppAdapter)listview.Adapter).Items.Where(info => PackageManager.GetApplicationLabel(info).Contains(args.Query));
            };
            
            return true;
        }
    }

    public class AppAdapter : ArrayAdapter<ApplicationInfo>
    {
        int ResourceId;
        internal IList<ApplicationInfo> Items;

        public AppAdapter(Context context, int resource, IList<ApplicationInfo> list) : base(context,resource,list) {
            ResourceId = resource;
            Items = list;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LinearLayout itemView;

            ApplicationInfo item = GetItem(position);

            if (convertView == null)
            {
                itemView = new LinearLayout(Context);
                String inflater = Context.LayoutInflaterService;
                LayoutInflater li = (LayoutInflater)
                        Context.GetSystemService(inflater);
                li.Inflate(ResourceId, itemView, true);
            }
            else
            {
                itemView = (LinearLayout)convertView;
            }
            var icon = itemView.FindViewById<ImageView>(Resource.Id.iconView);
            var appname = itemView.FindViewById<TextView>(Resource.Id.textAppName);
            var packagename = itemView.FindViewById<TextView>(Resource.Id.textPackageName);
            icon.SetImageDrawable(item.LoadIcon(Context.PackageManager));
			string expectedName = Context.PackageManager.GetApplicationLabel(item);
            if (string.IsNullOrWhiteSpace(expectedName)) {
                packagename.Visibility = ViewStates.Gone;
                appname.Text = item.PackageName;
            }
            else
            {
                appname.Text = expectedName;
                packagename.Text = item.PackageName;
            }
            return itemView;
        }
        
    }
    
}