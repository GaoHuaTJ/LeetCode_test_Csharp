using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            //Day2 day2_test = new Day2(1534236469);
            //day2_test.Test();
            //Console.ReadKey();

            //第三天测试
            //Day3 day3Test=new Day3(101);
            //Console.WriteLine(day3Test.Test());
            //Console.ReadKey();

            //第四天测试；太简单了。不想多写
            //int[] answer =new []{1,2,3};
            //int[] guess = new[] { 3, 2, 3 };
            //Console.WriteLine($"猜中了{Day4.game(guess, answer)}次");

            //第四天还是太简单了
            string J = "Aa";
            string S = "aAAbbbb";
            Console.WriteLine($"{Day5.NumJewelsInStones(J, S)}");

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

        //逆序输出
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
                    if(ans>Int32.MaxValue)//如果是大于int32的最大值，返回0
                    {
                        return 0;
                    }
                    n--;
                }
                return isNegative == true ? -Convert.ToInt32(ans):Convert.ToInt32(ans);
            }
        }

        //回文数
        //判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。
        private class Day3
        {
            public Day3(int x)
            {
                this._x = x;
            }

            private int _x;

            /// <summary>
            /// 测试函数
            /// </summary>
            /// <param name="x">输入要测试的整数</param>
            /// <returns>输出是不是回文数</returns>
            public  bool Test()
            {
                Console.WriteLine(IsPalindrome(_x) ? $"{_x}是回文数" : $"{_x}不是回文数");
                return IsPalindrome(_x) ;
            }

            /// <summary>
            /// 输入一个整数，如果是回文数，返回true，否则false
            /// </summary>
            /// <param name="x">输入整数</param>
            /// <returns>输出bool</returns>
            private static  bool IsPalindrome(int x)
            {
                if (x<0)
                {
                    return false;//负数没有回文数
                }
                else if (x>=0 & x<10)//个位数全部都是回文数
                {
                    return true;
                }
                else
                {
                    int n = 1;
                    //记录是几位数
                    while (x / Math.Pow(10, n)>=10)
                    {
                        n++;
                    }
                    List<int> numList = new List<int>();//存储每一位的数字
                    while (n>=0)
                    {
                        int temp = (int)(x / (Math.Pow(10, n)));
                        numList.Add(temp);
                        x -= temp * ((int)Math.Pow(10, n));
                        n--;
                    }
                    List<int> numReverseList = new List<int>(numList.ToArray());//存储反转元素
                    numReverseList.Reverse();//进行反转
                    return !numList.Where((t, i) => t != numReverseList[i]).Any();
                }
            }
        }
        
        
        //猜数字
        //小A 和 小B 在玩猜数字。小B 每次从 1, 2, 3 中随机选择一个，小A 每次也从 1, 2, 3 中选择一个猜。他们一共进行三次这个游戏，请返回 小A 猜对了几次？
        //输入的guess数组为 小A 每次的猜测，answer数组为 小B 每次的选择。guess和answer的长度都等于3
        class Day4
        {
            public static int game(int[] guess, int[] answer)
            {
                //记录初始的记录数值
                int times=0;
                for (int i = 0; i < answer.Length; i++)
                {
                    if (answer[i]==guess[i])
                    {
                        times++;
                    }
                }
                return times;
            }
        }

        //宝石与石头
        class Day5
        {
            /// <summary>
            ///判断石头中有多少个是钻石（区分大小写）
            /// </summary>
            /// <param name="J">钻石代码</param>
            /// <param name="S">石头代码</param>
            /// <returns></returns>
            public static int NumJewelsInStones(string J, string S)
            {
                return J.Sum(j => S.Count(s => j == s));
            }
        }
    }
}