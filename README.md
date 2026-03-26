# apbd-cw2-git-s33108
duzo inspirowałam się zadaniem przykładowym PJATK-APBD-Tut2-Example.
Rozdzieliłam wszystko na foldery:(modele, serwisy, wyjątki i enum)
folder modele odpowiada za klasy abstrakcyjne i zwykłe klasy, które reprezentują obiekty oraz przechowywują ich stan.
folder serwisy odpowiada za całą logike. 

Polimorfizm w klasach użytkowników: Klasy 'Student' i 'Pracownik' dziedziczą po klasie 'Osoba' i same definiują swój limit wypożyczeń poprzez nadpisanie metody 'GetMaxReservations()'.(kohezja)
StatusSprzetu jest w enumie przez co ogranicza to błędy.

'SerwisSprzetu' zajmuje się tylko zarządzaniem pulą dostępnych urządzeń (dodawanie, wyszukiwanie).
'SerwisWypozyczen' zajmuje się natomiast procesem wypożyczania. Nie przejmuje się tym, w jaki sposób zaimplementowano listę sprzętu, ani jak dokładnie liczy się matematycznie karę za opóźnienie (to robi kalkulat).
Obsługa błędów za pomocą dedykowanych wyjątków a nie w klasie.
Niski sprzężenie widać po wykorzystywaniu interfejsów. np: SerwisWypozyczen, który w swoim konstruktorze przyjmuje interfejs IKalkulatorKar, a nie konkretną klasę kalkulatora.

instrukcja uruchomienia: skoipiować repozytorium. otworzyć APBDzadanie2.sln w środowisku IDE i potem uruchomić aplikacje.
