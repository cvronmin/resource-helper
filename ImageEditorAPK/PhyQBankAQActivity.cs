using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Android.Support.V4.View;
using Java.Lang;
using Android.Graphics;
using Android.Support.V4.App;
using Fragment = Android.Support.V4.App.Fragment;
using ImageEditorAPK;

namespace ImageEditorAPK
{
    [Activity(Label = "PhyQBankAQ")]
    public class PhyQBankAQActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        Spinner spinnerAns;
        readonly Dictionary<string, string> anss = new Dictionary<string, string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PhyQBankAQ);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_action_nav_menu_holo_dark);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                drawerLayout.CloseDrawers();
                Intent intent = null;
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_encrypt:
                        intent = new Intent(this, typeof(EncryptActivity));
                        break;
                    case Resource.Id.nav_imgedit:
                        intent = new Intent(this, typeof(MainActivity));
                        break;
                    case Resource.Id.nav_phyqbank:
                        intent = new Intent(this, typeof(PhyQBankActivity));
                        break;
                    default:
                        break;
                }
                    intent.AddFlags(ActivityFlags.ClearTask);
                    intent.AddFlags(ActivityFlags.NewTask);
                    StartActivity(intent);
            };
            string uri = Intent.GetStringExtra("uri");
            init(uri);
            ReadyAnsDict();
            spinnerAns = FindViewById<Spinner>(Resource.Id.spinnerAns);
            spinnerAns.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, anss.Values.ToList());
            var editTextRegNo = FindViewById<EditText>(Resource.Id.editTextRegNo);
            var editTextPW = FindViewById<EditText>(Resource.Id.editTextPW);
            var butSubmit = FindViewById<Button>(Resource.Id.butSubmit);
            butSubmit.Click += (sender, e)=>{
                var request = WebRequest.CreateHttp("http://ccleungsir.asuscomm.com/qbank/answerquestion.php");
                request.Method = "POST";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.ContentType = "application/x-www-form-urlencoded";
                request.KeepAlive = true;
                using (var stream = new System.IO.StreamWriter(request.GetRequestStream()))
                {
                    stream.Write(string.Format("regno={0}&password={1}&answer={2}&a={3}&b={4}&c={5}&d={6}&as={7}&submit_answer=Submit", editTextRegNo.Text, editTextPW.Text, anss.ElementAt(spinnerAns.SelectedItemPosition).Key,
                        argA, argB, argC, argD, argAs));
                }
                var response = request.GetResponse();
                var html = new HtmlDocument();
                html.Load(response.GetResponseStream());
                new Android.Support.V7.App.AlertDialog.Builder(this).SetMessage(html.DocumentNode.InnerText).Show();
            };
        }
        string argA, argB, argC, argD, argAs;
        private void init(string uri) {
            WebRequest request = WebRequest.Create(uri);
            WebResponse response = request.GetResponse();
            var html = new HtmlDocument();
            html.Load(response.GetResponseStream());
            var img = "http://ccleungsir.asuscomm.com/qbank/" + html.DocumentNode.Element("img").GetAttribute("src").Value;
            var inputs = html.DocumentNode.Element("form").Elements("input");
            foreach (var input in inputs)
            {
                switch (input.GetAttribute("name").Value)
                {
                    case "a":
                        argA = input.GetAttribute("value").Value;
                        break;
                    case "b":
                        argB = input.GetAttribute("value").Value;
                        break;
                    case "c":
                        argC = input.GetAttribute("value").Value;
                        break;
                    case "d":
                        argD = input.GetAttribute("value").Value;
                        break;
                    case "as":
                        argAs = input.GetAttribute("value").Value;
                        break;
                    default:
                        break;
                }
            }
            var imgView = FindViewById<ImageView>(Resource.Id.imgView);
            imgView.SetImageBitmap(GetImageBitmapFromUrl(img));
            html = null;
        }
        private void ReadyAnsDict() {
            anss.Add("noname", "Please select...");
            anss.Add("A", "A");
            anss.Add("B", "B");
            anss.Add("C", "C");
            anss.Add("D", "D");
            anss.Add("E", "E");
            anss.Add("T", "T");
            anss.Add("F", "F");
            anss.Add("Z", "I don\'t know");
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
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
    public class KVArrayAdapter<T1, T2> : ArrayAdapter<T2>
    {
        Dictionary<T1, T2> dict;
        public KVArrayAdapter(Context context, int resId) : base(context, resId) { }
        public KVArrayAdapter(Context context, int resId, List<T2> list) : base(context, resId, list) { }

        public KVArrayAdapter(Context context, int resId, Dictionary<T1, T2> list) : base(context, resId, list.Values.ToList()) { dict = list; }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            return base.GetView(position, convertView, parent);
        }
    }
}