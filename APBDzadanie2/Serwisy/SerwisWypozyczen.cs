using System;
using System.Collections.Generic;
using System.Linq;
using APBDzadanie2.Modele;
using APBDzadanie2.Wyjatki;
using APBDzadanie2.Enums;
namespace APBDzadanie2.Serwisy;

public class SerwisWypozyczen : ISerwisWypozyczen
{
    private readonly List<Wypozyczenie> _wypozyczenia = [];
    private readonly IKalkulatorKar _kalkulatorKar;

    // Wstrzykujemy kalkulator kar do serwisu
    public SerwisWypozyczen(IKalkulatorKar kalkulatorKar)
    {
        _kalkulatorKar = kalkulatorKar;
    }

    public void UtworzWypozyczenie(Osoba osoba, Sprzet sprzet, DateTime odKiedy, DateTime doKiedy)
    {
        // Używamy Twojego ENUMA!
        if (sprzet.Status != StatusSprzetu.DOSTEPNY)
        {
            throw new WyjatekSprzetNiedostepny(sprzet.Id);
        }

        int aktywneWypozyczeniaOsoby = _wypozyczenia.Count(w => 
                                        !w.IsCancelled 
                                        && w.ActualReturnDate == null 
                                        && w.Osoba == osoba);

        
       
        

        var noweWypozyczenie = new Wypozyczenie(sprzet, osoba, odKiedy, doKiedy);
        _wypozyczenia.Add(noweWypozyczenie);
        
        // Sprzęt został wypożyczony, zmieniamy status na niedostępny
        sprzet.Status = StatusSprzetu.NIEDOSTEPNY; 
    }

    public void ZwrocSprzet(int idWypozyczenia, DateTime dataZwrotu)
    {
        var wypozyczenie = _wypozyczenia.FirstOrDefault(w => w.Id == idWypozyczenia);

        if (wypozyczenie is null)
        {
            throw new WyjatekBrakWypozyczenia(idWypozyczenia);
        }

        // Obliczamy karę za pomocą kalkulatora
        decimal kara = _kalkulatorKar.ObliczKare(wypozyczenie.To, dataZwrotu);

        // Używamy metody z Twojej klasy Wypozyczenie
        wypozyczenie.OddanieSprzetu(dataZwrotu, kara);
        
        // Sprzęt wraca do wypożyczalni
        wypozyczenie.Sprzet.Status = StatusSprzetu.DOSTEPNY;
    }

    public void AnulujWypozyczenie(int idWypozyczenia)
    {
        var wypozyczenie = _wypozyczenia.FirstOrDefault(w => w.Id == idWypozyczenia);
        
        if (wypozyczenie is null)
        {
            throw new WyjatekBrakWypozyczenia(idWypozyczenia);
        }
        
        wypozyczenie.Cancel();
        // Zwalniamy sprzęt po anulowaniu
        wypozyczenie.Sprzet.Status = StatusSprzetu.DOSTEPNY; 
    }

    public List<Wypozyczenie> PobierzWypozyczeniaOsoby(Osoba osoba)
    {
        return _wypozyczenia.Where(w => w.Osoba == osoba && !w.IsCancelled).ToList();
    }

    public List<Wypozyczenie> PobierzPrzeterminowane(DateTime dataOdniesienia)
    {
        return _wypozyczenia.Where(w => 
            !w.IsCancelled && 
            w.ActualReturnDate == null && 
            w.To < dataOdniesienia).ToList();
    }

    public List<Wypozyczenie> PobierzWszystkie()
    {
        return _wypozyczenia;
    }
}