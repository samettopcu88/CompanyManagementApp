using CompanyManagementApp.API.DTOs;
using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace CompanyManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResumeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResumeById(int id)
        {
            var resume = await _unitOfWork.Resumes.GetByIdAsync(id);
            if (resume == null)
                return NotFound();

            var resumeDTO = _mapper.Map<ResumeDTO>(resume);
            return Ok(resumeDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResumes()
        {
            var resumes = await _unitOfWork.Resumes.GetAllAsync();
            var resumeDTOs = _mapper.Map<IEnumerable<ResumeDTO>>(resumes);
            return Ok(resumeDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResume([FromBody] ResumeDTO resumeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resume = _mapper.Map<Resume>(resumeDTO);
            await _unitOfWork.Resumes.AddAsync(resume);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResumeById), new { id = resume.ResumeId }, resumeDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResume(int id, [FromBody] ResumeDTO resumeDTO)
        {
            if (id != resumeDTO.ResumeId)
                return BadRequest();

            var resume = await _unitOfWork.Resumes.GetByIdAsync(id);
            if (resume == null)
                return NotFound();

            _mapper.Map(resumeDTO, resume);
            await _unitOfWork.Resumes.UpdateAsync(resume);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResume(int id)
        {
            var resume = await _unitOfWork.Resumes.GetByIdAsync(id);
            if (resume == null)
                return NotFound();

            await _unitOfWork.Resumes.DeleteAsync(resume);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
