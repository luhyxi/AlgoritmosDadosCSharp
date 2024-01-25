namespace AlgoritmosDadosCSharp;

public class OperacoesListas
{
    public static List<string> TenOrMoreChars(List<string> input)
    {
        for (var index = 0; index < input.Count;)
        {
            if (input[index].Length < 10)
            {
                input.RemoveAt(index);
            }
            else
            {
                index++;
            }
        }
        return input;
    }
}

public class OperacoesPilhas
{
    public static bool IsBalanced(string input)
    {
        var parenthesesDict = new Dictionary<char, char>
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };

        var stack = new Stack<char>();

        foreach (var letter in input)
        {
            if (parenthesesDict.ContainsKey(letter))
            {
                if (stack.Count == 0 || stack.Pop() != parenthesesDict[letter])
                {
                    return false;
                }
            }
            else if (parenthesesDict.ContainsValue(letter))
            {
                stack.Push(letter);
            }
        }

        return stack.Count == 0;
    }
}

public class OperacoesFilas
{
    
}

public class OperacoesDict
{
    
}