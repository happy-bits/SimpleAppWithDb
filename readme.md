# Vad

En exempelsite med databas, som kan användas för att visa hur publicering kan göras

# Starta lokalt

Kör detta kommando för att skapa en ny databas lokalt. Ändra portnumret och lösenordet till dina egna värden.

    $env:PGPASSWORD="password"; psql -U postgres -f reset-database.sql -p 5434

Kör detta för att skapa tabeller i databasen.

    dotnet ef database update

Kör detta för att starta servern.

    dotnet run

Om du nu går in till http://localhost:5106/TestDatabase så ska du kunna trycka på "Add Random Product" för att lägga till ett nytt produkt. Produkterna sparas i databasen.
