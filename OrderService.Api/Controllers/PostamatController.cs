using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderService.Application.Repositories;
using OrderService.Models;

namespace OrderService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostamatController : ControllerBase
    {
        private readonly IPostamatRepository _postamatRepository;
        private readonly ILogger<PostamatController> _logger;

        public PostamatController(IPostamatRepository postamatRepository, ILogger<PostamatController> logger)
        {
            _postamatRepository = postamatRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("{postamatId}")]
        public ActionResult<Postamat> Get(int postamatId)
        {
            var postamat = _postamatRepository.GetOrDefault(postamatId);
            if (postamat == null)
            {
                return NotFound();
            }

            return postamat;
        }
    }
}
