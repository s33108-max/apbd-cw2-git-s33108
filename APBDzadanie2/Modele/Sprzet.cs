namespace APBDzadanie2.Modele;

public abstract class Sprzet(string nazwa,string marka, int rokKupienia)
{
    private static int _nextId = 1;
    
    public int Id { get; } = _nextId++;
    public string Nazwa { get; set; } = nazwa;
    public string Marka { get; set; } = marka;
    public int RokKupienia { get; set; } = rokKupienia;
    public StatusSprzetu Status { get; set; } = StatusSprzetu.DOSTEPNY;

}