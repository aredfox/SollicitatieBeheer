using Beheerdersportaal.Api.Infrastructuur.Handlers;
using MediatR;
using Sollicitatiebeheer.Data.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace Beheerdersportaal.Api.Functionaliteiten.Afdelingen
{    
        public class Handler : DbRequestHandler<SollicitatiebeheerDatabase, GetAfdelingenRequest, GetAfdelingenResponse>
        {            
            public Handler(SollicitatiebeheerDatabase database)
                : base(database) { }

            public override GetAfdelingenResponse Handle(GetAfdelingenRequest message)
            {
                var afdelingen = _db.Afdelingen                    
                    .ToList();

                if (afdelingen.Count == 0)
                    return null;

                return new GetAfdelingenResponse
                {
                    Afdelingen = afdelingen.Select(functie => new Afdeling
                    {
                        Id = functie.Id,
                        Naam = functie.Naam,
                    }).ToList()
                };
            }
        }
        public class GetAfdelingenRequest : BaseRequest<GetAfdelingenResponse> { }
        public class GetAfdelingenResponse : BaseResponse
        {
            public List<Afdeling> Afdelingen { get; set; }
        }    
}
