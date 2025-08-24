using System;
using System.Collections.Generic;

namespace HelloWorld{
    class Program{
        static void Main(string[] args){

            int []nums = {1, 6, 12, 4, 1, 4};
            int target = 8;

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i ++){
                if (! map.ContainsKey(nums[i]))
                    map[nums[i]] = 0;

                map[nums[i]] ++;

                int need = target - nums[i];
                if (map.ContainsKey(need)){
                    if (need == nums[i] && map[nums[i]] < 2) // A number shouldn't be paired with itself unless there is another occurance of it
                        continue;
                    Console.WriteLine($"{nums[i]}, {need}");
                }
            }
        }
    }

}