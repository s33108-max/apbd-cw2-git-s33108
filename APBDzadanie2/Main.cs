using System;
using System.Linq;
using APBDzadanie2.Modele;
using APBDzadanie2.Serwisy;
using APBDzadanie2.Wyjatki;

namespace APBDzadanie2;

class Program
{
    static void Main()
    {

        IKalkulatorKar kalkulator = new KalkulatorKar(12.0m); 
        ISerwisSprzetu serwisSprzetu = new SerwisSprzetu();
        ISerwisWypozyczen serwisWypozyczen = new SerwisWypozyczen(kalkulator);
        
        
        
        Kamera kamera = new Kamera("Lumix GH6", "Panasonic", 2023, 120, false);
        Laptop laptop = new Laptop("MacBook Pro", "Apple", 2024, "macOS", 14.2);
        Projektor projektor = new Projektor("EB-W51", "Epson", 2022, 4000, true);
        
        
        serwisSprzetu.DodajSprzet(laptop);
        serwisSprzetu.DodajSprzet(projektor);
        serwisSprzetu.DodajSprzet(kamera);
        
        Student student = new Student("Alina", "Maslo", "Student", "s12345");
        Pracownik pracownik = new Pracownik("Anna", "Nowak", "Wykładowca", "Baz Danych");
        
        serwisWypozyczen.UtworzWypozyczenie(student, laptop, DateTime.Now, DateTime.Now.AddDays(3));
        Console.WriteLine($"Sukces: {student.Imie} wypożyczył sprzęt: {laptop.Nazwa}.\n");
        
        try
        {
            // Pracownik próbuje wypożyczyć ten sam laptop, który przed chwilą wypozyczyl student
            serwisWypozyczen.UtworzWypozyczenie(pracownik, laptop, DateTime.Now, DateTime.Now.AddDays(2));
        }
        catch (Exception ex) 
        {
            Console.WriteLine($"{ex.Message}\n");
        }
        
        var wypozyczenieStudenta = serwisWypozyczen.PobierzWypozyczeniaOsoby(student).First();
        serwisWypozyczen.ZwrocSprzet(wypozyczenieStudenta.Id, DateTime.Now.AddDays(1)); //oddajemy po 1 dniu
        
        //spozniene oddanie 
        serwisWypozyczen.UtworzWypozyczenie(pracownik, projektor, DateTime.Now, DateTime.Now.AddDays(2));
        var wypozyczeniePracownika = serwisWypozyczen.PobierzWypozyczeniaOsoby(pracownik).First();
        serwisWypozyczen.ZwrocSprzet(wypozyczeniePracownika.Id, DateTime.Now.AddDays(6));
        Console.WriteLine($"Zwrócono po terminie! Naliczona kara: {wypozyczeniePracownika.PenaltyFee} zł.\n");
        
        var wszystkieWypozyczenia = serwisWypozyczen.PobierzWszystkie();
        var dostepnySprzet = serwisSprzetu.PobierzDostepne();
        
        Console.WriteLine($"Całkowita historia wypożyczeń: {wszystkieWypozyczenia.Count}");
        Console.WriteLine($"Aktualnie dostępny sprzęt na półkach ({dostepnySprzet.Count} szt.):");
        foreach (var s in dostepnySprzet)
        {
            Console.WriteLine($" - {s.Nazwa} (Marka: {s.Marka})");
        }
    }
}