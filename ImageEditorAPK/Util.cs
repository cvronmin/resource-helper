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
using Java.Nio;
using Android.Provider;
using Android.Database;

namespace ImageEditorAPK
{
    static class Util
    {
        public static byte[] ToByteArray (this ByteBuffer buf) {
            IntPtr classHandle = JNIEnv.FindClass("java/nio/ByteBuffer");
            IntPtr methodId = JNIEnv.GetMethodID(classHandle, "array", "()[B");
            IntPtr resultHandle = JNIEnv.CallObjectMethod(buf.Handle, methodId);
            byte[] result = JNIEnv.GetArray<byte>(resultHandle);
            JNIEnv.DeleteLocalRef(resultHandle);
            return result;
        }

        public static string GetRealPathFromUri(this Activity activity, Android.Net.Uri uri) {
            string[] filePathColumn = { MediaStore.Images.ImageColumns.Data };
            using (ICursor cursor = activity.ContentResolver.Query(uri, filePathColumn, null, null, null))
            {
                if(cursor != null)
                if (cursor.MoveToFirst())
                {
                    int columnIndex = cursor.GetColumnIndex(filePathColumn[0]);
                    string yourRealPath = cursor.GetString(columnIndex);
                        return yourRealPath;
                }
                else
                {
                        return "";
                    //boooo, cursor doesn't have rows ...
                }
            }
            return "";
        }
    }
}