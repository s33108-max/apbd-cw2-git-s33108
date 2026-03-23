namespace APBDzadanie2;

public class Laptop(string nazwa,string marka, int rokKupienia, string systemOperacyjny, double iloscCali) : Sprzet(nazwa,marka, rokKupienia)
{
    public string SystemOperacyjny {get; set;} = systemOperacyjny;
    public double IloscCali {get; set;} = iloscCali;
}