using Beheerdersportaal.Model.Afdelingen;
using Beheerdersportaal.Model.Functies;
using Beheerdersportaal.Model.Vacatures;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Beheerdersportaal.Api.Functionaliteiten.Vacatures
{
    public class LijstVacaturesOp
    {
        public class Handler : IRequestHandler<Request, Response>
        {
            public Response Handle(Request message)
            {
                var vacatures = new List<Model.Vacatures.Vacature> {
                        new Model.Vacatures.Vacature
                        {
                            Nummer = 56120663,
                            Functie = new Functie { Naam = "Begeleider" },
                            Afdeling = new Afdeling { Naam = "OOOC Potgieter" },
                            Omschrijving = @"Voor OOOC Potgieter zoeken we een voltijds begeleider. Binnen OOOC Potgieter worden jongens en meisjes opgevangen van 14 tot 17 jaar met voornamelijk gedrags-en gezagsproblemen."
                        },
                        new Model.Vacatures.Vacature
                        {
                            Nummer = 56241022,
                            Functie = new Functie { Naam = "Administratief medewerker" },
                            Afdeling = new Afdeling { Naam = "Administratie" },
                            Omschrijving = @"We zijn op zoek naar een tijdelijke medewerker ter ondersteuning van de administratieve diensten en onthaal binnen onze sector jeugdhulp. Je bent verantwoordelijk voor de verzameling, verwerking en rapportering van gegevens, opmaak van documenten, archivering, telefonisch onthaal, correcte doorverwijzing van kliënten, enz."
                        }
                    };                

                return new Response
                {
                    Vacatures = vacatures.Select(vacature => new Vacature
                    {
                        Nummer = vacature.Nummer,
                        Functie = vacature.Functie.Naam,
                        Afdeling = vacature.Afdeling.Naam,
                        Omschrijving = vacature.Omschrijving
                    }).ToList()
                };
            }
        }
        public class Request : IRequest<Response> { }
        public class Response {
            public List<Vacature> Vacatures { get; set; }
        }
    }
}
