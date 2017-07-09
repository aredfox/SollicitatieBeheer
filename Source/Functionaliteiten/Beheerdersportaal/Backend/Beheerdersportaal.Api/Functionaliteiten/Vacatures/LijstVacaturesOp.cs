using MediatR;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Data.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace Beheerdersportaal.Api.Functionaliteiten.Vacatures
{
    public class LijstVacaturesOp
    {
        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly SollicitatiebeheerDatabase _db;

            public Handler(SollicitatiebeheerDatabase sollicitatiebeheerDatabase)
            {                
                _db = sollicitatiebeheerDatabase;                
            }

            public Response Handle(Request message)
            {
                var vacatures = _db.Vacatures
                    .Include(x => x.Functie)
                    .Include(x => x.Afdeling)
                    .ToList();                

                return new Response
                {
                    Vacatures = vacatures.Select(vacature => new Vacature
                    {
                        Id = vacature.Id,
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
