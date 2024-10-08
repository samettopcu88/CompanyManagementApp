using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CompanyManagementApp.API.DTOs;
using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeaveRequestController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/leaverequest
        [HttpGet]
        public async Task<IActionResult> GetLeaveRequests()
        {
            var leaveRequests = await _unitOfWork.LeaveRequests.GetAllAsync();
            var leaveRequestDTOs = _mapper.Map<IEnumerable<LeaveRequestDTO>>(leaveRequests);
            return Ok(leaveRequestDTOs);
        }

        // GET: api/leaverequest/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveRequest(int id)
        {
            var leaveRequest = await _unitOfWork.LeaveRequests.GetByIdAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            var leaveRequestDTO = _mapper.Map<LeaveRequestDTO>(leaveRequest);
            return Ok(leaveRequestDTO);
        }

        // POST: api/leaverequest
        [HttpPost]
        public async Task<IActionResult> CreateLeaveRequest([FromBody] LeaveRequestDTO leaveRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestDTO);
            await _unitOfWork.LeaveRequests.AddAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLeaveRequest), new { id = leaveRequest.LeaveRequestId }, leaveRequestDTO);
        }

        // PUT: api/leaverequest/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaveRequest(int id, [FromBody] LeaveRequestDTO leaveRequestDTO)
        {
            if (id != leaveRequestDTO.LeaveRequestId)
            {
                return BadRequest("ID mismatch");
            }

            var leaveRequest = await _unitOfWork.LeaveRequests.GetByIdAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            _mapper.Map(leaveRequestDTO, leaveRequest);
            _unitOfWork.LeaveRequests.UpdateAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/leaverequest/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            var leaveRequest = await _unitOfWork.LeaveRequests.GetByIdAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            await _unitOfWork.LeaveRequests.DeleteAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
