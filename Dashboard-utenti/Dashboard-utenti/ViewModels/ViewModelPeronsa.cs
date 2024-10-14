﻿using Dashboard_utenti.MODELS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_utenti.ViewModels
{
    public class ViewModelPeronsa : INotifyPropertyChanged
    {
        public Persona persona;
        public ObservableCollection<Persona> ListaPersone { get; set; }

        public Persona Persona
        {
            get => persona;
            set
            {
                persona = value;
                OnPropertyChanged(nameof(ID));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Cognome));
                OnPropertyChanged(nameof(DataNascita));
                OnPropertyChanged(nameof(Indirizzo));
                OnPropertyChanged(nameof(Citta));
                OnPropertyChanged(nameof(CAP));
                OnPropertyChanged(nameof(Telefono));
            }
        }
     
        public ViewModelPeronsa() { 
            ListaPersone = new ObservableCollection<Persona>();
            persona = new Persona();
        }

        public int ID
        {
            get => persona.ID;
            set
            {
                persona.ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get => persona.Name;
            set
            {
                persona.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Cognome
        {
            get => persona.Cognome;
            set
            {
                persona.Cognome = value;
                OnPropertyChanged(nameof(Cognome));
            }
        }

        public DateTime DataNascita
        {
            get => persona.DataNascita;
            set
            {
                persona.DataNascita = value;
                OnPropertyChanged(nameof(DataNascita));
            }
        }

        public string Indirizzo
        {
            get => persona.Indirizzo;
            set
            {
                persona.Indirizzo = value;
                OnPropertyChanged(nameof(Indirizzo));
            }
        }

        public string Citta
        {
            get => persona.Citta;
            set
            {
                persona.Citta = value;
                OnPropertyChanged(nameof(Citta));
            }
        }

        public int CAP
        {
            get => persona.CAP;
            set
            {
                persona.CAP = value;
                OnPropertyChanged(nameof(CAP));
            }
        }

        public string Telefono
        {
            get => persona.Telefono;
            set
            {
                persona.Telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
