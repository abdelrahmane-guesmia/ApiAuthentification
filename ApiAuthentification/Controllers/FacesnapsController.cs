using ApiAuthentification.Services;
using ApiAuthentification.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiAuthentification.Auth;

namespace ApiAuthentification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacesnapsController : ControllerBase
    {
        private IFacesnapService _facesnapService;

        public FacesnapsController(IFacesnapService facesnapService)
        {
            _facesnapService = facesnapService;
        }
        // GET: api/<FacesnapsController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Facesnap>), 200)]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<Facesnap>> Get()
        {
            var items = _facesnapService.GetFacesnaps();
            return items;
        }

        // GET api/<FacesnapsController>/id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Facesnap), 200)]
        [ProducesResponseType(404)]
        public ActionResult<Facesnap> Get(Guid id)
        {
            var item = _facesnapService.GetSingleFacesnap(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/<FacesnapsController>
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [ProducesResponseType(201)]
        public IActionResult Create([FromBody] Facesnap facesnap)
        {
            if (ModelState.IsValid)
            {
                facesnap.id = Guid.NewGuid();
                _facesnapService.AddFacesnap(facesnap);
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/<FacesnapsController>/id
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Edit([FromBody] Facesnap facesnap)
        {
            if (ModelState.IsValid)
            {
                _facesnapService.UpdateFacesnap(facesnap);
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<FacesnapsController>/id
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Delete(Guid id)
        {
            var data = _facesnapService.GetSingleFacesnap(id);
            if (data == null)
            {
                return NotFound();
            }
            _facesnapService.DeleteFacesnap(id);
            return NoContent();
        }
    }
}
