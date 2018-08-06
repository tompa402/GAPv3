﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.DAL
{
    // public class GAPv3ContextInitializer : DropCreateDatabaseIfModelChanges<GAPv3Context>
    public class GAPv3ContextInitializer : DropCreateDatabaseAlways<GAPv3Context>
    {
        protected override void Seed(GAPv3Context context)
        {
            // loading default values
            context.Norms.Add(new Norm()
            {
                Name = "HRN ISO/IEC 27001:2013",
                Description = "Informacijska tehnologija - Sigurnosne tehnike - Sustavi upravljanja informacijskom sigurnošću - Zahtjevi"
            });
            context.Norms.Add(new Norm()
            {
                Name = "HRN ISO/IEC 27002:2013",
                Description = "Information technology – Security techniques – Code of practice for information security controls"
            });

            context.Organisations.Add(new Organisation() { OrganisationId = 1, Name = "Test organizacija" });
            context.Organisations.Add(new Organisation() { OrganisationId = 2, Name = "Druga test organizacija" });

            context.Reports.Add(new Report() { Name = "Custom report", NormId = 1, OrganisationId = 1 });
            context.Reports.Add(new Report() { Name = "Custom report 2", NormId = 2, OrganisationId = 2 });

            context.NormItems.Add(new NormItem() { Name = "Kontekst organizacije", IsItem = false, ParentId = null, Order = 4, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Razumijevanje organizacije i njenog konteksta", IsItem = true, Order = 1, ParentId = 1, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Razumijevanje potreba i očekivanja zainteresiranih strana", IsItem = true, Order = 2, ParentId = 1, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Definiranje opsega ISMS-a", IsItem = true, Order = 3, ParentId = 1, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Sustav upravljanja informacijskom sigurnošću", IsItem = true, Order = 4, ParentId = 1, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Rukovodstvo", IsItem = false, ParentId = null, Order = 5, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Rukovodstvo i predanost menadžmenta", IsItem = true, Order = 1, ParentId = 6, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "ISMS politika", IsItem = true, Order = 2, ParentId = 6, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Uloge, odgovornosti i ovlasti", IsItem = true, Order = 3, ParentId = 6, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Planiranje", IsItem = false, ParentId = null, Order = 6, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Aktivnosti za prepoznavanje rizika i prilika", IsItem = false, Order = 1, ParentId = 10, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Općenito", IsItem = true, Order = 1, ParentId = 11, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Procjena rizika informacijske sigurnosti", IsItem = true, Order = 2, ParentId = 11, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Obrada rizika informacijske sigurnosti", IsItem = true, Order = 3, ParentId = 11, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Ciljevi ISMS-a i planovi za njihovo ostvarivanje", IsItem = true, Order = 2, ParentId = 10, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Podrška", IsItem = false, ParentId = null, Order = 7, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Resursi", IsItem = true, Order = 1, ParentId = 16, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Kompetencije", IsItem = true, Order = 2, ParentId = 16, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Awareness", IsItem = true, Order = 3, ParentId = 16, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Komunikacija", IsItem = true, Order = 4, ParentId = 16, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Dokumentirane informacije", IsItem = false, Order = 5, ParentId = 16, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Općenito", Order = 1, IsItem = true, ParentId = 21, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Izrada i ažuriranje", IsItem = true, Order = 2, ParentId = 21, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Kontrola dokumentiranih informacija", IsItem = true, Order = 3, ParentId = 21, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Operacije", IsItem = false, ParentId = null, Order = 8, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Operativno planiranje i nadzor", IsItem = true, Order = 1, ParentId = 25, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Procjena rizika informacijske sigurnosti", IsItem = true, Order = 2, ParentId = 25, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Obrada rizika informacijske sigurnosti", IsItem = true, Order = 3, ParentId = 25, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Ocjenjivanje uspješnosti", IsItem = false, ParentId = null, Order = 9, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Praćenje, mjerenje, analiza i procjena", IsItem = true, Order = 1, ParentId = 29, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Interni audit", IsItem = true, Order = 2, ParentId = 29, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Ocjena sustava od strane Uprave", IsItem = true, Order = 3, ParentId = 29, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Poboljšanja", IsItem = false, ParentId = null, Order = 10, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Nesukladnosti i korektivne aktivnosti", IsItem = true, Order = 1, ParentId = 33, NormId = 1 });
            context.NormItems.Add(new NormItem() { Name = "Kontinuirano poboljšavanje", IsItem = true, Order = 2, ParentId = 33, NormId = 1 });

            // report ISO2
            context.NormItems.Add(new NormItem() { Name = "Politike ISMS-a", IsItem = false, ParentId = null, Order = 5, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Politika informacijske sigurnosti", IsItem = false, ParentId = 36, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Politike informacijske sigurnosti", IsItem = true, ParentId = 37, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Provjera politike informacijske sigurnosti", IsItem = true, ParentId = 37, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Organizacija informacijske sigurnosti", IsItem = false, ParentId = null, Order = 6, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Unutarnja organizacija", IsItem = false, ParentId = 40, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Uloge i odgovornosti u informacijskoj sigurnostia", IsItem = true, ParentId = 41, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odjeljivanje funkcija", IsItem = true, ParentId = 41, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontakt s nadležnim tijelima", IsItem = true, ParentId = 41, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontakti s posebnim interesnim grupama", IsItem = true, ParentId = 41, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Informacijska sigurnost u upravljanju projektima", IsItem = true, ParentId = 41, Order = 5, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Mobilni uređaji i rad na daljinu", IsItem = false, ParentId = 40, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Mobilni uređaji", IsItem = true, ParentId = 47, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Rad na daljinu", IsItem = true, ParentId = 47, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnost ljudskih resursa", IsItem = false, ParentId = null, Order = 7, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Prije zaposlenja", IsItem = false, ParentId = 50, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Provjeravanje", IsItem = true, ParentId = 51, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Trajanje i uvjeti zaposlenja", IsItem = true, ParentId = 51, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnost ljudskih resursa", IsItem = false, ParentId = 50, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odgovornost uprave", IsItem = true, ParentId = 54, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Razina svijesti o informacijskoj sigurnosti, obrazovanje i obučavanje", IsItem = true, ParentId = 54, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Disciplinski postupak", IsItem = true, ParentId = 54, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Prekid ili promjena zaposlenja", IsItem = false, ParentId = 50, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odgovornost za prekid ili promjenu zaposlenja", IsItem = true, ParentId = 58, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje imovinom", IsItem = false, ParentId = null, Order = 8, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje imovinom", IsItem = false, ParentId = 60, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Popis imovine", IsItem = true, ParentId = 61, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Vlasništvo nad imovinom", IsItem = true, ParentId = 61, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Prihvatljivo korištenje imovinom", IsItem = true, ParentId = 61, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Povrat imovine", IsItem = true, ParentId = 61, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Klasifikacija informacija", IsItem = false, ParentId = 60, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Klasifikacija informacija", IsItem = true, ParentId = 66, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Označavanje informacija", IsItem = true, ParentId = 66, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Rukovanje imovinom", IsItem = true, ParentId = 66, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Rukovanje medijima", IsItem = false, ParentId = 60, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje uklonjivim medijima", IsItem = true, ParentId = 70, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odbacivanje medija", IsItem = true, ParentId = 70, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Prijevoz fizičkih medija", IsItem = true, ParentId = 70, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontrola pristupa", IsItem = false, ParentId = null, Order = 9, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Poslovni zahtjevi kontrole pristupa", IsItem = false, ParentId = 74, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Granice fizičkog sigurnosnog prostora", IsItem = true, ParentId = 75, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontrole fizičkog pristupa", IsItem = true, ParentId = 75, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje korisničkim pristupom", IsItem = false, ParentId = 74, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Prijava i odjava korisnika", IsItem = true, ParentId = 78, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Dodjeljivanje korisničkih prava", IsItem = true, ParentId = 78, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje povlaštenim pravima pristupa", IsItem = true, ParentId = 78, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje tajnim informacijama za autentifikaciju korisnika", IsItem = true, ParentId = 78, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Provjera prava korisničkog pristupa", IsItem = true, ParentId = 78, Order = 5, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Ukidanje ili podešavanje prava pristupa", IsItem = true, ParentId = 78, Order = 6, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odgovornosti korisnika", IsItem = false, ParentId = 74, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Korištenje tajnih informacija za autentifikaciju", IsItem = true, ParentId = 85, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontrola pristupa aplikacijama i sustavu", IsItem = false, ParentId = 74, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Ograničavanje pristupa informacijama", IsItem = true, ParentId = 87, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Procedura sigurnog prijavljivanja", IsItem = true, ParentId = 87, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje korisničkim zaporkama", IsItem = true, ParentId = 87, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Uporaba privilegiranih utility programa", IsItem = true, ParentId = 87, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontrola pristupa izvornom kodu programa", IsItem = true, ParentId = 87, Order = 5, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kriptografija", IsItem = false, ParentId = null, Order = 10, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kriptografske kontrole", IsItem = false, ParentId = 93, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Politika korištenja kriptografskih kontrola", IsItem = true, ParentId = 94, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje ključevima", IsItem = true, ParentId = 94, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Fizička sigurnost i sigurnost okruženja", IsItem = false, ParentId = null, Order = 11, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Granice fizičke sigurnosti", IsItem = false, ParentId = 97, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Politika kontrole pristupa", IsItem = true, ParentId = 98, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontrole fizičkog pristupa", IsItem = true, ParentId = 98, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Osiguranje ureda, prostorija i opreme", IsItem = true, ParentId = 98, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Zaštita od vanjskih prijetnji i nepogoda", IsItem = true, ParentId = 98, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Rad u osiguranim područjima", IsItem = true, ParentId = 98, Order = 5, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Područja sa javnim pristupom, područja za istovar i utovar", IsItem = true, ParentId = 98, Order = 6, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Oprema", IsItem = false, ParentId = 97, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Zaštita opreme", IsItem = true, ParentId = 105, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Potporne usluge", IsItem = true, ParentId = 105, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnost ožičenja", IsItem = true, ParentId = 105, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Održavanje opreme", IsItem = true, ParentId = 105, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Iznošenje imovine", IsItem = true, ParentId = 105, Order = 5, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnost opreme izvan prostora", IsItem = true, ParentId = 105, Order = 6, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurno odbacivanje ili ponovno korištenje opreme", IsItem = true, ParentId = 105, Order = 7, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Korisnička oprema bez nadzora", IsItem = true, ParentId = 105, Order = 8, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Politika praznog stola i zaslona", IsItem = true, ParentId = 105, Order = 9, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Operacijska sigurnost", IsItem = false, ParentId = null, Order = 12, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Radne procedure i odgovornosti", IsItem = false, ParentId = 115, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Dokumentirane radne procedure", IsItem = true, ParentId = 116, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje promjenama", IsItem = true, ParentId = 116, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje kapacitetom", IsItem = true, ParentId = 116, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odvajanje razvojne, testne i produkcijske okoline", IsItem = true, ParentId = 116, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Zaštita od zloćudnog koda", IsItem = false, ParentId = 115, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontrole za zaštitu od zloćudnog koda", IsItem = true, ParentId = 121, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnosne kopije (backup)", IsItem = false, ParentId = 115, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnosne kopije informacija", IsItem = true, ParentId = 123, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnost sistemskih datoteka", IsItem = false, ParentId = 115, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Zapisi o događajima", IsItem = true, ParentId = 125, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Zaštita logova", IsItem = true, ParentId = 125, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Zapisi administratora i operatera", IsItem = true, ParentId = 125, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sinkronizacija satova", IsItem = true, ParentId = 125, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontrola produkcijskog softvera", IsItem = false, ParentId = 115, Order = 5, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Instalacija softvera na produkcijskom sustavu", IsItem = true, ParentId = 130, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje tehničkom ranjivošću", IsItem = false, ParentId = 115, Order = 6, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje tehničkom ranjivošću", IsItem = true, ParentId = 132, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Ograničenja za instalaciju softvera", IsItem = true, ParentId = 132, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Razmatranje revizije informacijskih sustava", IsItem = false, ParentId = 115, Order = 7, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontrola revizije informacijskih sustava", IsItem = true, ParentId = 135, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnost komunikacija", IsItem = false, ParentId = null, Order = 13, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje sigurnošću mreže", IsItem = false, ParentId = 137, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Kontrola mreže", IsItem = true, ParentId = 138, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnost mrežnih usluga", IsItem = true, ParentId = 138, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odvajanje u mrežama", IsItem = true, ParentId = 138, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Razmjena informacija", IsItem = false, ParentId = 137, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Politike i procedure za razmjenu informacija", IsItem = true, ParentId = 142, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sporazumi o razmjeni informacija", IsItem = true, ParentId = 142, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Elektronska razmjena informacija", IsItem = true, ParentId = 142, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sporazumi o povjerljivosti", IsItem = true, ParentId = 142, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Nabava, razvoj i održavanje sustava", IsItem = false, ParentId = null, Order = 14, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnosni zahtjevi za informacijske sustave", IsItem = false, ParentId = 147, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Analiza i specifikacija sigurnosnih zahtjeva", IsItem = true, ParentId = 148, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnost aplikacija na javnim mrežama", IsItem = true, ParentId = 148, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Zaštita transakcija", IsItem = true, ParentId = 148, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnost u procesima razvoja i podrške", IsItem = false, ParentId = 147, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnosna politika razvoja", IsItem = true, ParentId = 152, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Procedure kontrole promjene sustava", IsItem = true, ParentId = 152, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Tehnička provjera aplikacija nakon promjena operativne platforme", IsItem = true, ParentId = 152, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Ograničenje promjena softverskih paketa", IsItem = true, ParentId = 152, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Principi sigurnosti u inženjeringu IS-a", IsItem = true, ParentId = 152, Order = 5, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurno razvojno okruženje", IsItem = true, ParentId = 152, Order = 6, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Razvoj povjeren vanjskim izvršiteljima", IsItem = true, ParentId = 152, Order = 7, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sigurnosna testiranja sustava", IsItem = true, ParentId = 152, Order = 8, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Testiranje prihvaćanja sustava", IsItem = true, ParentId = 152, Order = 9, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Testni podaci", IsItem = false, ParentId = 147, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Zaštita testnih podataka", IsItem = true, ParentId = 162, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odnosi s dobavljačima", IsItem = false, ParentId = null, Order = 15, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Informacijska sigurnost u odnosu s dobavljačima", IsItem = false, ParentId = 164, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Politika sigurnosti za odnose s dobavljačima", IsItem = true, ParentId = 165, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Uključivanje sigurnosti u ugovore s dobavljačima", IsItem = true, ParentId = 165, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Lanac nabave informacijsko-komunikacijske tehnologije", IsItem = true, ParentId = 165, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje isporukama dobavljača", IsItem = false, ParentId = 165, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Nadzor i provjera usluga dobavljača", IsItem = true, ParentId = 168, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje promjenama usluga dobavljača", IsItem = true, ParentId = 168, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje s incidentima informacijske sigurnosti", IsItem = false, ParentId = null, Order = 16, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje incidentima i unapređenjima informacijske sigurnosti", IsItem = false, ParentId = 172, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odgovornosti i procedure", IsItem = true, ParentId = 173, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Izvješćivanje o sigurnosnim događajima", IsItem = true, ParentId = 173, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Izvješćivanje o sigurnosnim slabostima", IsItem = true, ParentId = 173, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Procjena i odlučivanje vezano za događaje informacijske sigurnosti", IsItem = true, ParentId = 173, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odgovor na incidente informacijske sigurnosti", IsItem = true, ParentId = 173, Order = 5, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Učenje na sigurnosnim incidentima", IsItem = true, ParentId = 173, Order = 6, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Prikupljanje dokaza", IsItem = true, ParentId = 173, Order = 7, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Upravljanje kontinuitetom poslovanja s aspekta informacijske sigurnosti", IsItem = false, ParentId = null, Order = 17, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Prikupljanje dokaza", IsItem = false, ParentId = 181, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Planiranje kontinuiteta informacijske sigurnosti", IsItem = true, ParentId = 182, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Implementacija kontinuiteta informacijske sigurnosti", IsItem = true, ParentId = 182, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Verifikacija, provjera i evaluacija kontinuiteta informacijske sigurnosti", IsItem = true, ParentId = 182, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Redundantnost", IsItem = false, ParentId = 181, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Dostupnost opreme za obradu informacija", IsItem = true, ParentId = 186, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Sukladnost", IsItem = false, ParentId = null, Order = 18, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Redundantnost", IsItem = false, ParentId = 188, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Određivanje primjenjivih zakona", IsItem = true, ParentId = 189, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Prava intelektualnog vlasništva", IsItem = true, ParentId = 189, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Zaštita zapisa", IsItem = true, ParentId = 189, Order = 3, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Zaštita podatakak i privatnost osobnih informacija", IsItem = true, ParentId = 189, Order = 4, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Odredbe o kriptografskim kontrolama", IsItem = true, ParentId = 189, Order = 5, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Provjera informacijske sigurnosti", IsItem = false, ParentId = 188, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Neovisna provjera informacijske sigurnosti", IsItem = true, ParentId = 195, Order = 1, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Usklađenost sa sigurnosnim pravilima i standardima", IsItem = true, ParentId = 195, Order = 2, NormId = 2 });
            context.NormItems.Add(new NormItem() { Name = "Provjera tehničke sukladnosti", IsItem = true, ParentId = 195, Order = 3, NormId = 2 });
            context.SaveChanges();
        }
    }
}