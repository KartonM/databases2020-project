# System zarządzania hurtownią warzyw i owoców

## Wykorzystana technologia
Aplikacja zbudowana jest przy użyciu frameworka ASP.NET Core. Baza danych (MS SQL) stworzona została przy użyciu Entity Framework Core i podejścia "Model First". Frontend aplikacji został zrealizowany w oparciu o Razor Views.

## Schemat bazy danych
Schemat bazy danych wygenerowanej na podstawie modelu. Tabela Companies zawiera zarówno informacje o firmach-klientach, jak i firmach-dostawcach, z którymi współpracujemy (strategia TPH obsługi dziedziczenia). Zdecydowaliśmy się na przechowywanie aktualnej ilości produktu w tabeli Products (KgsInStock) i jej aktualizację przy każdej dostawie i sprzedaży, ponieważ uznaliśmy, że z czasem przy wielu zarejestrowanych dostawach i sprzedażach w systemie, często wykonywana operacja wyliczania tej ilości byłaby zbyt kosztowna. 
![schemat](https://github.com/KartonM/databases2020-project/blob/master/db_schema.png)

## Struktura aplikacji
### Wartwa persystencji danych
Klasy, na podstawie których generowana są tabele znajdują się w folderze [Models](https://github.com/KartonM/databases2020-project/tree/master/EFCoreZadanie2/Models). Baza definiowana jest na podstawie klasy [ApplicationDbContext](https://github.com/KartonM/databases2020-project/blob/master/EFCoreZadanie2/Data/ApplicationDbContext.cs), gdzie zadeklarowane są tabele oraz dodatkowo opisane są tabele łącznikowe używane przy relacjach M-N oraz strategia dziedziczenia w przypadku firm-dostawców i firm-klientów. We wszystkich operacjach na danych pośredniczy klasa [Repository](https://github.com/KartonM/databases2020-project/blob/master/EFCoreZadanie2/Data/Repository.cs), dostarczana do innych klas przez mechanizm Dependency Injection skonfigurowany w pliku [Startup.cs](https://github.com/KartonM/databases2020-project/blob/master/EFCoreZadanie2/Startup.cs).

### Logika aplikacji i wartwa widoku
W aplikacji został zasotosowany pattern MVC. Poza wspomnianymi wyżej klasami Modelu mamy też jeden Controller ([HomeController](https://github.com/KartonM/databases2020-project/blob/master/EFCoreZadanie2/Controllers/HomeController.cs)) oraz widoki Razor Views znajdujące się w folderze [Views/Home](https://github.com/KartonM/databases2020-project/tree/master/EFCoreZadanie2/Views/Home). Do komunikacji między Controllerem a widokami w niektórych przyapdkach wykorzystywane są również klasy znajdujące się w folderze [ViewModels](https://github.com/KartonM/databases2020-project/tree/master/EFCoreZadanie2/ViewModels)

## Opis funkcjonalności:<br/>
-dodawanie kategorii produktu<br/>
-dodawanie klientów<br/>
-dodawanie i tworzenie nowych faktur<br/>
-dodawanie produktów<br/>
-dodawanie dostawców<br/>
-przeglądanie statystyk:<br/>
*bilans miesięczny, tygodniowy<br/>
*najaktywniejsi klienci(tygodniowo, miesięczie)<br/>
*przegląd zalegających produktów<br/>
*wykaz brakujących produktów<br/>
*wartośc produktu w magazynie<br/>
-tworzenie dostaw<br/>

## Contributors
- [Marcin Kozubek](https://github.com/KartonM)

- [Paweł Kocimski](https://github.com/kocimski)
