namespace APBDzadanie2.Modele;

public abstract class Osoba (string imie, string nazwisko, string typUzytkownika)
{
    private static int _nextId = 1;
    
    public int Id { get; } = _nextId++;
    public string Imie { get; set; } = imie;
    public string Nazwisko { get; set; } = nazwisko;
    public string TypUzytkownika { get; set; } = typUzytkownika;
    
    public abstract int GetMaxReservations();
}