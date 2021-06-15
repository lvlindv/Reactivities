using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    // "controller" is a placeholder that gets replaced with wathever 
    //the controllname class name is - the word controller. 
    [Route("api/[controller]")]    
    public class BaseApiController : ControllerBase
    {
        
    }
}