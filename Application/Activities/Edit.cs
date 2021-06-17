using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        // Creating neasted classes inside Edit, detalis and List
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);
                // if request.Activity.Title is nulll
                // then set it to Activity.Title
                //activity.Title = request.Activity.Title ?? activity.Title;
                // Istället för att dätta varje property manuellt som raden kod ovan, så kan vi göra som koden under.
                //_mapper.Map vill effektivt uppdatera våra properties inuti våra object. 
                // tar bort mycket av den mapping-koden som vi annars skulle behövt skriva by hand. sparar oss typing. 
                _mapper.Map(request.Activity, activity);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}