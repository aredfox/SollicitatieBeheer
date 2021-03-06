﻿using Beheerdersportaal.Model.Afdelingen;
using Beheerdersportaal.Model.Functies;
using Beheerdersportaal.Model.Gedeeld;
using Beheerdersportaal.Model.Vacatures;
using System.Collections.Generic;
using System.Linq;

namespace Sollicitatiebeheer.Data.EFCore.Migrations
{
    internal class SeedScript
    {
        private SollicitatiebeheerDatabase _database;

        public SeedScript(SollicitatiebeheerDatabase database)
        {
            _database = database;
        }

        public void Start()
        {
            SeedAfdelingen();
            SeedFuncties();
            SeedVacatures();
        }

        private void Seed<T>(params T[] entiteiten) where T : class, IEntiteit
            => Seed(entiteiten.ToList());
        private void Seed<T>(List<T> entiteiten) where T : class, IEntiteit
        {
            if (entiteiten == null && entiteiten.Any())
                return;

            if (_database.Set<T>().Any())
                return;
            
            _database.AddRange(entiteiten);
            _database.SaveChanges();            
        }

        private void SeedAfdelingen()
        {            
            Seed
            (                
                new Afdeling { Naam = "OOOC Potgieter" },
                new Afdeling { Naam = "OOOC Jacob Jordaens" },
                new Afdeling { Naam = "OOOC Harmonie" },
                new Afdeling { Naam = "Den Dam" },
                new Afdeling { Naam = "Personeelsdienst" },
                new Afdeling { Naam = "Administratie" },
                new Afdeling { Naam = "Boekhouding" },
                new Afdeling { Naam = "Technische dienst" }
            );            
        }

        private void SeedFuncties()
        {
            Seed
            (
                new Functie { Naam = "Begeleider" },
                new Functie { Naam = "Nachtbegeleider" },
                new Functie { Naam = "Maatschappelijk assistent" },
                new Functie { Naam = "Ombudsman/vrouw" },
                new Functie { Naam = "Administratief medewerker" },
                new Functie { Naam = "Poetshulp" },
                new Functie { Naam = "Klusjesman" }
            );            
        }

        private void SeedVacatures()
        {
            Seed
            (
                new Vacature {
                    Nummer = 56120663,
                    Functie = _database.Functies.Where(x => x.Naam == "Begeleider").Single(),
                    Afdeling = _database.Afdelingen.Where(x => x.Naam == "OOOC Potgieter").Single(),
                    Omschrijving = @"Voor OOOC Potgieter zoeken we een voltijds begeleider. Binnen OOOC Potgieter worden jongens en meisjes opgevangen van 14 tot 17 jaar met voornamelijk gedrags-en gezagsproblemen."
                },
                new Vacature {
                    Nummer = 56241022,
                    Functie = _database.Functies.Where(x => x.Naam == "Administratief medewerker").Single(),
                    Afdeling = _database.Afdelingen.Where(x => x.Naam == "Administratie").Single(),
                    Omschrijving = @"We zijn op zoek naar een tijdelijke medewerker ter ondersteuning van de administratieve diensten en onthaal binnen onze sector jeugdhulp. Je bent verantwoordelijk voor de verzameling, verwerking en rapportering van gegevens, opmaak van documenten, archivering, telefonisch onthaal, correcte doorverwijzing van kliënten, enz."
                },
                new Vacature {
                    Nummer = 56015976,
                    Functie = _database.Functies.Where(x => x.Naam == "Nachtbegeleider").Single(),
                    Afdeling = _database.Afdelingen.Where(x => x.Naam == "OOOC Potgieter").Single(),
                    Omschrijving = @"Je staat in voor de begeleiding van minderjarigen in onze orthopedagogische residentie volgens een volcontinu systeem."
                },
                new Vacature {
                    Nummer = 55775903,
                    Functie = _database.Functies.Where(x => x.Naam == "Maatschappelijk assistent").Single(),
                    Afdeling = _database.Afdelingen.Where(x => x.Naam == "OOOC Harmonie").Single(),
                    Omschrijving = @"Binnen de voorziening heb je een verantwoordelijke functie op vlak van administratie, dossierkennis, -opbouw en –beheer. Je bent ook verantwoordelijk voor de opbouw van contacten tussen de jongere en zijn gezin binnen de residentiele dossiers."
                }
            );            
        }        
    }
}
