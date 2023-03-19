# Tesla-cars-rental
Simple CRUD application with rental office offering Tesla cars on mallorca. This web app is implemented using ASP.net and React.

## 1. Projekt bazy danych ## 
Pracę rozpocząłem od zaprojektowania bazy danych. Tak wstępnie wyglądał projekt bazy danych dla wypożyczalni.

<p align="center">
<img src="https://user-images.githubusercontent.com/93988101/225420185-8829fb72-0da4-4722-860d-4271a12b5975.png">
</p>

##

## 2. Implementacja bazy danych ## 
Zaimplementowanie bazy danych w aplikacji JetBrains Rider przy użyciu EntityFramework.

##

## 3. Organizacja repozytorium na GitHub ## 
Stworzenie zdalnego repozytorium na GitHub oraz wgranie wstępnego projektu strony serwerowej jak i klienckiej.

##

## 4. Continuous Integration ## 
Zastosowanie Continuous Integration po stronie serwerowej sprawdzająca poprawność wprowadzania nowych zmian do projektu pod względem kompilacji kodu.

<p align="center">
<img src="https://user-images.githubusercontent.com/93988101/226205388-4a8dea3b-8c68-4b70-a376-b1d9006efcb2.png">
</p>

##

## 5. GitFlow ## 
Prowadzenie projektu w oparciu o GitFlow. Projekt składa się z dwóch głownych gałęzi: Main, Develop. Zadania zostały podzielone na poszczególne Issues. Każda nowa gałąź projektu zakłada wykonanie kolejnego Issue oraz po skończeniu zadania towrzony jest pull request sprawdzający zmiany oraz konfilkty z gałęzią Develop. Jeśli wszystkie zmiany zostały zatwierdzone gałąź Develop jest mergowana do gałęzi Main.

<p align="center">
<img src="https://user-images.githubusercontent.com/93988101/226205416-fb3390db-fe33-4d34-89ce-1479fe5e4be9.png">
</p>

##

## 6. DataBaseSeeder ## 
Implementacja DataBaseSeeder. Dzięki niemu uzupełniamy bazę danych naszymi podanymi wypożyczalniami oraz modelami aut dostępnych w danej lokacji.

##

## 7. Wzorce projektowe ## 
Implementacja wzorców projektowych w celu modernizacji projektu.
### 7.1. Wzorzec repozytoriów ###
Wzorzec repozytoriów w języku C# jest popularnym wzorcem projektowym stosowanym w programowaniu aplikacji, które korzystają z bazy danych. Wzorzec ten służy do izolowania warstwy biznesowej od warstwy danych, co ułatwia testowanie kodu oraz zmiany w bazie danych bez wpływu na kod aplikacji.
Oto kilka kroków, które warto uwzględnić przy tworzeniu repozytoriów w C#:

1. Utworzenie interfejsu repozytorium - należy stworzyć interfejs, który będzie definiował metody dostępu do danych (np. dodawanie, usuwanie, modyfikowanie). W interfejsie nie powinny znajdować się szczegóły implementacji.

2. Utworzenie klasy repozytorium - klasa ta implementuje interfejs i zawiera logikę dostępu do bazy danych. Warto korzystać z biblioteki ORM (Object-Relational Mapping), która ułatwia mapowanie danych pomiędzy obiektami a bazą danych.

3. Utworzenie kontekstu bazy danych - kontekst bazy danych służy do zarządzania połączeniem z bazą danych oraz śledzeniem zmian. Kontekst ten powinien być wstrzykiwany do repozytoriów za pomocą narzędzia do wstrzykiwania zależności (np. Autofac, Ninject).

<p align="center">
  <img src="https://user-images.githubusercontent.com/93988101/226205284-0f7e027b-fe67-487a-9854-e3b16802aaec.png">
</p>

### 7.2. Wzorzec CQRS ###
Wzorzec CQRS (Command-Query Responsibility Segregation) to wzorzec projektowy stosowany w projektowaniu aplikacji, który ma na celu oddzielenie logiki zapisu danych (Command) od logiki odczytu danych (Query).

Wzorzec ten zakłada, że aplikacja posiada dwa osobne modele: model komend (Command Model) i model zapytań (Query Model). Model komend służy do obsługi żądań dotyczących zmiany stanu systemu, takich jak dodawanie, aktualizowanie lub usuwanie danych, a model zapytań służy do obsługi zapytań o odczyt danych.

Dzięki zastosowaniu wzorca CQRS, możliwe jest zoptymalizowanie wydajności aplikacji poprzez zoptymalizowanie modelu zapytań i modelu komend. Model zapytań może być np. w pełni zdenormalizowany, co pozwala na szybsze wykonywanie zapytań, a model komend może być zoptymalizowany pod kątem szybkiego i bezpiecznego wprowadzania zmian w systemie.

<p align="center">
  <img src="https://user-images.githubusercontent.com/93988101/226204924-098b086a-459a-40dd-ba40-b41392979ad8.png">
</p>

### 7.3. Wzorzec Unit of work ###
Wzorzec Unit of Work jest często stosowany w języku C# jako sposób na izolowanie warstwy dostępu do danych od reszty aplikacji. Wzorzec ten służy do koordynowania operacji na bazie danych, takich jak dodawanie, usuwanie i aktualizacja rekordów, w ramach jednej transakcji.

Wzorzec ten składa się z dwóch głównych elementów: Unit of Work oraz Repozytorium.

Unit of Work to klasa, która reprezentuje jedną transakcję na bazie danych i umożliwia grupowanie operacji na kilku repozytoriach. W Unit of Work zawarte są metody, które umożliwiają dodawanie, usuwanie i aktualizację rekordów w bazie danych.

Repozytorium to interfejs lub klasa, która definiuje metody dostępu do danych, takie jak pobieranie, dodawanie, usuwanie i aktualizacja rekordów w bazie danych. Repozytoria są używane w Unit of Work, aby umożliwić grupowanie operacji na różnych encjach w ramach jednej transakcji.

<p align="center">
  <img src="https://user-images.githubusercontent.com/93988101/226204961-ef5a0115-cae0-46bc-a0c4-bbf19f7e091a.png">
</p>

##

## 8. Exceptions ## 
Implementacja napotkanych wyjątków z jakimi będziemy mieli doczynienia w trakcie działania programu(ExceptionHandlerMiddleware).

##

## 9. Walidacja nowego wypożyczenia ## 
Stworzenie walidatora odpowiadającego za walidację danych wprowadzanych podczas tworzenia nowego wypożyczenia.

<p align="center">
<img src="https://user-images.githubusercontent.com/93988101/226205337-969effc2-46e5-41c9-a968-5a240e42a3a8.png">
</p>

##

## 10. CRUD opperations ## 
Implementacja pierwszych funkcji CRUD odnieśnie tworzenia nowego wypożyczenia.

<p align="center">
<img src="https://user-images.githubusercontent.com/93988101/226205355-853f99e5-edc0-49a2-8496-43d24ff85ab3.png">
</p>

## 11. Implementacja strony klienckiej ## 
Rozpoczęcie pracy nad stroną frontendu. Implementacja nowego projektu React oraz instalacja potrzbnych bibliotek. W dalszej kolejności zaimplementowane zostały
wszystkie dostępne kompenenty oraz Routy. Aplikacja będzie składa się ze 3 stron: Main, newRental oraz GetAllCarsFromRentalPoint. Jesteśmy w stanie tworzyć nowe wypożyczenie auta oraz podejrzeć wszystkie auta oraz ich dostępność.

<p align="center">
<img src="https://user-images.githubusercontent.com/93988101/226205759-2958e6d1-b282-433e-86eb-5d38362be35f.png">
</p>

## 12. Połączenie strony serwerowej i klienckiej ## 
Przy uzyciu axios udało się połączyć te dwie aplikacje oraz umożliwiło to pobieranie danych z serwera jak i wysyłanie ich na serwer.


## Jak działa aplikacja ## 
Aplikacja umożliwia nam stworzenie nowego wypożyczenia na jedno z aut marki Tesla na słonecznej Majorce. Mamy do dyspozycji wszystkie aktualnie dostępne auta marki Tesla, które rozmieszczone są w czterech punktach wypożyczeń: Palma Airport, Palma City Center, Alcudia, Manacor. Aplikacja miała zakładać tworzenie nowych wypożyczeń dlatego tabele związane z samochodami i placówkami zostały wypełnione z góry narzuconymi danymi, co ułatwia pracę przy projeckie. Zostały utworzone podstawowe operacje CRUD dla tabel co umożliwia nam takie funckje jak np. podgląd wszytskich aut lub podgląd wszystkich aut w konkretnej wypożyczalni. Tworzenie wypożyczenia będzie wymagało nas podania podstawowych danych osobowych oraz określenia jakie auto nas interesuje oraz podanie punktu początkowego oraz końcowego naszej przygody z autem. W tym miejscu działa pełna walidacja, która uniemożliwia wprowadzania błędnych danych m.in: 
1. Nazwa placówki, z której bierzemy lub oddajemy auto musi mieć poprawną nazwę
2. Nazwa modelu auta także musi być poprawna
3. Data końca wypożyczenia musi być większa od teraźniejszej daty oraz nie możliwe jest wypożyczenie auta na więcej niż 20 dni.

Data początkowa wypozyczenia jest ustawiona na teraźniejszą co sprawia, że już w momencie tworzenia wypożyczenia auto staje się naszą własnością. Dodatkowo każde auto ma swój koszt jak musimy zapłacić za dzień. W dalszej częsci przeliczana jest ilośc dni w konkretnym wypozyczeniu i do tabeli z wypożyczeniami dopisana jest kwota końcowa. W momencie tworzenia nowego wypożyczenia pobieramy informacje o wybranym aucie oraz zmieniamy mu status na ,,niedostępne" co uniemożliwia nam wypożyczenia go przez kolejną osobę. Podczas działania aplikacji, wykonywana jest operacja w tle, która na bieżąco sprawdza czy jakiś rekord w tabeli wypożyczeń nie ma zapisanej daty końcowej wypozyczenia, która jest mniejsza niż data teraźniejsza. Jeśli znajdzie taką to usuwa danyc rekord z tabeli oraz zmienia status danego auta na ,,dostępne".

## TODO ## 
Aplikacja oczywiście może być rozbudowana o nowe funckje oraz udoskonalona pod wzgledem różnych funckckonalności np:
1. Poprawienie strony klienckiej pod względem połączenia z serwerem. Refaktor kodu.
2. Wprowadzenie tabeli z użytkownikami oraz stworzenia możliwości logowania.
3. Sprawdzanie czy dane wypożyczenie jest opłacone czy nie oraz pobieranie od użytkownika konkretnych kwot. W sytuacji kiedy mielibyśmy konta użytkownika sprawdzalibysmy także warunki, czy użytkownik ma odpowiednia kwote do opłacenia wypożyczenia.
4. Dodanie więcej stron po stronie klienckiej, aby wyświetlić więcej informacji
