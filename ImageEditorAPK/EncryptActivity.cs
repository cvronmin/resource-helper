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

using AlertDialog = Android.App.AlertDialog;
using Android.Provider;
using Android.Support.V4.Provider;
using Android.Text;
using Android.Content.PM;

namespace ToolBoxAPK
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
                Intent intent;
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_imgedit:
                        intent = new Intent(this, typeof(MainActivity));
                        break;
                    case Resource.Id.nav_namegen:
                        intent = new Intent(this, typeof(MonitorActivity));
                        break;
                    case Resource.Id.nav_launch:
                        intent = new Intent(this, typeof(LaunchingActivity));
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



            var butEDImgs = FindViewById<Button>(Resource.Id.butEDImgs);
            butEDImgs.Click += (sender, e) => {
                AlertDialog.Builder db = new AlertDialog.Builder(this);
                db.SetPositiveButton("Encrypt", (sender1, e1) => {
                    Intent selectMultiFilesIntent = new Intent(Intent.ActionOpenDocument);
                    selectMultiFilesIntent.PutExtra(Intent.ExtraAllowMultiple, true);
                    selectMultiFilesIntent.SetType("*/*");
                    selectMultiFilesIntent.AddCategory(Intent.CategoryOpenable);
                    
                        Intent selectFolderIntent = new Intent(Intent.ActionOpenDocumentTree);
                    //selectFolderIntent.PutExtra(Intent.ExtraAllowMultiple, true);
                    //selectFolderIntent.SetType("*/*");
                    //selectFolderIntent.AddCategory(Intent.CategoryOpenable);
                    var a  = PackageManager.QueryIntentActivities(selectMultiFilesIntent, 0);
                    var a1 = PackageManager.QueryIntentActivities(selectFolderIntent    , 0);
                    bool usefolderone = false;
                    if (a.Count == 0) usefolderone = true;
                    if (usefolderone && a1.Count == 0) {
                        AlertDialog.Builder db1 = new Android.App.AlertDialog.Builder(this);
                        db1.SetMessage("No selectors found");
                        db1.Create().Show();
                        return;
                    }

                    Intent chooserIntent = Intent.CreateChooser(usefolderone ? selectFolderIntent : selectMultiFilesIntent, GetText(Resource.String.PickImage));
                    chooserIntent = new Intent(Intent.ActionChooser);
                    chooserIntent.PutExtra(Intent.ExtraTitle, "Open as...");
                    SpannableString forEditing = new SpannableString(" (selecting multiple files)");
                    forEditing.SetSpan(new Android.Text.Style.ForegroundColorSpan(Android.Graphics.Color.Cyan), 0, forEditing.Length(), SpanTypes.ExclusiveExclusive);
                    Intent[] extraIntents = new Intent[a.Count];
                    for (int i = 0; i < extraIntents.Length; i++)
                    {
                        ResolveInfo ri = a[i];
                        String packageName = ri.ActivityInfo.PackageName;
                        Intent intent = new Intent();
                        intent.SetComponent(new ComponentName(packageName, ri.ActivityInfo.Name));
                        intent.SetAction(Intent.ActionOpenDocument);
                        intent.PutExtra(Intent.ExtraAllowMultiple, true);
                        intent.SetType("*/*");
                        intent.AddCategory(Intent.CategoryOpenable);
                        string label = TextUtils.Concat(ri.LoadLabel(PackageManager), forEditing.SubSequence(0, forEditing.Length()));
                        extraIntents[i] = new LabeledIntent(intent, packageName, label, ri.Icon);
                    }
                    forEditing = new SpannableString(" (selecting folder)");
                    forEditing.SetSpan(new Android.Text.Style.ForegroundColorSpan(Android.Graphics.Color.Cyan), 0, forEditing.Length(), SpanTypes.ExclusiveExclusive);
                    Intent[] extraIntents1 = new Intent[a1.Count];
                    for (int i = 0; i < extraIntents1.Length; i++)
                    {
                        ResolveInfo ri = a1[i];
                        String packageName = ri.ActivityInfo.PackageName;
                        Intent intent = new Intent();
                        intent.SetComponent(new ComponentName(packageName, ri.ActivityInfo.Name));
                        intent.SetAction(Intent.ActionOpenDocumentTree);
                        string label = TextUtils.Concat(ri.LoadLabel(PackageManager), forEditing.SubSequence(0, forEditing.Length()));
                        extraIntents1[i] = new LabeledIntent(intent, packageName, label, ri.Icon);
                    }
                    Intent[] final = null;
                    if (!usefolderone)
                    {
                        final = new Intent[a.Count + a1.Count];
                        Array.Copy(extraIntents, final, extraIntents.Length);
                        Array.Copy(extraIntents1, 0, final, extraIntents.Length, extraIntents1.Length);
                    }
                    else {
                        final = extraIntents1;
                    }
                    if (final.Length != 0) {
                        chooserIntent.PutExtra(Intent.ExtraIntent, final[0]);
                    }
                    if (final.Length > 1)
                    {
                        var a2 = new Intent[final.Length - 1];
                        Array.Copy(final, 1, a2, 0, a2.Length);
                        chooserIntent.PutExtra(Intent.ExtraInitialIntents, a2);
                    }
                    StartActivityForResult(chooserIntent, 2333);
                });
                db.SetNegativeButton("Decrypt", (sender1, e1) => {
                    Intent selectMultiFilesIntent = new Intent(Intent.ActionOpenDocument);
                    selectMultiFilesIntent.PutExtra(Intent.ExtraAllowMultiple, true);
                    selectMultiFilesIntent.SetType("*/*");
                    selectMultiFilesIntent.AddCategory(Intent.CategoryOpenable);

                    Intent selectFolderIntent = new Intent(Intent.ActionOpenDocumentTree);
                    //selectFolderIntent.PutExtra(Intent.ExtraAllowMultiple, true);
                    //selectFolderIntent.SetType("*/*");
                    //selectFolderIntent.AddCategory(Intent.CategoryOpenable);
                    var a = PackageManager.QueryIntentActivities(selectMultiFilesIntent, 0);
                    var a1 = PackageManager.QueryIntentActivities(selectFolderIntent, 0);
                    bool usefolderone = false;
                    if (a.Count == 0) usefolderone = true;
                    if (usefolderone && a1.Count == 0)
                    {
                        AlertDialog.Builder db1 = new Android.App.AlertDialog.Builder(this);
                        db1.SetMessage("No selectors found");
                        db1.Create().Show();
                        return;
                    }

                    Intent chooserIntent = Intent.CreateChooser(usefolderone ? selectFolderIntent : selectMultiFilesIntent, GetText(Resource.String.PickImage));
                    chooserIntent = new Intent(Intent.ActionChooser);
                    chooserIntent.PutExtra(Intent.ExtraTitle, "Open as...");
                    SpannableString forEditing = new SpannableString(" (selecting multiple files)");
                    forEditing.SetSpan(new Android.Text.Style.ForegroundColorSpan(Android.Graphics.Color.Cyan), 0, forEditing.Length(), SpanTypes.ExclusiveExclusive);
                    Intent[] extraIntents = new Intent[a.Count];
                    for (int i = 0; i < extraIntents.Length; i++)
                    {
                        ResolveInfo ri = a[i];
                        String packageName = ri.ActivityInfo.PackageName;
                        Intent intent = new Intent();
                        intent.SetComponent(new ComponentName(packageName, ri.ActivityInfo.Name));
                        intent.SetAction(Intent.ActionOpenDocument);
                        intent.PutExtra(Intent.ExtraAllowMultiple, true);
                        intent.SetType("*/*");
                        intent.AddCategory(Intent.CategoryOpenable);
                        string label = TextUtils.Concat(ri.LoadLabel(PackageManager), forEditing.SubSequence(0, forEditing.Length()));
                        extraIntents[i] = new LabeledIntent(intent, packageName, label, ri.Icon);
                    }
                    forEditing = new SpannableString(" (selecting folder)");
                    forEditing.SetSpan(new Android.Text.Style.ForegroundColorSpan(Android.Graphics.Color.Cyan), 0, forEditing.Length(), SpanTypes.ExclusiveExclusive);
                    Intent[] extraIntents1 = new Intent[a1.Count];
                    for (int i = 0; i < extraIntents1.Length; i++)
                    {
                        ResolveInfo ri = a1[i];
                        String packageName = ri.ActivityInfo.PackageName;
                        Intent intent = new Intent();
                        intent.SetComponent(new ComponentName(packageName, ri.ActivityInfo.Name));
                        intent.SetAction(Intent.ActionOpenDocumentTree);
                        string label = TextUtils.Concat(ri.LoadLabel(PackageManager), forEditing.SubSequence(0, forEditing.Length()));
                        extraIntents1[i] = new LabeledIntent(intent, packageName, label, ri.Icon);
                    }
                    Intent[] final = null;
                    if (!usefolderone)
                    {
                        final = new Intent[a.Count + a1.Count];
                        Array.Copy(extraIntents, final, extraIntents.Length);
                        Array.Copy(extraIntents1, 0, final, extraIntents.Length, extraIntents1.Length);
                    }
                    else
                    {
                        final = extraIntents1;
                    }
                    if (final.Length != 0)
                    {
                        chooserIntent.PutExtra(Intent.ExtraIntent, final[0]);
                    }
                    if (final.Length > 1)
                    {
                        var a2 = new Intent[final.Length - 1];
                        Array.Copy(final, 1, a2, 0, a2.Length);
                        chooserIntent.PutExtra(Intent.ExtraInitialIntents, a2);
                    }
                    StartActivityForResult(chooserIntent, 6666);
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
                Intent intent = new Intent(this, typeof(CryptImagesService));
                intent.PutExtra("dir", data.Data);
                intent.PutExtra("files", data.ClipData);
                intent.PutExtra("decrypt", requestCode == 6666);
                StartService(intent);
            }
        }
    }
}

