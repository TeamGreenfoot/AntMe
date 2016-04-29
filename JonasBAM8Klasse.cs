using AntMe.Deutsch;
using AntMe.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntMe.Player.Kordinaten
{
    #region Globaler Speicher

    public class Speicher
    {
        public static Bau bau = null;
        public static int späh_stepf = 0;

        public static List<Zucker> zucker_list = new List<Zucker>();
        public static Zucker akt_zucker = null;
        public static int zucker_counter = 0;

        // Zuckerhaufen erneuerung
        public static void zucker_sort()
        {
            // Leere löschen
            for (int i = 0; i < zucker_list.Count() - 1; i++)
            {
                if (zucker_list[i].Menge <= 0)
                {
                    zucker_list.Remove(zucker_list[i]);
                }
            }

            int count = zucker_list.Count();
            Zucker zucker_alt;

            for (int runde = 0; runde < count; runde++)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    if (Koordinate.BestimmeEntfernung(bau, zucker_list[i]) > Koordinate.BestimmeEntfernung(bau, zucker_list[i + 1]))
                    {
                        // tauschen
                        zucker_alt = zucker_list[i];
                        zucker_list[i] = zucker_list[i + 1];
                        zucker_list[i + 1] = zucker_alt;
                    }
                }
            }

            // aktuellen leeren falls leer
            if (akt_zucker.Menge == 0)
            {
                akt_zucker = null;
            }
        }
        public static void zucker_refresh()
        {
            // refresh
            if (akt_zucker != null && akt_zucker.Menge <= 100)
            {
                akt_zucker = zucker_list[0];
            }
        }

        public static List<Obst> obst_list = new List<Obst>();
        public static List<Obst> obst_old = new List<Obst>();
        public static Obst akt_obst = null;
        public static int obst_counter = 0;

        // Apfel erneuerung
        public static void obst_refresh()
        {
            // refresh
            obst_old.Add(akt_obst);
            obst_list.Remove(akt_obst);
            if (obst_list.Count >= 1)
            {
                akt_obst = obst_list[0];
            }

            for (int i = 0; i < obst_list.Count - 1; i++)
            {
                obst_list[i] = obst_list[i + 1];
            }
            if (obst_list.Count <= 0)
            {
                akt_obst = null;
            }
        }

        public static Wanze akt_wanze = null;
        public static int wanzen_counter = 0;
    }

    #endregion

    [Spieler(
        Volkname = "JonasBAM8",   // Hier kannst du den Namen des Volkes festlegen
        Vorname = "Jonas",              // An dieser Stelle kannst du dich als Schöpfer der Ameise eintragen
        Nachname = "B.A.M"          // An dieser Stelle kannst du dich als Schöpfer der Ameise eintragen
    )]

    #region Kastendeklaration

    #region Späher
    [Kaste(
        Name = "Späher1",                  // Name der Berufsgruppe
        AngriffModifikator = -1,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = -1,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 2,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = -1,                // Tragkraft einer Ameise
        ReichweiteModifikator = 1,          // Ausdauer einer Ameise
        SichtweiteModifikator = 1           // Sichtweite einer Ameise
    )]

    [Kaste(
        Name = "Späher2",                  // Name der Berufsgruppe
        AngriffModifikator = -1,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = -1,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 2,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = -1,                // Tragkraft einer Ameise
        ReichweiteModifikator = 1,          // Ausdauer einer Ameise
        SichtweiteModifikator = 1           // Sichtweite einer Ameise
    )]

    [Kaste(
        Name = "Späher3",                  // Name der Berufsgruppe
        AngriffModifikator = -1,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = -1,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 2,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = -1,                // Tragkraft einer Ameise
        ReichweiteModifikator = 1,          // Ausdauer einer Ameise
        SichtweiteModifikator = 1           // Sichtweite einer Ameise
    )]

    [Kaste(
        Name = "Späher4",                  // Name der Berufsgruppe
        AngriffModifikator = -1,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = -1,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 2,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = -1,                // Tragkraft einer Ameise
        ReichweiteModifikator = 1,          // Ausdauer einer Ameise
        SichtweiteModifikator = 1           // Sichtweite einer Ameise
    )]

    [Kaste(
        Name = "FSpäher",                  // Name der Berufsgruppe
        AngriffModifikator = -1,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = -1,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 1,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = -1,                // Tragkraft einer Ameise
        ReichweiteModifikator = 1,          // Ausdauer einer Ameise
        SichtweiteModifikator = 2           // Sichtweite einer Ameise
    )]
    #endregion

    [Kaste(
        Name = "Sammler",                  // Name der Berufsgruppe
        AngriffModifikator = -1,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = -1,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 2,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = 2,                // Tragkraft einer Ameise
        ReichweiteModifikator = 0,          // Ausdauer einer Ameise
        SichtweiteModifikator = -1           // Sichtweite einer Ameise
    )]

    [Kaste(
        Name = "Kämpfer",                  // Name der Berufsgruppe
        AngriffModifikator = 2,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = -1, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = 1,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 0,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = -1,                // Tragkraft einer Ameise
        ReichweiteModifikator = 0,          // Ausdauer einer Ameise
        SichtweiteModifikator = -1           // Sichtweite einer Ameise
    )]

    [Kaste(
        Name = "ZuckerKämpfer",                  // Name der Berufsgruppe
        AngriffModifikator = 1,             // Angriffsstärke einer Ameise
        DrehgeschwindigkeitModifikator = 0, // Drehgeschwindigkeit einer Ameise
        EnergieModifikator = 0,             // Lebensenergie einer Ameise
        GeschwindigkeitModifikator = 1,     // Laufgeschwindigkeit einer Ameise
        LastModifikator = -1,                // Tragkraft einer Ameise
        ReichweiteModifikator = 0,          // Ausdauer einer Ameise
        SichtweiteModifikator = -1           // Sichtweite einer Ameise
    )]

    #endregion

    public class KordinatenKlasse : Basisameise
    {
        // Variabeln
        int späh_step1 = 0;
        int späh_step2 = 0;
        int späh_step3 = 0;
        int späh_step4 = 0;
        int do_nothing_counter = 0;
        int obst_angle_reset = 0;
        public Spielobjekt ZielOptimized = null;

        #region Kasten

        public override string BestimmeKaste(Dictionary<string, int> anzahl)
        {
            #region Späher
            if (anzahl["FSpäher"] < 1)
            {
                return "FSpäher";
            }
            else
            if (anzahl["Späher1"] < 1)
            {
                return "Späher1";
            }
            else
            if (anzahl["Späher2"] < 1)
            {
                return "Späher2";
            }
            else
            if (anzahl["Späher3"] < 1)
            {
                return "Späher3";
            }
            else
            if (anzahl["Späher4"] < 1)
            {
                return "Späher4";
            }
            #endregion
            else
            if (anzahl["ZuckerKämpfer"] < 5)
            {
                return "ZuckerKämpfer";
            }
            else
            if (anzahl["Sammler"] < 40)
            {
                return "Sammler";
            }
            else
            if (anzahl["Kämpfer"] < 15)
            {
                return "Kämpfer";
            }
            else
                return "Sammler";
        }

        #endregion

        #region Fortbewegung

        public override void Wartet()
        {
            #region Einmalig
            // Baureferenz
            if (Speicher.bau == null)
            {
                GeheZuBau();
                Speicher.bau = Ziel as Bau;
                BleibStehen();
            }
            #endregion

            #region Späherbewegung
            if (Kaste == "Späher1")
            {
                if (späh_step1 == 0) { GeheZuKoordinate(-350, 0); späh_step1 = 1; }
                else
                if (späh_step1 == 1) { GeheZuKoordinate(0, -450); späh_step1 = 2; }
                else
                if (späh_step1 == 2) { GeheZuKoordinate(550, 0); späh_step1 = 3; }
                else
                if (späh_step1 == 3) { GeheZuKoordinate(0, 650); späh_step1 = 4; }
                else
                if (späh_step1 == 4) { GeheZuKoordinate(-750, 0); späh_step1 = 5; }
                else
                if (späh_step1 == 5) { GeheZuKoordinate(0, -850); späh_step1 = 6; }
                else
                if (späh_step1 == 6) { GeheZuKoordinate(950, 0); späh_step1 = 7; }
                else
                if (späh_step1 == 7) { GeheZuKoordinate(0, -1050); späh_step1 = 8; }
            }
            if (Kaste == "Späher2")
            {
                if (späh_step2 == 0) { GeheZuKoordinate(0, -350); späh_step2 = 1; }
                else
                if (späh_step2 == 1) { GeheZuKoordinate(450, 0); späh_step2 = 2; }
                else
                if (späh_step2 == 2) { GeheZuKoordinate(0, 550); späh_step2 = 3; }
                else
                if (späh_step2 == 3) { GeheZuKoordinate(-650, 0); späh_step2 = 4; }
                else
                if (späh_step2 == 4) { GeheZuKoordinate(0, -750); späh_step2 = 5; }
                else
                if (späh_step2 == 5) { GeheZuKoordinate(850, 0); späh_step2 = 6; }
                else
                if (späh_step2 == 6) { GeheZuKoordinate(0, 950); späh_step2 = 7; }
                else
                if (späh_step2 == 7) { GeheZuKoordinate(-1050, 0); späh_step2 = 8; }
            }
            if (Kaste == "Späher3")
            {
                if (späh_step3 == 0) { GeheZuKoordinate(350, 0); späh_step3 = 1; }
                else
                if (späh_step3 == 1) { GeheZuKoordinate(0, 450); späh_step3 = 2; }
                else
                if (späh_step3 == 2) { GeheZuKoordinate(-550, 0); späh_step3 = 3; }
                else
                if (späh_step3 == 3) { GeheZuKoordinate(0, -650); späh_step3 = 4; }
                else
                if (späh_step3 == 4) { GeheZuKoordinate(750, 0); späh_step3 = 5; }
                else
                if (späh_step3 == 5) { GeheZuKoordinate(0, 850); späh_step3 = 6; }
                else
                if (späh_step3 == 6) { GeheZuKoordinate(-950, 0); späh_step3 = 7; }
                else
                if (späh_step3 == 7) { GeheZuKoordinate(0, -1050); späh_step3 = 8; }
            }
            if (Kaste == "Späher4")
            {
                if (späh_step4 == 0) { GeheZuKoordinate(0, 350); späh_step4 = 1; }
                else
                if (späh_step4 == 1) { GeheZuKoordinate(-450, 0); späh_step4 = 2; }
                else
                if (späh_step4 == 2) { GeheZuKoordinate(0, -550); späh_step4 = 3; }
                else
                if (späh_step4 == 3) { GeheZuKoordinate(650, 0); späh_step4 = 4; }
                else
                if (späh_step4 == 4) { GeheZuKoordinate(0, 750); späh_step4 = 5; }
                else
                if (späh_step4 == 5) { GeheZuKoordinate(-850, 0); späh_step4 = 6; }
                else
                if (späh_step4 == 6) { GeheZuKoordinate(0, -950); späh_step4 = 7; }
                else
                if (späh_step4 == 7) { GeheZuKoordinate(1050, 0); späh_step4 = 8; }
            }

            if (Kaste == "FSpäher")
            {
                if (Speicher.späh_stepf == 0)
                {
                    GeheZuKoordinate(-50, -50);
                    GeheGeradeaus();
                    Speicher.späh_stepf = 1;
                }
                else
                if (Speicher.späh_stepf == 1)
                {
                    GeheZuKoordinate(50, -50);
                    GeheGeradeaus();
                    Speicher.späh_stepf = 2;
                }
                else
                if (Speicher.späh_stepf == 2) //#?#?#?#?#?#?#?#?#?#?#?#?#
                {
                    GeheZuKoordinate(50, 50);
                    GeheGeradeaus();
                    Speicher.späh_stepf = 3;
                }
                if (Speicher.späh_stepf == 3)
                {
                    GeheZuKoordinate(-50, 50);
                    GeheGeradeaus();
                    Speicher.späh_stepf = 0;
                }
            }
            #endregion

            if (Kaste == "Sammler")
            {
                if (Speicher.akt_obst != null && AktuelleLast == 0)
                {
                    GeheZuZielOptimized(Speicher.akt_obst);
                    Speicher.obst_counter = Speicher.obst_counter + 1;
                }
                else
                if (Speicher.akt_zucker != null && AktuelleLast == 0)
                {
                    GeheZuZielOptimized(Speicher.akt_zucker);
                    Speicher.zucker_counter = Speicher.zucker_counter + 1;
                }
                else
                    GeheGeradeaus();
            }

            if (Kaste == "Kämpfer")
            {
                if (Speicher.akt_wanze != null)
                {
                    GeheZuZielOptimized(Speicher.akt_wanze);
                    Speicher.wanzen_counter = Speicher.wanzen_counter + 1;
                }
                else
                GeheGeradeaus();
            }

            if (Kaste == "ZuckerKämpfer")
            {
                if (Speicher.akt_zucker != null)
                {
                    GeheZuZielOptimized(Speicher.akt_zucker);
                }
                else
                GeheGeradeaus();
            }
        }

        public override void WirdMüde()
        {
        }

        public override void IstGestorben(Todesart todesart)
        {
            if (Kaste == "Sammler" && AktuelleLast >= 10 && (ZielOptimized == Speicher.bau || Ziel == Speicher.bau))
            {
                Speicher.zucker_counter = Speicher.zucker_counter - 1;
            }
        }

        public override void Tick()
        {
            // Ziel erreicht Aktion
            if (ZielOptimized != null)
            {
                int distance = Koordinate.BestimmeEntfernung(this, ZielOptimized);
                if (distance < Sichtweite / 1.5)
                {
                    GeheZuZiel(ZielOptimized);
                    ZielOptimized = null;
                }
            }

            // Resurcen Refresher
            if (Speicher.akt_zucker != null && Speicher.akt_zucker.Menge <= 0)
            {
                Speicher.zucker_sort();
            }
            if (Speicher.zucker_counter >= 100)
            {
                Speicher.zucker_refresh();
                Speicher.zucker_counter = 0;
            }
            if (Speicher.obst_counter >= 5)
            {
                Speicher.obst_refresh();
                Speicher.obst_counter = 0;
            }
            if (Speicher.wanzen_counter >= 10)
            {
                Speicher.akt_wanze = null;
                Speicher.wanzen_counter = 0;
            }

            // Obst tragerichtung reset
            if (Kaste == "Sammler" && GetragenesObst != null && AktuelleLast > 0)
            {
                obst_angle_reset = obst_angle_reset + 1;
                if (obst_angle_reset >= 250)
                {
                    GeheZuBauOptimized();
                    obst_angle_reset = 0;
                }
            }

            // Zuweit laufende Ameisen korigieren
            if (Kaste == "Sammler" && AktuelleLast == 10 && EntfernungZuBau < 80)
            {
                GeheZuBauOptimized();
            }

            // Zulange nichts reset // bringt nicht viel
            if ((Kaste == "Sammler" || Kaste == "ZuckerKämpfer") && ZielOptimized == null)
            {
                do_nothing_counter = do_nothing_counter + 1;
                if (do_nothing_counter >= 100)
                {
                    BleibStehen();
                    do_nothing_counter = 0;
                }
            }

            // Kampfradius
            if (Kaste == "Kämpfer" && EntfernungZuBau > 350)
            {
                GeheZuBauOptimized();
            }

            // Zuckerkämpfer beim Zucker behalten
            if (Kaste == "Zuckerkämpfer" && Koordinate.BestimmeEntfernung(this, Speicher.akt_zucker) > 50)
            {
                GeheZuZielOptimized(Speicher.akt_zucker);
            }

            // Identifier
            if (Kaste == "FSpäher" || Kaste == "Späher1" || Kaste == "Späher2" || Kaste == "Späher3" || Kaste == "Späher4")
            {
                Denke("SP");
            }
            if (Kaste == "Sammler")
            {
                Denke("S");
            }
            if (Kaste == "Kämpfer")
            {
                Denke("K");
            }
            if (Kaste == "ZuckerKämpfer")
            {
                Denke("ZK");
            }
        }

        #endregion

        #region Nahrung

        public override void Sieht(Obst obst)
        {
            if (Speicher.akt_obst == null && !Speicher.obst_old.Contains(obst) && Koordinate.BestimmeEntfernung(Speicher.bau, obst) < 1050)
            {
                Speicher.akt_obst = obst;
            }
            else
            if (!Speicher.obst_list.Contains(obst) && !Speicher.obst_old.Contains(obst) && Koordinate.BestimmeEntfernung(obst, Speicher.bau) < 1050)
            {
                Speicher.obst_list.Add(obst);
            }

            if (Kaste == "Sammler" && ZielOptimized == null && BrauchtNochTräger(obst))
            {
                GeheZuZielOptimized(obst);
            }
        }

        public override void Sieht(Zucker zucker)
        {
            if (Speicher.akt_zucker == null && Koordinate.BestimmeEntfernung(Speicher.bau, zucker) < 1050)
            {
                Speicher.akt_zucker = zucker;
            }
            else
            if (!Speicher.zucker_list.Contains(zucker) && Koordinate.BestimmeEntfernung(Speicher.bau, zucker) < 1050)
            {
                Speicher.zucker_list.Add(zucker);
                Speicher.zucker_sort();
            }

            if (Kaste == "Sammler" && ZielOptimized == null)
            {
                GeheZuZielOptimized(zucker);
            }
        }

        public override void ZielErreicht(Obst obst)
        {
            if (Kaste == "Sammler" && BrauchtNochTräger(obst))
            {
                Nimm(obst);
                GeheZuBauOptimized();
            }
        }

        public override void ZielErreicht(Zucker zucker)
        {
            if (Kaste == "Sammler")
            {
                Nimm(zucker);
                GeheZuBauOptimized();
            }
        }

        #endregion

        #region Kommunikation

        public override void RiechtFreund(Markierung markierung)
        {
        }

        public override void SiehtFreund(Ameise ameise)
        {
        }

        public override void SiehtVerbündeten(Ameise ameise)
        {
        }

        #endregion

        #region Kampf

        public override void SiehtFeind(Ameise ameise)
        {
            if (Kaste == "Kämpfer" && ameise.MaximaleGeschwindigkeit <= MaximaleGeschwindigkeit)
            {
                GreifeAn(ameise);
            }

            if (Kaste == "ZuckerKämpfer")
            {
                if (Koordinate.BestimmeEntfernung(this, ameise) > 10)
                {
                    GeheZuZielOptimized(ameise);
                }
                else
                    GreifeAn(ameise);
            }
        }

        public override void SiehtFeind(Wanze wanze)
        {
            if (EntfernungZuBau < 300)
            {
                Speicher.akt_wanze = wanze;
            }

            // Wanzen umgehen ################### wenig effect
            
            if (Kaste == "Sammler" && ZielOptimized == Speicher.bau)
            {
                int ziel_angle = Koordinate.BestimmeRichtung(this, ZielOptimized);
                int wanz_angle = Koordinate.BestimmeRichtung(this, wanze);
                int diff = ziel_angle - wanz_angle;

                // rechtsrum
                if (0 <= diff && diff < 4)
                {
                    DreheUmWinkel(-6);
                    GeheGeradeaus();
                }
                else
                if (4 <= diff && diff < 7)
                {
                    DreheUmWinkel(-4);
                    GeheGeradeaus();
                }
                else
                // linksrum
                if (0 > diff && diff > -5)
                {
                    DreheUmWinkel(6);
                    GeheGeradeaus();
                }
                else
                if (-5 > diff && diff > -8)
                {
                    DreheUmWinkel(4);
                    GeheGeradeaus();
                }
                else
                    GeheZuZielOptimized(ZielOptimized);
            }
            

            if (Kaste == "Kämpfer" && AnzahlAmeisenDerSelbenKasteInSichtweite >= 2)
            {
                if (Koordinate.BestimmeEntfernung(this, wanze) < 10)
                {
                    GreifeAn(wanze);
                }
                else
                {
                    GeheZuZielOptimized(wanze);
                }
            }
        }

        public override void WirdAngegriffen(Ameise ameise)
        {
            if (Kaste == "Kämpfer" && Kaste == "ZuckerKämpfer")
            {
                GreifeAn(ameise);
            }
        }

        public override void WirdAngegriffen(Wanze wanze)
        {
            if (Kaste == "Kämpfer")
            {
                GreifeAn(wanze);
            }
        }

        #endregion

        #region BASE Funktionen

        protected void GeheZuKoordinate(int x, int y)
        {
            int myX = BestimmeX(this);
            int myY = BestimmeY(this);

            int diffX = x - myX;
            int diffY = y - myY;

            int distance = (int)Math.Sqrt((diffX * diffX) + (diffY * diffY));
            double radiant = Math.Atan2(diffY, diffX);
            int richtung = (int)((radiant / (2 * Math.PI)) * 360);

            DreheInRichtung(richtung);
            GeheGeradeaus(distance);
        }

        protected int BestimmeX(Spielobjekt spielobjekt)
        {
            int richtung = Koordinate.BestimmeRichtung(Speicher.bau, this);
            int distance = Koordinate.BestimmeEntfernung(Speicher.bau, this) + 32;

            float angle = ((float)richtung / 360) * ((float)Math.PI * 2);

            return (int)(Math.Cos(angle) * distance);
        }

        protected int BestimmeY(Spielobjekt spielobjekt)
        {
            int richtung = Koordinate.BestimmeRichtung(Speicher.bau, this);
            int distance = Koordinate.BestimmeEntfernung(Speicher.bau, this) + 32;

            float angle = ((float)richtung / 360) * ((float)Math.PI * 2);

            return (int)(Math.Sin(angle) * distance);
        }

        protected int BestimmeX(CoreAnt spielobjekt)
        {
            int richtung = Koordinate.BestimmeRichtung(Speicher.bau, this);
            int distance = Koordinate.BestimmeEntfernung(Speicher.bau, this) + 32;

            float angle = ((float)richtung / 360) * ((float)Math.PI * 2);

            return (int)(Math.Cos(angle) * distance);
        }

        protected int BestimmeY(CoreAnt spielobjekt)
        {
            int richtung = Koordinate.BestimmeRichtung(Speicher.bau, this);
            int distance = Koordinate.BestimmeEntfernung(Speicher.bau, this) + 32;

            float angle = ((float)richtung / 360) * ((float)Math.PI * 2);

            return (int)(Math.Sin(angle) * distance);
        }

        protected void GeheZuZielOptimized(Spielobjekt spielobjekt)
        {
            if (spielobjekt != null)
            {
                int angle = Koordinate.BestimmeRichtung(this, spielobjekt);
                int distance = Koordinate.BestimmeEntfernung(this, spielobjekt);
                DreheInRichtung(angle);
                GeheGeradeaus(distance);
                ZielOptimized = spielobjekt;
            }
        }

        protected void GeheZuBauOptimized()
        {
            GeheZuZielOptimized(Speicher.bau);
        }

        #endregion
    }
}
