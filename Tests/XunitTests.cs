using AlgoritmosDadosCSharp;

namespace Tests;

public class OperacoesListasTests
{
    [Fact]
    public void TenOrMoreChars_RemoverPalavrasMenosQueDezLetras()
    {
        // Arrange
        var input = new List<string>
        {
            "Idiossincrasia",
            "Ambivalente",
            "Quimérica",
            "Perpendicular",
            "Efêmero",
            "Pletora",
            "Obnubilado",
            "Xilografia",
            "Quixote",
            "Inefável"
        };

        // Act
        var result = OperacoesListas.TenOrMoreChars(input);

        // Assert
        Assert.DoesNotContain("Quixote", result);
        Assert.DoesNotContain("Efêmero", result);
        Assert.DoesNotContain("Pletora", result);
        Assert.DoesNotContain("Quimérica", result);
    }

    [Fact]
    public void TenOrMoreChars_ContemPalavrasMaioresQueDezLetras()
    {
        // Arrange
        var input = new List<string>
        {
            "Idiossincrasia",
            "Ambivalente",
            "Perpendicular",
            "Obnubilado",
            "Xilografia",
            "Inefável"
        };

        // Act
        var result = OperacoesListas.TenOrMoreChars(input);

        // Assert
        Assert.Contains("Idiossincrasia", result);
        Assert.Contains("Ambivalente", result);
        Assert.Contains("Perpendicular", result);
        Assert.Contains("Obnubilado", result);
        Assert.Contains("Xilografia", result);
    }
}
public class OperacoesPilhasTests
{
    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { "", true };
        yield return new object[] { "()", true };
        yield return new object[] { "{[()]}", true };
        yield return new object[] { "{[(])}", false };
        yield return new object[] { "abc", true };
        yield return new object[] { "({})", true };
        yield return new object[] { "[()]", true };
        yield return new object[] { "[{()}]", true };
        yield return new object[] { "[{]", false };
        yield return new object[] { "(", false };
        yield return new object[] { ")", false };
        yield return new object[] { "{{[()]}}", true };
        yield return new object[] { "{{[()]", false };
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void IsBalanced_RetornaResultadoValido(string input, bool expectedResult)
    {
        // Act
        var result = OperacoesPilhas.IsBalanced(input);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}

public class OperacoesFilasTests
{
    private class DeterministicRandomizer : IRandomizer
    {
        private readonly int _presetResult;

        public DeterministicRandomizer(int presetResult)
        {
            _presetResult = presetResult;
        }

        public int Next(int minValue, int maxValue)
        {
            return _presetResult;
        }
    }

    [Theory]
    [InlineData(3, 9, 2)]
    [InlineData(5, 19, 3)]
    // O resultado de um teste automatizado deve ser determinístico.
    // Para isso temos que ter no nosso sistema
    // classes testáveis, isto é, as classes devem de alguma forma permitir o resultado esperado para determinados
    // cenários sejam coletáveis.
    // Nesse caso, precisei fazer algumas modificações para permitir injetar o "randomizador" e definir o número de
    // passes, pois assim consigo predizer o jogador vencedor com um simples teste de mesa.
    public void BatataQuente_RetornaResultadoValido(int numJogadores, int numPasses, int vencedorEsperado)
    {
        // Arrange
        var randomizer = new DeterministicRandomizer(numPasses);

        // Act
        var result = OperacoesFilas.BatataQuente(randomizer, numJogadores);

        // Assert
        Assert.Equal(result, vencedorEsperado);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-40)]
    public void BatataQuente_ZeroOuMenorThrowException(int numJogadores)
    {
        // Arrange + Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => OperacoesFilas.BatataQuente(numJogadores));
    }

    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(6)]
    public void BatataQuente_RetornaResultadoDentroNumeroPlayers(int numJogadores)
    {
        // Act
        var result = OperacoesFilas.BatataQuente(numJogadores);

        // Assert
        // 0 (zero) não deveria estar dentro do espectro válido XP
        Assert.True(result >= 1 && result <= numJogadores);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(50)]
    public void BatataQuente_RetornaResultadoVariosJogadores(int numJogadores)
    {
        // Act
        var result = OperacoesFilas.BatataQuente(numJogadores);

        // Assert
        // Do jeito que estava antes, esse teste poderia resultar em um falso positivo.
        // Os jogadores válidos são entre 1 e numJogadores.
        // Se houvesse um erro de implementação e sua classe do jogo retornasse 0 (zero), esse teste aceitaria
        // como resultado válido esperado
        Assert.InRange(result, 1, numJogadores - 1);
    }
}

public class OperacoesDictTests
{
    const string loremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
        Nulla auctor porta velit a tincidunt. Nam efficitur iaculis placerat. Aenean lectus dui, 
        sollicitudin id rhoncus tristique, aliquet sed quam. Phasellus blandit magna at elementum 
        consequat. Nam vitae nunc vehicula, blandit felis a, placerat augue. Quisque bibendum a 
        ipsum at scelerisque. Duis molestie turpis quis orci vehicula aliquam. Duis non elementum 
        erat. Phasellus et dui odio. Nunc vitae leo sem. Curabitur nec enim id mi aliquet commodo 
        at et sapien. Fusce sit amet nisi elit. Interdum et malesuada fames ac ante ipsum primis 
        in faucibus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere 
        cubilia curae; Duis vitae dolor at sem ultrices euismod. Morbi aliquet, felis et mattis 
        congue, justo nunc pharetra lectus, a lobortis mauris eros et nulla. Orci varius natoque 
        penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas sollicitudin 
        posuere nibh malesuada suscipit. Nam a sapien ex. Donec mollis justo est, quis tempus mi 
        pharetra at. Cras fringilla enim eu egestas scelerisque. Praesent tristique imperdiet 
        consectetur. Donec interdum pulvinar nulla vel pharetra. Class aptent taciti sociosqu ad 
        litora torquent per conubia nostra, per inceptos himenaeos. Aliquam interdum finibus mi, 
        in tempus lorem. Cras diam magna, viverra vitae ante eget, scelerisque sodales velit. 
        Aliquam erat volutpat. Mauris consectetur sapien mi, vel euismod quam consectetur id.";

    [Theory]
    [InlineData("to be or not to be, that is the question")]
    public void ContadorPalavras_RetornaNumeroExato(string text)
    {
        // Act
        var result = OperacoesDict.ContadorPalavras(text);

        // Assert
        Assert.Equal(2, result["to"]);
        Assert.Equal(2, result["be"]);
        Assert.Equal(1, result["or"]);
        Assert.Equal(1, result["not"]);
        Assert.Equal(1, result["that"]);
        Assert.Equal(1, result["is"]);
        Assert.Equal(1, result["the"]);
        Assert.Equal(1, result["question"]);
    }

    [Theory]
    [InlineData(loremIpsum)]
    public void ContadorPalavras_TestePorAmostra(string text)
    {
        // Act
        var result = OperacoesDict.ContadorPalavras(text);

        // Assert
        Assert.Equal(7, result["et"]);
        Assert.Equal(2, result["lorem"]);
        Assert.Equal(4, result["ipsum"]);
        Assert.Equal(1, result["viverra"]);
    }
}
