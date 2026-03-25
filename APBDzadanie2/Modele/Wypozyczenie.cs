namespace APBDzadanie2.Modele;

public class Wypozyczenie  (Sprzet sprzet, Osoba osoba, DateTime from, DateTime to)
{
    private static int _nextId = 1;
    
     public int Id { get; set; } = _nextId++;
     public Sprzet Sprzet { get; set; } = sprzet;
     public Osoba Osoba { get; set; } = osoba;
     public DateTime From { get; set; } = from >= to ? throw new ArgumentException("Invalid time range") : from;
     public DateTime To { get; set; } = to;
   
     public DateTime? ActualReturnDate { get;  set; }//?moze być null, dateTime typ danych do przechowywania godziny i daty
    
     public decimal PenaltyFee { get;  set; }
    
     public bool IsCancelled { get;  set; }
    
     public bool IsReturnedOnTime => ActualReturnDate.HasValue && ActualReturnDate.Value <= To; // hasvalue czy nie jest nullem
    
     public void Cancel()
     {
         if (ActualReturnDate is not null) 
             throw new InvalidOperationException("Nie można anulować zakończonego wypożyczenia.");
            
         IsCancelled = true;
     }

     public void OddanieSprzetu(DateTime returnDate, decimal penaltyFee)
     {
         if (IsCancelled)
             throw new InvalidOperationException("Nie można zwrócić anulowanego wypożyczenia.");

         if (ActualReturnDate is not null)
             throw new InvalidOperationException("Sprzęt został już zwrócony.");

         ActualReturnDate = returnDate;
         PenaltyFee = penaltyFee;
     }

     public bool Overlaps(DateTime from, DateTime to)
    {
        return !(From > to || from > To);
    }
}