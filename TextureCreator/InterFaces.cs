using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextureCreator
{
    interface Geometry
    {
        void draw(int a, int r, int g, int b);
    }
    public interface Former {
        void new16file();
        void new32file();
        void new64file();
    }
}
