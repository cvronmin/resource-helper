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

namespace ImageEditorAPK
{
    [Activity(Label = "PhyQBank")]
    public class PhyQBankActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        ViewPager pager;
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PhyQBank);
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
            
            pager = FindViewById<ViewPager>(Resource.Id.viewPager1);
            string uri = null;
            if (savedInstanceState != null) uri = savedInstanceState.GetString("qbank_url");
            initPager(uri);
            var lblCount = FindViewById<TextView>(Resource.Id.lblCount);
            pager.PageScrolled += (sender, e) => {
                lblCount.Text = (e.Position + 1) + "/" + pager.Adapter.Count;
            };
        }
        public override bool OnOptionsItemSelected (IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void initPager (string uri)
        {
            WebRequest request = WebRequest.Create(uri ?? "http://ccleungsir.asuscomm.com/qbank/l.php?a=210.1.Q.ff88341cc2a53ba2e2958685fb6771a7.Y");
            WebResponse response = request.GetResponse();
            var html = new HtmlDocument();
            html.Load(response.GetResponseStream());
            var tableBody = html.DocumentNode.Element("table");
            var trs = tableBody.Elements("tr");
            var tds = trs.Select(e => e.Elements("td").ToList()[0]).Where(e => e.Element("a") != null).Where(e => e.Element("a").InnerHtml.Contains("answerquestion.php"));
            var list = new List<PageFragment>();
            foreach (var item in tds)
            {
                var b = "http://ccleungsir.asuscomm.com/qbank/" + item.Element("img").Attributes.Single(att => att.Name.Equals("src")).Value;
                var a = PageFragment.newInstance(item.FirstChild.InnerText, b, item.Element("a").Attributes.Single(att => att.Name.Equals("href")).Value);
                list.Add(a);
            }
            pager.Adapter = new ViewFragmentAdapter(SupportFragmentManager, list);
        }
        private Bitmap GetImageBitmapFromUrl (string url)
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
    public class PageFragment : Fragment {
        string title, imgUri, ansUri;

        public string AnsUri
        {
            get
            {
                return ansUri;
            }

            private set
            {
                ansUri = value;
            }
        }

        public string ImgUri
        {
            get
            {
                return imgUri;
            }

            private set
            {
                imgUri = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            private set
            {
                title = value;
            }
        }

        public static PageFragment newInstance (string title, string imgUri, string ansUri)
        {
            PageFragment f = new PageFragment();
            Bundle bdl = new Bundle(1);
            bdl.PutString("title", title);
            bdl.PutString("imgUri", imgUri);
            bdl.PutString("ansUri", ansUri);
            f.Arguments = bdl;
            return f;
        }
        public override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Title = Arguments.GetString("title");
            ImgUri = Arguments.GetString("imgUri");
            AnsUri = Arguments.GetString("ansUri");
        }
        public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.PhyQBankTD, container, false);
        }
        public override void OnViewCreated (View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            ImageView img =  view.FindViewById<ImageView>(Resource.Id.imgView);
            var bitmap = GetImageBitmapFromUrl(view.Context, ImgUri);
            if(bitmap != null) img.SetImageBitmap(bitmap);
            var butAns = view.FindViewById<Button>(Resource.Id.butAns);
            butAns.Click += (s, e) => {
                Intent inte = new Intent(view.Context, typeof(PhyQBankAQActivity));
                inte.PutExtra("uri", ansUri);
                StartActivity(inte);
            };
        }


        private Bitmap GetImageBitmapFromUrl (string url)
        {
            Bitmap imageBitmap = null;
            string shCache = url.Substring(url.LastIndexOf('/') + 1);

            using (var webClient = new WebClient())
            {
                try
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
                catch (System.Net.WebException)
                {
                    return null;
                }
            }

            return imageBitmap;
        }
        private Bitmap GetImageBitmapFromUrl (Context context, string url)
        {
            Bitmap imageBitmap = null;
            string shCache = url.Substring(url.LastIndexOf('/') + 1);
            Java.IO.File cache = new Java.IO.File(context.CacheDir, shCache);
            if (!cache.Exists())
            {
                using (var webClient = new WebClient())
                {
                    try
                    {
                        var imageBytes = webClient.DownloadData(url);
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                            using (var s = new System.IO.FileStream(cache.AbsolutePath,System.IO.FileMode.Create)) {
                                imageBitmap.Compress(Bitmap.CompressFormat.Png, 100, s);
                            }
                        }
                    }
                    catch (WebException)
                    {
                        return null;
                    }
                }
            }
            else
            {
                imageBitmap = BitmapFactory.DecodeFile(cache.AbsolutePath);
            }

            return imageBitmap;
        }
    }
    public class ViewFragmentAdapter : FragmentPagerAdapter
    {
        public override int Count
        {
            get
            {
                return fragments.Count;
            }
        }

        public override Fragment GetItem (int position)
        {
            return fragments[position];
        }

        private List<PageFragment> fragments;
        public ViewFragmentAdapter (Android.Support.V4.App.FragmentManager fm, List<PageFragment> fragments) : base(fm)
        {
            this.fragments = fragments;
        }

        public new string GetPageTitle (int pos)
        {
            return fragments[pos].Title;
        }
    }
    public class ViewPagerAdapter : PagerAdapter
    {
        public override int Count
        {
            get
            {
                if (Views != null)
                {
                    return Views.Count;
                }
                return 0;
            }
        }

        public override bool IsViewFromObject (View view, Java.Lang.Object @object)
        {
            return view == @object;
        }
        public List<View> Views { get; private set; }

        public ViewPagerAdapter (List<View> Views)
        {
            this.Views = Views;
        }
        
        /* 
         * 销毁View 
         */
    public override void DestroyItem (ViewGroup container, int position, Java.Lang.Object obj)
        {
            ((ViewPager) container).RemoveView(Views[position]);
        }

        /* 
         * 初始化 
         */
    public override Java.Lang.Object InstantiateItem (ViewGroup container, int position)
        {
            ((ViewPager) container).AddView(Views[position], 0);
            return Views[position];

        }
    }
}