using System.Collections.Generic;

class Program
{
    static bool TestBrackets(string s)
    {
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (stack.Count == 0)
                    return false;

                char top = stack.Pop();

                if ((c == ')' && top != '(') || (c == ']' && top != '[') ||(c == '}' && top != '{'))
                    return false;
            }
        }

        return stack.Count == 0;
    }
    static void Main()
    {
        string input = Console.ReadLine();
        if (TestBrackets(input))
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
    }
}
