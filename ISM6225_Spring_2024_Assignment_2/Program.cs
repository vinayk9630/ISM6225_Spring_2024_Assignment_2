﻿/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            //int[] nums2 = { 0, 1, 0, 3, 12, 4, 1, 4, 0, 6 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            //int[] nums3 = { 0, 1, 2, -2 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            //int binaryInput = 101111;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            //int[] nums5 = { 3, 6, 12, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            //string result = RemoveOccurrences("axxxxyyyyb", "xy");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums.Length == 0) return 0; //if array is empty return 0.
                int k = 1; // Pointer for next unique element position.

                //counting  non-duplicate values 
                for (int i = 1; i < nums.Length; i++) 
                {
                    if (nums[i] != nums[i - 1]) 
                    {
                        nums[k] = nums[i];
                        k++;
                    }
                }
                // Optionally, fill the remainder of the array with 101 for clarity.
                for (int i = k; i < nums.Length; i++)
                {
                    nums[i] = 101;
                }

                return k; // k is the count of unique elements.
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*self reflection: the task was to remove duplicates from a sorted array in-place and return the count of unique elements. 
         * This indeed taught me the importance of array manipulation and understanding pointer manipulation for in-place modifications.
         * The position where different elements were required to be placed was being tracked using a different pointer variable 'k'. 
         * That way, one ensures to have managed to change the array in just one pass without using any extra space, which was allowed per the problem's constraints.
         * The most essential point learned from this question is the importance of traversing techniques more so when the array is sorted. 
         * Thus, it is very important to be able to use the sorted nature of the array to efficiently optimize the operations of removing duplicates. 
         * For example, knowing how an empty array would be a handled edge case will serve in making the code robust.
         * Would be able to further improve it, looking for alternative ways of removing duplicates, 
         * possibly with a different time complexity or space complexity tradeoff—either using a HashSet or using two-pointer techniques. 
         * Generally, this question made me understand the technique of array modification better and how important it is to take into consideration the constraints of the problem in order to have the most effective solutions.


         */

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 2) //// Check if the array is null or has less than 2 elements
                {
                    return new List<int>(nums);
                }

                int insertPosition = 0;
                // Move all non-zero values to the beginning of the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        nums[insertPosition++] = nums[i];
                    }
                }
                // Fill the remaining positions with zeros.
                while (insertPosition < nums.Length)
                {
                    nums[insertPosition++] = 0;
                }
                return new List<int>(nums); //Return the modified array as a list
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*Self-Reflection:

The second part of the problem was related to moving all zeros to the end of the array, ensuring the relative order of non-zero elements in place. It really stressed the importance of array manipulations with proficient traversal techniques.

But suppose I wrote a program to move all the zeroes to the right. I wouldn't be inclined to do this in O.

Returning to this question drives home the concept of in-place pointer manipulation, as in Question 1. It tries to bring out the understanding of how to deal with the elements of a similar array in such a way that the relative position is not changed, i.e. a key problem for manipulation. The only improvement that I could think of would be in the part of manipulating the array. Alternative mechanisms to perform this manipulation—say, two pointer techniques or even changing the loop conditions for more performance—have to be explored. Extra care needs to be taken while handling edge cases, like in this case, where the array contains lesser elements and yet the solution has to remain correct.

In general, this was very good; it really helped one to dig deep into array manipulation and, most importantly, it instigated the understanding of the constraint of the problem while making an algorithm.

I'll continue with the self-reflections for the remaining questions in subsequent responses.

         */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                //sort the array to avoid duplicates.
                Array.Sort(nums);
                List<IList<int>> result = new List<IList<int>>();
                // Iterate through the array to find triplets.
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Ignore duplicate values
                    if (i > 0 && nums[i] == nums[i - 1])
                    {
                        continue;
                    }

                    int left = i + 1, right = nums.Length - 1;
                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];

                        // If the sum of the triplet is zero, add it to the result list.
                        if (sum == 0)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip duplicate elements after finding a valid triplet.
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;

                            // Move pointers inward to look for new potential triplets.
                            left++;
                            right--;
                        }
                        // If the sum is less than zero, increment left pointer.
                        else if (sum < 0)
                        {
                            left++;
                        }
                        // If the sum is more than zero, decrement right pointer.
                        else
                        {
                            right--;
                        }
                    }
                }

                return result; // Return all found triplets that sum up to zero.

            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
 Self-Reflection:
 was to return all unique triplets in an array summing to zero. This question gave me an idea about how I could use the two-pointer technique to find the triplets without finding them repeatedly. The array being sorted is an important step in that it makes finding of the triplets smooth, as one can easily obtain the possible triplet combinations.

So, handling the edge cases is inevitable, either input arrays with fewer elements or duplicate triplets. On the other side, the consideration of problem constraints—for instance, the size of the input array and its range of integer values—assisted very well while making this problem.

One thing that I could work with in this code is trying the other approach that will help me get the triplets. It uses a HashSet so that I do not print any duplicate triplets. I can actually do some improvements to the loop conditions such that it's more efficient. Another thing would be learning what are the time complexities of some of the approaches that help me solve similar problems more efficiently.

This question broadly helped me learn two-pointer techniques, the need for sorting arrays to enable efficient traversals, and identification of the unique combinations broadly.

         */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int maxConsecutiveOnes = 0;
                int currentConsecutiveOnes = 0;

                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        currentConsecutiveOnes++; // Increment count of current consecutive ones
                        maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, currentConsecutiveOnes); // Update max if current streak is larger
                    }
                    else
                    {
                        currentConsecutiveOnes = 0; // Reset current count on encountering a zero
                    }
                }

                return maxConsecutiveOnes;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         * Self-Reflection:

 tasked with finding the maximum number of consecutive ones in a binary array.

This problem further enforces the fact that you have to search the array properly while counting the reference number one being tracked with respect to the continuous number one. In simple words, it means that after iteratively scanning the array and updating the count of one whenever one is continuous, it helped find the maximum number of consecutive ones with no extra space. This will help to give insight into handling extreme cases, like when given an array with very few elements or arrays not containing consecutive ones. Further, this will help to know the computational complexity since the problem constraints will be considered on the input size of the array given. Thus, it will be one of the best features of improving alternative ways of finding consecutive ones, which will bring improvement. This might call for the use of dynamic programming or even bitwise operations, just to check if there will be a faster way of counting. Moreover, understanding some of the implications of time complexity for differing approaches would help in efficient problem-solving. This question really helped to understand the worth of techniques for traversals of arrays and understand it quite vividly to recall the worth of considering problem constraints while deciding to form algorithms for it. Sure, let's continue with the self-reflections for the remaining questions

         */
        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimalValue = 0;
                int baseValue = 1; // 2^0
                // Iterate through binary number.
                while (binary > 0)
                {
                    int lastDigit = binary % 10; // Get the last digit of the binary number
                    binary = binary / 10; // Remove the last digit from the binary number
                    decimalValue += lastDigit * baseValue;
                    baseValue = baseValue * 2; // Move to the next power of 2
                }

                return decimalValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         Self-Reflection: required me to write a program that takes in a binary number and finds the decimal equivalent of that number using normal bitwise operators or the Math.Pow function. Here, I was to do something out of the box, coming up with a conversion using just basic arithmetic operations.

This will be done by extracting the individual binary digits and updating the decimal value iteratively.

Key to understand in that respect was how to handle the edge cases, for example, to cater to varied lengths of binary numbers or even those constraints over the input range. This helped in optimizing the performance of the algorithm due to the consideration of constraints from the problem, such as the size of the given input binary number.

One area I could do better in: explore other avenues of converting binary to decimal, maybe using bitwise operations or recursion to see if there could be any time efficiency improvement or if more input types could be handled. It is on us to try and understand what time complexity is implied fully within different approaches when much more efficiently solving similar problems. This was an important question overall as it provided good practice in implementing arithmetic operations for number conversion and, at the same time, highlighted again the importance of having problem constraints in efficient algorithm design.

*/

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // If the array has less than 2 elements, no gap can exist, so return 0.
                if (nums.Length < 2) return 0;

                // Find the minimum and maximum element in the array.
                int min = nums.Min();
                int max = nums.Max();
                // Calculate the size of each bucket.
                // The maximum gap will be at least as big as (max - min) / (nums.Length - 1).
                int b = Math.Max(1, (max - min) / (nums.Length - 1));
                // Calculate the number of buckets needed.
                int bCount = (max - min) / b + 1;

                // Initialize lists to hold the min and max for each bucket.
                List<int?> bMin = new List<int?>(new int?[bCount]);
                List<int?> bMax = new List<int?>(new int?[bCount]);

                // Place each number in the appropriate bucket.
                foreach (var num in nums)
                {
                    int idx = (num - min) / b;
                    if (!bMin[idx].HasValue || num < bMin[idx]) bMin[idx] = num;
                    if (!bMax[idx].HasValue || num > bMax[idx]) bMax[idx] = num;
                }
                // Iterate through the buckets to find the maximum gap.
                int maxGap = 0;
                int previousMax = min;
                for (int i = 0; i < bCount; i++)
                {
                    if (!bMin[i].HasValue) continue;
                    maxGap = Math.Max(maxGap, bMin[i].Value - previousMax);
                    previousMax = bMax[i].Value;
                }

                return maxGap; //return maximum gap
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         self reflection: tasked with finding the maximum difference between successive elements in a sorted array.

Here is where I got the idea of bucketing and pigeonhole distribution in order to calculate the maximum gap efficiently.

I can easily find the maximum difference within the whole range of elements if the whole is divided into buckets and the minimum and maximum values within one bucket are treated with linear time complexity.

It further elaborated on how to design a solution that understands how to handle edge cases, for example, very few elements in arrays or all elements in arrays being the same, in order to design a correct and efficient solution. It also further helps check the limits presented by the problem, for example, the size of the input array that could make the algorithm more optimized.

One area of this work that can be improved is the approach followed for the determination of the maximum gap. That is to say, it considers either the other strategies of the bucket or the sorting strategies to further gain efficiency or apply in the scenarios of their use. Apart from that, time complexity implications of various approaches would help in solving problems efficiently.

In short, this question is in fact attempting to bring out valuable insights into techniques of bucketing and reiterates the need to keep the constra
         */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Sort the array in non-ascending order to compare the 1st array number with the sum of other 2
                Array.Sort(nums, (a, b) => b.CompareTo(a)); 

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // sum of any two sides should be greater than 3rd side to form a triangle
                    if (nums[i] < nums[i + 1] + nums[i + 2])
                    {
                        // These sides can form a triangle, so return their perimeter
                        return nums[i] + nums[i + 1] + nums[i + 2];
                    }
                }
                // No valid triangle found
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         self reflection: Given an array A of positive integers, find a maximum value of the perimeter that can be obtained from a triangle having elements of the array as its sides. In this problem, I needed to search exhaustively to find valid triangles in the most efficient way. I needed to sort the array in non-decreasing order and then traverse to see what a valid side for a triangle would be, whereby I'd be able to do the needful to find out the largest possible perimeter.

And that is, understanding how such edge cases are to be handled, like in the case of arrays that contain fewer elements than are necessary for forming a valid triangle combination, and many others would help in coming up with a proper and efficient solution.

In order to help optimize the performance of this algorithm, we considered a range of constraints, such as the size of the input array and the range within which the integers can take values.

Where I possibly could have done better is in exploring other methods that may lead to finding valid combinations of triangles; for example, looking at sorting methods or some mathematical properties of triangles that may likely eliminate some redundancies or make the code more generic. In addition, the ability to deduce time complexity implications over those alternatives will help in solving similar problems better.

In all, this question gave very good practice for finding valid combinations and reinforced how important problem constraints are when designing algorithms for obtaining an efficient solution.

         */

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Find the index of the first occurrence of 'part' in 's'
                int index = s.IndexOf(part);

                // Continue looping as long as 'part' is found within 's'
                while (index != -1)
                {
                    // Remove the found occurrence of 'part' from 's'
                    s = s.Remove(index, part.Length);
                    // Search for the next occurrence of 'part'
                    index = s.IndexOf(part);
                }

                return s; // return the final string 's' after removing all occurrences of 'part' from 's'.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*Self-Reflection:

One was to remove all occurrences of a given substring from a supplied string. It required very efficient techniques of string manipulation, as it was supposed to process successively the supplied string for removing all occurrences of the substring from it. I used the IndexOf function and string manipulation techniques, so I was able to remove it in place without taking extra space.

It was very important in order to understand the handlings of some edge cases: either strings of different length or substrings of different occurrence, in coming up with the correct and optimal solution design. Further, the given constraints of the problem also helped optimize the performance of the algorithm through input string length consideration. An area where I may improve would be considering experimenting with various methods of removing substrings from the regular expression or string slicing approach where possible, if they are going to prove more efficient or come out with different kinds of scenarios. Understandably, time complexity implications would be quite important to be much more efficient in this regard for many other similar problems in problem-solving. All in all, this question was quite a good exercise to practice string-manipulation techniques and emphasized well how important it is to take into account the constraints of a problem to come up with algorithms. After these are self-reflections on the major learnings and considerations of each question, revealing strategies of problem-solving and principles of algorithm design.
         */

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}