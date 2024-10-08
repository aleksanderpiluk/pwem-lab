Zadanie

Zadanie 1:
Zbadaj strukturę projektu aplikacji webowej:

Stwórz nowy projekt, który implementuje podejście oparte na stronach.
Przeanalizuj foldery projektu, takie jak foldery zawierające widoki, zasoby statyczne oraz pliki konfiguracyjne.
Opisz rolę każdego z folderów oraz kluczowych plików (np. gdzie znajdują się widoki, gdzie umieszczane są zasoby statyczne, jak zarządzane są pliki konfiguracji).
Zbadaj, jak domyślnie organizowany jest projekt oraz jakie elementy można w nim dostosować do własnych potrzeb.
Cel zadania: Poznanie struktury projektu webowego, zrozumienie funkcji i roli kluczowych folderów i plików.

Rozwiazanie

> Stworzylismy projekt korzystajacy z templatki Razora

`Program.cs`\
Jest to główny plik uruchomieniowy aplikacji. Zawiera:
- konfigurację serwera, 
- middleware, 
- routingu.

`lab1.csproj`\
Plik odpowiadajacy:
- za zarzadzanie zaleznosciami w projekcie 
- konfiguracje kompilacji 
- definuje które pliki zródłowe sa czescia projektu
- informuje o wersji projektu
- moze zawierac konfiguracje specyficzne dla projektu np. postkompilacje

`appsettings.json` | `appsettings.Development.json` \
Plik konfiguracji, który służy do przechowywania ustawień, takich jak połączenia z bazą danych, klucze API itp. Możesz również dodać inne pliki konfiguracji jak appsettings.Development.json, aby przechowywać konfiguracje specyficzne dla środowisk.


folder `Properties` zawiera: 

`launchSettings.json` \
Plik zawierający konfigurację profili uruchomieniowych (np. informacje o serwerach, HTTPS).

folder `obj` zawiera: \
- pliki posrednie kompilacji
- metadane projektu
- kompilacje zaleznosci z `lab1.csproj`
- moze tez dzielic konfiguracje takie jak `Debug`, `Relase` 

Jest to folder tymczasowy i jest tworzony przy kompilacji projektu


folder `wwwroot` zawiera: \
statyczne zasoby (np. pliki CSS, JavaScript, obrazy). Zasoby te są dostępne bezpośrednio z przeglądarki.

folder `Pages` zawiera: \
Zawiera widoki strony `Razor`.
