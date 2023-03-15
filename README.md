# Tesla-cars-rental
Simple CRUD application with rental office offering Tesla cars on mallorca. This web app is implemented using ASP.net and React.

## 1. Projekt bazy danych ## 
Pracę rozpocząłem od zaprojektowania bazy danych. Tak wstępnie wyglądał projekt bazy danych dla wypożyczalni.

<p align="center">
![image](https://user-images.githubusercontent.com/93988101/225165478-c847cedc-b748-4f4a-a33c-0b730eda4c41.png)
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
### 7.2. Wzorzec CQRS ###
### 7.3. Wzorzec Unit of work ###

##

## 8. Exceptions ## 
Implementacja napotkanych wyjątków z jakimi będziemy mieli doczynienia w trakcie działania programu(ExceptionHandlerMiddleware).

##

## 9. Walidacja nowego wypożyczenia ## 
Stworzenie walidatora odpowiadającego za walidację danych wprowadzanych podczas tworzenia nowego wypożyczenia.

##

## 10. CRUD opperations ## 
Implementacja pierwszych funkcji CRUD odnieśnie tworzenia nowego wypożyczenia.
