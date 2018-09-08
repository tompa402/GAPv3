using System.Collections.Generic;
using System.Data.Entity;
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
                NormId = 1,
                Name = "HRN ISO/IEC 27001:2013",
                Description = "Informacijska tehnologija - Sigurnosne tehnike - Sustavi upravljanja informacijskom sigurnošću - Zahtjevi"
            });
            context.Norms.Add(new Norm()
            {
                NormId = 2,
                Name = "HRN ISO/IEC 27002:2013",
                Description = "Information technology – Security techniques – Code of practice for information security controls"
            });

            context.Organisations.Add(new Organisation()
            {
                OrganisationId = 1,
                Name = "Test organizacija",
                Address = "Test address",
                AssetOne = "DA",
                AssetTwo = "asd",
                AssetThree = "Test",
                BuildingPossession = "Da",
                EmployeesNumber = "160",
                GuardService = "Da",
                ITService = "Da",
                Location = "Test lokacija",
                Ownership = "Full",
                Size = "Ne znma",
                Type = "4",
                VideoSurveillance = "Da"
            });
            context.Organisations.Add(new Organisation()
            {
                OrganisationId = 2,
                Name = "Druga test organizacija",
                Address = "Test address",
                AssetOne = "DA",
                AssetTwo = "asd",
                AssetThree = "Test",
                BuildingPossession = "Da",
                EmployeesNumber = "160",
                GuardService = "Da",
                ITService = "Da",
                Location = "Test lokacija",
                Ownership = "Full",
                Size = "Ne znma",
                Type = "4",
                VideoSurveillance = "Da"
            });

            context.Reports.Add(new Report() { Name = "Custom report", NormId = 1, OrganisationId = 1 });
            context.Reports.Add(new Report() { Name = "Custom report 2", NormId = 2, OrganisationId = 2 });

            context.Statuses.Add(new Status() { StatusId = 1, Name = "Potpuno implementiran" });
            context.Statuses.Add(new Status() { StatusId = 2, Name = "Djelomice implementiran" });
            context.Statuses.Add(new Status() { StatusId = 3, Name = "Nije implementiran" });

            context.Controls.Add(new Control() { ControlId = 1, Name = "Da" });
            context.Controls.Add(new Control() { ControlId = 2, Name = "Ne" });

            context.Reasons.Add(new Reason() { ReasonId = 1, Name = "Zakonska obaveza" });
            context.Reasons.Add(new Reason() { ReasonId = 2, Name = "Ugovorna obaveza" });
            context.Reasons.Add(new Reason() { ReasonId = 3, Name = "Poslovna potreba" });
            context.Reasons.Add(new Reason() { ReasonId = 4, Name = "Procjena rizika" });
            context.Reasons.Add(new Reason() { ReasonId = 5, Name = "Dobra praksa" });
            context.Reasons.Add(new Reason() { ReasonId = 6, Name = "Drugi razlog" });
            context.Reasons.Add(new Reason() { ReasonId = 7, Name = "Nije primjenjivo" });

            context.ReportValueAdditionalItems.Add(new ReportValueAdditionalItem() { NormId = 1, HaveControl = false, HaveReason = false });
            context.ReportValueAdditionalItems.Add(new ReportValueAdditionalItem() { NormId = 2, HaveControl = true, HaveReason = true });

            context.Users.Add(new User()
            {
                Email = "tnovak@vvg.hr",
                Password = "2",
                Name = "Tom",
                LastName = "N",
                JMBAG = 123456
            });
            context.Users.Add(new User()
            {
                Email = "jpavlov@vvg.hr",
                Password = "josip",
                Name = "J",
                LastName = "Lo",
                JMBAG = 123456
            });
            context.Users.Add(new User()
            {
                Email = "test@vvg.hr",
                Password = "test",
                Name = "Test",
                LastName = "Testić",
                JMBAG = 123456
            });

            context.Roles.Add(new Role() { RoleId = 1, RoleName = "admin" });
            context.Roles.Add(new Role() { RoleId = 2, RoleName = "user" });
            context.Roles.Add(new Role() { RoleId = 3, RoleName = "guest" });

            context.UserRoles.Add(new UserRole() { RoleId = 1, UserId = 1 });
            context.UserRoles.Add(new UserRole() { RoleId = 2, UserId = 2 });

            context.UserOrganisations.Add(new UserOrganisation() { UserId = 1, OrganisationId = 1 });
            context.UserOrganisations.Add(new UserOrganisation() { UserId = 2, OrganisationId = 1 });
            context.UserOrganisations.Add(new UserOrganisation() { UserId = 3, OrganisationId = 2 });

            context.NormItems.Add(new NormItem() { NormItemId = 1, Name = "Kontekst organizacije", IsItem = false, ParentId = null, Order = 4, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 2, Name = "Razumijevanje organizacije i njenog konteksta", IsItem = true, Order = 1, ParentId = 1, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 3, Name = "Razumijevanje potreba i očekivanja zainteresiranih strana", IsItem = true, Order = 2, ParentId = 1, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 4, Name = "Definiranje opsega ISMS-a", IsItem = true, Order = 3, ParentId = 1, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 5, Name = "Sustav upravljanja informacijskom sigurnošću", IsItem = true, Order = 4, ParentId = 1, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 6, Name = "Rukovodstvo", IsItem = false, ParentId = null, Order = 5, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 7, Name = "Rukovodstvo i predanost menadžmenta", IsItem = true, Order = 1, ParentId = 6, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 8, Name = "ISMS politika", IsItem = true, Order = 2, ParentId = 6, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 9, Name = "Uloge, odgovornosti i ovlasti", IsItem = true, Order = 3, ParentId = 6, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 10, Name = "Planiranje", IsItem = false, ParentId = null, Order = 6, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 11, Name = "Aktivnosti za prepoznavanje rizika i prilika", IsItem = false, Order = 1, ParentId = 10, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 12, Name = "Općenito", IsItem = true, Order = 1, ParentId = 11, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 13, Name = "Procjena rizika informacijske sigurnosti", IsItem = true, Order = 2, ParentId = 11, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 14, Name = "Obrada rizika informacijske sigurnosti", IsItem = true, Order = 3, ParentId = 11, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 15, Name = "Ciljevi ISMS-a i planovi za njihovo ostvarivanje", IsItem = true, Order = 2, ParentId = 10, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 16, Name = "Podrška", IsItem = false, ParentId = null, Order = 7, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 17, Name = "Resursi", IsItem = true, Order = 1, ParentId = 16, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 18, Name = "Kompetencije", IsItem = true, Order = 2, ParentId = 16, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 19, Name = "Awareness", IsItem = true, Order = 3, ParentId = 16, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 20, Name = "Komunikacija", IsItem = true, Order = 4, ParentId = 16, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 21, Name = "Dokumentirane informacije", IsItem = false, Order = 5, ParentId = 16, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 22, Name = "Općenito", Order = 1, IsItem = true, ParentId = 21, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 23, Name = "Izrada i ažuriranje", IsItem = true, Order = 2, ParentId = 21, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 24, Name = "Kontrola dokumentiranih informacija", IsItem = true, Order = 3, ParentId = 21, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 25, Name = "Operacije", IsItem = false, ParentId = null, Order = 8, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 26, Name = "Operativno planiranje i nadzor", IsItem = true, Order = 1, ParentId = 25, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 27, Name = "Procjena rizika informacijske sigurnosti", IsItem = true, Order = 2, ParentId = 25, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 28, Name = "Obrada rizika informacijske sigurnosti", IsItem = true, Order = 3, ParentId = 25, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 29, Name = "Ocjenjivanje uspješnosti", IsItem = false, ParentId = null, Order = 9, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 30, Name = "Praćenje, mjerenje, analiza i procjena", IsItem = true, Order = 1, ParentId = 29, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 31, Name = "Interni audit", IsItem = true, Order = 2, ParentId = 29, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 32, Name = "Ocjena sustava od strane Uprave", IsItem = true, Order = 3, ParentId = 29, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 33, Name = "Poboljšanja", IsItem = false, ParentId = null, Order = 10, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 34, Name = "Nesukladnosti i korektivne aktivnosti", IsItem = true, Order = 1, ParentId = 33, NormId = 1 });
            context.NormItems.Add(new NormItem() { NormItemId = 35, Name = "Kontinuirano poboljšavanje", IsItem = true, Order = 2, ParentId = 33, NormId = 1 });
            context.SaveChanges();
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

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 1,
                NormItemId = 1,
                Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 1, NormItemId = 2, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 1, NormItemId = 3, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 1, NormItemId = 4, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 1, NormItemId = 5, StatusId = 1, Note = "Napomena test" }
                    }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 1,
                NormItemId = 6,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 1, NormItemId = 7, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 8, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 9, StatusId = 1, Note = "Napomena test" }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 1,
                NormItemId = 10,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 1, NormItemId = 11, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 1, NormItemId = 12, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 1, NormItemId = 13, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 1, NormItemId = 14, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 1, NormItemId = 15, StatusId = 1, Note = "Napomena test" }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 1,
                NormItemId = 16,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 1, NormItemId = 17, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 18, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 19, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 20, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 21, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 1, NormItemId = 22, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 1, NormItemId = 23, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 1, NormItemId = 24, StatusId = 1, Note = "Napomena test" }
                    } },
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 1,
                NormItemId = 25,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 1, NormItemId = 26, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 27, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 28, StatusId = 1, Note = "Napomena test" }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 1,
                NormItemId = 29,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 1, NormItemId = 30, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 31, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 32, StatusId = 1, Note = "Napomena test" }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 1,
                NormItemId = 33,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 1, NormItemId = 34, StatusId = 1, Note = "Napomena test" },
                    new ReportValue() { ReportId = 1, NormItemId = 35, StatusId = 1, Note = "Napomena test" }
                }
            });

            // report ISO2 - Values
            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 36,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 37, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 38, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 39, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 40,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 41, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 42, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 43, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 44, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 45, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 46, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 47, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 48, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 49, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 50,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 51, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 52, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 53, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 54, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 55, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 56, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 57, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 58, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 59, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 60,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 61, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 62, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 63, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 64, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 65, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 66, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 67, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 68, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 69, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 70, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 71, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 72, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 73, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 74,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 75, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 76, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 77, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 78, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 79, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 80, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 81, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 82, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 83, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 84, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 85, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 86, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 87, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 88, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 89, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 90, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 91, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 92, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 93,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 94, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 95, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 96, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 97,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 98, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 99, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 100, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 101, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 102, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 103, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 104, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 105, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 106, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 107, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 108, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 109, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 110, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 111, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 112, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 113, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 114, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 115,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 116, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 117, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 118, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 119, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 120, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 121, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 122, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 123, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 124, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 125, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 126, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 127, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 128, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 129, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 130, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 131, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 132, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 133, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 134, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 135, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 136, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 137,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 138, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 139, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 140, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 141, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 142, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 143, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 144, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 145, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 146, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 147,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 148, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 149, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 150, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 151, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 152, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 153, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 154, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 155, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 156, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 157, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 158, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 159, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 160, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 161, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 162, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 163, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 164,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 165, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 166, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 167, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 168, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 169, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 170, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 171, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 172,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 173, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 174, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 175, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 176, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 177, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 178, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 179, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 180, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 181,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 182, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 183, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 184, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 185, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 186, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 187, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.ReportValues.Add(new ReportValue()
            {
                ReportId = 2,
                NormItemId = 188,
                Children = new List<ReportValue>
                {
                    new ReportValue() { ReportId = 2, NormItemId = 189, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 190, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 191, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 192, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 193, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 194, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } },
                    new ReportValue() { ReportId = 2, NormItemId = 195, Children = new List<ReportValue>
                    {
                        new ReportValue() { ReportId = 2, NormItemId = 196, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 197, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" },
                        new ReportValue() { ReportId = 2, NormItemId = 198, ControlId = 1, ReasonId = 1, StatusId = 1, Note = "Napomena test" }
                    } }
                }
            });

            context.SaveChanges();
        }
    }
}