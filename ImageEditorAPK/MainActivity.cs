using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ImageEditorAPK
{
    [Activity(Label = "Image Editor", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate {
                Intent getIntent = new Intent(Intent.ActionGetContent);
                getIntent.SetType("image/*");

                //Intent pickIntent = new Intent(Intent.ActionPick, Android.Provider.MediaStore.Images.Media.ExternalContentUri);
                //pickIntent.SetType("image/*");

                Intent chooserIntent = Intent.CreateChooser(getIntent,GetText(Resource.String.PickImage));
                chooserIntent.PutExtra(Intent.ExtraInitialIntents, new Intent[] { getIntent });

                StartActivityForResult(chooserIntent, 0);
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
    }
}

