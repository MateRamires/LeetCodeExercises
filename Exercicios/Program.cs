using Exercicios;
using Exercicios.Array___Hash;
using Exercicios.LinkedList;
using Exercicios.Stack;
using Exercicios.Two_Pointers;

//Array & Hashing
ArayHashExercises ExerciseArray = new ArayHashExercises();

//Ex 217
ExerciseArray.HasDuplicate([1, 2, 6, 8, 3]);

//Ex 242
ExerciseArray.IsAnagram("abc", "cba");

//Ex 1
ExerciseArray.TwoSum([1,2,7,1,5], 7);

//Ex 49
ExerciseArray.GroupAnagram(["eat", "tea", "tan", "ate", "nat", "bat"]);

//Ex 347
ExerciseArray.TopKFrequent([1, 1, 1, 2, 2, 3], 2);

//Ex 271
ExerciseArray.Enconde(new List<string>{"teste", "aaeee"});

//Ex 13
ExerciseArray.RomanToInt("XIV");

//Ex 1941
ExerciseArray.AreOccurrencesEqual("aabbb");

//Ex 2068
ExerciseArray.CheckAlmostEquivalent("abcdeef", "abaaaacc");

//Ex 36
ExerciseArray.IsValidSudoku(new char[][] {
    new char[] {'5','3','.','.','7','.','.','.','.'},
    new char[] {'6','.','.','1','9','5','.','.','.'},
    new char[] {'.','9','8','.','.','.','.','6','.'},
    new char[] {'8','.','.','.','6','.','.','.','3'},
    new char[] {'4','.','.','8','.','3','.','.','1'},
    new char[] {'7','.','.','.','2','.','.','.','6'},
    new char[] {'.','6','.','.','.','.','2','8','.'},
    new char[] {'.','.','.','4','1','9','.','.','5'},
    new char[] {'.','.','.','.','8','.','.','7','9'}
});

//Ex 128
ExerciseArray.LongestConsecutive([100, 4, 200, 1, 3, 2]);

//Ex 238
ExerciseArray.ProductExceptSelf([1, 2, 3, 4]);




//Two Pointers
TwoPointersExercise exerciseTwoPt = new TwoPointersExercise();

//Ex 125
exerciseTwoPt.isPalindrome("Arara");

//Ex 557
exerciseTwoPt.ReverseWords("let's codee!");

//Ex 2000
exerciseTwoPt.ReversePrefix("abcdefd", 'd');

//Ex 167
exerciseTwoPt.TwoSum([1,3,4,5,7,10,11], 9);

//Ex 15
exerciseTwoPt.ThreeSum([-1, 0, 1, 2, -1, -4]);  

//Ex 11
exerciseTwoPt.MaxArea([1, 8, 6, 2, 5, 4, 8, 3, 7]);

//Ex 42
exerciseTwoPt.Trap([0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]);





//Stack
StackExercises stackExercises = new StackExercises();

//Ex 20
stackExercises.IsValid("(");

//Ex 150
stackExercises.EvalRPN(["2", "1", "+", "3", "*"]);

//Ex 739
stackExercises.DailyTemperatures([73, 74, 75, 71, 69, 72, 76, 73]);


//Sliding Window
SlidingWindowExercises slidingWidowExercises = new SlidingWindowExercises();

//Ex 121
slidingWidowExercises.MaxProfit([7, 1, 5, 2, 6, 4]);

//Ex 3
slidingWidowExercises.LengthOfLongestSubstring("abcabcbb");

//Ex 424
slidingWidowExercises.CharacterReplacement("AABABBA", 2);





//Linked List
LinkedListExercises linkedListExercises = new LinkedListExercises();




//Linked List Basic
LinkedListBasic linkedListBasic = new LinkedListBasic();

linkedListBasic.MontarLista();






TwoPointersExercise680 exercise = new TwoPointersExercise680();
exercise.ValidPalindrome("cbbcc");