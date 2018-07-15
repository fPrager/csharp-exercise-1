using System;
using System.Collections.Generic;

namespace App
{
    /*
        ["Tokyo", "London", "Rome", "Donlon", "Kyoto", "Paris"]

        // YOUR ALGORITHM

        [
            [ "Tokyo", "Kyoto" ],
            [ "London", "Donlon" ],
            [ "Rome" ],
            [ "Paris" ]
        ]
     */
     
    class Program
    {
        static void PrintOutput(List<List<string>> output)
        {
            string print = "";
            foreach(var list in output)
            {
                print += "[";
                foreach(var s in list)
                    print+= s + " ";
                print += "]";
            }
            Console.WriteLine("[" + print + "]");
        }

        static bool IsMatch(string s1, string s2)
        {
            if(s1.Length == 0)
                return true;

            for(int i = 1; i <= s1.Length; i++)
            {
                if(s2 == (s1.Substring(i, s1.Length - i) + s1.Substring(0, i)))
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            List<string> input = new List<string>{"Tokyo", "London", "Rome", "Donlon", "Kyoto", "Paris"};
            
            Console.WriteLine("Input:");
            PrintOutput(new List<List<string>>(){input});
            
            List<List<string>> output = new List<List<string>>();
            foreach(var s in input)
            {
                bool insert = false;
                int i = -1;
                while(!insert)
                {
                    i++;
                    if(output.Count == i)
                    {
                        output.Add(new List<string>{s});
                        insert = true;
                        continue;
                    }

                    string root = output[i][0];

                    if(root.Length != s.Length)
                        continue;
                    
                    if(!IsMatch(s.ToLower(),root.ToLower()))
                        continue;
                    
                    output[i].Add(s);
                    insert = true;
                }
            }

            Console.WriteLine("Output:");
            PrintOutput(output);
        }
    }
}
