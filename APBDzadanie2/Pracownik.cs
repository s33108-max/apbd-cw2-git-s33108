namespace APBDzadanie2;

public class Pracownik (string imie, string nazwisko, string typUzytkownika, string katedra) : Osoba(imie, nazwisko, typUzytkownika)
{
    public string Katedra { get; set; } = katedra;
    
    public override int GetMaxReservations() => 5;
}