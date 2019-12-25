﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LeetCode_test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //第一天测试
            //Day1 day1_test=new Day1( { 3, 2, 3 });
            //day1_test.Test();

            //第二天测试
            Day2 day2_test = new Day2(1534236469);
            day2_test.Test();
            Console.ReadKey();
        }

        //两数之和：
        //给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
        //你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
        //示例:
        //给定 nums = [2, 7, 11, 15], target = 9
        //因为 nums[0] + nums[1] = 2 + 7 = 9
        //所以返回[0, 1]
        private class Day1
        {

            /// <summary>
            /// 输入待测试的整数数组
            /// </summary>
            /// <param name="nums"></param>
            Day1(int[] nums)
            {
                this.nums = nums;
            }

            private int[] nums;

            //测试
            public void Test()
            {
                int target = 6;
                foreach (var item in TwoSum(nums, target))
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }

            //暴力法实现
            public static int[] TwoSum(int[] nums, int target)
            {
                Console.WriteLine("暴力法测试");
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
                throw new ArgumentException("输入参数有问题");
            }

            //哈希表实现
            //不能解决数组中有重复的情况
            public static int[] TwoSumHashTable(int[] nums, int target)
            {
                Console.WriteLine("哈希表实现");
                Hashtable ht = new Hashtable();
                for (int i = 0; i < nums.Length; i++)
                {
                    ht.Add(nums[i], i);
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (ht.ContainsKey(complement))
                    {
                        if (((int)ht[complement] != i))
                        {
                            return new int[] { i, (int)ht[complement] };
                        }
                    }
                }
                throw new ArgumentException("参数输入有误");
            }
        }

        //给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。
        //示例 1:
        //输入: 123
        //输出: 321
        //示例 2:
        //输入: -123
        //输出: -321
        //示例 3:
        //输入: 120
        //输出: 21
        private class Day2
        {
            /// <summary>
            /// 输入的测试值
            /// </summary>
            /// <param name="x">测试值int</param>
            public Day2(int x)
            {
                this.x = x;
            }

            private readonly int x;//测试值
            
            public void Test()
            {
                Console.WriteLine(x);
                Console.WriteLine(Reverse(x));
            }

            /// <summary>
            /// 反转函数
            /// </summary>
            /// <param name="x">输入的是int</param>
            /// <returns>返回的是其反转数值</returns>
            private static int Reverse(int x)
            {
                int n = 1;//数字的起始位数
                bool isNegative = false;
                List<Int32> ansList = new List<int>();
                if (x < 10 & x > (-10))//判断为个位数
                {
                    return x;
                }
                else
                {
                    if (x < 0)//判断是否为负数，除各位数以外的负数
                    {
                        x = -x;
                        isNegative = true;
                    }
                    while (x / (Math.Pow(10, n)) >= 10)
                    {
                        n++;
                    }
                    while (n >= 0)
                    {
                        int temp = (int)(x / (Math.Pow(10, n)));
                        ansList.Add(temp);
                        x -= temp * ((int)Math.Pow(10, n));
                        n--;
                    }
                }
                ansList.Reverse();
                if (ansList.Count==10&ansList[0]==9)//C#中9 * 1000,000,000 = 410065408， 不等于9,000,000,000. 但是 2 * 1,000,000,000 = 2,000,000,000.
                {
                    return 0;
                }
                double ans = 0;//防止溢出后续无法比较，定义为double
                n = ansList.Count;
                foreach (var item in ansList)
                {
                    ans =ans+ item * (int)Math.Pow(10, n - 1);
                    if(ans>Int32.MaxValue)
                    {
                        return 0;
                    }
                    n--;
                }
                return isNegative == true ? -Convert.ToInt32(ans):Convert.ToInt32(ans);
            }
        }
    }
}