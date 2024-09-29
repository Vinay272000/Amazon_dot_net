using AmazonClone.Models;
using AmazonClone.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmazonClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : Controller
    {
        public IStatesService _StateService;
        public StatesController(IStatesService statesService) { _StateService = statesService; }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<States> states = await _StateService.GetStates();
            return states.Any() ? Ok(states) : BadRequest();
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            States state = await _StateService.GetStateById(id);
            return state != null ? Ok(state) : BadRequest();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post(States state)
        {
            bool isCreated = await _StateService.Create(state);
            return isCreated ? Ok() : BadRequest();
        }

        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(States state)
        {
            bool isDeleted = await _StateService.DeleteState(state);
            return isDeleted ? Ok() : BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(States state)
        {
            bool isUpdated = await _StateService.UpdateState(state);
            return isUpdated ? Ok() : BadRequest();
        }
    }
}
