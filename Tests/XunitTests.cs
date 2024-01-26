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

public class BatataQuenteTests
{
    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    public void BatataQuente_RetornaResultadoValido(int numJogadores)
    {
        // Act
        var result = OperacoesFilas.BatataQuente(numJogadores);

        // Assert
        Assert.InRange(result - 1, 0, numJogadores - 1);
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
        Assert.True(result >= 0 && result <= numJogadores);
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
        Assert.InRange(result, 0, numJogadores - 1);
    }

}