namespace APBDzadanie2;

public abstract class Osoba (string imie, string nazwisko, string typUzytkownika)
{
    private static int _nextIdOsoba = 1;
    
    public int Id { get; } = _nextIdOsoba++;
    public string Imie { get; set; } = imie;
    public string Nazwisko { get; set; } = nazwisko;
    public string TypUzytkownika { get; set; } = typUzytkownika;
}