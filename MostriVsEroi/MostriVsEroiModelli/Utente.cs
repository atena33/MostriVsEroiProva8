﻿using System;
using System.Collections.Generic;

namespace MostriVsEroi.Modelli
{
    public class Utente
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }
        public List<Eroe> Eroi { get; set; }

        public Utente()
        {

        }
        public Utente(string username, string password)
        {
            Username = username;
            Password = password;
            IsAuthenticated = false;
            IsAdmin = false;
        }
    }
}
