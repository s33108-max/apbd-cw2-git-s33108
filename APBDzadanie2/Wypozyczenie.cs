namespace APBDzadanie2;

public class Wypozyczenie  (Sprzet sprzet, Osoba osoba, DateTime from, DateTime to)
{
    private static int _nextId = 1;
    
     public int Id { get; set; } = _nextId++;
     public Sprzet Sprzet { get; set; } = sprzet;
     public Osoba Osoba { get; set; } = osoba;
     public DateTime From { get; set; } = from >= to ? throw new ArgumentException("Invalid time range") : from;
     public DateTime To { get; set; } = to;
    public bool IsCancelled { get; private set; } = false;
    
    public void Cancel()
    {
        IsCancelled = true;
    }
    
    public bool Overlaps(DateTime from, DateTime to)
    {
        return !(From > to || from > To);
    }
}