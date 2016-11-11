using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Text;
using CRMKJK;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

namespace ImageEditorAPK
{
    [Activity(Label = "Encoder", Icon = "@drawable/icon")]
    public class EncryptActivity : AppCompatActivity
    {
        private readonly string[] EncodeType = new string[]{ "base64" , "crmkjk" };
        DrawerLayout drawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            
            SetContentView(Resource.Layout.Encrypt);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //Enable support action bar to display hamburger
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_action_nav_menu_holo_dark);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            Spinner spinnerEncodeType = FindViewById<Spinner>(Resource.Id.spinnerEncodeType);
            spinnerEncodeType.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, EncodeType);

            EditText editTextOrigin = FindViewById<EditText>(Resource.Id.editTextO);
            EditText editTextEncode = FindViewById<EditText>(Resource.Id.editTextE);

            Button butEncode = FindViewById<Button>(Resource.Id.butEncode);
            Button butDecode = FindViewById<Button>(Resource.Id.butDecode);

            butEncode.Click += (sender, e) => {
                switch (EncodeType[spinnerEncodeType.SelectedItemPosition])
                {
                    case "crmkjk":
                        editTextEncode.Text = CRMKJK.CRMKJK.Encode(editTextOrigin.Text);
                        break;
                    case "base64":
                        if (string.IsNullOrWhiteSpace(editTextOrigin.Text)) return;
                        editTextEncode.Text = Convert.ToBase64String(Encoding.Default.GetBytes(editTextOrigin.Text));
                        break;
                    default:
                        break;
                }
            };

            butDecode.Click += (sender, e) => {
                switch (EncodeType[spinnerEncodeType.SelectedItemPosition])
                {
                    case "crmkjk":
                        try
                        {
                            editTextOrigin.Text = CRMKJK.CRMKJK.Decode(editTextEncode.Text);
                        }
                        catch (UnexpectedCRMKJKEncodeException)
                        {
                            Toast.MakeText(this, "ERROR: unexpected crmkjk encode", ToastLength.Short).Show();
                        }
                        break;
                    case "base64":
                        if (string.IsNullOrWhiteSpace(editTextEncode.Text)) return;
                        try
                        {
                            editTextOrigin.Text = Encoding.Default.GetString(Convert.FromBase64String(editTextEncode.Text));
                        }
                        catch (FormatException)
                        {
                            Toast.MakeText(this, "ERROR: unexpected base64 encode", ToastLength.Short).Show();
                        }
                        break;
                    default:
                        break;
                }
            };

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                drawerLayout.CloseDrawers();
                if (e.MenuItem.ItemId == Resource.Id.nav_imgedit)
                {
                    StartActivity(new Intent(this, typeof(MainActivity)));
                }
            };
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

