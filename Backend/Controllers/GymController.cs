// namespace GYMIND.API.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class GymController : ControllerBase
//     {
//         private readonly IGymService _gymService;

//         public GymController(IGymService gymService)
//         {
//             _gymService = gymService;
//         }

//         // Endpoint to get all gyms
//         [HttpGet]
//         public async Task<IActionResult> GetAllGyms()
//         {
//             var gyms = await _gymService.GetAllGymsAsync();
//             return Ok(gyms);
//         }

//         // Endpoint to get a gym by ID
//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetGymById(Guid id)
//         {
//             var gym = await _gymService.GetGymByIdAsync(id);
//             if (gym == null)
//                 return NotFound();

//             return Ok(gym);
//         }

//         // Endpoint to create a new gym
//         [HttpPost]
//         public async Task<IActionResult> CreateGym([FromBody] CreateGymRequest request)
//         {
//             var createdGym = await _gymService.CreateGymAsync(request);
//             return CreatedAtAction(nameof(GetGymById), new { id = createdGym.GymId }, createdGym);
//         }
//     }
// }