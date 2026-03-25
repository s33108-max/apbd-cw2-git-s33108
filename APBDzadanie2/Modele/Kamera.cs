namespace APBDzadanie2.Modele;

public class Kamera (string nazwa, string marka, int rokKupienia,int maxFps, bool isPtz) : Sprzet(nazwa,marka, rokKupienia)
{
    public int MaxFps {get; set;} = maxFps;
    public bool IsPtz {get; set;} = isPtz;
}