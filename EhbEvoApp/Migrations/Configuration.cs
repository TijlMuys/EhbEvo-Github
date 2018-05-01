namespace EhbEvoApp.Migrations
{
    using EhbEvoApp.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EhbEvoApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EhbEvoApp.Models.ApplicationDbContext context)
        {
            /*
            //Opleidingen teovoegen
            var overk = new Program() { ProgramName = "* Meerdere Opleidingen *", ProgramType = "* Meerdere Types *" };
            //Communicatie, media en talen
            var cmt1 = new Program() { ProgramName = "Communicatiemanagement", ProgramType = "Bachelor" };
            var cmt2 = new Program() { ProgramName = "Journalistiek", ProgramType = "Bachelor" };
            var cmt3 = new Program() { ProgramName = "Office Management", ProgramType = "Bachelor" };
            var cmt4 = new Program() { ProgramName = "Marketing", ProgramType = "Graduaat (HBO5)" };
            //Gezondheid, voeding en labo
            var gvl1 = new Program() { ProgramName = "Biomedische Laboratoriumtechnologie", ProgramType = "Bachelor" };
            var gvl2 = new Program() { ProgramName = "Verpleegkunde", ProgramType = "Bachelor" };
            var gvl3 = new Program() { ProgramName = "Voedings- & Dieetkunde", ProgramType = "Bachelor" };
            var gvl4 = new Program() { ProgramName = "Vroedkunde", ProgramType = "Bachelor" };
            var gvl5 = new Program() { ProgramName = "Verpleegkunde (HB05)", ProgramType = "Graduaat (HBO5)" };
            var gvl6 = new Program() { ProgramName = "Pediatrie en Neonatologie", ProgramType = "Bachelor-na-bachelor" };
            var gvl7 = new Program() { ProgramName = "Zorgmanagement", ProgramType = "Bachelor-na-bachelor" };
            var gvl8 = new Program() { ProgramName = "Diabeteseducator 17-18", ProgramType = "Postgraduaat" };
            var gvl9 = new Program() { ProgramName = "Forensisch Onderzoek", ProgramType = "Postgraduaat" };
            var gvl10 = new Program() { ProgramName = "Peri-operatieve anesthesie - OK & anesthesieverpleegkundigen", ProgramType = "Postgraduaat" };
            var gvl11 = new Program() { ProgramName = "Postgraduaat Palliatieve zorg", ProgramType = "Postgraduaat" };
            var gvl12 = new Program() { ProgramName = "Bio-informatica", ProgramType = "Bij- en nascholing" };
            var gvl13 = new Program() { ProgramName = "Cultuursensitieve zorg in de praktijk", ProgramType = "Bij- en nascholing" };
            var gvl14 = new Program() { ProgramName = "Kansarmoede en zwangerschap in Brussel", ProgramType = "Bij- en nascholing" };
            var gvl15 = new Program() { ProgramName = "Kwaliteitsvolle postnatale zorgverlening na vervroegd ontslag uit het ziekenhuis", ProgramType = "Bij- en nascholing" };
            var gvl16 = new Program() { ProgramName = "Mentorenopleiding verpleegkundige", ProgramType = "Bij- en nascholing" };
            var gvl17 = new Program() { ProgramName = "Mentorenopleiding vroedkunde", ProgramType = "Bij- en nascholing" };
            var gvl18 = new Program() { ProgramName = "Proefdierkunde", ProgramType = "Bij- en nascholing" };
            var gvl19 = new Program() { ProgramName = "Referentieverpleegkundige diabetes", ProgramType = "Bij- en nascholing" };
            var gvl20 = new Program() { ProgramName = "Referentieverpleegkundige in de zorginfectiebeheersing", ProgramType = "Bij- en nascholing" };
            var gvl21 = new Program() { ProgramName = "Sportvoedingsadvies op maat geven - sportdiëtetiek", ProgramType = "Bij- en nascholing" };
            var gvl22 = new Program() { ProgramName = "Toekomstige ouders die hun opties niet kennen, hebben er geen: Tips en tricks voor perinatale gezondheidspromotie", ProgramType = "Bij- en nascholing" };
            var gvl23 = new Program() { ProgramName = "Voedingsbeleid in de geriatrische instelling", ProgramType = "Bij- en nascholing" };
            var gvl24 = new Program() { ProgramName = "Voedingsproductontwikkeling - Food product design", ProgramType = "Bij- en nascholing" };
            var gvl25 = new Program() { ProgramName = "Ziekenhuisfarmacie", ProgramType = "Bij- en nascholing" };
            //ICT, technologie en web
            var itw1 = new Program() { ProgramName = "Multimedia & Communicatietechnologie", ProgramType = "Bachelor" };
            var itw2 = new Program() { ProgramName = "Toegepaste Informatica", ProgramType = "Bachelor" };
            var itw3 = new Program() { ProgramName = "Digital Design & Development", ProgramType = "Bachelor of master in de Kunsten" };
            var itw4 = new Program() { ProgramName = "Informatica", ProgramType = "Graduaat (HBO5)" };
            var itw5 = new Program() { ProgramName = "Blockchain for Business", ProgramType = "Bij - en nascholing" };
            var itw6 = new Program() { ProgramName = "Digitale beeldvorming", ProgramType = "Bij - en nascholing" };
            var itw7 = new Program() { ProgramName = "Gamification for Business", ProgramType = "Bij - en nascholing" };
            var itw8 = new Program() { ProgramName = "Security for cloud applications", ProgramType = "Bij - en nascholing" };
            //Management, economie en toerisme
            var met1 = new Program() { ProgramName = "Hotelmanagement", ProgramType = "Bachelor" };
            var met2 = new Program() { ProgramName = "Idea & Innovation Management", ProgramType = "Bachelor" };
            var met3 = new Program() { ProgramName = "Office Management", ProgramType = "Bachelor" };
            var met4 = new Program() { ProgramName = "Toerisme- & Recreatiemanagement", ProgramType = "Bachelor" };
            var met5 = new Program() { ProgramName = "Boekhouden", ProgramType = "Graduaat (HBO5)" };
            var met6 = new Program() { ProgramName = "Hotel- en cateringmanagement", ProgramType = "Graduaat (HBO5)" };
            var met7 = new Program() { ProgramName = "Winkelmanagement", ProgramType = "Graduaat (HBO5)" };
            var met8 = new Program() { ProgramName = "Zorgmanagement", ProgramType = "Bachelor-na-bachelor" };
            var met9 = new Program() { ProgramName = "Erfgoedondernemerschap", ProgramType = "Postgraduaat" };
            var met10 = new Program() { ProgramName = "Geweldloze en verbindende communicatie 17-18", ProgramType = "Bij- en nascholing" };
            var met11 = new Program() { ProgramName = "Ondernemingszin / Entrepreneurship", ProgramType = "Bij- en nascholing" };
            //Mens en maatschappij
            var mem1 = new Program() { ProgramName = "Sociaal Werk", ProgramType = "Bachelor" };
            var mem2 = new Program() { ProgramName = "Bibliotheekwezen en documentaire informatiekunde", ProgramType = "Graduaat(HBO5)" };
            var mem3 = new Program() { ProgramName = "Openbare besturen", ProgramType = "Graduaat(HBO5)" };
            var mem4 = new Program() { ProgramName = "Rechtspraktijk", ProgramType = "Graduaat(HBO5)" };
            var mem5 = new Program() { ProgramName = "Syndicaal Werk", ProgramType = "Graduaat(HBO5)" };
            //Natuur en tuin
            var net1 = new Program() { ProgramName = "Landschaps- & Tuinarchitectuur", ProgramType = "Bachelor" };
            //var net2 = new Program() { ProgramName = "Bio-informatica", ProgramType = "Bij- en nascholing" };
            //var net3 = new Program() { ProgramName = "Proefdierkunde", ProgramType = "Bij- en nascholing" }; --> zie gvl18
            //Onderwijs en pedagogie
            var oep1 = new Program() { ProgramName = "Kleuteronderwijs", ProgramType = "Bachelor" };
            var oep2 = new Program() { ProgramName = "Lager Onderwijs", ProgramType = "Bachelor" };
            var oep3 = new Program() { ProgramName = "Pedagogie van het jonge kind", ProgramType = "Bachelor" };
            var oep4 = new Program() { ProgramName = "Secundair Onderwijs", ProgramType = "Bachelor" };
            var oep5 = new Program() { ProgramName = "Health Coach 17-18", ProgramType = "Postgraduaat" };
            var oep6 = new Program() { ProgramName = "Postgraduaat Niet-confessionele Zedenleer 17-18", ProgramType = "Postgraduaat" };
            var oep7 = new Program() { ProgramName = "Attest Rooms-katholieke godsdienst 17-18", ProgramType = "Bij- en nascholing" };
            var oep8 = new Program() { ProgramName = "Binnenklasdifferentiatie in de rekenles 17-18", ProgramType = "Bij- en nascholing" };
            var oep9 = new Program() { ProgramName = "Binnenklasdifferentiatie: ook in de geschiedenislessen een haalbare kaart 17-18", ProgramType = "Bij- en nascholing" };
            var oep10 = new Program() { ProgramName = "Creatief met Excel 17-18", ProgramType = "Bij- en nascholing" };
            var oep11 = new Program() { ProgramName = "De kracht van je stem 17-18", ProgramType = "Bij- en nascholing" };
            var oep12 = new Program() { ProgramName = "Democratische dialoog 17-18", ProgramType = "Bij- en nascholing" };
            var oep13 = new Program() { ProgramName = "Gesprekken met kinderen: hoe de taalvaardigheid stimuleren bij (anderstalige) leerlingen in het basisonderwijs. 17-18", ProgramType = "Bij- en nascholing" };
            var oep14 = new Program() { ProgramName = "Het creatieve kind experimenteert ... 17-18", ProgramType = "Bij- en nascholing" };
            var oep15 = new Program() { ProgramName = "ICT in de wiskundeles in het lager onderwijs 17-18", ProgramType = "Bij- en nascholing" };
            var oep16 = new Program() { ProgramName = "Janusz Korczak als inspiratie voor de pedagogische praktijk 17-18", ProgramType = "Bij- en nascholing" };
            var oep17 = new Program() { ProgramName = "Jongens die dansen, meisjes die brullen... Creatief aan de slag met genderstereotypen in de klas 17-18", ProgramType = "Bij- en nascholing" };
            var oep18 = new Program() { ProgramName = "Laat kleuters bewegen om later beter te leren! 17-18", ProgramType = "Bij- en nascholing" };
            var oep19 = new Program() { ProgramName = "Meertaligheid (als) troef. Positief omgaan met taaldiversiteit in het basisonderwijs 17-18", ProgramType = "Bij- en nascholing" };
            var oep20 = new Program() { ProgramName = "Wiskunde in de kleuterklas 17-18", ProgramType = "Bij- en nascholing" };
            //Koninklijk Conservatorium Brussel
            var kcb1 = new Program() { ProgramName = "Musical", ProgramType = "Bachelor of master in de Kunsten" };
            var kcb2 = new Program() { ProgramName = "Muziek", ProgramType = "Bachelor of master in de Kunsten" };
            var kcb3 = new Program() { ProgramName = "Specifieke Lerarenopleiding Muziek", ProgramType = "Bachelor of master in de Kunsten" };
            var kcb4 = new Program() { ProgramName = "Muziek (Postgraduaat)", ProgramType = "Postgraduaat" };
            //Royal Institute for Theatre, Cinema and Sound (RITCS)
            var ritcs1 = new Program() { ProgramName = "Audiovisuele Kunsten", ProgramType = "Bachelor of master in de Kunsten" };
            var ritcs2 = new Program() { ProgramName = "Dramatische Kunsten", ProgramType = "Bachelor of master in de Kunsten" };
            //save to context
            //Departementen toevoegen
            var dep0 = new EhbEvo.Models.Department() { DepartmentName = "* Meerdere Departmenten *" };
            dep0.Programs.Add(overk);
            var dep1 = new EhbEvo.Models.Department() { DepartmentName = "Design & Technologie" };
            dep1.Programs.Add(overk);
            dep1.Programs.Add(itw1);
            dep1.Programs.Add(itw2);
            dep1.Programs.Add(itw3);
            dep1.Programs.Add(itw4);
            dep1.Programs.Add(itw5);
            dep1.Programs.Add(itw6);
            dep1.Programs.Add(itw7);
            dep1.Programs.Add(itw8);
            var dep2 = new EhbEvo.Models.Department() { DepartmentName = "Gezondheidszorg & Landschapsarchitectuur" };
            dep2.Programs.Add(overk);
            dep2.Programs.Add(gvl1);
            dep2.Programs.Add(gvl2);
            dep2.Programs.Add(gvl3);
            dep2.Programs.Add(gvl4);
            dep2.Programs.Add(gvl5);
            dep2.Programs.Add(gvl6);
            dep2.Programs.Add(gvl7);
            dep2.Programs.Add(gvl8);
            dep2.Programs.Add(gvl9);
            dep2.Programs.Add(gvl10);
            dep2.Programs.Add(gvl11);
            dep2.Programs.Add(gvl12);
            dep2.Programs.Add(gvl13);
            dep2.Programs.Add(gvl14);
            dep2.Programs.Add(gvl15);
            dep2.Programs.Add(gvl16);
            dep2.Programs.Add(gvl17);
            dep2.Programs.Add(gvl18);
            dep2.Programs.Add(gvl19);
            dep2.Programs.Add(gvl20);
            dep2.Programs.Add(gvl21);
            dep2.Programs.Add(gvl22);
            dep2.Programs.Add(gvl23);
            dep2.Programs.Add(gvl24);
            dep2.Programs.Add(gvl25);
            dep2.Programs.Add(net1);
            var dep3 = new EhbEvo.Models.Department() { DepartmentName = "Management, Media & Maatschappij" };
            dep3.Programs.Add(overk);
            dep3.Programs.Add(cmt1);
            dep3.Programs.Add(cmt2);
            dep3.Programs.Add(cmt3);
            dep3.Programs.Add(cmt4);
            dep3.Programs.Add(met1);
            dep3.Programs.Add(met2);
            dep3.Programs.Add(met3);
            dep3.Programs.Add(met4);
            dep3.Programs.Add(met5);
            dep3.Programs.Add(met6);
            dep3.Programs.Add(met7);
            dep3.Programs.Add(met8);
            dep3.Programs.Add(met9);
            dep3.Programs.Add(met10);
            dep3.Programs.Add(met11);
            dep3.Programs.Add(mem1);
            dep3.Programs.Add(mem2);
            dep3.Programs.Add(mem3);
            dep3.Programs.Add(mem4);
            dep3.Programs.Add(mem5);
            var dep4 = new EhbEvo.Models.Department() { DepartmentName = "Onderwijs & Pedagogie" };
            dep4.Programs.Add(overk);
            dep4.Programs.Add(oep1);
            dep4.Programs.Add(oep2);
            dep4.Programs.Add(oep3);
            dep4.Programs.Add(oep4);
            dep4.Programs.Add(oep5);
            dep4.Programs.Add(oep6);
            dep4.Programs.Add(oep7);
            dep4.Programs.Add(oep8);
            dep4.Programs.Add(oep9);
            dep4.Programs.Add(oep10);
            dep4.Programs.Add(oep11);
            dep4.Programs.Add(oep12);
            dep4.Programs.Add(oep13);
            dep4.Programs.Add(oep14);
            dep4.Programs.Add(oep15);
            dep4.Programs.Add(oep16);
            dep4.Programs.Add(oep17);
            dep4.Programs.Add(oep18);
            dep4.Programs.Add(oep19);
            dep4.Programs.Add(oep20);
            var dep5 = new EhbEvo.Models.Department() { DepartmentName = "Koninklijk Conservatorium Brussel" };
            dep5.Programs.Add(overk);
            dep5.Programs.Add(kcb1);
            dep5.Programs.Add(kcb2);
            dep5.Programs.Add(kcb3);
            dep5.Programs.Add(kcb4);
            var dep6 = new EhbEvo.Models.Department() { DepartmentName = "Royal Institute for Theatre, Cinema and Sound (RITCS)" };
            dep6.Programs.Add(overk);
            dep6.Programs.Add(ritcs1);
            dep6.Programs.Add(ritcs2);
            //ADD Departments to context
            context.Departments.Add(dep0);
            context.Departments.Add(dep1);
            context.Departments.Add(dep2);
            context.Departments.Add(dep3);
            context.Departments.Add(dep4);
            context.Departments.Add(dep5);
            context.Departments.Add(dep6);
            context.SaveChanges();
            //adminaccount aanmaken
            //RegisterViewModel admin = new RegisterViewModel() {FirstName="System", LastName="Administrator", Email="admin@gmail.com", Name="Administrator", Password="adminpass", ConfirmPassword="adminpass", Department=dep1, DepartmentId=dep1.DepartmentId };

            //rollen toevoegen
            var adminrole = new IdentityRole() { Name = "Admin" };
            var docentrole = new IdentityRole() { Name = "Docent" };
            var personeelrole = new IdentityRole() { Name = "Personeel" };
            var opleidingshoofdrole = new IdentityRole() { Name = "Opleidingshoofd" };
            var opleidingsmedewerkerrole = new IdentityRole() { Name = "Opleidingsmedewerker" };
            context.Roles.Add(adminrole);
            context.Roles.Add(docentrole);
            context.Roles.Add(personeelrole);
            context.Roles.Add(opleidingshoofdrole);
            context.Roles.Add(opleidingsmedewerkerrole);
            //Register admin
            //Register(admin, context, adminrole, dep1);


            base.Seed(context);
            */
        }
    }
}
