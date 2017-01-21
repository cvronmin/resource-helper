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
            ClipData cd = intent.GetParcelableExtra("files") as ClipData;
            ClipData.Item cdi = cd.GetItemAt(0);
            bool decrypt = intent.GetBooleanExtra("decrypt",false);

            intent1.PutExtra("noticeId", 0x731);
            intent1.PutExtra("decrypt", decrypt);
            PendingIntent pi = PendingIntent.GetBroadcast(this, 0, intent1, 0);

            nb.SetContentTitle(string.Format("Images {0}", decrypt ? "decrypting" : "encrypting"));
            nb.SetContentText("Getting file list...");
            var action = new Notification.Action(Android.Resource.Drawable.IcDelete, "Cancel", pi);
            //nb.AddAction(action);
            noticeMgr.Notify(0x731, nb.Build());
            DocumentFile[] files = null;
            if (dir != null)
            {
                files = DocumentFile.FromTreeUri(this, dir).ListFiles();
            }
            else if (cd != null) {
                files = new DocumentFile[cd.ItemCount];
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = DocumentFile.FromSingleUri(this, cd.GetItemAt(i).Uri);
                }
            }
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
                        if (!decrypt)
                        {
                            using (var a = new System.IO.BinaryReader(f, Encoding.GetEncoding(1252)))
                            {
                                byte[] by = a.ReadBytes((int)f.Length);
                                var sb = new StringBuilder();
                                foreach (var item in by)
                                {
                                    sb.AppendFormat("{0:X2}", item);
                                }
                                by = null;
                                b = sb.ToString();
                            }
                        }
                        else {
                            using (var a = new System.IO.StreamReader(f, Encoding.GetEncoding(1252)))
                            {
                                b = a.ReadToEnd();
                            }
                        }
                    }
                    b = decrypt ? CRMKJK.CRMKJK.Decode(b, Encoding.UTF8) : CRMKJK.CRMKJK.EncodeEasy(b, Encoding.UTF8, CRMKJK.CRMKJKState.EncodeTextB64Encode);
                    using (var f = ContentResolver.OpenOutputStream(files[i].Uri))
                    {
                        if (decrypt)
                        {
                            using (var a = new System.IO.BinaryWriter(f, Encoding.GetEncoding(1252)))
                            {
                                var by = new byte[b.Length / 2];
                                for (int i1 = 0; i1 < b.Length / 2; i1++)
                                {
                                    try
                                    {
                                        by[i1] = byte.Parse(int.Parse(b.Substring(i1 * 2, 2), System.Globalization.NumberStyles.HexNumber).ToString());
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                                a.Write(by);
                                by = null;
                            }
                        }
                        else
                        {
                            using (var a = new System.IO.StreamWriter(f, Encoding.UTF8))
                            {
                                a.Write(b);
                            }
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