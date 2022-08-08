// See https://aka.ms/new-console-template for more information
using Library;
using System;
using System.Collections;
using System.Collections.Generic;



static void afisareMeniu() {
    Console.WriteLine("----- \n MENIU    ");
    Console.WriteLine("1. Adauga o carte in biblioteca.");
    Console.WriteLine("2. Afisare carti din biblioteca.");
    Console.WriteLine("3. Afisare exemplare disponibile carte.");
    Console.WriteLine("4. Imprumutare carte.");
    Console.WriteLine("5. Restituire carte.");
    Console.WriteLine("6. Lista cititori.");
    Console.WriteLine("----------\n");
}


try {
    List<Carte> listaCarti = new List<Carte>();
    List<Cititor> listaCititori = new List<Cititor>();

    Carte uglyLove = new Carte("Ugly Love", "9786068754079", 30.3, 1);
    Carte artaManipularii = new Carte("Arta manipularii", "9786069456392", 19.95, 1);
    Carte hotulDeCarti = new Carte("Hotul de carti", "9786066096133", 24.5, 1);

    listaCarti.Add(hotulDeCarti);
    listaCarti.Add(uglyLove);
    listaCarti.Add(artaManipularii);

    int index = 0;
    int alegere;
    string confirmare;

    do {
        // afisare meniu
        afisareMeniu();
        Console.Write("Alege o optiune(1-5): ");
        alegere = int.Parse(Console.ReadLine());
        Console.Clear();

        switch (alegere) {
            case 1:
                adaugareCarteInBiblioteca(listaCarti);
                break;
            case 2:
                afisareCarti(listaCarti, "\n");
                break;
            case 3:
                Console.WriteLine("----- Afisare exemplare disponibile carte ------");

                Console.WriteLine("Numele cartii: ");
                string numeCarteCautata = Console.ReadLine().ToString();

                afisareExemplareDisponibile(listaCarti, numeCarteCautata);
                break;
            case 4:
                Console.WriteLine("----- Imprumuta carte ------");

                Console.WriteLine("Numele cartii: ");
                string numeCarteImprumutata = Console.ReadLine().ToString();

                Console.WriteLine("Numele cititorului: ");
                string numeCititor = Console.ReadLine().ToString();

                imprumutaCarte(listaCarti, numeCarteImprumutata, listaCititori, numeCititor);
                break;
            case 5:
                Console.WriteLine("----- Restituie carte ------");

                Console.WriteLine("Numele cartii: ");
                string numeCarteRestituita = Console.ReadLine().ToString();

                Console.WriteLine("Numele abonatului: ");
                string numeAbonat = Console.ReadLine().ToString();
                
                Console.Write("Luna restituirii: ");
                int month = int.Parse(Console.ReadLine());

                Console.Write("Ziua restituirii: ");
                int day = int.Parse(Console.ReadLine());

                Console.Write("Anul restituirii ");

                int year = int.Parse(Console.ReadLine());

                if (day < 32 && month < 13)
                {
                    DateTime dataRestituirii = new DateTime(year, month, day);

                    restituieCarte(listaCarti, numeCarteRestituita, listaCititori, numeAbonat, dataRestituirii);
                }
                else {
                    Console.Write("Ati introdus o data gresita!");
                }

                break;
            case 6:
                afisareCititori(listaCititori, "\n");
                break;

            default: 
                Console.WriteLine("invalid");
                break;
        }

        Console.WriteLine("Scrie ok sau OK pentru a continua:");
        confirmare = Console.ReadLine().ToString();
        Console.Clear();
    }
    while (confirmare == "ok" || confirmare == "OK");
}
catch (FormatException) {
    Console.WriteLine("Invalid input");
}


static void adaugareCarteInBiblioteca(List<Carte> listaCarti) {
    Console.WriteLine("----- Adauga carte in biblioteca ------");

    Console.WriteLine("Numele cartii: ");
    string numeCarte = Console.ReadLine().ToString();

    Console.WriteLine("Pretul cartii: ");
    double pret = double.Parse(Console.ReadLine());

    Console.WriteLine("ISBN-ul cartii: ");
    string ISBNCarte = Console.ReadLine().ToString();

    Carte carteExistentaInBiblioteca = listaCarti
                .FirstOrDefault(x => x.ToString().Contains(ISBNCarte));

    if (carteExistentaInBiblioteca != null) {
        carteExistentaInBiblioteca.NumarExemplare = carteExistentaInBiblioteca.NumarExemplare + 1;
    }
    else {
        Carte carte = new Carte(numeCarte, ISBNCarte, pret, 1);
        listaCarti.Add(carte);
    }
    
}


 static void afisareCarti(List<Carte> listaCarti, string separator)
{
    // concateneaza elementele listei folosind separatorul separator
    Console.WriteLine(string.Join(separator, listaCarti));
}

static void afisareCititori(List<Cititor> listaCititori, string separator)
{
    // concateneaza elementele listei folosind separatorul separator
    Console.WriteLine(string.Join(separator, listaCititori));
}

static void afisareExemplareDisponibile(List<Carte> listaCarti, string numeCarte) {
   
    // returneaza primul element gasit care satisface conditia
    Carte carteExistentaInBiblioteca = listaCarti
                .FirstOrDefault(x => x.ToString().Contains(numeCarte));

    if (carteExistentaInBiblioteca != null)
    {
        if (carteExistentaInBiblioteca.NumarExemplare > 0)
        {
            Console.WriteLine(carteExistentaInBiblioteca.ToString());
        }
        else {
            Console.WriteLine("Pentru cartea " + numeCarte +  " nu exista niciun exemplar disponibil!!");
        }
    }
    else {
        Console.WriteLine("Nu exista cartea in biblioteca!!");
    }
}


static void imprumutaCarte(List<Carte> listaCarti, string numeCarte, List<Cititor> listaCititori, string numeCititor)
{

    DateTime data = DateTime.Now;

    DateTime dataImprumutarii = data.Date;

    // returneaza primul element gasit care satisface conditia
    Carte carteExistentaInBiblioteca = listaCarti
    .FirstOrDefault(x => x.ToString().Contains(numeCarte));

    if (carteExistentaInBiblioteca != null)
    {
        Cititor cititor = new Cititor(numeCititor, dataImprumutarii, carteExistentaInBiblioteca, true);

        carteExistentaInBiblioteca.NumarExemplare = carteExistentaInBiblioteca.NumarExemplare - 1;

        listaCititori.Add(cititor);
    }
    else {
        Console.WriteLine("Nu exista cartea in biblioteca!!");
    }
    
}

static void restituieCarte (List<Carte> listaCarti, string numeCarte, List<Cititor> listaCititori, string numeCititor, DateTime dataRestituirii) {

    // returneaza primul element gasit care satisface conditia
    Cititor cititorExistent = listaCititori
            .FirstOrDefault(x => x.ToString().Contains(numeCititor));

    if (cititorExistent != null)
    {
        // returneaza primul element gasit care satisface conditia
        Carte carteImprumutata = cititorExistent.CarteImprumutata;

        double pretCarte = carteImprumutata.PretCarte;

        if (carteImprumutata != null) {

            int anulRestituirii = dataRestituirii.Year;
            int lunaRestituirii = dataRestituirii.Month;
            int ziuaRestituirii = dataRestituirii.Day;

            DateTime dataimprumutarii = cititorExistent.DataImprumutarii;

            int anulImprumutarii = dataimprumutarii.Year;
            int lunaImprumutarii = dataimprumutarii.Month;
            int ziuaImprumutarii = dataimprumutarii.Day;

            if (anulImprumutarii <= anulRestituirii && lunaImprumutarii <= lunaRestituirii && ziuaImprumutarii <= ziuaRestituirii)
            {
                double numarZile = (dataRestituirii - cititorExistent.DataImprumutarii).TotalDays;

                if (numarZile > 14)
                {
                    double zileDePlata = numarZile - 14;

                    double dePlatit = (pretCarte * 0.01) * zileDePlata;

                    cititorExistent.Platit = false;

                    Console.WriteLine("Pentru a restitui cartea, trebuie sa platiti " + dePlatit + " lei!");

                    Console.WriteLine("Pentru a plati, tasteaza ok sau OK");

                    string dorintaPlata = Console.ReadLine().ToString();

                    if (dorintaPlata == "ok" || dorintaPlata == "OK")
                    {
                        cititorExistent.Platit = true;

                        Carte carteExistentaInBiblioteca = listaCarti
                            .FirstOrDefault(x => x.ToString().Contains(numeCarte));

                        if (carteExistentaInBiblioteca != null) {
                            carteExistentaInBiblioteca.NumarExemplare = carteExistentaInBiblioteca.NumarExemplare + 1;
                        }

                        Console.WriteLine("Cartea s-a restituit!");
                    }
                    else
                    {
                        Console.WriteLine("Cartea nu s-a putut restitui!");
                    }
                }
                else
                {
                    Carte carteExistentaInBiblioteca = listaCarti
                        .FirstOrDefault(x => x.ToString().Contains(numeCarte));

                    if (carteExistentaInBiblioteca != null) {
                        carteExistentaInBiblioteca.NumarExemplare = carteExistentaInBiblioteca.NumarExemplare + 1;
                    }
                    
                    Console.WriteLine("Cartea s-a restituit!");
                }
            }
            else {
                Console.WriteLine("Ati introdus o data a restituirii anterioara celei de imprumutare!");
            }
        }
        else {
            Console.WriteLine("Nu ati imprumutat aceasta carte!");
        }
    }
    else {
        Console.WriteLine("Nu sunteti abonat la serviciile noastre!");
    }
}


