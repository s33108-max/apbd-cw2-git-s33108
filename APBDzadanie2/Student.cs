namespace APBDzadanie2;

public class Student (string imie, string nazwisko, string typUzytkownika, string s) : Osoba(imie, nazwisko, typUzytkownika)
{
    public string S { get; set; } = s;
    
    public override int GetMaxReservations() => 2;
}