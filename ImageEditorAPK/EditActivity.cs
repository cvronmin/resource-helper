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
using System.Drawing;
using Android.Graphics;
using Java.Nio;

namespace ImageEditorAPK
{
    [Activity(Label = "Editor")]
    public class EditActivity : Activity
    {
        ImageView imageView;
        Bitmap map;
        
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Edit);

            imageView = FindViewById<ImageView>(Resource.Id.imageView);
            imageView.SetImageURI(Intent.GetParcelableExtra("Image").JavaCast<Android.Net.Uri>());
            CreateAgain();
            var butGrey = FindViewById<Button>(Resource.Id.butGrey);
            butGrey.Click += delegate {
                if (map == null) {
                    //Toast.MakeText(this, "BitMap == null!", ToastLength.Long).Show();
                    CreateAgain();
                }
                butGrey.Enabled = false;
                int size = map.RowBytes * map.Height * 4;
                ByteBuffer buf = ByteBuffer.Allocate(size);
                map.CopyPixelsToBuffer(buf);
                byte[] byt = buf.ToByteArray();
                
                for (int ctr = 0; ctr < size; ctr += 4)
                {
                    //access array in form of argb. for ex. byt[0] is 'r', byt[1] is 'g' and so on..
                    //create the grayscale version
                    byte grayScale =
                       (byte) ((byt[ctr + 2] * .11) + //B
                       (byt[ctr + 1] * .59) +  //G
                       (byt[ctr] * .3)); //R

                    //set the new image's pixel to the grayscale version
                    byt[ctr + 2] = grayScale; //B
                    byt[ctr + 1] = grayScale; //G
                    byt[ctr] = grayScale; //R
                    //if (sw > 3) nRow[x * sw + 3] = oRow[x * sw + 3]; //A
                }
                ByteBuffer retBuf = ByteBuffer.Wrap(byt);
                map.CopyPixelsFromBuffer(retBuf);

                imageView.SetImageBitmap(map);
                
                butGrey.Enabled = true;
            };
        }
        private void CreateAgain () {
            imageView.BuildDrawingCache(false);
            map = imageView.GetDrawingCache(false);
        }
        private void butGray_Click (object sender, EventArgs e)
        {
            //buttonGray.Enabled = false;
            

            //buttonGray.Enabled = true;
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
    }
}