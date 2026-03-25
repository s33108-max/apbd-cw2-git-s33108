namespace APBDzadanie2.Wyjatki;

public class WyjatekBrakWypozyczenia(int idWypozyczenia)
    : Exception($"Nie znaleziono sprzętu o identyfikatorze: {idWypozyczenia}");