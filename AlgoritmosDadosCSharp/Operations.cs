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
        var parenthesesDict = new Dictionary<char, char> { { ')', '(' }, { '}', '{' }, { ']', '[' } };
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
        // Test cases
        if (numJogadores <= 1)
            throw new ArgumentOutOfRangeException(nameof(numJogadores),
                "Numero de jogadores deve ser positivo e maior que um");

        var passesRandom = new Random();

        var FilaJogadores = new Queue<int>();

        // Coloca os Jogadores em seus postos
        for (var i = 1; i <= numJogadores; i++) FilaJogadores.Enqueue(i);

        // Jogo
        while (FilaJogadores.Count > 1)
        {
            var passes = passesRandom.Next(1, 100);

            // Passar a batata dentre jogadores
            for (var i = 0; i < passes; i++)
            {
                var jogadorRecente = FilaJogadores.Dequeue();
                FilaJogadores.Enqueue(jogadorRecente); 
            }

            // Eliminar jogador
            var jogadorEliminado = FilaJogadores.Dequeue();
            Console.WriteLine($"Jogador {jogadorEliminado} foi eliminado.");

        }

        // Último jogador restante
        return FilaJogadores.Dequeue();
    }


}

public class OperacoesDict
{
    public int ContadorPalavras()
    {
        
    }
}