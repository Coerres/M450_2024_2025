using TDD_2._4_BankKonto;

[TestClass]
public class BankkontoTest
{
    [TestMethod]
    public void ZinsBerechnung_Bereich1_EgalerStatus()
    {
        // Arrange
        Bankkonto konto = new Bankkonto(12345678, 5000, "Standard");
        int tage = 1;

        // Act
        double zins = konto.SchreibeZinsGut(tage);

        // Assert
        Assert.AreEqual(1.25, zins, 0.01); // 5000 * 0.25% = 1.25
    }

    [TestMethod]
    public void ZinsBerechnung_Bereich2_EgalerStatus()
    {
        // Arrange
        Bankkonto konto = new Bankkonto(12345678, 20000, "VIP");
        int tage = 1;

        // Act
        double zins = konto.SchreibeZinsGut(tage);

        // Assert
        Assert.AreEqual(37.5, zins, 0.01); // 20000 * 0.2% = 37.5
    }

    [TestMethod]
    public void ZinsBerechnung_Bereich3_VIP()
    {
        // Arrange
        Bankkonto konto = new Bankkonto(12345678, 75000, "VIP");
        int tage = 1;

        // Act
        double zins = konto.SchreibeZinsGut(tage);

        // Assert
        Assert.AreEqual(187.5, zins, 0.01); // 75000 * (AktivZins - 0.75%) = 187.5
    }

    [TestMethod]
    public void ZinsBerechnung_Bereich3_Standard()
    {
        // Arrange
        Bankkonto konto = new Bankkonto(12345678, 75000, "Standard");
        int tage = 1;

        // Act
        double zins = konto.SchreibeZinsGut(tage);

        // Assert
        Assert.AreEqual(187.5, zins, 0.01); // 75000 * (AktivZins - 1.0%) = 187.5
    }

    [TestMethod]
    public void ZinsBerechnung_MehrereTage()
    {
        // Arrange
        Bankkonto konto = new Bankkonto(12345678, 10000, "Standard");
        int tage = 10;

        // Act
        double zins = konto.SchreibeZinsGut(tage);

        // Assert
        Assert.AreEqual(20.0, zins, 0.01); // (10000 * 0.2%) * 10 Tage = 20.0
    }
}
