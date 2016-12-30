﻿using System;
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

using AlertDialog = Android.App.AlertDialog;
using Android.Provider;

namespace ImageEditorAPK
{
    [Activity(Label = "Encoder", Icon = "@drawable/icon")]
    public class EncryptActivity : AppCompatActivity
    {
        private readonly string[] EncodeType = new string[]{ "base64" , "crmkjk", "unicode" };
        DrawerLayout drawerLayout;
        Switch switchForceUnicode, switchEncodeTextEncode;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            
            SetContentView(Resource.Layout.Encrypt);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_action_nav_menu_holo_dark);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            switchForceUnicode = FindViewById<Switch>(Resource.Id.switchForceUnicode);
            switchEncodeTextEncode = FindViewById<Switch>(Resource.Id.switchEncodeTextEncode);
            var listView1 = FindViewById<ScrollView>(Resource.Id.listView1);
            listView1.Visibility = ViewStates.Gone;
            Spinner spinnerEncodeType = FindViewById<Spinner>(Resource.Id.spinnerEncodeType);
            spinnerEncodeType.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, EncodeType);
            spinnerEncodeType.ItemSelected += (sender, e) => {
                if (e.Position == 1) {
                    listView1.Visibility = ViewStates.Visible;
                }
                else
                {
                    listView1.Visibility = ViewStates.Gone;
                }
            };


            EditText editTextOrigin = FindViewById<EditText>(Resource.Id.editTextO);
            EditText editTextEncode = FindViewById<EditText>(Resource.Id.editTextE);

            Button butEncode = FindViewById<Button>(Resource.Id.butEncode);
            Button butDecode = FindViewById<Button>(Resource.Id.butDecode);

            butEncode.Click += (sender, e) => {
                switch (EncodeType[spinnerEncodeType.SelectedItemPosition])
                {
                    case "crmkjk":
                        editTextEncode.Text = CRMKJK.CRMKJK.EncodeEasy(editTextOrigin.Text, (switchForceUnicode.Checked ? CRMKJKState.Unicode : 0) | (switchEncodeTextEncode.Checked ? CRMKJKState.EncodeTextB64Encode : 0));
                        break;
                    case "base64":
                        if (string.IsNullOrWhiteSpace(editTextOrigin.Text)) return;
                        editTextEncode.Text = Convert.ToBase64String(Encoding.Default.GetBytes(editTextOrigin.Text));
                        break;
                    case "unicode":
                        editTextEncode.Text = editTextOrigin.Text.EscapeToUnicode();
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
                    case "unicode":
                        if (string.IsNullOrWhiteSpace(editTextEncode.Text)) return;
                        try
                        {
                            editTextOrigin.Text = editTextEncode.Text.TrapToUnicode();
                        }
                        catch (FormatException)
                        {
                            Toast.MakeText(this, "ERROR: unexpected unicode", ToastLength.Short).Show();
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
                    var intent = new Intent(this, typeof(MainActivity));
                    intent.AddFlags(ActivityFlags.ClearTask);
                    intent.AddFlags(ActivityFlags.NewTask);
                    StartActivity(intent);
                }
            };



            var butEDImgs = FindViewById<Button>(Resource.Id.butEDImgs);
            butEDImgs.Click += (sender, e) => {
                AlertDialog.Builder db = new AlertDialog.Builder(this);
                db.SetPositiveButton("Encrypt", (sender1, e1) => {
                    Intent getIntent = new Intent(Intent.ActionGetContent);
                    getIntent.SetType("image/*");
                    getIntent.AddCategory(Intent.CategoryOpenable);

                    Intent chooserIntent = Intent.CreateChooser(getIntent, GetText(Resource.String.PickImage));

                    StartActivityForResult(chooserIntent, 2333);
                });
                db.SetNegativeButton("Decrypt", (sender1, e1) => {
                    Intent getIntent = new Intent(Intent.ActionGetContent);
                    getIntent.SetType("*/*");
                    getIntent.AddCategory(Intent.CategoryOpenable);

                    Intent chooserIntent = Intent.CreateChooser(getIntent, GetText(Resource.String.PickImage));

                    StartActivityForResult(chooserIntent,6666);
                });
                Dialog dialog = db.Create();
                dialog.Show();
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
        protected override void OnActivityResult (int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                string path = "";
                
                if (requestCode == 6666)
                {
                    var id = DocumentsContract.GetDocumentId(data.Data);
                    path = Util.GetRealPathFromUri(this, id);
                    if (!path.StartsWith("/storage/")) {
                        path = System.IO.Path.Combine("/storage/emulated/0", path);
                    }
                    // ExternalStorageProvider
                    if (Util.IsExternalStorageDocument(data.Data))
                    {
                         string docId = DocumentsContract.GetDocumentId(data.Data);
                         string[] split = docId.Split(':');
                         string type = split[0];

                        if ("primary".Equals(type,StringComparison.InvariantCultureIgnoreCase))
                        {
                            path = Android.OS.Environment.ExternalStorageDirectory + "/" + split[1];
                        }

                        // TODO handle non-primary volumes
                    }
                }
                else if(requestCode == 2333) {
                    path = Util.GetRealPathFromUri(this, data.Data);
                }
                Java.IO.File dir = new Java.IO.File(path).ParentFile;
                Intent intent = new Intent(this, typeof(CryptImagesService));
                intent.PutExtra("dir", dir.AbsolutePath);
                intent.PutExtra("decrypt", requestCode == 6666);
                StartService(intent);
            }
        }
    }
}

