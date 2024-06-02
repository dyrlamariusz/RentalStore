using Microsoft.AspNetCore.Mvc;
using RentalStore.Application.Dto;
using RentalStore.Application.Services;
using RentalStore.Domain.Models;

namespace RentalStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rental>> GetAll()
        {
            var rentals = _rentalService.GetAll();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public ActionResult<Rental> Get(int id)
        {
            var rental = _rentalService.Get(id);
            if (rental == null)
            {
                return NotFound();
            }
            return Ok(rental);
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] CreateRentalDto rentalDto)
        {
            if (rentalDto == null)
            {
                return BadRequest("Rental data is null");
            }

            var rentalId = _rentalService.Create(rentalDto);
            return CreatedAtAction(nameof(Get), new { id = rentalId }, rentalId);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Rental rental)
        {
            if (id != rental.RentalId)
            {
                return BadRequest("ID mismatch");
            }

            _rentalService.Update(rental);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rental = _rentalService.Get(id);
            if (rental == null)
            {
                return NotFound();
            }

            _rentalService.Delete(rental);
            return NoContent();
        }

        [HttpGet("active")]
        public ActionResult<IEnumerable<Rental>> GetActiveRentals()
        {
            var activeRentals = _rentalService.GetActiveRentals();
            return Ok(activeRentals);
        }

        [HttpGet("agreement/{agreementId}")]
        public ActionResult<IEnumerable<Rental>> GetRentalsByAgreementId(int agreementId)
        {
            var rentals = _rentalService.GetRentalsByAgreementId(agreementId);
            return Ok(rentals);
        }
    }
}
