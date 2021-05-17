using System;
using System.Collections.Generic;
using System.Text;

namespace TextBasedGame1
{
    class ConsoleInputOutput
    {
        public static void Print(string content)
        {
            Console.Write(content);
        }
        public static void PrintNew(string content)
        {
            Console.WriteLine(content);
        }


        public static string RecieveInput()
        {
            return Console.ReadLine();
        }

        public static string RecieveInput(string content)
        {
            PrintNew(content);
            return Console.ReadLine();
        }

        public static int RecieveOptions(string [] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                PrintNew(i+1 + ". " + options[i]);
            }
            return Int32.Parse(RecieveInput());
        }
        public static int RecieveOptions(string content, string[] options)
        {
            PrintNew(content);
            for (int i = 0; i < options.Length; i++)
            {
                PrintNew(i + 1 + ". " + options[i]);
            }
            return Int32.Parse(RecieveInput());
        }
        public static bool RecieveYesNo(string content)
        {
            while (true)
            {
                string yesOrNo = RecieveInput(content + " (Yes/No)").ToUpper();
                if (yesOrNo == "YES")
                {
                    return true;
                }
                else if (yesOrNo == "NO")
                {
                    return false;
                }
                else { }
            }
        }

    }
}
