namespace APBDzadanie2.Wyjatki;

public class WyjatekSprzetNiedostepny(int id)
    : Exception($"sprzet o {id} jest niedostepny");