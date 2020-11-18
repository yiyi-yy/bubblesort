using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Implement
{
    public class ImplSort : ISort
    {
        public string arrToString(int[] arr)
        {

            if (arr == null || arr.Length == 0 )
            {
                return string.Empty;
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in arr)
            {
                stringBuilder.Append(item+",");
            }
            string result = stringBuilder.ToString().Substring(0,stringBuilder.Length-1);
            return result;
        }

        public int[] bubbleSort(int[] arr)
        {
            try
            {
                if (arr==null||arr.Length==0||arr.Length==1)
                {
                    return arr;
                }
                //第一层循环，计算一共排n次
                for (int i = 0; i < arr.Length-1; i++)
                {
                    //第二层循环，将每个数字与他后面的数字比较，如果大则交换，所以第一层循环的前n位数字就会一直有序，只要比较后面的待排序所以要减掉i
                    for (int j = 0; j < arr.Length-i-1; j++)
                    {
                        if (arr[j]>arr[j+1])
                        {
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
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

        public int[] selectedSort(int[] arr)
        {
            try
            {
                if (arr == null || arr.Length == 0 || arr.Length == 1)
                {
                    return arr;
                }
                for (int i = 0, k = 0; i < arr.Length - 1; i++, k = i)
                {
                    for (int j = i+1; j < arr.Length; j++)
                    {
                        if (arr[k] > arr[j])
                        {
                            k = j;
                        }
                    }
                    if (k!=i)
                    {
                        int temp = arr[i];
                        arr[i] = arr[k];
                        arr[k] = temp;
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
