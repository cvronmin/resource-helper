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

using Toolbar = Android.Support.V7.Widget.Toolbar;
using DrawerLayout = Android.Support.V4.Widget.DrawerLayout;
using Android.Support.V7.App;
using Android.Support.Design.Widget;

namespace ToolBoxAPK
{
    [Activity(Label = "MonitorActivity")]
    public class MonitorActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Monitor);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

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
                if (e.MenuItem.ItemId == Resource.Id.nav_encrypt)
                {
                    var intent = new Intent(this, typeof(EncryptActivity));
                    intent.AddFlags(ActivityFlags.ClearTask);
                    intent.AddFlags(ActivityFlags.NewTask);
                    StartActivity(intent);
                }
                if (e.MenuItem.ItemId == Resource.Id.nav_imgedit)
                {
                    var intent = new Intent(this, typeof(MainActivity));
                    intent.AddFlags(ActivityFlags.ClearTask);
                    intent.AddFlags(ActivityFlags.NewTask);
                    StartActivity(intent);
                }
            };
            ActivityManager am = (ActivityManager)GetSystemService(ActivityService);
            IList<ActivityManager.RunningServiceInfo> a = am.GetRunningServices(int.MaxValue);
            a = a.Where(b => b.Process.StartsWith("com.whatsapp")).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in a)
            {
                sb.AppendLine(string.Format("Service process {0} with component {1}", item.Process, item.Service.ClassName));
            }
            var textView = FindViewById<TextView>(Resource.Id.textView1);
            textView.Text = sb.ToString();
        }

        public override bool OnOptionsItemSelected (IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}