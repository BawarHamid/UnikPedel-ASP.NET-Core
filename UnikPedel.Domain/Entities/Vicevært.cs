﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.DomainServices;

namespace UnikPedel.Domain.Entities
{
    public class Vicevært : BaseEntity
    {

        public IServiceProvider? _serviceProvider { get; set; }

        [Required]

        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }

        //public IEnumerable<EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }
        //public int EjendomsAnsvarligId { get; set; }
        public IEnumerable<EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }
        public IEnumerable<Rekvisition> Rekvisitioner { get; set; }
        public IEnumerable<Ejendom> Ejemdom { get; set; }
        public IEnumerable<TidRegistering> TidRegistrering { get; set; }

        //Constructor for Ef
        private Vicevært()
        {

        }
        //only test 
        public Vicevært(int id, string fornavn, string efternavn, int telefon, string email)
        {
            Id = id;
            ForNavn = fornavn;
            EfterNavn = efternavn;
            Telefon = telefon;
            Email = email;
        }

        public Vicevært(IServiceProvider serviceProvider, string fornavn, string efternavn, int telefon, string email)
        {
            if (telefon == default) throw new ArgumentOutOfRangeException(nameof(telefon), "Telefon nummer skal være udfyldt");
            if (email == default) throw new ArgumentOutOfRangeException(nameof(email), "Email skal være udfyldt");
            ForNavn = fornavn;
            EfterNavn = efternavn;
            Telefon = telefon;
            Email = email;
            _serviceProvider = serviceProvider; 

            if (CheckViceværtTlfOgEmail()) throw new Exception("Der findes en vicevært med det sammen Telefon nummer eller Email"); 


        }
        public bool CheckViceværtTlfOgEmail() 
        {
            var viceværtDomainService = _serviceProvider?.GetService<IViceværtDomainService>();
            if (viceværtDomainService == null) throw new Exception("Implementation of IViceværtDomainService was not found");

            return viceværtDomainService.GetExsistingViceværter().Any(a => a.Id != Id && a.Telefon == Telefon || a.Email == Email);
        }

        public void Update(string fornavn, string efternavn, int telefon, string email)
        {
            ForNavn = fornavn;
            EfterNavn = efternavn;
            Telefon = telefon;
            Email = email;
        }
    }
}
