using Beheerdersportaal.Api.Infrastructuur.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sollicitatiebeheer.Data.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beheerdersportaal.Api.Functionaliteiten.Vacatures
{
    public class GetVacatures
    {
        public class Handler : DbRequestHandler<SollicitatiebeheerDatabase, Request, Response>
        {
            public Handler(SollicitatiebeheerDatabase database)
                : base(database) { }

            public override Response Handle(Request message)
            {                
                var afdelingFilter = message.Afdeling ?? -1;
                var functieFilter = message.Functie ?? -1;

                var vacatures = _db.Vacatures
                    .Include(x => x.Functie)
                    .Include(x => x.Afdeling)                    
                    .Where(x =>                                            
                            (afdelingFilter != -1 ? x.AfdelingId == afdelingFilter : true)
                         && (functieFilter != -1 ? x.FunctieId == functieFilter : true)
                    )
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
        public class Request : IRequest<Response>
        {
            public int? Afdeling { get; set; }
            public int? Functie { get; set; }
        }
        public class Response {
            public List<Vacature> Vacatures { get; set; }
        }
    }
}
