namespace AlgoritmosDadosCSharp;

public class OperacoesListas
{
    // Está 100% funcional. Entretanto, em termos de manutenibilidade, é recomendado que 
    // não alteremos o objeto de entrada pois isso acaba causando indireção. Isso é chamado de
    // fnução mutadora ou função destrutiva.
    // O ideal é criar uma nova lista e colocar nela os objetos resultantes da "filtragem", tornando a
    // função imutável.
    // Note que os objetos não serão duplicados na memória, eles só estarão sendo referenciados
    // em duas listas diferentes =)
    public static List<string> TenOrMoreChars(List<string> input)
    {
        var result = new List<string>();

        for (var index = 0; index < input.Count; index++)
        {
            if (input[index].Length >= 10)
            {
                result.Add(input.ElementAt(index));
            }
        }

        return result;
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

public interface IRandomizer
{
    int Next(int minValue, int maxValue);
}

public class NativeRandomizer : IRandomizer
{
    Random rnd = new Random();
    public int Next(int minValue, int maxValue)
        => rnd.Next(minValue, maxValue);
}

public class OperacoesFilas
{

    public static int BatataQuente(int numJogadores)
        => BatataQuente(new NativeRandomizer(), numJogadores);

    public static int BatataQuente(IRandomizer randomizer, int numJogadores)
    {
        // Test cases
        if (numJogadores <= 1)
            throw new ArgumentOutOfRangeException(nameof(numJogadores),
                // Nice catch! Se quisesse garantir isso em tempo de compilação, poderia
                // também definir o parametro com o tipo `uint`, que seria o inteiro
                // sem sinal, fazendo com que número fosse positivo
                "Numero de jogadores deve ser positivo e maior que um");

        var FilaJogadores = new Queue<int>();

        // Coloca os Jogadores em seus postos
        for (var i = 1; i <= numJogadores; i++) FilaJogadores.Enqueue(i);
        
        // Jogo
        while (FilaJogadores.Count > 1)
        {
            var passes = randomizer.Next(1, 100);

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
    public static Dictionary<string, int> ContadorPalavras(string input)
    {
        Dictionary<string, int> PalavrasEncontradas = [];
        string[] inputArray = input.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string palavra in inputArray)
        {
            string palavraClean = palavra.Trim().ToLower();
            if (!PalavrasEncontradas.ContainsKey(palavraClean))
            {
                PalavrasEncontradas.Add(palavraClean, 1);
            }
            else
            {
                PalavrasEncontradas[palavraClean]++;
            }
        }
        return PalavrasEncontradas;
    }
}

