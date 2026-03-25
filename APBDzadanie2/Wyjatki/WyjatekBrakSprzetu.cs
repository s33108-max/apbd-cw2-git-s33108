namespace APBDzadanie2.Wyjatki;

public class WyjatekBrakSprzetu(int id)
    : Exception($"Nie znaleziono sprzętu o identyfikatorze: {id}");