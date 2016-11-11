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
using Android.Support.V7.App;
using Android.Util;
using System.Drawing;
using Android.Graphics;
using Java.Nio;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using File = Java.IO.File;

namespace ImageEditorAPK
{
    [Activity(Label = "Editor")]
    public class EditActivity : AppCompatActivity
    {
        Uri uri;
        ImageView imageView;
        LinearLayout layoutHandle;
        Bitmap map;
        ProgressBar progressBar;
        
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Edit);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            
            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);
            var a = SupportActionBar;
            a.SetDisplayHomeAsUpEnabled(true);

            imageView = FindViewById<ImageView>(Resource.Id.imageView);
            layoutHandle = FindViewById<LinearLayout>(Resource.Id.layoutHandle);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            uri = Intent.GetParcelableExtra("Image").JavaCast<Uri>();
            imageView.SetImageURI(uri);
            map = Android.Provider.MediaStore.Images.Media.GetBitmap(ContentResolver, uri);
            //CreateAgain();
            var butGrey = FindViewById<ImageButton>(Resource.Id.butGrey);
            butGrey.Click += delegate
            {
                ModifyImage((byt, ctr) =>
                {
                    //access array in form of argb. for ex. byt[0] is 'r', byt[1] is 'g' and so on..
                    //create the grayscale version
                    byte grayScale =
                       (byte)((byt[ctr + 2] * .11) + //B
                       (byt[ctr + 1] * .59) +  //G
                       (byt[ctr] * .3)); //R

                    //set the new image's pixel to the grayscale version
                    byt[ctr + 2] = grayScale; //B
                    byt[ctr + 1] = grayScale; //G
                    byt[ctr] = grayScale; //R
                    //if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                });
            };
            var butbw = FindViewById<ImageButton>(Resource.Id.butbw);
            butbw.Click += delegate
            {
                SeekBarDialogFragment dialog = new SeekBarDialogFragment(this, 0, 255, 105, Resource.String.DialogPickNoForThreshold, Resource.String.DialogThreshold, Resource.String.DialogThreshold, Resource.String.DialogThreshold);
                dialog.Ok += delegate {
                    ModifyImage((byt, ctr) =>
                    {
                        //create the grayscale version
                        byte grayScale =
                           (byte) ((byt[ctr + 2] * .11) + //B
                           (byt[ctr + 1] * .59) +  //G
                           (byt[ctr] * .3)); //R

                        byte bw = (255 - grayScale > dialog.finProgress) ? (byte) 255 : (byte) 0;

                        //set the new image's pixel to the grayscale version
                        byt[ctr + 2] = bw; //B
                        byt[ctr + 1] = bw; //G
                        byt[ctr] = bw; //R
                                       //if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                    }); };
                dialog.Show(FragmentManager, "seekThreshold");
            };
            var butShiftBin = FindViewById<ImageButton>(Resource.Id.butShiftBin);
            butShiftBin.Click += delegate {
                var dialog = new SeekBarDialogFragment(this, -23, 23, 0,Resource.String.DialogPickNoForShift,Resource.String.DialogShiftBinLeft, Resource.String.DialogShiftDoNothing,Resource.String.DialogShiftBinRight);
                dialog.Ok += delegate {
                    ModifyImage((byt,ctr)=> {
                        //create the shifted version
                        int shift = (byt[ctr] << 16) + (byt[ctr + 1] << 8) + byt[ctr + 2];
                        shift = rightShift(shift, dialog.finProgress);

                        //set the new image's pixel to the grayscale version
                        byt[ctr] = (byte)((shift >> 16) & 255); //R
                        byt[ctr + 1] = (byte)((shift >> 8) & 255); //G
                        byt[ctr + 2] = (byte)(shift & 255); //B
                    });
                };
                dialog.Show(FragmentManager,"seekShiftBin");
            };
            var butShiftHex = FindViewById<ImageButton>(Resource.Id.butShiftHex);
            butShiftHex.Click += delegate {
                var dialog = new SeekBarDialogFragment(this, -5, 5, 0, Resource.String.DialogPickNoForShift, Resource.String.DialogShiftHexLeft, Resource.String.DialogShiftDoNothing, Resource.String.DialogShiftHexRight);
                dialog.Ok += delegate {
                    ModifyImage((byt, ctr) => {
                        //create the shifted version
                        int shift = (byt[ctr] << 16) + (byt[ctr + 1] << 8) + byt[ctr + 2];
                        shift = rightShift(shift, dialog.finProgress * 4);

                        //set the new image's pixel to the grayscale version
                        byt[ctr] = (byte)((shift >> 16) & 255); //R
                        byt[ctr + 1] = (byte)((shift >> 8) & 255); //G
                        byt[ctr + 2] = (byte)(shift & 255); //B
                    });
                };
                dialog.Show(FragmentManager, "seekShiftHex");
            };
            var butInvert = FindViewById<ImageButton>(Resource.Id.butInvert);
            butInvert.Click += delegate {
                ModifyImage((byt, ctr) => {
                    byt[ctr + 2] = (byte)~byt[ctr + 2]; //B
                    byt[ctr + 1] = (byte)~byt[ctr + 1]; //G
                    byt[ctr] = (byte)~byt[ctr]; //R
                });
            };
            var butRGBMono = FindViewById<ImageButton>(Resource.Id.butRGBmono);
            butRGBMono.Click +=delegate{
                SeekBarDialogFragment dialog = new SeekBarDialogFragment(this, 0, 255, 105, Resource.String.DialogPickNoForThreshold, Resource.String.DialogThreshold, Resource.String.DialogThreshold, Resource.String.DialogThreshold);
                dialog.Ok += delegate {
                    ModifyImage((byt, ctr) => {
                        byt[ctr] = (255 - byt[ctr] > dialog.finProgress) ? (byte) 255 : (byte) 0; //R
                        byt[ctr + 1] = (255 - byt[ctr + 1] > dialog.finProgress) ? (byte) 255 : (byte) 0; //G
                        byt[ctr + 2] = (255 - byt[ctr + 2] > dialog.finProgress) ? (byte) 255 : (byte) 0; //B
                    }); };
                dialog.Show(FragmentManager, "seekRGBThreshold");
            };
            var but8bit = FindViewById<ImageButton>(Resource.Id.but8bit);
            but8bit.Click += delegate {
                ModifyImage((byt, ctr) => {
                    byt[ctr + 2] = (byte) fourfive(byt[ctr + 2]); //B
                    byt[ctr + 1] = (byte) fourfive(byt[ctr + 1]); //G
                    byt[ctr] = (byte) fourfive(byt[ctr]); //R
                });
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.MenuEdit, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.home:
                    Finish();
                    return true;
                case Resource.Id.reset:
                    map = Android.Provider.MediaStore.Images.Media.GetBitmap(ContentResolver, uri);
                    imageView.SetImageBitmap(map);
                    return true;
                case Resource.Id.save:
                    return SaveImage();
                case Resource.Id.saveAsCopy:
                    return SaveImage(true);
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            if(map == null)
                 CreateAgain();
            imageView.SetImageBitmap(map);
            
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            map.Recycle();
        }

        private bool SaveImage (bool preventOverride = false) {
            var folder = new File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "image_editor");
            if (!folder.Exists()) folder.Mkdir();
            var filename = this.GetRealPathFromUri(uri);
            filename = filename.Substring(filename.LastIndexOf(File.SeparatorChar));
            var file = new File(folder, filename);
            int count = 0;
            if(preventOverride)
            while (file.Exists())
            {
                count++;
                file = new File(folder, filename.Insert(filename.LastIndexOf('.'), string.Format("({0})", count)));
            }
            if (!file.Exists()) file.CreateNewFile();
            var fullname = file.AbsolutePath;
            try
            {
                using (var stream = new System.IO.FileStream(fullname, System.IO.FileMode.Create))
                {
                    var format = System.Text.RegularExpressions.Regex.IsMatch(filename, "\\w+(.jpg|.jpeg|.jpe|.jfif)", System.Text.RegularExpressions.RegexOptions.IgnoreCase) ? Bitmap.CompressFormat.Jpeg : filename.EndsWith(".png") ? Bitmap.CompressFormat.Png : Bitmap.CompressFormat.Webp;
                    map.Compress(format, 100, stream);
                }
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Uri.FromFile(file));
                SendBroadcast(mediaScanIntent);
                Toast.MakeText(this, "Saved as " + fullname.Substring(fullname.IndexOf(Environment.DirectoryPictures)), ToastLength.Short).Show();
                return true;
            }
            catch (Exception e)
            {
                Log.Warn("ImageEditor", Java.Lang.Throwable.FromException(e));
                Toast.MakeText(this, "Unable to save image", ToastLength.Short).Show();
                return false;
            }
        }

        private async void ModifyImage(Action<byte[], int> procedue){
            if (procedue == null) return;
            if (map == null)
            {
                CreateAgain();
            }
            layoutHandle.Visibility = ViewStates.Gone;
            await System.Threading.Tasks.Task.Run(() => {
                try
                {
                    int size = map.RowBytes * map.Height * 4;
                    ByteBuffer buf = ByteBuffer.Allocate(size);
                    map.CopyPixelsToBuffer(buf);
                    buf.Rewind();
                    byte[] byt = new byte[size];
                    buf.Get(byt);

                    for (int ctr = 0; ctr < size; ctr += 4)
                    {
                        procedue.Invoke(byt, ctr);
                    }
                    ByteBuffer retBuf = ByteBuffer.Wrap(byt);
                    map.CopyPixelsFromBuffer(retBuf);
                    buf.Dispose();
                    retBuf.Dispose();
                    byt = null;
                }
                catch (OutOfMemoryException)
                {
                    RunOnUiThread(() => {
                        Toast.MakeText(this, "Out of memory! Try cleaning up", ToastLength.Short).Show();
                        GC.Collect();
                        Java.Lang.JavaSystem.Gc();
                    });
                }
                catch (Exception) { throw; }


            }).ContinueWith(task => {
                RunOnUiThread(() => {
                    imageView.SetImageBitmap(map);
                    layoutHandle.Visibility = ViewStates.Visible;
                });
            });
        }
        private void CreateAgain () {
            imageView.BuildDrawingCache(false);
            map = imageView.GetDrawingCache(false);
        }

        public int averageColor (int R, int G, int B)
        {
            return (R + G + B) / 3;
        }
        public int groupColor (int average)
        {
            return average < 127 ? 0 : 255;
        }
        public int groupColor (int average, int split)
        {
            return average < split ? 0 : 255;
        }
        public int leftShift(int par, int dight)
        {
            if (dight < 0) return rightShift(par, Math.Abs(dight));
            int temp = par << dight;
            temp = (temp | (par >> (24 - dight)));
            return temp & 0xFFFFFF;
        }
        public int rightShift(int par, int dight)
        {
            if (dight < 0) return leftShift(par, Math.Abs(dight));
            int temp = par >> dight;
            temp = (temp | ((par << (24 - dight)) & 0xFFFFFF));
            return temp & 0xFFFFFF;
        }
        public int fourfive (int target)
        {
            if ((target % 16) < 7)
            {
                target = (int) ((float) target / 255 * 16f) * 16 - 1;
            }
            else
            {
                target = (int) ((float) target / 255 * 16f) * 16 - 1 + 16;
            }
            if (target < 0)
            {
                target = 0;
            }
            if (target > 255)
            {
                target = 255;
            }
            return target;
        }

    }
}