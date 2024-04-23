# 23-PO2-Zad2-GetHashCode
Programowanie obiektowe 2 - 2023

Eksperyment ze słownikiem i dobrym/złym GetHashCode()

Należy stworzyć własną strukturę/klasę, która posłuży jako typ klucza dla słownika (Dictionary). Prosta funkcja testująca sprawdzi działanie dodawania elementów do słownika i pobierania włożonych wcześniej wartości oraz zmierzy czas działania (wystarczy różnica pobieranych DateTime.Now). Do słownika należy wrzucić i pobierać odpowiednio dużo wartości, by otrzymać miarodajne czasy wykonania.
Efektem eksperymentu powinna być świadomość kiedy i dlaczego działa to szybko a kiedy i dlaczego wolno, dlaczego bez GetHashCode dla klas jest wyjątek, a dla struktur nie itd. Do rozliczenia potrzebny jest kod eksperymentu i krótki opis wniosków (można go wstawić jako komentarz do pliku z kodem).
W skrócie, do zrobienia jest:

 - typy wartościowy i referencyjny (struct i class) dla obiektów-kluczy słownika,
 - niepoprawna definicja GetHashCode() (np. stała wartość - najgorsze co może być) i poprawna (dobrze rozróżniająca),
 - ogólna metoda testująca sparametryzowana typem klucza,
 - program główny sprawdzający po kolei 6 wariantów (struktura/klasa i zły/dobry/brak GetHashCode),
 - wnioski. 

Uwaga! GetHashCode() nadpisujemy zwykle w parze z Equals() - ten sam kod haszujący nie wystarcza by dwa klucze uznać za jednakowe - ostatecznie decyduje właśnie Equals(), która domyślnie, w przypadku typów referencyjnych porównuje referencje właśnie, a w przypadku typów wartościowych porówna wnętrza (dla struktur pole po polu). 
