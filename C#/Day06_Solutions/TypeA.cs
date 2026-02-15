using System;

namespace gg
{
    public class TypeA
    {
        private int F;       
        internal int G;      
        public int H;        

        public TypeA(int f, int g, int h)
        {
            F = f;
            G = g;
            H = h;
        }

        public int GetF()
        {
            return F;
        }
    }
}
