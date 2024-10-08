using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CompanyManagementApp.API.DTOs;
using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppRoleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/approle
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = _unitOfWork.RoleManager.Roles.ToList(); // RoleManager kullanılıyor
            var roleDTOs = _mapper.Map<IEnumerable<AppRoleDTO>>(roles);
            return Ok(roleDTOs);
        }

        // GET: api/approle/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(string id)
        {
            var role = await _unitOfWork.RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var roleDTO = _mapper.Map<AppRoleDTO>(role);
            return Ok(roleDTO);
        }

        // POST: api/approle
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] AppRoleDTO appRoleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = _mapper.Map<AppRole>(appRoleDTO);
            var result = await _unitOfWork.RoleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, appRoleDTO);
        }

        // PUT: api/approle/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] AppRoleDTO appRoleDTO)
        {
            if (id != appRoleDTO.Id)
            {
                return BadRequest("ID mismatch");
            }

            var role = await _unitOfWork.RoleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return NotFound();
            }

            _mapper.Map(appRoleDTO, role);
            var result = await _unitOfWork.RoleManager.UpdateAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

        // DELETE: api/approle/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _unitOfWork.RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var result = await _unitOfWork.RoleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }
    }
}
