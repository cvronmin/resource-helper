using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace TextureEditor
{
    class PixelModifyThread
    {
        internal delegate void ModifyFinishEventHandler(Bitmap map);
        internal delegate void ModifyChangingEventHandler(int process, int max);

        public event ModifyFinishEventHandler ModifyFinishEvent;
        public event ModifyChangingEventHandler ModifyChangingEvent;

        private Bitmap bitmap;
        private int width, height, pixels, id;
        private int? arg = null;
        protected void OnModifyFinishEvent(Bitmap bitmap)
        {
            ModifyFinishEventHandler handler = ModifyFinishEvent;
            if (handler != null) TEMain.Invoke(new Action(() => handler(bitmap)));
        }
        protected void OnModifyChangingEvent(int process)
        {
            ModifyChangingEventHandler handler = ModifyChangingEvent;
            if (handler != null) TEMain.Invoke(new Action(() => handler(process , width * height)));
        }
        public PixelModifyThread(Bitmap bitmap, int modID, int? obj = null) {
            this.bitmap = bitmap;
            id = modID;
            arg = obj;
        }
        public void Start() {
            var thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }
        private void Run() {
            width = bitmap.Width;
            height = bitmap.Height;
            pixels = width * height;
            int process = 0;
            switch (id)
            {
                // case 1: Gray the bitmap
                case 1:
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            int tmp = averageColor(bitmap.GetPixel(x, y).R, bitmap.GetPixel(x, y).G, bitmap.GetPixel(x, y).B);
                            bitmap.SetPixel(x, y, Color.FromArgb(bitmap.GetPixel(x, y).A, tmp, tmp, tmp));
                            ++process;
                            OnModifyChangingEvent(process);
                        }
                    }
                    OnModifyFinishEvent(bitmap);
                    break;
                // case 2: seperate the bitmap within Black and White
                case 2:
                    int seperater = arg ?? 127;
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            int tmp = groupColor(averageColor(bitmap.GetPixel(x, y).R, bitmap.GetPixel(x, y).G, bitmap.GetPixel(x, y).B), seperater);
                            bitmap.SetPixel(x, y, Color.FromArgb(bitmap.GetPixel(x, y).A, tmp, tmp, tmp));
                            ++process;
                            OnModifyChangingEvent(process);
                        }
                    }
                    OnModifyFinishEvent(bitmap);
                    break;
                // case 3: shift left
                case 3:
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            int tmp = leftShift(bitmap.GetPixel(x, y).ToArgb() & 0xFFFFFF, arg ?? 8);
                            bitmap.SetPixel(x, y, Color.FromArgb(bitmap.GetPixel(x, y).A, (tmp >> 16) & 255, (tmp >> 8) & 255, tmp & 255));
                            ++process;
                            OnModifyChangingEvent(process);
                        }
                    }
                    OnModifyFinishEvent(bitmap);
                    break;
                // case 4: shift right
                case 4:
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            int tmp = rightShift(bitmap.GetPixel(x, y).ToArgb() & 0xFFFFFF, arg ?? 8);
                            bitmap.SetPixel(x, y, Color.FromArgb(bitmap.GetPixel(x, y).A, (tmp >> 16) & 255, (tmp >> 8) & 255, tmp & 255));
                            ++process;
                            OnModifyChangingEvent(process);
                        }
                    }
                    OnModifyFinishEvent(bitmap);
                    break;
                default:
                    break;
            }
        }
        public int averageColor(int R, int G, int B)
        {
            return (R + G + B) / 3;
        }
        public int groupColor(int average)
        {
            return average < 127 ? 0 : 255;
        }
        public int groupColor(int average, int split)
        {
            return average < split ? 0 : 255;
        }
        public int leftShift(int par, int dight)
        {
            int temp = par << dight;
            temp = (temp | (par >> (Convert.ToString(0xFFFFFF, 2).Length - dight)));
            return temp & 0xFFFFFF;
        }
        public int rightShift(int par, int dight)
        {
            int temp = par >> dight;
            temp = (temp | ((par << Convert.ToString(0xFFFFFF, 2).Length - dight) & (twoDight(dight) << Convert.ToString(0xFFFFFF, 2).Length - dight)));
            return temp & 0xFFFFFF;
        }
        [Obsolete]
        private int leftMove(int par)
        {
            return leftMove(par, 1);
        }
        [Obsolete]
        private int leftMove(int par, int dight)
        {
            int temp = par << dight;
            temp = (temp | (par >> Convert.ToString(par, 2).Length - dight));
            return temp & 0xFFFFFF;
        }
        [Obsolete]
        private int rightMove(int par)
        {
            return rightMove(par, 1);
        }
        [Obsolete]
        private int rightMove(int par, int dight)
        {
            int temp = par >> dight;
            temp = (temp | ((par & temp) << Convert.ToString(par, 2).Length - dight));
            return temp & 0xFFFFFF;
        }
        private int twoDight(int dight)
        {
            int temp = 0;
            for (int i = 0; i < dight; i++)
            {
                temp += (int)Math.Pow(2, i);
            }
            return temp;
        }
    }
}
