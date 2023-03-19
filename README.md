# Tesla-cars-rental
Simple CRUD application with rental office offering Tesla cars on mallorca. This web app is implemented using ASP.net and React.

## 1. Projekt bazy danych ## 
Pracę rozpocząłem od zaprojektowania bazy danych. Tak wstępnie wyglądał projekt bazy danych dla wypożyczalni.

![image](https://user-images.githubusercontent.com/93988101/225420185-8829fb72-0da4-4722-860d-4271a12b5975.png)

##

## 2. Implementacja bazy danych ## 
Zaimplementowanie bazy danych w aplikacji JetBrains Rider przy użyciu EntityFramework.

##

## 3. Organizacja repozytorium na GitHub ## 
Stworzenie zdalnego repozytorium na GitHub oraz wgranie wstępnego projektu strony serwerowej jak i klienckiej.

##

## 4. Continuous Integration ## 
Zastosowanie Continuous Integration po stronie serwerowej sprawdzająca poprawność wprowadzania nowych zmian do projektu pod względem kompilacji kodu.

##

## 5. GitFlow ## 
Prowadzenie projektu w oparciu o GitFlow. Projekt składa się z dwóch głownych gałęzi: Main, Develop. Zadania zostały podzielone na poszczególne Issues. Każda nowa gałąź projektu zakłada wykonanie kolejnego Issue oraz po skończeniu zadania towrzony jest pull request sprawdzający zmiany oraz konfilkty z gałęzią Develop. Jeśli wszystkie zmiany zostały zatwierdzone gałąź Develop jest mergowana do gałęzi Main.

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


### 7.2. Wzorzec CQRS ###
Wzorzec CQRS (Command-Query Responsibility Segregation) to wzorzec projektowy stosowany w projektowaniu aplikacji, który ma na celu oddzielenie logiki zapisu danych (Command) od logiki odczytu danych (Query).

Wzorzec ten zakłada, że aplikacja posiada dwa osobne modele: model komend (Command Model) i model zapytań (Query Model). Model komend służy do obsługi żądań dotyczących zmiany stanu systemu, takich jak dodawanie, aktualizowanie lub usuwanie danych, a model zapytań służy do obsługi zapytań o odczyt danych.

Dzięki zastosowaniu wzorca CQRS, możliwe jest zoptymalizowanie wydajności aplikacji poprzez zoptymalizowanie modelu zapytań i modelu komend. Model zapytań może być np. w pełni zdenormalizowany, co pozwala na szybsze wykonywanie zapytań, a model komend może być zoptymalizowany pod kątem szybkiego i bezpiecznego wprowadzania zmian w systemie.

![image](https://user-images.githubusercontent.com/93988101/226204924-098b086a-459a-40dd-ba40-b41392979ad8.png)

<p align="center">
  <img src="https://user-images.githubusercontent.com/93988101/226204924-098b086a-459a-40dd-ba40-b41392979ad8.png">
</p>

### 7.3. Wzorzec Unit of work ###
Wzorzec Unit of Work jest często stosowany w języku C# jako sposób na izolowanie warstwy dostępu do danych od reszty aplikacji. Wzorzec ten służy do koordynowania operacji na bazie danych, takich jak dodawanie, usuwanie i aktualizacja rekordów, w ramach jednej transakcji.

Wzorzec ten składa się z dwóch głównych elementów: Unit of Work oraz Repozytorium.

Unit of Work to klasa, która reprezentuje jedną transakcję na bazie danych i umożliwia grupowanie operacji na kilku repozytoriach. W Unit of Work zawarte są metody, które umożliwiają dodawanie, usuwanie i aktualizację rekordów w bazie danych.

Repozytorium to interfejs lub klasa, która definiuje metody dostępu do danych, takie jak pobieranie, dodawanie, usuwanie i aktualizacja rekordów w bazie danych. Repozytoria są używane w Unit of Work, aby umożliwić grupowanie operacji na różnych encjach w ramach jednej transakcji.

![image](https://user-images.githubusercontent.com/93988101/226204961-ef5a0115-cae0-46bc-a0c4-bbf19f7e091a.png)


##

## 8. Exceptions ## 
Implementacja napotkanych wyjątków z jakimi będziemy mieli doczynienia w trakcie działania programu(ExceptionHandlerMiddleware).

##

## 9. Walidacja nowego wypożyczenia ## 
Stworzenie walidatora odpowiadającego za walidację danych wprowadzanych podczas tworzenia nowego wypożyczenia.

##

## 10. CRUD opperations ## 
Implementacja pierwszych funkcji CRUD odnieśnie tworzenia nowego wypożyczenia.
