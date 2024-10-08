using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CompanyManagementApp.API.DTOs;
using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppUserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/appuser
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _unitOfWork.UserManager.Users.ToListAsync();
            var userDTOs = _mapper.Map<IEnumerable<AppUserDTO>>(users);
            return Ok(userDTOs);
        }

        // GET: api/appuser/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _unitOfWork.UserManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var userDTO = _mapper.Map<AppUserDTO>(user);
            return Ok(userDTO);
        }

        // POST: api/appuser
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AppUserDTO appUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<AppUser>(appUserDTO);
            var result = await _unitOfWork.UserManager.CreateAsync(user, appUserDTO.Password); // Şifreyle oluşturma
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/appuser/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] AppUserDTO appUserDTO)
        {
            if (id != appUserDTO.Id)
            {
                return BadRequest("ID mismatch");
            }

            var user = await _unitOfWork.UserManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            _mapper.Map(appUserDTO, user);
            var result = await _unitOfWork.UserManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

        // DELETE: api/appuser/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _unitOfWork.UserManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            var result = await _unitOfWork.UserManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }
}
