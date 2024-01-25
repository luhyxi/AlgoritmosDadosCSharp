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
    
}

public class OperacoesFilas
{
    
}

public class OperacoesDict
{
    
}