using APBDzadanie2.Modele;
namespace APBDzadanie2.Serwisy;

public interface ISerwisSprzetu
{
    void DodajSprzet(Modele.Sprzet sprzet);
    Modele.Sprzet PobierzSprzetPoId(int id);
    List<Modele.Sprzet> PobierzWszystkie(); //caly sprzet w systemie
    List<Modele.Sprzet> PobierzDostepne();
    void UstawJakoDostepny(int id);
    void UstawJakoNiedostepny(int id);
}