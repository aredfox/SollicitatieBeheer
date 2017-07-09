using MediatR;
using Sollicitatiebeheer.Data.EFCore;
using System.Linq;

namespace Beheerdersportaal.Api.Functionaliteiten.Vacatures
{
    public class WijzigVacature
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
                if(message.Vacature != null)
                {
                    var vacature = _db.Vacatures.SingleOrDefault(v => v.Id == message.Vacature.Id);
                    if (vacature != null) {
                        vacature.Omschrijving = message.Vacature.Omschrijving;
                        _db.Update(vacature);
                    }
                }
                
                _db.SaveChanges();

                return new Response();
            }
        }
        public class Request : IRequest<Response> {
            public Vacature Vacature { get; set; }
        }
        public class Response { }        
    }
}
