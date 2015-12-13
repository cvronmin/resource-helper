using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace TextureEditor
{
    class TEMain
    {
        public static Dispatcher Dispatcher = Dispatcher.CurrentDispatcher;
        public static void Invoke(Delegate invoke, object[] argObjects = null)
        {
            TEMain.Dispatcher.Invoke(invoke, argObjects);
        }
    }
}
