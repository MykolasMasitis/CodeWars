using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Channels;

namespace CaesarCipher
{
    public class KadanesAlgorithm
    {
        /*
         The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:
           maxSequence [-2, 1, -3, 4, -1, 2, 1, -5, 4]
            -- should be 6: [4, -1, 2, 1]
            Easy case is when the list is made up of only positive numbers and the maximum sum is the sum of the whole array. If the list is made up of only negative numbers, return 0 instead.
           Empty list is considered to have zero greatest sum. Note that the empty list or array is also a valid sublist/subarray.
        */
        public int MaxSequence(int[] arr)
        {
            int length = arr.Length;
            int l_max = 0;
            int g_max = Int32.MinValue;

            for (int i = 0; i < length; i++)
            {
                l_max = Math.Max(arr[i], arr[i] + l_max);
                if (l_max > g_max)
                    g_max = l_max;
            }

            return g_max == Int32.MinValue ? 0 : g_max;
        }
    }

    public class CaesarCipher
    {
        public static List<string> movingShift(string s, int shift)
        {
            s = string.Join("", Enumerable.Range(0, s.Length).
                Select(x => (char.IsUpper(s, x)) ? (char)((s[x] + shift + x - 65) % 26 + 65) : (char.IsLower(s, x)) ? (char)((s[x] + shift + x - 97) % 26 + 97) : s[x]));
            var rs = new List<string>();
            foreach (Match m in Regex.Matches(s, ".{0," + (s.Length / 5 + 1) + "}")) 
                if (rs.Count < 5) rs.Add(m.Value);
            return rs;

        }
        /*
        ((s[x] + shift + x - 65) % 26 + 65)
        ((s[x] + x - 65) % 26 + 65)
        ((s[x] + x) % 26)
             
        ((u[x] - shift - x % 26 + 26 - 65) % 26 + 65)             
        ((u[x] - x % 26 + 26 - 65) % 26 + 65)             
        ((u[x] - x % 26 + 26) % 26)             
             */
        public static string demovingShift(List<string> s, int shift)
        {
            string u = string.Join("", s);
            u = string.Join("", Enumerable.Range(0, u.Length).
                Select(x => (char.IsUpper(u, x)) ? (char)((u[x] - shift - x % 26 + 26 - 65) % 26 + 65) : (char.IsLower(u, x)) ? (char)((u[x] - shift - x % 26 + 26 - 97) % 26 + 97) : u[x]));
            return u;
        }
    }
    public class A<T>
    {
        public static int Count { get; set; }
        public A() { Count++; }
    }
    interface IA
    {
        int M1 { get; }
        int M2 { set; }
        int M3 { get; set; }
        int M4();
    }
    class A : IA
    {
        int IA.M1 { get { return 0; } }
        public int M2 { set { } }
        public int M3 { get { return 0; } set { } }
        public int M4() { return 0; }

    }
    class A2 : IA
    {
        public int M1 { get { return 0; } }
        int IA.M2 { set { } }
        int IA.M3 { get { return 0; } set { } }
        public int M4() { return 0; }
        int IA.M4() { return 0; }
    }

    class Program
    {

        interface IB
        {

        }
        public static T M<T>() where T:new()
        {
            return new T();
        }
        //public struct A
        //{
        //    public bool val;
        //    public A(int v) { val = v == 0; }       // #1
        //    public A(char a) : this() { }           // #2
        //    public A(double a) { this = new A(); }  // #3
        //    private A(bool a) { val = a; }          // #4
        //    protected A(long a) { val = a == 0; }   // #5
        //}
        static void Main(string[] args)
        {
            A2 a = new A2();
            var m1 = a.M1;   // #1
            a.M2 = 0;        // #2
            var m3 = a.M3;   // #3
            var m4 = a.M4(); // #4

            try
            {
                // yield return можно, если нет catch!!!
                // yield break нельзя!
            }
            catch
            {
                // yield return нельзя!
                // yield break можно!
            }
            finally
            {
                // yield return нельзя!
                // yield break нельзя!
            }

            if (true)
                goto Start;
            else
                goto Finish;

            Start:
            Console.WriteLine("Это метка Start!");
            
            Finish:
            Console.WriteLine("Это метка Finish!");

            Console.WriteLine("Это после меток!");

            //double a = new int();
            //var _a = new double();


            //double d_d = 4.5d;
            //object c_c = d_d;
            //decimal e_e = (double)c_c;

            //object o = 1f;
            //double a1 = (double)(float)o;        // #1
            //double a2 = (float)o;                // #2
            //double a3 = (double)o;               // #3
            //double a4 = (float)(double)(float)o; // #4

            //IA a = new A();
            //var m1 = a.M1;
            //a.M2 = 0;
            //var m3 = a.M3;
            //var m4 = a.M4();

            //var arr = new[] { 1, 2, 3 };
            //var list = new List<Func<int>>();
            //for (int i = 0; i < arr.Length; i++)
            //    list.Add(() => arr[i]);

            //foreach (var q in list)
            //    Console.Write(q());

            //IEnumerable<object> a1 = new string[0];
            //object[] a2 = new int[0];
            //string[] a3 = new object[0];
            //Action<string> a4 = new Action<object>(delegate { });
            //Action<object> a5 = new Action<string>(delegate { });

            //var _arr = new[] { "a", "b" };
            //var _list = new List<string>();
            //for (int i = 0; i < _arr.Length; i++)
            //    list.Add(() => _arr[i]);

            //var s = string.Empty;
            //foreach (var q in list)
            //    s += q();
            //Console.WriteLine("{0}+{1}", 1, 2);

            //string s_str = "qwert";
            //s_str += 1;

            //Console.WriteLine(s_str);

            //double d = 4.5d;
            //object c = d;
            //decimal e = (double)c;

            //string inputData = Console.ReadLine();

            //bool checked = Convert.ToBoolean(Console.ReadLine());

            //var outputText = "Hello World"; var flag = true;
            //int year, month, day; year = 2015; month = 9; day = 28;
            //string Question = @"Хочешь научиться программировать?";
            //Console.WriteLine(Question);

            //new A<object>();
            //new A<string>();
            //new A<int>();
            //Console.WriteLine(A<string>.Count);

            //string x = "x";
            //string a = "xx";
            //string b = "xx";
            //string c = x + x;
            //Console.Write("{0} {1};", a == b, ReferenceEquals(a, b));
            //Console.Write("{0} {1};", a == c, ReferenceEquals(a, c));

            //bool priz=Tr


            /*
            object[] a1 = new string[0];
            object[] a2 = new int[0];
            int[] a2 = new object[0];
            string[] a3 = new object[0];

            Action<string> a4 = new Action<object>(delegate { });
            Action<object> a5 = new Action<string>(delegate { });
            System.Collections.Generic.List<int> ll = new List<int>();

            var list = new List<Func<int>>();
            foreach (var q in new[] { 1, 2 })
                list.Add(() => q);

            var s = 1;
            foreach (var q in list)
            {
                Console.WriteLine(q());
                s *= q();
                Console.WriteLine(s);

            }
            */
            //List<int> list = new List<int>();

            /*
            LinkedList<int> lst = new LinkedList<int>();
            Dictionary<string, string> dct = new Dictionary<string, string>();
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            HashSet<int> hash = new HashSet<int>();
            ArrayList ar = new ArrayList();
            Console.WriteLine(s);
            */

            // string s = "O CAPTAIN! my Captain! our fearful trip is done;";

            //foreach (Match m in Regex.Matches(s, ".{0," + (s.Length / 5 + 1) + "}"))
            //    Console.WriteLine(m.Value);

            //string outPut = string.Join("", CaesarCipher.movingShift("HELLO", 0)); // HELLO -> HFNOS

            //string[] people = { "Tom", "Bob", "Sam", "Kate", "Alice" };
            //string[] peopleRange1 = people[^2..];       // два последних - Kate, Alice
            //string[] peopleRange2 = people[..^1];       // начиная с предпоследнего - Tom, Bob, Sam, Kate
            //string[] peopleRange3 = people[^3..^1];

            //for(int i = 0; i < peopleRange3.Length; i++)
            //{
            //    Console.WriteLine($"peopleRange3: {peopleRange3[i]}");
            //}
            //Console.WriteLine($"peopleRange2: {peopleRange2}");
            //Console.WriteLine($"peopleRange3: {peopleRange3}");

            //Console.WriteLine(outPut);

            //Console.WriteLine(outPut);



            Console.ReadLine();

        }
    }
}
