using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TextureCreator
{
    class Recorder
    {
        Bitmap[] recordMap = new Bitmap[10];

        public void addRecord(Bitmap newRecord) { 
            if(this.countRecord() >= recordMap.Length){
                for (int i = 1; i < recordMap.Length; i++)
                {
                    recordMap.SetValue(recordMap.GetValue(i), i-1);
                }
                recordMap.SetValue(newRecord, 9);
            }
            else
            {
                recordMap.SetValue(newRecord, this.countRecord());
            }
        }
        public void saveHistory() {
            for (int i = 0; i < (this.countRecord()); i++)
            {
                recordMap[i].Save(Environment.CurrentDirectory + "\\" + "history" + i + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        public Bitmap getRecord() {
            return recordMap[this.countRecord() - 1];
        }
        public Bitmap getRecord(int record) {
            return recordMap[record];
        }
        public int getRecordCount() {
            return recordMap.Count();
        }
        private int countRecord() {
            int count = 0;
            for (int i = 0; i < recordMap.Length; i++)
            {
                if(recordMap[i] != null){
                    ++count;
                }
            }
            return count;
        }
    }
}
