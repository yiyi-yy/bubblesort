using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Implement
{
    public class ImplSort : ISort
    {
        public int[] bubbleSort(int[] arr)
        {
            try
            {
                if (arr==null||arr.Length==0||arr.Length==1)
                {
                    return arr;
                }
                for (int i = 0; i < arr.Length-1; i++)
                {
                    for (int j = 0; j < arr.Length-i-1; j++)
                    {
                        if (arr[j]>arr[j+1])
                        {
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = arr[j];
                        }
                    }
                }
                return arr;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
