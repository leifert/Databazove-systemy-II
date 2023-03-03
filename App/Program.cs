using System;
using System.Collections.ObjectModel;
using VolejbalovaLigaORM;
using VolejbalovaLigaORM.ORM;
using VolejbalovaLigaORM.ORM.DAO.mssql;
using System.Windows.Forms;

namespace VolejbalovaLigaORM
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
           
            
            Database db = new Database();
            db.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new menu());

            ////// 1.1 Novy trener
            //Console.WriteLine("\n1.1 Novy trener");
            //int count1 = TrenerTable.Select(db).Count;
            //Trener t = new Trener();
            //t.jmeno = "Alfred";
            //t.prijmeni = "Kratochvil";
            //TrenerTable.Insert(t, db);
            //int count2 = TrenerTable.Select(db).Count;
            //Console.WriteLine("#Pred insertem: " + count1);
            //Console.WriteLine("#Po insertu: " + count2);

            //// 1.2 Seznam treneru
            //Console.WriteLine("\n1.2 Seznam treneru");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}", "id_trener", "jmeno", "prijmeni");
            //Collection<Trener> t2 = TrenerTable.Select(db);
            //foreach (Trener i in t2)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}", i.id_trener, i.jmeno, i.prijmeni);

            //// 1.3 Aktualizace trenera
            //Console.WriteLine("\n1.3 Aktualizace trenera");
            //t.id_trener = 1;
            //t.jmeno = "Karel";
            //t.prijmeni = "Novak";
            //TrenerTable.Update(t, db);


            //// 2.1 Nova hala
            //Console.WriteLine("\n2.1 Nova hala");
            //count1 = HalaTable.Select(db).Count;
            //Hala h = new Hala();
            //h.nazev = "hala1";
            //h.adresa = "U stadionu 16, Opava";
            //h.kapacita = 1500;
            //h.cena_listku = 250;
            //HalaTable.Insert(h, db);
            //count2 = HalaTable.Select(db).Count;
            //Console.WriteLine("#Pred insertem: " + count1);
            //Console.WriteLine("#Po insertu: " + count2);

            //// 2.2 Seznam hal
            //Console.WriteLine("\n2.2 Seznam hal");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", "id_hala", "nazev", "adresa", "kapacita", "cena_listku");
            //Collection<Hala> h2 = HalaTable.Select(db);
            //foreach (Hala i in h2)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", i.id_hala, i.nazev, i.adresa, i.kapacita, i.cena_listku);

            //// 2.3 Detail haly
            //Hala detail = new Hala();
            //Console.WriteLine("\n2.3 Detail haly");
            //detail = HalaTable.DetailHaly(5, db);
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", detail.id_hala, detail.nazev, detail.adresa, detail.kapacita, detail.cena_listku);

            //// 2.4 Aktualizace haly
            //Console.WriteLine("\n2.4 Aktualizace haly");
            //h.id_hala = 1;
            //h.nazev = "neco";
            //h.adresa = "sladova";
            //h.kapacita = 1500;
            //h.cena_listku = 200;
            //HalaTable.Update(h, db);

            //// 2.5 Seznam hal podle prumerne navstevnosti
            //h2 = HalaTable.Prumerna_Navstevnost();
            //Console.WriteLine("\n2.5 Seznam hal podle prumerne navstevnosti");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", "nazev", "adresa", "kapacita", "prumer");
            //foreach (Hala i in h2)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", i.nazev, i.adresa, i.kapacita, i.prumer);

            //// 3.1 Novy zaznam klubu
            //Console.WriteLine("\n3.1 Novy zaznam klubu");
            //count1 = TabulkaTable.Select(db).Count;
            //Tabulka k = new Tabulka();
            //k.id_klub = 3;
            //k.zapasy_celkem = 0;
            //k.vyhry = 0;
            //k.prohry = 0;
            //k.vyhrane_sety = 0;
            //k.prohrane_sety = 0;
            //k.body = 0;
            //TabulkaTable.Insert(k, db);
            //count2 = TabulkaTable.Select(db).Count;
            //Console.WriteLine("#Pred insertem: " + count1);
            //Console.WriteLine("#Po insertu: " + count2);

            ////3.2 Tabulka volejbalovych klubu
            //Collection<Tabulka> vys = TabulkaTable.Vysledna_tabulka();
            //Console.WriteLine("\n3.2 Tabulka volejbalovych klubu");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", "nazev", "zapasy_celkem", "vyhry", "prohry", "vyhrane_sety", "prohrane_sety", "body");
            //foreach (Tabulka i in vys)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", i.nazev, i.zapasy_celkem, i.vyhry, i.prohry, i.vyhrane_sety, i.prohrane_sety, i.body);

            //// 3.3 Aktualizace klubu
            //Console.WriteLine("\n3.3 Aktualizace klubu");
            //k.id_klub = 3;
            //k.zapasy_celkem = 1;
            //k.vyhry = 0;
            //k.prohry = 0;
            //k.vyhrane_sety = 0;
            //k.prohrane_sety = 0;
            //k.body = 0;
            //TabulkaTable.Update(k, db);

            //// 3.4 odstraneni klubu
            //Console.WriteLine("\n3.4 odstraneni klubu");
            //int dltCount = TabulkaTable.Delete(3, db);
            //Console.WriteLine("#D: " + dltCount);
            //count2 = TabulkaTable.Select(db).Count;
            //Console.WriteLine("#Po deletu: " + count2);

            //// 4.1 Novy hrac
            //Console.WriteLine("\n4.1 Novy hrac");
            //count1 = HracTable.Select(db).Count;
            //Hrac hr = new Hrac();
            //hr.id_klub = 2;
            //hr.jmeno = "Jan";
            //hr.prijmeni = "Štokr";
            //hr.datum_narozeni = new DateTime(1983, 1, 16);
            //hr.pozice = "univerzál";
            //hr.vyska = 200;
            //hr.stav = "Aktivní";
            //HracTable.Insert(hr, db);
            //count2 = HracTable.Select(db).Count;
            //Console.WriteLine("#Pred insertem: " + count1);
            //Console.WriteLine("#Po insertu: " + count2);

            ////4.2 Smazani hrace
            //Console.WriteLine("\n4.2 Smazani hrace");
            //HracTable.delete(1, db);
            //Hrac Dhrac = new Hrac();
            //Dhrac = HracTable.DetailHrace(1, db);
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", Dhrac.id_hrac, Dhrac.id_klub, Dhrac.jmeno, Dhrac.prijmeni, Dhrac.datum_narozeni, Dhrac.pozice, Dhrac.vyska, Dhrac.stav);

            ////4.3 Obnoveni hrace
            //Console.WriteLine("\n4.3 Obnoveni hrace");
            //HracTable.ObnoveniHrace(1, db);
            //Dhrac = HracTable.DetailHrace(1, db);
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", Dhrac.id_hrac, Dhrac.id_klub, Dhrac.jmeno, Dhrac.prijmeni, Dhrac.datum_narozeni, Dhrac.pozice, Dhrac.vyska, Dhrac.stav);


            ////4.4 Aktualizace hrace
            //Console.WriteLine("\n4.4 Aktualizace hrace");
            //hr.vyska = 206;
            //HracTable.Update(hr, db);

            //// 4.5 Seznam hracu
            //Console.WriteLine("\n4.5 Seznam hracu");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", "id_hrace", "id_klub", "jmeno", "prijmeni", "datum_narozeni", "pozice", "vyska", "stav");
            //Collection<Hrac> hr2 = HracTable.Select(db);
            //foreach (Hrac i in hr2)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", i.id_hrac, i.id_klub, i.jmeno, i.prijmeni, i.datum_narozeni, i.pozice, i.vyska, i.stav);

            ////4.6 Detail hrace
            //Console.WriteLine("\n4.6 Detail hrace");
            //hr = HracTable.DetailHrace(3, db);
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", hr.id_hrac, hr.id_klub, hr.jmeno, hr.prijmeni, hr.datum_narozeni, hr.pozice, hr.vyska, hr.stav);

            ////4.7 Seznam hracu v klubu
            //Console.WriteLine("\n4.7 Seznam hracu v klubu");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", "id_hrace", "id_klub", "jmeno", "prijmeni", "datum_narozeni", "pozice", "vyska", "stav");
            //Collection<Hrac> hr3 = HracTable.Seznam_hracu_v_klubu(1, db);
            //foreach (Hrac i in hr3)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", i.id_hrac, i.id_klub, i.jmeno, i.prijmeni, i.datum_narozeni, i.pozice, i.vyska, i.stav);

            ////4.8 Seznam hracu a statistiky v zapase
            //Console.WriteLine("\n4.8 Seznam hracu a statistiky v zapase");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", "klub", "jmeno", "prijmeni", "eso", "chybny_servis", "utok", "blok");
            //Collection<Hrac> statzap = HracTable.Statistika_hracu_zapas(1, db);
            //foreach (Hrac i in statzap)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", i.klub, i.jmeno, i.prijmeni, i.eso, i.chybny_servis, i.utok, i.blok);

            ////4.9 Seznam hracu a jejich celkove statistiky
            //Console.WriteLine("\n4.9 Seznam hracu a jejich celkove statistiky");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", "klub", "jmeno", "prijmeni", "eso", "chybny_servis", "utok", "blok");
            //Collection<Hrac> statcelkem = HracTable.Statistika_hracu_celkem(db);
            //foreach (Hrac i in statcelkem)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}", i.klub, i.jmeno, i.prijmeni, i.eso, i.chybny_servis, i.utok, i.blok);

            ////5.1 Novy prestup
            //Console.WriteLine("\n5.1 Novy prestup");
            //count1 = Historie_prestupuTable.Seznam_prestupu_hrace(2, db).Count;
            //Historie_prestupuTable.Prestup(2, 1, 40000);
            //count2 = Historie_prestupuTable.Seznam_prestupu_hrace(2, db).Count;
            //Console.WriteLine("#Pred prestupem: " + count1);
            //Console.WriteLine("#Po prestupu: " + count2);

            ////5.2 Aktualizace prestupu
            //Console.WriteLine("\n5.2 Aktualizace prestupu");
            //Historie_prestupu hist = new Historie_prestupu();
            //hist.id_prestup = 1;
            //hist.id_hrac = 1;
            //hist.stary_klub = 1;
            //hist.novy_klub = 2;
            //hist.datum_prestupu = new DateTime(2020, 1, 16);
            //hist.cena_prestupu = 50000;
            //Historie_prestupuTable.Update(hist, db);

            ////5.3 Vypis vsech prestupu hrace
            //Console.WriteLine("\n5.3 Vypis vsech prestupu hrace");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", "id_prestup", "id_hrac", "stary_klub", "novy_klub", "datum_prestupu", "cena");
            //Collection<Historie_prestupu> prestup = Historie_prestupuTable.Seznam_prestupu_hrace(1, db);
            //foreach (Historie_prestupu i in prestup)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", i.id_prestup, i.id_hrac, i.stary_klub, i.novy_klub, i.datum_prestupu, i.cena_prestupu);


            ////6.1 Novy rozhodci
            //Console.WriteLine("\n6.1 Novy rozhodci");
            //count1 = RozhodciTable.Select(db).Count;
            //Rozhodci r = new Rozhodci();
            //r.jmeno = "Miloš";
            //r.prijmeni = "Vondrka";
            //r.pocet_zapasu = 0;
            //r.stav = "Aktivní";
            //RozhodciTable.Insert(r, db);
            //count2 = RozhodciTable.Select(db).Count;
            //Console.WriteLine("#Pred insertem: " + count1);
            //Console.WriteLine("#Po insertu: " + count2);

            ////6.2 Aktualizace rozhodciho
            //Console.WriteLine("\n6.2 Aktualizace rozhodciho");
            //r.id_rozhodci = 2;
            //r.pocet_zapasu = 1;
            //RozhodciTable.Update(r, db);

            //// 6.3 Seznam vsech rozhodcich
            //Console.WriteLine("\n6.3 Seznam vsech rozhodcich");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", "id_rozhodci", "jmeno", "prijmeni", "pocet_zapasu", "stav");
            //Collection<Rozhodci> r2 = RozhodciTable.Select(db);
            //foreach (Rozhodci i in r2)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", i.id_rozhodci, i.jmeno, i.prijmeni, i.pocet_zapasu, i.stav);

            ////6.4 Smazani rozhodciho
            //Rozhodci Dr = new Rozhodci();
            //Console.WriteLine("\n6.4 Smazani rozhodciho");
            //RozhodciTable.Delete(1, db);
            //Dr = RozhodciTable.SelectID(1, db);
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", Dr.id_rozhodci, Dr.jmeno, Dr.prijmeni, Dr.pocet_zapasu, Dr.stav);

            ////6.5 Obnoveni rozhodciho
            //Console.WriteLine("\n6.5 Obnoveni rozhodciho");
            //RozhodciTable.ObnoveniRozhodciho(1, db);
            //Dr = RozhodciTable.SelectID(1, db);
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", Dr.id_rozhodci, Dr.jmeno, Dr.prijmeni, Dr.pocet_zapasu, Dr.stav);

            ////7.1 Novy klub
            //count1 = KlubTable.Select(db).Count;
            //Console.WriteLine("\n7.1 Novy klub");
            //Klub kl = new Klub();
            //kl.nazev = "VK Lvi Prah";
            //kl.id_hala = 4;
            //KlubTable.Insert(kl, db);
            //count2 = KlubTable.Select(db).Count;
            //Console.WriteLine("#Pred insertem: " + count1);
            //Console.WriteLine("#Po insertu: " + count2);

            ////7.2 Update klubu
            //Console.WriteLine("\n7.2 Update klubu");
            //kl.id_klub = 4;
            //kl.nazev = "VK Lvi Praha";
            //kl.id_trener = 1;
            //KlubTable.Update(kl, db);

            ////7.3 Seznam vsech klubu
            //Console.WriteLine("\n7.3 Seznam vsech klubu");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", "id_klub", "nazev", "id_trener", "id_hala");
            //Collection<Klub> kl2 = KlubTable.Select(db);
            //foreach (Klub i in kl2)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", i.id_klub, i.nazev, i.id_trener, i.id_hala);

            ////7.4 Detail klubu
            //Console.WriteLine("\n7.4 Detail klubu");
            //kl = KlubTable.DetailKlubu(1, db);
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", kl.id_klub, kl.nazev, kl.id_trener, kl.id_hala);

            //// 8.1 Novy zapas
            //Console.WriteLine("\n8.1 Novy zapas");
            //count1 = ZapasTable.Select(db).Count;
            //Zapas zap = new Zapas();
            //zap.kolo = 3;
            //zap.id_domaci = 1;
            //zap.id_hoste = 2;
            //zap.domaci_sety = 0;
            //zap.hoste_sety = 0;
            //zap.datum_zapasu = new DateTime(2020, 1, 16, 16, 00, 00);
            //zap.id_rozhodci = 1;
            //zap.pocet_divaku = 0;
            //ZapasTable.Insert(zap, db);
            //count2 = ZapasTable.Select(db).Count;
            //Console.WriteLine("#Pred insertem: " + count1);
            //Console.WriteLine("#Po insertu: " + count2);


            //// 8.2 Aktualizace zapasu
            //Console.WriteLine("\n8.2 Aktualizace zapasu");
            //zap.pocet_divaku = 156;
            //ZapasTable.Update(zap, db);

            ////8.3 Seznam zapasu
            //Console.WriteLine("\n8.3 Seznam zapasu");
            //Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}{8,-10}", "id_zapas", "kolo", "id_domaci", "id_hoste", "domaci_sety", "hoste_sety", "datum_zapasu", "id_rozhodci", "pocet_divaku");
            //Collection<Zapas> zap2 = ZapasTable.Select(db);
            //foreach (Zapas i in zap2)
            //    Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}{8,-10}", i.id_zapas, i.kolo, i.id_domaci, i.id_hoste, i.domaci_sety, i.hoste_sety, i.datum_zapasu, i.id_rozhodci, i.pocet_divaku);

            ////8.4 Seznam zápasů určitého kola
            //Console.WriteLine("\n8.4 Seznam zápasů urciteho kola");
            //Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}{8,-10}", "id_zapas", "kolo", "id_domaci", "id_hoste", "domaci_sety", "hoste_sety", "datum_zapasu", "id_rozhodci", "pocet_divaku");
            //Collection<Zapas> zap3 = ZapasTable.Seznam_zapasu_kola(1, db);
            //foreach (Zapas i in zap3)
            //    Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}{8,-10}", i.id_zapas, i.kolo, i.id_domaci, i.id_hoste, i.domaci_sety, i.hoste_sety, i.datum_zapasu, i.id_rozhodci, i.pocet_divaku);

            ////8.5 Detail zapasu
            //Console.WriteLine("\n8.5 Detail zapasu");
            //zap = ZapasTable.DetailZapasu(5, db);
            //Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}{5,-10}{6,-10}{7,-10}{8,-10}", zap.id_zapas, zap.kolo, zap.id_domaci, zap.id_hoste, zap.domaci_sety, zap.hoste_sety, zap.datum_zapasu, zap.id_rozhodci, zap.pocet_divaku);

            ////8.6 Seznam kol
            //Console.WriteLine("\n8.6 Seznam kol");
            //Console.WriteLine("{0,-10}", "kola");
            //Collection<Zapas> kola = ZapasTable.Seznam_kol(db);
            //foreach (Zapas i in kola)
            //    Console.WriteLine("{0,-10}", i.kolo);

            //// 8.7 Odehrani zapasu
            //Console.WriteLine("\n8.7 Odehrani zapasu");
            //Zapas odehrani = new Zapas();
            //odehrani = ZapasTable.DetailZapasu(5, db);
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", "id_zapas", "kolo", "id_domaci", "id_hoste", "domaci_sety", "hoste_sety", "datum_zapasu", "id_rozhodci", "pocet_divaku");
            //Console.WriteLine("Pred:\n{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", odehrani.id_zapas, odehrani.kolo, odehrani.id_domaci, odehrani.id_hoste, odehrani.domaci_sety, odehrani.hoste_sety, odehrani.datum_zapasu, odehrani.id_rozhodci, odehrani.pocet_divaku);
            //ZapasTable.Odehrat(5, 1, 2, 3, 3, 0, 1, 350);
            //odehrani = ZapasTable.DetailZapasu(5, db);
            //Console.WriteLine("Po:\n{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", odehrani.id_zapas, odehrani.kolo, odehrani.id_domaci, odehrani.id_hoste, odehrani.domaci_sety, odehrani.hoste_sety, odehrani.datum_zapasu, odehrani.id_rozhodci, odehrani.pocet_divaku);

            ////8.8 Zmena rozhodciho v zapase
            //Console.WriteLine("\n8.8 Zmena rozhodciho v zapase");
            //Zapas zmena = new Zapas();
            //zmena = ZapasTable.DetailZapasu(2, db);
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", "id_zapas", "kolo", "id_domaci", "id_hoste", "domaci_sety", "hoste_sety", "datum_zapasu", "id_rozhodci", "pocet_divaku");
            //Console.WriteLine("Pred:\n{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", zmena.id_zapas, zmena.kolo, zmena.id_domaci, zmena.id_hoste, zmena.domaci_sety, zmena.hoste_sety, zmena.datum_zapasu, zmena.id_rozhodci, zmena.pocet_divaku);
            //ZapasTable.ZmenaRozhodciho(2, 2, db);
            //zmena = ZapasTable.DetailZapasu(2, db);
            //Console.WriteLine("Po:\n{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", zmena.id_zapas, zmena.kolo, zmena.id_domaci, zmena.id_hoste, zmena.domaci_sety, zmena.hoste_sety, zmena.datum_zapasu, zmena.id_rozhodci, zmena.pocet_divaku);

            ////9.1 Nova statistika
            //Console.WriteLine("\n9.1 Nova statistika");
            //count1 = Statistika_zapasuTable.Select(db).Count;
            //Statistika_zapasu stat = new Statistika_zapasu();
            //stat.id_zapas = 2;
            //stat.id_hrac = 1;
            //stat.eso = 4;
            //stat.chybny_servis = 2;
            //stat.utok = 5;
            //stat.blok = 0;
            //Statistika_zapasuTable.Insert(stat, db);
            //count2 = Statistika_zapasuTable.Select(db).Count;
            //Console.WriteLine("#Pred insertem: " + count1);
            //Console.WriteLine("#Po insertu: " + count2);

            ////9.2 Aktualizace statistiky
            //Console.WriteLine("\n9.2 Aktualizace statistiky");
            //stat.id_zapas = 2;
            //stat.id_hrac = 1;
            //stat.chybny_servis = 3;
            //Statistika_zapasuTable.Update(stat, db);

            ////9.3 Detail statistiky hracu v zapase
            //Statistika_zapasu detailS = new Statistika_zapasu();
            //Console.WriteLine("\n9.3 Detail statistiky hracu v zapase");
            //detailS = Statistika_zapasuTable.DetailStatistiky(2, 1, db);
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", "id_zapas", "id_hrac", "eso", "chybny_servis", "utok", "blok");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", detailS.id_zapas, detailS.id_hrac, detailS.eso, detailS.chybny_servis, detailS.utok, detailS.blok);

            ////9.4 Seznam vsech statistik pro konkretni zapas
            //Console.WriteLine("\n9.4 Seznam vsech statistik pro konkretni zapas");
            //Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", "id_zapas", "id_hrac", "eso", "chybny_servis", "utok", "blok");
            //Collection<Statistika_zapasu> stat2 = Statistika_zapasuTable.Statistika_zapasu(1, db);
            //foreach (Statistika_zapasu i in stat2)
            //    Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20}", i.id_zapas, i.id_hrac, i.eso, i.chybny_servis, i.utok, i.blok);

            db.Close();
            Console.WriteLine("Press Enter to end");
            Console.ReadLine();
        }
    }
}
