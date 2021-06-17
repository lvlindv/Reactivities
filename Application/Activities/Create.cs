using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    // Query does ruturn data, command does not.
    public class Create
    {
        public class command : IRequest
        {
            // This is what we want to recieve as a parameter from our API
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<command>
        {
            // create a constructor so we can inject our datacontext here 
            // and persist our changes
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            // Our request holds an activity object 
            public async Task<Unit> Handle(command request, CancellationToken cancellationToken)
            {
                // adding the activity in memory, we are not toutching the database.
                // therfore we do not need to use the asyns version of this. add.
                // Entity framework are tracking that we are adding an activity to our activities inside our context in our memory.

                _context.Activities.Add(request.Activity);


                await _context.SaveChangesAsync();

                // does not return anything. Just letting our API controller know that we are finishing 
                // whats going on above.
                return Unit.Value;
            }
        }
    }
}