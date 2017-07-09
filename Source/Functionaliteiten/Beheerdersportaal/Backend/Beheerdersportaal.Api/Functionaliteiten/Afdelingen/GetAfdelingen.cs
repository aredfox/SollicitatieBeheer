﻿using Beheerdersportaal.Api.Infrastructuur.Handlers;
using MediatR;
using Sollicitatiebeheer.Data.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace Beheerdersportaal.Api.Functionaliteiten.Afdelingen
{
    public class GetAfdelingen
    {
        public class Handler : DbRequestHandler<SollicitatiebeheerDatabase, Request, Response>
        {            
            public Handler(SollicitatiebeheerDatabase database)
                : base(database) { }

            public override Response Handle(Request message)
            {
                var afdelingen = _db.Afdelingen                    
                    .ToList();

                return new Response
                {
                    Afdelingen = afdelingen.Select(functie => new Afdeling
                    {
                        Id = functie.Id,
                        Naam = functie.Naam,
                    }).ToList()
                };
            }
        }
        public class Request : IRequest<Response> { }
        public class Response
        {
            public List<Afdeling> Afdelingen { get; set; }
        }
    }
}
