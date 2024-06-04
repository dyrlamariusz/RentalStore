﻿using Microsoft.AspNetCore.Mvc;
using RentalStore.Application.Services;
using RentalStore.Domain.Exceptions;
using RentalStore.SharedKernel.Dto;

namespace RentalStore.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ILogger<EquipmentController> _logger;

        public EquipmentController(IEquipmentService equipmentService, ILogger<EquipmentController> logger)
        {
            this._equipmentService = equipmentService;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EquipmentDto>> Get()
        {
            var result = _equipmentService.GetAll();
            _logger.LogDebug("Pobrano listę wszystkich sprzętów");
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetEquipment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EquipmentDto> Get(int id)
        {
            /*var result = _equipmentService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            _logger.LogDebug($"Pobrano sprzęt o id = {id}");
            return Ok(result);*/
            try
            {
                var result = _equipmentService.GetById(id);
                _logger.LogDebug($"Pobrano sprzęt o id = {id}");
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateEquipmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _equipmentService.Create(dto);
            _logger.LogDebug($"Utworzono nowy sprzęt z id = {id}");
            var actionName = nameof(Get);
            var routeValues = new { id };
            return CreatedAtAction(actionName, routeValues, null);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                _equipmentService.Delete(id);
                _logger.LogDebug($"Usunięto sprzęt z id = {id}");
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Błąd podczas usuwania sprzętu");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] UpdateEquipmentDto dto)
        {
            try
            {
                _equipmentService.Update(id, dto);
                _logger.LogDebug($"Zaktualizowano sprzęt z id = {id}");
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Błąd podczas aktualizacji sprzętu");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
