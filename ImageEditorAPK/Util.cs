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
    }
}