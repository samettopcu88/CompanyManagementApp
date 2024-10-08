using CompanyManagementApp.API.DTOs;
using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace CompanyManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Notification/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var notification = await _unitOfWork.Notifications.GetByIdAsync(id);
            if (notification == null)
                return NotFound();

            var notificationDTO = _mapper.Map<NotificationDTO>(notification);
            return Ok(notificationDTO);
        }

        // GET: api/Notification
        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await _unitOfWork.Notifications.GetAllAsync();
            var notificationDTOs = _mapper.Map<IEnumerable<NotificationDTO>>(notifications);
            return Ok(notificationDTOs);
        }

        // POST: api/Notification
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationDTO notificationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var notification = _mapper.Map<Notification>(notificationDTO);
            await _unitOfWork.Notifications.AddAsync(notification);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNotificationById), new { id = notification.NotificationId }, notificationDTO);
        }

        // PUT: api/Notification/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, [FromBody] NotificationDTO notificationDTO)
        {
            if (id != notificationDTO.NotificationId)
                return BadRequest();

            var notification = await _unitOfWork.Notifications.GetByIdAsync(id);
            if (notification == null)
                return NotFound();

            _mapper.Map(notificationDTO, notification);
            await _unitOfWork.Notifications.UpdateAsync(notification);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Notification/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var notification = await _unitOfWork.Notifications.GetByIdAsync(id);
            if (notification == null)
                return NotFound();

            await _unitOfWork.Notifications.DeleteAsync(notification);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
