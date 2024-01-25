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
    public void TenOrMoreChars_KeepsStringsEqualToOrGreaterThanTenChars()
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