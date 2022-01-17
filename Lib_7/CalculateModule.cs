using System;

namespace Lib_7
{
    public class CalculateModule
    {

        public string Calc(int[] array)
        {
            double pow;
            string result = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                pow = 0;
                if (array[i] < 0)
                {
                    pow = Math.Pow(array[i], 2);
                    result += ($"{array[i]} < 0 | {pow}\n");
                }
            }
            return result; 
        }
    }
}
