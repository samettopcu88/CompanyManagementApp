using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CompanyManagementApp.API.DTOs;
using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseRequestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseRequestController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/expenserequest
        [HttpGet]
        public async Task<IActionResult> GetExpenseRequests()
        {
            var expenseRequests = await _unitOfWork.ExpenseRequests.GetAllAsync();
            var expenseRequestDTOs = _mapper.Map<IEnumerable<ExpenseRequestDTO>>(expenseRequests);
            return Ok(expenseRequestDTOs);
        }

        // GET: api/expenserequest/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseRequest(int id)
        {
            var expenseRequest = await _unitOfWork.ExpenseRequests.GetByIdAsync(id);
            if (expenseRequest == null)
            {
                return NotFound();
            }
            var expenseRequestDTO = _mapper.Map<ExpenseRequestDTO>(expenseRequest);
            return Ok(expenseRequestDTO);
        }

        // POST: api/expenserequest
        [HttpPost]
        public async Task<IActionResult> CreateExpenseRequest([FromBody] ExpenseRequestDTO expenseRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expenseRequest = _mapper.Map<ExpenseRequest>(expenseRequestDTO);
            await _unitOfWork.ExpenseRequests.AddAsync(expenseRequest);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpenseRequest), new { id = expenseRequest.ExpenseRequestId }, expenseRequestDTO);
        }

        // PUT: api/expenserequest/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpenseRequest(int id, [FromBody] ExpenseRequestDTO expenseRequestDTO)
        {
            if (id != expenseRequestDTO.ExpenseRequestId)
            {
                return BadRequest("ID mismatch");
            }

            var expenseRequest = await _unitOfWork.ExpenseRequests.GetByIdAsync(id);
            if (expenseRequest == null)
            {
                return NotFound();
            }

            _mapper.Map(expenseRequestDTO, expenseRequest);
            _unitOfWork.ExpenseRequests.UpdateAsync(expenseRequest);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/expenserequest/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseRequest(int id)
        {
            var expenseRequest = await _unitOfWork.ExpenseRequests.GetByIdAsync(id);
            if (expenseRequest == null)
            {
                return NotFound();
            }

            await _unitOfWork.ExpenseRequests.DeleteAsync(expenseRequest);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
