using System.Threading.Tasks;
using ApplicantTracking.Application.Commands;
using ApplicantTracking.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApplicantTracking.Api.Controllers
{
    [ApiController]
    [Route("candidates")]
    public sealed class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var candidates = await _mediator.Send(new GetCandidatesQuery());
            return Ok(candidates);
        }

        [HttpGet("{idCandidate:int}")]
        public async Task<IActionResult> Get([FromRoute] int idCandidate)
        {
            var candidate = await _mediator.Send(new GetCandidateByIdQuery(idCandidate));
            return candidate != null ? Ok(candidate) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCandidateCommand command)
        {
            var candidate = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { idCandidate = candidate.IdCandidate }, candidate);
        }

        [HttpPut("{idCandidate:int}")]
        public async Task<IActionResult> Edit([FromRoute] int idCandidate, [FromBody] UpdateCandidateCommand command)
        {
            if (idCandidate != command.IdCandidate)
                return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{idCandidate:int}")]
        public async Task<IActionResult> Delete([FromRoute] int idCandidate)
        {
            await _mediator.Send(new DeleteCandidateCommand(idCandidate));
            return NoContent();
        }
    }
}
