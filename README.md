# dissociate
### dissociate yourself from reality
Von Sven Oppliger, Robin Leanman und Dimitrios Lanaras.

### Aufgabenstellung

Als Projekt möchten wir eine Chatplattform erstellen. Das ganze soll ein bisschen eine Anlehnung an Discord sein. Im Design möchten wir uns jedoch ein bisschen am Spiel Cyberpunk orientieren. Wir nennen unser Projekt dissociate. Abgrenzen wollen wir die Funktionen in dem wir nur einen Login- und Chatscreen haben. Wir werden eine Datenbank anbinden in welchem wir die Chatnachrichten, Benutzer und Profile speichern. Dazu wollen wir das ganze Projekt in C# mit dem EntityFramework umsetzen. Da man sich einloggen muss, werden wir auch ein Sessionhandling implementieren müssen. Bilder kann man im Chat nicht senden da dies zu aufwändig wäre. 

## Planung für unser Projekt

Als aller erstes haben wir für unser Projekt einen Prosa Text geschrieben. Aus diesem wollen dir danach mit der Verben-/Substantiven Methode unsere CRC Karten erstellen.

### Prosa Text

Eine Person kann sich bei unserer Applikation registrieren. Falls er schon registriert ist kann er sich anmelden. Angemeldet kann der Benutzer seine Server anschauen. Er kann auch seine Freunde anzeigen lassen. Man kann sich Profile von anderen Leuten anschauen. Man kann andere Leute anschreiben. Auch kann man anderen eine Freundschaftsanfrage senden. Man kann seine eigenen Server erstellen. Man kann in Servern mit anderen Leuten schreiben. Man kann sein eigenes Profil anpassen. Zum Profil gehören Bio, Profilbild und Profilbanner.

### Verben-/Substantiven Methode

Wir haben den Text danach analysiert und uns wichtige Klassen herausgeschrieben.

Klasse "Nachricht"
Wir dachten für die Nachrichten brauchen wir auf jeden Fall eine Klasse. Methoden wird diese keine haben da Sie einfach Informationen in ein Objekt speichern soll.

Klasse "Benutzer"
Wir brauchen auf jeden Fall die Klasse User um mit ihm zu interagieren. Wie bei der Message speichern wir hier nur Informationen über den User.

Klasse "Server"
Um einzelne Server zu handeln bräuchten wir auch hier eine Klasse dafür.

Als Methoden brauchen wir sicher folgendes:
-Login
-Register
-Send Message
-Send Friend Request
-Create Server
-Join Server
-Edit Profile
-Show Friends

### CRC-Cards

Aus dem Prosa und der Verben/Substantiven Methode haben wir anschliessend unsere CRC Cards auf Draw.io erstellt.

![image](https://user-images.githubusercontent.com/81744349/177546282-ec06a41b-e1fd-471c-a4d9-4ffaeec0a621.png)

Wir haben den User und Nachricht wie in der Verben/Substantiven Methode herausgefunden implementiert. Dazu kam ein Controller welcher alles handelt und ein Context da wir mit dem Entity Framework arbeiten werden.

### Klassendiagramm

Aus den CRC Cards konnten wir so ziemlich unser Klassendiagramm einfach zusammenlegen. 
![image](https://user-images.githubusercontent.com/81744349/177548916-2f656399-3234-42ec-8b24-79021381b5e7.png)

### Sequenzdiagramme

Um Unser Programm noch besser zu beschreiben haben wir zwei Sequenzdiagramme gemacht.

Dieses holt alle Nachrichten einer Konversation.
![image](https://user-images.githubusercontent.com/81744349/177603093-75f0c3cc-a1db-4a22-a4df-4a55fa8f9a18.png)

Dieses überprüft das Login.
![image](https://user-images.githubusercontent.com/81744349/177606846-4e893164-0cd8-4706-ba26-24c10fa6fce8.png)


### Use Case Diagramm

Wir haben auch ein Use Case Diagramm gemacht.

![image](https://user-images.githubusercontent.com/81744349/177624343-893b36d3-1ab0-48da-9c48-da61c354f718.png)



### Aktivitätsdiagramm

Als letztes haben wir noch ein Aktivitätsdiagramm gezeichnet.
![image](https://user-images.githubusercontent.com/81744349/177624285-02cb1d88-6f89-4357-a539-d33ebfc4ff27.png)



### ERD Diagramm

Zur Vollständigkeit ist hier noch unser ERD Diagramm.
![image](https://user-images.githubusercontent.com/81744349/177550686-606a7b2f-a8d3-46c3-b24d-44e02b6954a8.png)

### Design Pattern

Wir haben 2 respektive 3 Patterns implementiert.

Der DBContext ist ein Singleton da wir ihn natürlich nur eine Instanz davon brauchen.
Das Facade Pattern benutzen wir in dem wir im Controller auf den Context zugreifen obwohl andere Klassen nur auf den Controller zugreifen.
Dazu wenn man das Entity Framework benutzt implementiert man automatisch das Repository Pattern.

### Reflexion

Wir denken unser Projekt ist uns für diese kurze Zeit sehr gut gelungen. Manchmal gab es Kommunikationsschwierigkeiten jedoch konnten wir diese immer bewältigen. Wir hätten vielleicht mehr zu Anfang des Projektes arbeiten sollen damit wir am schluss nicht mehr so viel haben. Jedoch funktioniert in unserem Projekt die Hauptfunktion das chatten und wir konnten vor allem von den UMLs profitieren. Manchmal war es schwer sich ganz genau an die UMLs zu halten. Im Team war die Arbeit immer gut aufgeteilt. Schwer war für uns eigentlich nichts da alles soweit klar war. 
