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
using Environment = Android.OS.Environment;
using Java.IO;
using Java.Util;

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

        public static string GetRealPathFromUri (this Activity activity, Android.Net.Uri uri)
        {
            string[] filePathColumn = { MediaStore.Images.ImageColumns.Data };
            using (ICursor cursor = activity.ContentResolver.Query(uri, filePathColumn, null, null, null))
            {
                if (cursor != null)
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
        public static string GetRealPathFromUri (this Activity activity, string uri)
        {
            string[] column = { MediaStore.Images.ImageColumns.Data };
            string id = uri.Split(':')[1];

            // where id is equal to             
            string sel = MediaStore.Images.ImageColumns.Id + "=?";
            using (ICursor cursor = activity.ContentResolver.
                                      Query(MediaStore.Images.Media.ExternalContentUri,
                                      column, sel, new string[] { id }, null))
            {
                int columnIndex = cursor.GetColumnIndex(column[0]);

                if (cursor.MoveToFirst())
                {
                    return cursor.GetString(columnIndex);
                }
                else
                {
                    return id;
                }
            }
        }

        public static bool IsExternalStorageDocument (Android.Net.Uri uri)
        {
            return "com.android.externalstorage.documents".Equals(uri.Authority);
        }
        public static HtmlAgilityPack.HtmlAttribute GetAttribute(this HtmlAgilityPack.HtmlNode node, string name)
        {
            return node.Attributes.Single(arr => arr.Name.Equals(name));
        }
    }
    public class ExternalStorage
    {

        public static readonly string SdCard = "sdCard";
    public static readonly string ExternalSdCard = "externalSdCard";

    /**
     * @return True if the external storage is available. False otherwise.
     */
    public static bool IsAvailable()
        {
            string state = Environment.ExternalStorageState;
            if (Environment.MediaMounted.Equals(state) || Environment.MediaMountedReadOnly.Equals(state))
            {
                return true;
            }
            return false;
        }

        public static string GetSdCardPath()
        {
            return Environment.ExternalStorageDirectory.Path + "/";
        }

        /**
         * @return True if the external storage is writable. False otherwise.
         */
        public static bool IsWritable()
        {
            string state = Environment.ExternalStorageState;
            if (Environment.MediaMounted.Equals(state))
            {
                return true;
            }
            return false;

        }

        /**
         * @return A map of all storage locations available
         */
        public static Dictionary<string, File> GetAllStorageLocations()
        {
            Dictionary<string, File> map = new Dictionary<string, File>(10);

            List<string> mMounts = new List<string>(10);
            List<string> mVold = new List<string>(10);
            mMounts.Add("/mnt/sdcard");
            mVold.Add("/mnt/sdcard");

            try
            {
                File mountFile = new File("/proc/mounts");
                if (mountFile.Exists())
                {
                    Scanner scanner = new Scanner(mountFile);
                    while (scanner.HasNext)
                    {
                        string line = scanner.NextLine();
                        if (line.StartsWith("/dev/block/vold/"))
                        {
                            string[] lineElements = line.Split(' ');
                            string element = lineElements[1];

                            // don't add the default mount path
                            // it's already in the list.
                            if (!element.Equals("/mnt/sdcard"))
                                mMounts.Add(element);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }

            try
            {
                File voldFile = new File("/system/etc/vold.fstab");
                if (voldFile.Exists())
                {
                    Scanner scanner = new Scanner(voldFile);
                    while (scanner.HasNext)
                    {
                        string line = scanner.NextLine();
                        if (line.StartsWith("dev_mount"))
                        {
                            string[] lineElements = line.Split(' ');
                            string element = lineElements[2];

                            if (element.Contains(":"))
                                element = element.Substring(0, element.IndexOf(":"));
                            if (!element.Equals("/mnt/sdcard"))
                                mVold.Add(element);
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }


            for (int i = 0; i < mMounts.Count; i++)
            {
                string mount = mMounts[i];
                if (!mVold.Contains(mount))
                    mMounts.RemoveAt(i--);
            }
            mVold.Clear();

            List<string> mountHash = new List<string>(10);

            foreach (string mount in mMounts)
            {
                File root = new File(mount);
                if (root.Exists() && root.IsDirectory && root.CanWrite())
                {
                    File[] list = root.ListFiles();
                    String hash = "[";
                    if (list != null)
                    {
                        foreach (File f in list)
                        {
                            hash += f.Name.GetHashCode() + ":" + f.Length() + ", ";
                        }
                    }
                    hash += "]";
                    if (!mountHash.Contains(hash))
                    {
                        string key = SdCard + "_" + map.Count;
                        if (map.Count == 0)
                        {
                            key = SdCard;
                        }
                        else if (map.Count == 1)
                        {
                            key = ExternalSdCard;
                        }
                        mountHash.Add(hash);
                        map.Add(key, root);
                    }
                }
            }

            mMounts.Clear();

            if (map.Count == 0)
            {
                map.Add(SdCard, Environment.ExternalStorageDirectory);
            }
            return map;
        }


    }
}