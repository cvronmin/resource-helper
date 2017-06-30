using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CRMKJK
{
    public class CRMRandom : Random
    {
        private const int MBIG = Int32.MaxValue;
        private const int MSEED = 161803398;
        private const int MZ = 0;


        //
        // Member Variables
        //
        private int inext;
        private int inextp;
        public int[] SeedArray = new int[56];

        public CRMRandom() : this(Environment.TickCount) { }
        public CRMRandom(int Seed)
        {
            int ii;
            int mj, mk;

            //Initialize our Seed array.
            //This algorithm comes from Numerical Recipes in C (2nd Ed.)
            int subtraction = (Seed == Int32.MinValue) ? Int32.MaxValue : Math.Abs(Seed);
            mj = MSEED - subtraction;
            SeedArray[55] = mj;
            mk = 1;
            for (int i = 1; i < 55; i++)
            {  //Apparently the range [1..55] is special (Knuth) and so we're wasting the 0'th position.
                ii = (21 * i) % 55;
                SeedArray[ii] = mk;
                mk = mj - mk;
                if (mk < 0) mk += MBIG;
                mj = SeedArray[ii];
            }
            for (int k = 1; k < 5; k++)
            {
                for (int i = 1; i < 56; i++)
                {
                    SeedArray[i] -= SeedArray[1 + (i + 30) % 55];
                    if (SeedArray[i] < 0) SeedArray[i] += MBIG;
                }
            }
            inext = 0;
            inextp = 31;
            Seed = 1;
        }
        protected override double Sample()
        {
            //Including this division at the end gives us significantly improved
            //random number distribution.
            int v = InternalSample();
            return v * (1.0 / MBIG);
        }

        private int InternalSample()
        {
            int retVal;
            int locINext = inext;
            int locINextp = inextp;

            if (++locINext >= 56) locINext = 1;
            if (++locINextp >= 56) locINextp = 1;

            retVal = SeedArray[locINext] - SeedArray[locINextp];

            if (retVal == MBIG)
                retVal--;
            if (retVal < 0)
                retVal += MBIG;

            SeedArray[locINext] = retVal;

            inext = locINext;
            inextp = locINextp;

            return retVal;
        }

        private double GetSampleForLargeRange()
        {
            // The distribution of double value returned by Sample 
            // is not distributed well enough for a large range.
            // If we use Sample for a range [Int32.MinValue..Int32.MaxValue)
            // We will end up getting even numbers only.

            int result = InternalSample();
            // Note we can't use addition here. The distribution will be bad if we do that.
            bool negative = (InternalSample() % 2 == 0);  // decide the sign based on second sample
            if (negative)
            {
                result = -result;
            }
            double d = result;
            d += (Int32.MaxValue - 1); // get a number in range [0 .. 2 * Int32MaxValue - 1)
            d /= 2 * (uint)Int32.MaxValue - 1;
            return d;
        }

        public override int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue");
            }
            Contract.EndContractBlock();

            long range = (long)maxValue - minValue;
            if (range <= Int32.MaxValue)
            {
                return ((int)Math.Round(Sample() * range) + minValue);
            }
            else
            {
                return (int)((long)Math.Round(GetSampleForLargeRange() * range) + minValue);
            }
        }

        public double NextDouble(int minValue, int maxValue) {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue");
            }
            Contract.EndContractBlock();

            long range = (long)maxValue - minValue;
            if (range <= Int32.MaxValue)
            {
                return Sample() * range + minValue;
            }
            else
            {
                return GetSampleForLargeRange() * range + minValue;
            }
        }
    }

    public class RandomUtils
    {
        private const int MBIG = Int32.MaxValue;
        private const int MSEED = 161803398;
        private const int MZ = 0;

        public static int GetSeed(int minValue, int maxValue, int[] results)
        {
            long range = (long)maxValue - minValue;
            double[] samples = new double[results.Length];
            for (int i = 0; i < results.Length; i++)
            {
                samples[i] = (float)(results[i] - minValue) / range;
            }
            int inext, locINext = 0;
            int inextp, locINextp = 21;
            int[] SeedArray = new int[56];
            for (int i = 0; i < samples.Length; i++)
            {
                var a = (int)(samples[i] / (1.0 / MBIG));
                if (++locINext >= 56) locINext = 1;
                if (++locINextp >= 56) locINextp = 1;

                SeedArray[locINext] = a;
            }
            for (int i = samples.Length - 1; i >= 0; i--)
            {
                var a = (int)(samples[i] / (1.0 / MBIG));
                //locINext = (1 + i % 56) % 55 + 1;
                //locINextp = (22 + i % 56) % 55 + 1;

                SeedArray[locINext] = a;
                if (a - MBIG < 0) a -= MBIG;
                if (a == MBIG - 1) a++;

                SeedArray[locINextp] = SeedArray[locINext] - a;

                if (--locINext <= 0) locINext = 55;
                if (--locINextp <= 0) locINextp = 55;
                inext = locINext;
                inextp = locINextp;
            }
            for (int k = 1; k < 5; k++)
            {
                for (int i = 55; i > 0; i--)
                {
                    if (SeedArray[i] - MBIG < 0) SeedArray[i] -= MBIG;
                    SeedArray[i] += SeedArray[1 + (i + 30) % 55];
                }
            }
            int Seed;
            int mj;
            mj = SeedArray[55];
            int subtraction = MSEED - mj;
            Seed = subtraction == int.MaxValue ? int.MinValue : subtraction;
            return Seed;
        }
        public static int GetSeed(int minValue, int maxValue, double[] results)
        {
            long range = (long)maxValue - minValue;
            double[] samples = new double[results.Length];
            for (int i = 0; i < results.Length; i++)
            {
                samples[i] = (results[i] - minValue) / range;
            }
            int locINext = 0;
            int locINextp = 31;
            int[] SeedArray = new int[56];
            for (int i = 0; i < samples.Length; i++)
            {
                var a = (int)(samples[i] / (1.0 / MBIG));
                if (++locINext >= 56) locINext = 1;
                if (++locINextp >= 56) locINextp = 1;

                SeedArray[locINext] = a;
            }
            for (int i = samples.Length - 1; i >= 0; i--)
            {
                var retVal = SeedArray[locINext];

                if ((retVal/* + 1*/) == MBIG)
                    retVal/*++*/--;
                if (retVal/* - MBIG*/ < 0) retVal /*-*/+= MBIG;

                SeedArray[locINext] = SeedArray[locINextp] + retVal;

                if (--locINext <= 0) locINext = 55;
                if (--locINextp <= 0) locINextp = 55;
            }
            for (int k = 1; k < 5; k++)
            {
                for (int i = 55; i > 0; i--)
                {
                    SeedArray[i] += SeedArray[1 + (i + 30) % 55];
                    if (SeedArray[i]/* - MBIG */< 0) SeedArray[i] /*-*/+= MBIG;
                }
            }
            int Seed;
            int mj;
            mj = SeedArray[55];
            int subtraction = MSEED - mj;
            Seed = subtraction == int.MaxValue ? int.MinValue : (subtraction < 0 ? subtraction + MBIG : subtraction);
            return Seed;
        }

    }
}
