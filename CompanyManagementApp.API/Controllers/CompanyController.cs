using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CompanyManagementApp.API.DTOs;
using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/company
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync();
            var companyDTOs = _mapper.Map<IEnumerable<CompanyDTO>>(companies);
            return Ok(companyDTOs);
        }

        // GET: api/company/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            var companyDTO = _mapper.Map<CompanyDTO>(company);
            return Ok(companyDTO);
        }

        // POST: api/company
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDTO companyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = _mapper.Map<Company>(companyDTO);
            await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompany), new { id = company.CompanyId }, companyDTO);
        }

        // PUT: api/company/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyDTO companyDTO)
        {
            if (id != companyDTO.CompanyId)
            {
                return BadRequest("ID mismatch");
            }

            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _mapper.Map(companyDTO, company);
            _unitOfWork.Companies.UpdateAsync(company);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/company/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            await _unitOfWork.Companies.DeleteAsync(company);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
