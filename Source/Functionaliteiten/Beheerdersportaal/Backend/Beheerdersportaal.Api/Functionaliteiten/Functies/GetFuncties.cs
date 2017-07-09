using Beheerdersportaal.Api.Infrastructuur.Handlers;
using MediatR;
using Sollicitatiebeheer.Data.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace Beheerdersportaal.Api.Functionaliteiten.Functies
{
    public class GetFuncties
    {
        public class Handler : DbRequestHandler<SollicitatiebeheerDatabase, Request, Response>
        {
            public Handler(SollicitatiebeheerDatabase database) 
                : base(database) { }            

            public override Response Handle(Request message)
            {
                var functies = _db.Functies                    
                    .ToList();

                if (functies.Count == 0)
                    return null;

                return new Response
                {
                    Functies = functies.Select(functie => new Functie
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
            public List<Functie> Functies { get; set; }
        }
    }
}
