# Dokumentacja Housematica ![alt text](https://img.shields.io/badge/Aplikacja-1.0-blue) ![alt text](https://img.shields.io/badge/Dokumentacja-1.2-green)
![Netwings logo](https://github.com/awrobel196/Housematica/blob/main/Housematica/Shots/S_logo.png?raw=true)


## 1. Demo
 - Showreel: https://pensive-einstein.188-34-164-7.plesk.page/c3e979b6
 - Konfigurator: https://pensive-einstein.188-34-164-7.plesk.page/projects/details/2a71ddfd
 - Panel administracyjny: https://quirky-curie.188-34-164-7.plesk.page/ (email: admin@admin.pl; hasło: 3Ac2uq94#)


## 2. O aplikacji
Housematica to aplikacja webowa pozwalająca na udostępnianie wizualizacji 3D mieszkań (Showreel) oraz dokonowania ich prostej konfiguracji przez użytkowników końcowych w ramach platformy. W obrębie całej aplikacji wyróżnić można trzy kluczowe serwisy

## 3. Panel administracyjny
Panel administracyjny pozwala w łatwy sposób na zarządzanie aktualnymi wizualizacjami/konfiguracjami zagregowanymi w ramach jednego projektu. Głównym *key feature* samego panelu administracyjnego, jest możliwośc utworzenia wizualizacji/konfiguracji mieszkania w kilku krokach, bez znajomości wiedzy programistycznej czy z zakresu modelowania 3d. Przykładowo na potrzeby stworzenia konfiguracji mieszkania, potrzebujemy tylko jego model 3D (lub modele 3D, jeśli posiada on kilka konfiguracji rozmieszczenia pomieszczeń) oraz zdjęcia przedstawiające możliwe konfiguracje, jakie chcemy umieścić w ramach konfiguratora.

### Funkcje panelu administracyjnego
 - #### Licencje
Wszstkie utworzone konta w ramach panelu administracyjnego, agregowane są w postaci licencji, która współdzielona może być przez kilka kont. W ramach jednej licencji, użytkownicy mogą posiadać dostęp do tych samych projektów, a także współdzielić zasoby (czy też limity) przypisane do danej licencji. Każdy użytkownik może utworzyć specjalny kod, który pozwoli na rejestrację nowego użytkownika i automatyczne przypisanie go do tej samej licencji, co licencja zapraszającego.

![Netwings logo](https://github.com/awrobel196/Housematica/blob/main/Housematica/Shots/s1.PNG?raw=true)


 - #### Rejestracja/logowanie
Prosty mechanizm rejestracji pozwala na utworzenie nowego konta oraz jego pełną aktywację po potwierdzeniu podanego adresu email. W momencie rejestracji, tworzony zostaje nowa licencja testowa, w ramach któej użytkownik posiada ograniczoną liczbę zasobów (ograniczona ilość możliwych projektów i konfiguracji). Odmiennym typem utworzenia konta, jest rejestracja przy pomocy zaproszenia, które może zostać wysłane na adres email nowego użytkownika. Po rejestracji z takiego zaproszenia, nowy użytkownik dołączy do istniejącej licencji, z której wysłane zostało zaproszenie.

![Netwings logo](https://github.com/awrobel196/Housematica/blob/main/Housematica/Shots/s2.PNG?raw=true)


 - #### Projekty
Zarówno konfiguratory jak i same wizualizacje 3D agregowane są w ramach projektów (jeden projekt może posiadać kilka mieszkań do konfiguracji). Panel projektów z poziomu panelu administracyjnego posiada kilka przydatnych funkcji, a są to m.in. zagregowane dane na temat konfiguracji, ilość ich wyświetleń czy kliknięć. 

![Netwings logo](https://github.com/awrobel196/Housematica/blob/main/Housematica/Shots/s3.jpg?raw=true)

 - #### Showreel
Z poziomu panelu do danego projektu możemy przypisać Showreel - czyli reprezentację pojedynczej wizualizacji mieszkania. Aby utworzyć nowy showreel, potrzebny będzie jego model 3D (lub modele, jeśli przedmiotowy budynek posiada kilka kondygnacji), plan kondygnacji oraz podstawowe informacje o showreel. Po dodaniu nowej instancji wizualizacji mieszkania, z poziomu Projtku wygenerowany zostanie link, który pozwoli na dostęp do Showreel z prespektywy klienta

![Netwings logo](https://github.com/awrobel196/Housematica/blob/main/Housematica/Shots/s4_1.PNG?raw=true)

 - #### Konfigurator mieszkań
Konfigurator mieszkań to podobna funkcja co sam showreel, jednak za jego pomocą możemy uzyskać dostęp nie tylko do przeglądania danego mieszkania, ale także jego konfiguracji pod względem zarówno wykończenia jak i rozmieszczenia pomieszczeń. W zalezności od ilości konfiguracji rozmieszczeń pomieszczeń, w momencie tworzenia nowej konfiguracji mieszkania, należy dodać jeden lub więcej modeli 3D

![Netwings logo](https://github.com/awrobel196/Housematica/blob/main/Housematica/Shots/s5.PNG?raw=true)

## 4. Showreel
Showreel to serwis aplikacji, w poziomu którego mamy dostęp do pojedynczego mieszkania/budynku. Showreel w prosty sposób można zintegrować z własną stroną internetową, na której wyświetlany on będzie jako dodatkowy *feature* przedstawiający interaktywny model 3D. W showreel użytkownik może przełączać się między kondygnacjammi mieszkania (jeśli takie istnieją) oraz przeglądać najważniejsze informacje na temat mieszkania.

## 5. Konfigurator
Konfigurator to serwis aplikacji, w którym użytkownik może dokonać konfiguracji mieszkania. Wszystkie możliwe konfiguracje zdefiniowane są z poziomu panelu administracyjnego. Uzytkownik końcowy z poziomu konfiguratora może przełączać się między dostępnymi konfiguracjami co spowoduje automatyczne przeliczanie nowej ceny mieszkania. *Dodatkowo klient może zapisać skój kod aktualnej konfiguracji, a by w dowolnym momencie ją wczytać*
