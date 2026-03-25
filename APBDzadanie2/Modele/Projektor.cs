namespace APBDzadanie2.Modele;

public class Projektor (string nazwa, string marka, int rokKupienia,int jasnoscLumeny, bool posiadaRzytowanieBezprzewodowe) : Sprzet(nazwa,marka, rokKupienia)
{
    public int JasnoscLumeny  {get; set;} = jasnoscLumeny;
    public bool PosiadaRzytowanieBezprzewodowe { get; set; } = posiadaRzytowanieBezprzewodowe;
}