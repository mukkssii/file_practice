using System.Reflection.Metadata;

namespace file_practice
{
    internal class Program
    {
        //1
        static void ReadFile(string path)
        {

            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Console.WriteLine($"Content: \n{content}");
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }


        //2
        static void MakeArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"arr[{i}] = ");
                arr[i] = int.Parse(Console.ReadLine());
            }
        }
        static void SaveArray(string path, int[] arr)
        {
            File.WriteAllText(path, "");
            string[] lines;
            for (int i = 0; i < arr.Length; i++)
            {
                File.AppendAllText(path, $"{arr[i].ToString()}\n");
            }
            Console.WriteLine("Array saved");
        }
        static int[] LoadArray(string path)
        {
            
            string[] lines = File.ReadAllLines(path);
            int[] arr = new int[lines.Length];
            for (int i = 0;i < lines.Length;i++)
            {
                arr[i] = int.Parse(lines[i]);
            }
            return arr;
        }


        //3
        static void RandomSort()
        {
            Random rand = new Random();
            int evenCount = 0;
            int oddCount = 0;
            File.WriteAllText("even.txt", "");
            File.WriteAllText("odd.txt", "");
            for (int i = 0; i < 10000; i++)
            {
                int num = rand.Next(1, 1001);
                if (num % 2 == 0)
                {
                    File.AppendAllText("even.txt", num + "\n");
                    evenCount++;
                }
                else
                {
                    File.AppendAllText("odd.txt", num + "\n");
                    oddCount++;
                }
            }
            Console.WriteLine($"Even numbers: {evenCount}");
            Console.WriteLine($"Odd numbers: {oddCount}");
        }


        //4
        static void SearchWord(string path, string word)
        {
            string[] lines = File.ReadAllLines(path);
            bool found = false;
            for (int i = 0; i < lines.Length; i++)
            {
                int pos = lines[i].IndexOf(word);
                if (pos != -1)
                {
                    Console.WriteLine($"Line: {i + 1}");
                    Console.WriteLine($"Pos: {pos + 1}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Word not found");
            }
        }
        static void CountWord(string path, string word)
        {
            string text = File.ReadAllText(path);
            int count = 0;
            int pos = 0;
            while ((pos = text.IndexOf(word, pos)) != -1)
            {
                count++;
                pos += word.Length;
            }
            Console.WriteLine($"Count: {count}");
        }

        static void SearchReversed(string path, string word)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            string reversed = new string(chars);
            CountWord(path, reversed);
        }


        //5
        static void FileStats(string path)
        {
            string text = File.ReadAllText(path);
            int sentences = 0;
            int upper = 0;
            int lower = 0;
            int vowels = 0;
            int consonants = 0;
            int digits = 0;
            foreach (char c in text)
            {
                if (c == '.' || c == '!' || c == '?')
                {
                    sentences++;
                }
                if (char.IsUpper(c))
                {
                    upper++;
                }
                else if (char.IsLower(c))
                {
                    lower++;
                    if ("aeiou".Contains(char.ToLower(c)))
                    {
                        vowels++;
                    }
                    else
                    {
                        consonants++;
                    }
                }
                if (char.IsDigit(c))
                {
                    digits++;
                }
            }
            Console.WriteLine("Sentences: " + sentences);
            Console.WriteLine("Uppercase letters: " + upper);
            Console.WriteLine("Lowercase letters: " + lower);
            Console.WriteLine("Vowels: " + vowels);
            Console.WriteLine("Consonants: " + consonants);
            Console.WriteLine("Digits: " + digits);
        }


        static void Main(string[] args)
        {
            File.WriteAllText("file.txt", "Avadakedavra");
            // 1
            //ReadFile("file.txt");


            // 2
            /*int[] arr = new int[5];
            MakeArray(arr);
            Console.Write("1. Save array to file\n2. Load array from file\nChoice: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                SaveArray("arraySave.txt", arr);
            }
            else if (choice == 2)
            {
                Console.Write("Enter path: ");
                string pathArr = Console.ReadLine();
                int[] arr1 = LoadArray(pathArr);
                foreach (int i in arr1)
                {
                    Console.Write(i + " ");
                }
            }*/


            // 3
            //RandomSort();


            //4
            /*string path = "task4.txt";
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            Console.WriteLine("\n1. Search word\n2. Count word\n3. Search reversed word");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                SearchWord(path, word);
            }
            else if (choice == 2)
            {
                CountWord(path, word);
            }
            else if (choice == 3)
            {
                SearchReversed(path, word);
            }*/


            //5
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            FileStats(path);
        }
    }
}
