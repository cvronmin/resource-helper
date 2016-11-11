using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using DrawerLayout = Android.Support.V4.Widget.DrawerLayout;
using Android.Support.Design.Widget;
using Android.Views;

namespace ImageEditorAPK
{
    [Activity(Label = "Image Editor", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;
        DrawerLayout drawerLayout;
        //NavigationView a;


        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_action_nav_menu_holo_dark);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate {
                Intent getIntent = new Intent(Intent.ActionGetContent);
                getIntent.SetType("image/*");

                //Intent pickIntent = new Intent(Intent.ActionPick, Android.Provider.MediaStore.Images.Media.ExternalContentUri);
                //pickIntent.SetType("image/*");

                Intent chooserIntent = Intent.CreateChooser(getIntent,GetText(Resource.String.PickImage));
                //chooserIntent.PutExtra(Intent.ExtraInitialIntents, new Intent[] { getIntent });

                StartActivityForResult(chooserIntent, 0);
            };
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                drawerLayout.CloseDrawers();
                if (e.MenuItem.ItemId == Resource.Id.nav_encrypt)
                {
                    StartActivity(new Intent(this, typeof(EncryptActivity)));
                }
            };
        }

        protected override void OnActivityResult (int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok) {
                Intent intent = new Intent(this, typeof(EditActivity));
                intent.PutExtra("Image", data.Data);
                StartActivity(intent);
            }
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

