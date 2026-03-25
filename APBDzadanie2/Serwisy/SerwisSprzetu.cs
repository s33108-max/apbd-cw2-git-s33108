using APBDzadanie2.Wyjatki;
using APBDzadanie2.Modele;
using APBDzadanie2.Enums;
using System.Linq;

namespace APBDzadanie2.Serwisy;

public class SerwisSprzetu : ISerwisSprzetu
{
    private readonly List<Modele.Sprzet> _listaSprzetu = [];
    
    public void DodajSprzet(Modele.Sprzet sprzet)
    {
        _listaSprzetu.Add(sprzet);
    }
    
    public Sprzet PobierzSprzetPoId(int id)
    {
        return _listaSprzetu.FirstOrDefault(s => s.Id == id) 
               ?? throw new WyjatekBrakSprzetu(id);
    }

    public List<Sprzet> PobierzWszystkie()
    {
        return _listaSprzetu;
    }

    
    public List<Sprzet> PobierzDostepne()
    {
        
        return _listaSprzetu.Where(s => s.Status == StatusSprzetu.DOSTEPNY).ToList();
    }

    
    public void UstawJakoDostepny(int id)
    {
      
        PobierzSprzetPoId(id).Status = StatusSprzetu.DOSTEPNY;
    }

    
    public void UstawJakoNiedostepny(int id)
    {
        
        PobierzSprzetPoId(id).Status = StatusSprzetu.NIEDOSTEPNY;
    }
}