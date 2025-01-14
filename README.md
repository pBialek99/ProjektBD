Dokumentacja – Projekt zaliczeniowy BDwAI

Wymagania:
Paczki:
-	Microsoft.AspNetCore.Identity.EntityFrameworkCore v 9.0
-	Microsoft.AspNetCore.Identity.UI v 9.0
-	Microsoft.EntityFrameworkCore v 9.0
-	Microsoft.EntityFrameworkCore.Design v 9.0
-	Microsoft.EntityFrameworkCore.SqlServer v 9.0
-	Microsoft.EntityFrameworkCore.Tools v 9.0
-	Microsoft.VisualStudio.Web.CodeGeneration.Design v 9.0
Connection string:
"Server= … ;Database=Biblioteka;Trusted_Connection=True;TrustServerCertificate=True;"
W miejsce trzech kropek należy wpisać nazwę swojego serwera MS SQL.
Instalacja projektu:
Mając przygotowane wszystkie pliki, należy wykonać migrację i zaktualizować bazę danych:
-	add-migration
-	update-database

Testowi użytkownicy seedowani w Program.cs: 
-	Administrator
	Login: admin@mail.com
	Hasło: qwertY1#
Aby w pełni przetestować działanie aplikacji, należy samodzielnie dodać po jednym rekordzie do Category, Publisher, Book oraz utworzyć dwa konta użytkowników. Z poziomu administratora nie zobaczymy jak działa wypożyczanie książek i blokada przed oddaniem książki przez użytkownika, który jej nie wypożyczył.


Działanie aplikacji – od strony administratora:
Użytkownik z uprawnieniami administratora ma dostęp do widoków:
-	Home – podstawowe informacje na temat twórcy projektu
-	Privacy - defaultowa strona Privacy projektu MVC
-	List of books (Index) – wyświetla listę książek, brak widoczności i możliwości korzystania z przycisków wypożyczania i zwrotu książek
	Create – formularz do dodawania książek
	Edit – formularz do edycji książek
	Details - szczegółowe informacje na temat rekordu
	Delete - szczegółowe informacje na temat rekordu i możliwość jego usunięcia
-	List of borrowed books (Index) - wyświetla listę wypożyczonych książek
	Create – formularz pozwalający ustalić stan oraz datę wypożyczenia i oddania książki
	Edit – formularz pozwalający na edycję daty wypożyczenia i oddania książki
	Details – szczegółowe informacje na temat rekordu
	Delete – szczegółowe informacje na temat rekordu i możliwość jego usunięcia
-	List of categories (Index) - wyświetla listę kategorii
	Create – formularz pozwalający dodać nową kategorię do bazy
	Edit – formularz do edycji rekordu
	Details - szczegółowe informacje na temat rekordu
	Delete - szczegółowe informacje na temat rekordu i możliwość jego usunięcia
-	List of publishers (Index) – wyświetla listę wydawców
	Create – formularz pozwalający dodać nowego wydawce do bazy
	Edit – formularz do edycji rekordu
	Details - szczegółowe informacje na temat rekordu
	Delete - szczegółowe informacje na temat rekordu i możliwość jego usunięcia
-	Panel zarządzania kontem
-	Przycisk wylogowania (Logout)






Działanie aplikacji – od strony zalogowanego użytkownika:
Użytkownik z uprawnieniami administratora ma dostęp do widoków:
-	Home - podstawowe informacje na temat twórcy projektu
-	Privacy - defaultowa strona Privacy projektu MVC
-	List of books (Index) – wyświetla listę książek, widoczność i możliwość używania przycisków ‘Borrow’ (gdy książka nie jest wypożyczona) oraz ‘Return’ (gdy aktualnie zalogowany użytkownik jest tym, który wypożyczył daną książkę)
	Details - szczegółowe informacje na temat rekordu
-	List of borrowed books (Index)
	Details - szczegółowe informacje na temat rekordu
-	List of publishers (Index)
	Details - szczegółowe informacje na temat rekordu
-	Panel zarządzania kontem
-	Przycisk wylogowania (Logout)

Działanie aplikacji – od strony niezalogowanego użytkownika:
Użytkownik z uprawnieniami administratora ma dostęp do widoków:
-	Home - podstawowe informacje na temat twórcy projektu
-	Privacy – defaultowa strona Privacy projektu MVC
-	List of books (Index) – wyświetla listę książek, brak widoczności i możliwości korzystania z przycisków wypożyczania i zwrotu książek
	Details - szczegółowe informacje na temat rekordu
-	List of borrowed books (Index)
	Details - szczegółowe informacje na temat rekordu
-	List of publishers (Index)
	Details - szczegółowe informacje na temat rekordu
-	Przycisk Register – przenosi do formularza rejestracyjnego
-	Przycisk Login – przenosi do strony logowania

