using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TextBasedGame1
{
    class InputOutput
    {
        public static void Print(string content)
        {
            Console.Write(content);
        }
        public static void PrintNew(string content)
        {
            Console.WriteLine(content);
        }

        public static void PrintNewPause(string content)
        {
            Console.WriteLine(content);
            ReceiveInput();
        }


        public static string ReceiveInput()
        {
            return Console.ReadLine();
        }

        public static string ReceiveInput(string content)
        {
            PrintNew(content);
            return Console.ReadLine();
        }

        public static int ReceiveOptions(string [] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                PrintNew(i+1 + ". " + options[i]);
            }
            return Int32.Parse(ReceiveInput());
        }
        public static int ReceiveOptions(string content, List<string> options)
        {
            PrintNew(content);
            for (int i = 0; i < options.Count; i++)
            {
                PrintNew(i + 1 + ". " + options[i]);
            }
            return Int32.Parse(ReceiveInput());
        }
        public static bool ReceiveYesNo(string content)
        {
            while (true)
            {
                string yesOrNo = ReceiveInput(content + " (Yes/No)").ToUpper();
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

        public static string readFromScript(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Script.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode(path);
            return node.InnerText.Trim();
        }

    }
}
