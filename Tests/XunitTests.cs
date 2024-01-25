using AlgoritmosDadosCSharp;

namespace Tests;

public class OperacoesListasTests
{
    [Fact]
    public void TenOrMoreChars_RemovesStringsLessThanTenChars()
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
    public void TestIsBalanced(string input, bool expectedResult)
    {
        // Act
        var result = OperacoesPilhas.IsBalanced(input);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
