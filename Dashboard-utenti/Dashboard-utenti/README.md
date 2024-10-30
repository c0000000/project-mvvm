# Gestione Persone

## Descrizione del Progetto
Il progetto "Gestione Persone" offre una soluzione intuitiva ed efficiente per la gestione di un elenco di persone. Gli utenti possono registrarsi, effettuare il login e aggiornare le proprie informazioni personali. Tutti i dati sono archiviati in un file JSON, garantendo un'implementazione leggera e facilmente accessibile.

## Funzionalità

### Pagina di Login e Registrazione
- **Login**: Accedi al sistema utilizzando le tue credenziali.
- **Registrazione**: I nuovi utenti possono registrarsi, e le loro credenziali verranno memorizzate in un file `.json`.

### Pagina Lista Persone
- **Navigazione**: Una barra di navigazione intuitiva con le seguenti opzioni:
  - **Home**
  - **Gestione Utenti**
  - **Chiamate HTTP**
  - **Logout**
  - **Chiudi Programma**
- **Visualizzazione**: Mostra l'elenco delle persone registrate.
- **Aggiungi Persona**: Utilizza un modulo per inserire una nuova persona. Cliccando su una persona nella lista, il modulo si riempirà automaticamente con i suoi dati.
- **Salva Utenti**: Un pulsante dedicato per salvare le informazioni nel file `.json`.
- **Aggiorna Dati**: Possibilità di modificare i dati della persona selezionata.
- **Elimina Persona**: Un pulsante per rimuovere una persona dall'elenco.

### Richieste di Dati
Utilizzando HttpClient, il progetto effettua chiamate all'API di [Json-placeholder](https://dummyjson.com/) per gestire le richieste di dati.
- Crea una pagina che mostra tutte le attività da completare (todos) e i commenti presenti nel progetto, consentendo di visualizzarne solo uno alla volta.
- Effettua una richiesta GET sugli utenti di jsonPlaceholder.

## Gestione della Sessione Utente
- Dopo aver effettuato il login, se l'utente riapre l'applicazione, verrà automaticamente ri-autenticato, a meno che non abbia effettuato il logout precedentemente.

## Come Usarlo
1. Clona il repository.
2. Installa le dipendenze necessarie.
3. Avvia l'applicazione.
4. Accedi o registrati e inizia a gestire le persone!

