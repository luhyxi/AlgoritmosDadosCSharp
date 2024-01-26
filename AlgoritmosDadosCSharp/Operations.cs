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
    public static int BatataQuente(int numJogadores)
    {
        var random = new Random();
        var FilaBatateiros = new Queue<int>(numJogadores);
        for (var i = 0; i < numJogadores; i++) FilaBatateiros.Enqueue(i);

        for (var i = 0; i < random.Next(1, 100); i++)
        {
            if (FilaBatateiros.Count == 0)
                for (var j = 0; j < numJogadores; j++)
                    FilaBatateiros.Enqueue(j);

            FilaBatateiros.Dequeue();
        }

        return FilaBatateiros.Peek();
    }
}

public class OperacoesDict
{
    
}