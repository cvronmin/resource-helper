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
using Android.Support.V4.Provider;

namespace ImageEditorAPK
{
    [Service]
    public class CryptImagesService : IntentService
    {
        bool stop = false;
        public CryptImagesService () : base("CryptImagesService") { }
        /*public override IBinder OnBind (Intent intent)
        {
            return new ServiceBinder(this);
        }*/
        protected override void OnHandleIntent (Intent intent)
        {
            Intent intent1 = new Intent(this, typeof(BroadCaster));
            intent1.PutExtra("cancel", true);

            var noticeMgr = (NotificationManager)GetSystemService(NotificationService);
            var nb = new Notification.Builder(this);
            nb.SetSmallIcon(Android.Resource.Drawable.StatNotifyMore);
            nb.SetCategory(Notification.CategoryProgress);
            //nb.AddAction(new Notification.Action())
            nb.SetOngoing(true);
            //string dir = intent.GetStringExtra("dir");
            Android.Net.Uri dir = intent.GetParcelableExtra("dir") as Android.Net.Uri;
            bool decrypt = intent.GetBooleanExtra("decrypt",false);

            intent1.PutExtra("noticeId", 0x731);
            intent1.PutExtra("decrypt", decrypt);
            PendingIntent pi = PendingIntent.GetBroadcast(this, 0, intent1, 0);

            nb.SetContentTitle(string.Format("Images {0}", decrypt ? "decrypting" : "encrypting"));
            nb.SetContentText("Getting file list...");
            var action = new Notification.Action(Android.Resource.Drawable.IcDelete, "Cancel", pi);
            //nb.AddAction(action);
            noticeMgr.Notify(0x731, nb.Build());
            var files = DocumentFile.FromTreeUri(this,dir).ListFiles();
            noticeMgr.Notify(0x731, nb.SetContentText(string.Format("doing job... (0/{0})", files.Length)).SetProgress(files.Length, 0, false).Build());
            for (int i = 0; i < files.Length; i++)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(files[i].Uri.LastPathSegment, "[\\s\\S]+(.png|.jpg|.jpeg|.jpe|.jfif|.tif|.tiff|.bmp|.dib|.gif)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)) {
                    noticeMgr.Notify(0x731, nb.SetContentText(string.Format("doing job... ({0}/{1})",i+1,files.Length)).SetProgress(files.Length, i + 1, false).Build());
                    continue;
                }
                string b = "";
                try
                {
                    using (var f = ContentResolver.OpenInputStream(files[i].Uri))
                    {
                        using (var a = new System.IO.StreamReader(f, decrypt ? Encoding.UTF8 : Encoding.GetEncoding(1252)))
                        {
                            b = a.ReadToEnd();
                        }
                    }
                    b = decrypt ? CRMKJK.CRMKJK.Decode(b, Encoding.UTF8) : CRMKJK.CRMKJK.EncodeEasy(b, Encoding.UTF8, CRMKJK.CRMKJKState.EncodeTextB64Encode);
                    using (var f = ContentResolver.OpenOutputStream(files[i].Uri))
                    {
                        using (var a = new System.IO.StreamWriter(f, decrypt ? Encoding.GetEncoding(1252) : Encoding.UTF8))
                        {
                            a.Write(b);
                        }
                    }
                    GC.Collect();
                }
                catch (Exception) { }
                finally
                {
                    b = "";
                    noticeMgr.Notify(0x731, nb.SetContentText(string.Format("doing job... ({0}/{1})", i + 1, files.Length)).SetProgress(files.Length, i + 1, false).Build());
                }

            }
            noticeMgr.Notify(0x731, nb.SetContentText("done!").SetOngoing(false).SetProgress(0, 0, false).Build());
        }
        public class ServiceBinder : Binder {
            CryptImagesService service;
            public ServiceBinder (CryptImagesService s) { service = s; }
            public CryptImagesService getService () {
                return service;
            }
        }
        [BroadcastReceiver]
        public class BroadCaster : BroadcastReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                bool requireCancel = intent.GetBooleanExtra("cancel", false);
                if (requireCancel) context.StopService(new Intent(context, typeof(CryptImagesService)));
                int noticeId = intent.GetIntExtra("noticeId", 0x731);
                var noticeMgr = (NotificationManager)context.GetSystemService(Context.NotificationService);
                var nb = new Notification.Builder(context);
                nb.SetSmallIcon(Android.Resource.Drawable.StatNotifyMore);
                nb.SetCategory(Notification.CategoryProgress);
                bool decrypt = intent.GetBooleanExtra("decrypt", false);
                nb.SetContentTitle(string.Format("Images {0}", decrypt ? "decrypting" : "encrypting"));
                nb.SetContentText("Progress cancelled");
                noticeMgr.Notify(noticeId, nb.Build());
            }
        }
    }

}