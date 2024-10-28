# Gestione Persone

## Descrizione del Progetto
Questo progetto offre una soluzione semplice ed efficace per la gestione di un elenco di persone. Gli utenti possono registrarsi, effettuare il login e aggiornare le proprie informazioni. Tutti i dati vengono archiviati in un file JSON, garantendo un'implementazione leggera e facilmente accessibile.

## Funzionalità

### Pagina di Login e Registrazione
- **Login**: Accedi al sistema con le tue credenziali.
- **Registrazione**: I nuovi utenti possono registrarsi, e le loro credenziali verranno salvate in un file `.json`.

### Pagina Lista Persone
- **Navigazione**: Una barra di navigazione intuitiva con le seguenti opzioni:
  - **Home**
  - **Gestione Utenti**
  - **Chiamate HTTP**
  - **Logout**
  - **Chiudi Programma**
- **Visualizzazione**: Presenta l'elenco delle persone registrate.
- **Aggiungi Persona**: Utilizza un modulo per inserire una nuova persona. Cliccando su una persona nella lista, il modulo si riempirà automaticamente con i suoi dati.
- **Salva Utenti**: Un pulsante dedicato per salvare le informazioni nel file `.json`.
- **Aggiorna Dati**: Possibilità di modificare i dati della persona selezionata.
- **Elimina Persona**: Un pulsante per rimuovere una persona dall'elenco.

### Richieste di Dati
Utilizzando HttpClient, il progetto effettua chiamate all'API di [Json-placeholder](https://dummyjson.com/) per gestire le richieste di dati.
- Crea una pagina che mostra tutte le attività da completare (todos) e i commenti presenti nel progetto, consentendo di visualizzarne solo uno alla volta.


## Gestione sessione utente
- Utente dopo aver fatto il login se riapre l'applciazione rientra in maneria uatomtaica nel caso non avesse fatto il logute precedemente 
## Come Usarlo
1. Clona il repository.
2. Installa le dipendenze necessarie.
3. Avvia l'applicazione.
4. Accedi o registrati e inizia a gestire le persone!


