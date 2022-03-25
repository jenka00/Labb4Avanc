# Labb4Avanc

1. Hämta alla personer i systemet med hjälp av Postman Get: https://localhost:44360/api/persons
2. Hämta alla intressen som är kopplad till en person (här person med id 1) med Postman Get: https://localhost:44360/api/persons/1
3. Genom samma anrop som i nr 2 får man även fram alla länkar som är kopplade till personen 
4. För att koppla en person till ett nytt intresse kan man använda Postman Put: https://localhost:44360/api/leisures och klistra in följande i body, Json
   {
        "url": null,
        "personId": 2,        
        "interestId": 4     
    }
5. För att lägga till en ny länk för en person och ett visst intresse, kan man använda samma kommando som i fråga 4, och ersätta null-värdet i url med önskad länk.
