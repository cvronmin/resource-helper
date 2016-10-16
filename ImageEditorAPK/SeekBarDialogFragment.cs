using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ImageEditorAPK
{
    public class SeekBarDialogFragment : DialogFragment
    {
        private readonly Context _context;
        private readonly int _min, _max, _current, _titleId,_leftId,_middleId,_rightId;
        public int finProgress { get; set; }
        public delegate void EventOk(object sender,EventArgs e);
        public event EventOk Ok;

        public SeekBarDialogFragment(Context context, int min, int max, int current, int titleid,int leftid,int middleid,int rightid)
        {
            _context = context;
            _min = min;
            _max = max;
            _current = current;
            _titleId = titleid;
            _leftId = leftid;
            _middleId = middleid;
            _rightId = rightid;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var inflater = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);
            var view = inflater.Inflate(Resource.Layout.SeekBarDialog, null);
            var seek = view.FindViewById<SeekBar>(Resource.Id.seekBar1);
            var text = view.FindViewById<TextView>(Resource.Id.textView2);
            seek.Max = Math.Abs(_min) + Math.Abs(_max);
            seek.ProgressChanged += delegate {
                int processed = seek.Progress + _min;
                if (processed > 0)
                {
                    text.Text = string.Format(GetText(_rightId), Math.Abs(processed));
                }
                else if (processed < 0)
                {
                    text.Text = string.Format(GetText(_leftId), Math.Abs(processed));
                }
                else
                {
                    text.Text = string.Format(GetText(_middleId), Math.Abs(processed));
                }
            };
            seek.Progress = _current + Math.Abs(_min);
            var dialog = new AlertDialog.Builder(_context);
            dialog.SetTitle(_titleId);
            dialog.SetView(view);
            dialog.SetNegativeButton(Android.Resource.String.Cancel, (s, a) => { });
            dialog.SetPositiveButton(Android.Resource.String.Ok, (s, a) => { finProgress = seek.Progress + _min; Ok?.Invoke(s,a); });
            return dialog.Create();
        }
        
    }
}