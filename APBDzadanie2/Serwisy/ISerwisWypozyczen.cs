using APBDzadanie2.Wyjatki;
using APBDzadanie2.Modele;
using APBDzadanie2.Enums;
using System.Linq;

namespace APBDzadanie2.Serwisy;

public interface ISerwisWypozyczen
{
    void UtworzWypozyczenie(Osoba osoba, Sprzet sprzet, DateTime odKiedy, DateTime doKiedy);
    void ZwrocSprzet(int idWypozyczenia, DateTime dataZwrotu);
    void AnulujWypozyczenie(int idWypozyczenia);
    List<Wypozyczenie> PobierzWypozyczeniaOsoby(Osoba osoba);
    List<Wypozyczenie> PobierzPrzeterminowane(DateTime dataOdniesienia);
    List<Wypozyczenie> PobierzWszystkie();

}