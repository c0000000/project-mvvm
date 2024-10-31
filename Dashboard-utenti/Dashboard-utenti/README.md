# Gestione Persone

## Descrizione del Progetto
Il progetto **Gestione Persone** fornisce una soluzione intuitiva ed efficiente per la gestione di un elenco di persone. Gli utenti possono registrarsi, effettuare il login e aggiornare le proprie informazioni personali. I dati sono archiviati in un file JSON, garantendo un'implementazione leggera e facilmente accessibile.

## Funzionalità

### Autenticazione
- **Login**: Accesso al sistema tramite credenziali personali.
- **Registrazione**: Nuovi utenti possono registrarsi, con le credenziali memorizzate in un file `.json`.

### Interfaccia Utente
- **Navigazione**: Barra di navigazione intuitiva con le seguenti opzioni:
  - **Home**
  - **Gestione Utenti**
  - **Chiamate HTTP**
  - **Chiamate DB**
  - **Logout**
  - **Chiudi Programma**

#### Pagina Gestione Utenti
- **Visualizzazione Elenco**: Mostra l'elenco delle persone registrate.
- **Aggiunta Persona**: Modulo per inserire una nuova persona; cliccando su un nome nella lista, il modulo si riempirà automaticamente con i dati corrispondenti.
- **Salvataggio Dati**: Pulsante dedicato per salvare le informazioni nel file `.json`.
- **Aggiornamento Dati**: Possibilità di modificare i dati della persona selezionata.
- **Eliminazione Persona**: Pulsante per rimuovere una persona dall'elenco.

#### Pagina Gestione HTTP Dati - JSON
- **Richieste API**: Utilizzo di HttpClient per effettuare chiamate all'API di [Json-placeholder](https://dummyjson.com/).
  - Visualizzazione delle attività da completare (todos) e dei commenti, con la possibilità di visualizzarne solo uno alla volta.

#### Pagina Uses
- **Richiesta GET**: Recupero degli utenti da jsonPlaceholder.
  - Cliccando su un utente dalla lista, viene mostrata la richiesta JSON associata come un popup o oscurando il background.

#### Pagina Chiamate DB - Operazioni CRUD con Entity Framework
- Creazione di una pagina dedicata per aggiungere, leggere, modificare ed eliminare anagrafiche tramite un'interfaccia con input e quattro pulsanti CRUD per interagire con il database.
- Ricerca tramite input di una lista.

## Gestione della Sessione Utente
- Dopo il login, se l'utente riapre l'applicazione, verrà automaticamente ri-autenticato, a meno che non abbia effettuato il logout.

## Istruzioni per l'Uso
1. Clona il repository.
2. Installa le dipendenze necessarie.
3. Avvia l'applicazione.
4. Accedi o registrati e inizia a gestire le persone!


