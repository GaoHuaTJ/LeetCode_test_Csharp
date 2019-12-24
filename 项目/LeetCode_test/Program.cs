using System;
using System.Collections;

namespace LeetCode_test
{
    internal class Program
    {
        //两数之和：
        //给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
        //你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
        //示例:
        //给定 nums = [2, 7, 11, 15], target = 9
        //因为 nums[0] + nums[1] = 2 + 7 = 9
        //所以返回[0, 1]
        private static void Main(string[] args)
        {
            int[] nums = { 3, 2, 3 };
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
            Hashtable ht = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                ht.Add(nums[i],i );
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (ht.ContainsKey(complement))
                {
                    if (((int)ht[complement] != i))
                    {
                        return new int[]{i,(int)ht[complement]};
                    }
                }
            }
            throw new ArgumentException("参数输入有误");
        }
    }
}