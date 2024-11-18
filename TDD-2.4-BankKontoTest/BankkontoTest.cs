using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using TDD_2._4_BankKonto;

namespace TDD_2._4_BankKontoTest
{
    [TestClass]
    public class BankkontoTest
    {
        [TestMethod]
        public void KontoErstellungGuthabenIst0()
        {
            // Arrange
            int testKontoNummer = 12345678;

            // Act
            Bankkonto bankkonto = new(testKontoNummer, 0);

            // Assert
            Assert.AreEqual(0, bankkonto.Guthaben);
        }
     
        /* 
        * Spaeter initialisieren - Random Kontonummer
        [TestMethod]
        public void KontoErstellungNummerIstNicht0()
        {
            // Arrange


            // Act
            Bankkonto bankkonto = new Bankkonto();

            // Assert
            Assert.AreNotEqual(0, bankkonto.KontoNummer, "Kontonummer ist nicht 0");
        }*/

        [TestMethod]
        public void Einzahlen() {
            // Arrange 
            int testKontoNummer = 12345678;

            Bankkonto bankkonto = new(testKontoNummer, 0);

            double testBetrag = 1000;

            // Act
            bankkonto.ZahleEin(testBetrag);

            // Assert
            Assert.AreEqual(testBetrag, bankkonto.Guthaben);
        }

        [TestMethod]
        public void Beziehen()
        {
            // Arrange
            int testKontoNummer = 123455678;

            Bankkonto testBankkonto = new(testKontoNummer, 0);

            double testBetrag = 1000;

            // Act
            testBankkonto.Beziehe(testBetrag);

            // Assert
            Assert.AreEqual(-testBetrag, testBankkonto.Guthaben);
        }

        [TestMethod]
        public void Zahlungen()
        {
            // Arrange
            int testKontoNummer = 12345678;

            double testErwarteterBetrag = 1000 + 1000 - 3000 + 2000;

            Bankkonto testBankkonto = new(testKontoNummer, 0);

            // Act
            testBankkonto.ZahleEin(1000);
            testBankkonto.ZahleEin(1000);
            testBankkonto.Beziehe(3000);
            testBankkonto.ZahleEin(2000);

            // Assert
            Assert.AreEqual(testErwarteterBetrag, testBankkonto.Guthaben);
        }

        [TestMethod]
        public void AktivZins()
        {
            // Arrange
            int testKontoNummer = 12345678; 

            double testGuthaben = 1000;

            double testZinsBetrag = 0;

            Bankkonto testBankKonto = new(testKontoNummer, testGuthaben);

            // Act

            if (testGuthaben >= 0)
            {
                testZinsBetrag = testGuthaben * testBankKonto.aktivZins / 100;
            } else
            {
                testZinsBetrag = testGuthaben * testBankKonto.passivZins / 100;
            }

            // Assert
            Assert.AreEqual(2.5, testZinsBetrag);
        }

        [TestMethod]
        public void PassivZins()
        {
            // Arrange
            int testKontoNummer = 12345678;

            double testGuthaben = -1000;

            double testZinsBetrag = 0;

            Bankkonto testBankKonto = new(testKontoNummer, testGuthaben);

            // Act
            if (testGuthaben >= 0)
            {
                testZinsBetrag = testGuthaben * testBankKonto.aktivZins / 100;
            }
            else
            {
                testZinsBetrag = testGuthaben * testBankKonto.passivZins / 100;
            }

            // Assert
            Assert.AreEqual(-5.0, testZinsBetrag);
        }

        [TestMethod]
        public void KontoAbschlussZinsHinzufuegen()
        {
            // Arrange
            int testKontoNummer = 12345678;

            double testGuthaben = 1000;

            double testZinsBetrag = 2.5;

            Bankkonto testBankKonto = new(testKontoNummer, testGuthaben);

            // Act
            if (testZinsBetrag >= 0)
            {
                testGuthaben = testGuthaben + testZinsBetrag;
            }

            // Assert
            Assert.AreEqual(1002.5, testGuthaben);
        }

        [TestMethod]
        public void ZinsUndAbschluss()
        {
            // Arrange
            int testKontoNummer = 1488;

            double testGuthaben = 1000;

            double testZinsBetrag = 0;

            Bankkonto testBankKonto = new(testKontoNummer, testGuthaben);

            int anzahlTage = 180;

            // Act
            testZinsBetrag = testBankKonto.SchreibeZinsGut(anzahlTage);

            if (testBankKonto.SchreibeZinsGut(anzahlTage) >= 0)
            {
                testGuthaben = testGuthaben + testZinsBetrag;
            }
            else
            {
                testGuthaben = testGuthaben - testZinsBetrag;
            }

            // Assert
            Assert.AreEqual(1450, testGuthaben);
        }
    }
}