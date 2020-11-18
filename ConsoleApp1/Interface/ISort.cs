using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface ISort
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr">待排序数组</param>
        /// <returns>已排序数组</returns>
        public int[] bubbleSort(int[] arr);



        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="arr">待排序数组</param>
        /// <returns>已排序数组</returns>
        public int[] selectedSort(int[] arr);

        public string arrToString(int[] arr);
    }
}
