using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorsController : ControllerBase
    {
        private readonly IAdministratorRepository _administratorRepository;

        public AdministratorsController(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdministrators()
        {
            try
            {
                var administrators = await _administratorRepository.GetAll();
                return Ok(administrators);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdministratorById(int id)
        {
            try
            {
                var administrator = await _administratorRepository.GetById(id);

                if (administrator == null)
                {
                    return NotFound();
                }

                return Ok(administrator);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdministrator([FromBody] Administrator administrator)
        {
            try
            {
                var administratorId = await _administratorRepository.Add(administrator);
                return CreatedAtAction(nameof(GetAdministratorById), new { id = administratorId }, administrator);
            }
            catch (Exception ex)
            {
                // Handle exceptions or errors appropriately
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrator(int id)
        {
            try
            {
                var deleted = await _administratorRepository.Delete(id);

                if (!deleted)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
