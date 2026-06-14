#Dokumentace projektu – Projekt_Sklad

##Správa skladu

Program funguje jako jednoduchá správa skladu.

##Model tříd a vazby

Třída Program obsahuje hlavní logiku aplikace a pracuje s dynamickou kolekcí List<Produkty>. Třída Produkty reprezentuje jeden produkt a obsahuje vlastnosti: ID, Name, Pocet, Kategorie, Cena a MinimalniPocet. 

##Struktura aplikace (třídy, metody)

Program
- Main() – načítá data ze souboru, zobrazuje menu a zpracovává jednotlivé funkce.

Produkty
- ID – identifikátor produktu
- Name – název produktu
- Pocet – počet kusů na skladě
- Kategorie – kategorie produktu
- Cena – cena produktu
- MinimalniPocet – minimální počet kusů na skladě

##Popis práce se soubory

Data jsou ukládána v souboru Data.csv. Při spuštění programu se soubor načte pomocí StreamReader. Každý řádek představuje jeden produkt. Při volbě 'Uložit data do souboru' se obsah kolekce zapíše zpět pomocí StreamWriter.

##Popis ovládání

1. Vypsat všechny produkty – zobrazí kompletní seznam.
2. Vypsat produkty podle kategorie – filtruje produkty podle zadané kategorie.
3. Hromadná změna skladu – přidání nebo odebrání kusů celé kategorii.
4. Přidat nový produkt – vytvoření nového produktu včetně nové kategorie.
5. Zobrazit produkty s nízkým počtem kusů – výpis produktů pod zadanou hranicí.
6. Uložit data do souboru – uloží aktuální stav skladu.
