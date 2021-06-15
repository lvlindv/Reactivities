using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {        
        // Gets acess of datacontext inside ActivitiesController
        private readonly DataContext _context;
        // inject datacontext into the controller so we can query our database directly
        // and return the activities to the client
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }

        // Endpoint
        [HttpGet]
        // ActionResult takes a type parameter and returns a List of our activities.
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            // return our activities DbSet and get a List of this
            return await _context.Activities.ToListAsync();
        }

        // To select an individually activity
        // Pass in a root-parameter
        [HttpGet("{id}")] // activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }

    }
}