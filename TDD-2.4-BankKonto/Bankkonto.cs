using System;

namespace TDD_2._4_BankKonto
{
    public class Bankkonto
    {
        public int KontoNummer { get; private set; }
        public double Guthaben { get; private set; }
        public double AktivZins { get; private set; } = 0.25; // Standard aktiv Zins
        public double PassivZins { get; private set; } = 0.5;  // Standard passiv Zins
        public string Status { get; private set; } // "Standard" oder "VIP"

        public Bankkonto(int kontoNummer, double guthaben, string status)
        {
            KontoNummer = kontoNummer;
            Guthaben = guthaben;
            Status = status;
        }

        // Einzahlung 
        public void ZahleEin(double betrag)
        {
            if (betrag > 0)
            {
                Guthaben += betrag;
            }
        }

        // Auszahlung 
        public void Beziehe(double betrag)
        {
            Guthaben -= betrag;
        }

        public double SchreibeZinsGut(int anzahlTage)
        {
            double zinsProTag = 0.0;

            // Berechnung des Zinses 
            if (Guthaben >= 0 && Guthaben < 10000)
            {
                // Guthaben < 10000: AktivZins bleibt unverändert
                zinsProTag = Guthaben * (AktivZins / 100);
            }
            else if (Guthaben >= 10000 && Guthaben < 50000)
            {
                // Guthaben zwischen 10000 und 50000: AktivZins - 0.5%
                zinsProTag = Guthaben * ((AktivZins - 0.5) / 100);
                if (zinsProTag < 0) zinsProTag = 0; // Sicherstellen, dass der Zins nicht negativ wird
            }
            else if (Guthaben >= 50000 && Guthaben < 100000)
            {
                // Guthaben zwischen 50000 und 100000
                if (Status == "VIP")
                {
                    // VIP-Kunden: AktivZins - 0.75%
                    zinsProTag = Guthaben * ((AktivZins - 0.75) / 100);
                }
                else
                {
                    // Standard-Kunden: AktivZins - 1.0%, aber Zinsabzug kann nicht unter 0 gehen
                    double zinsAbzug = AktivZins - 1.0;
                    if (zinsAbzug < 0)
                        zinsAbzug = 0; // Sicherstellen, dass der Zinsabzug nicht negativ wird
                    zinsProTag = Guthaben * (zinsAbzug / 100);
                }
            }

            // Zinsberechnung (Tage)
            double gesamtZins = zinsProTag * anzahlTage;
            return Math.Round(gesamtZins, 2); 
        }



    }
}
