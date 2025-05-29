using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services
{

    // Primary constructor defined in C# 12 so that we can directly assign the parameters to the private fields.
    // From the class definiton.
    public class LeaveTypesService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypesService
    {


        public async Task<List<LeaveTypeReadOnlyVM>> GetAllAsync()
        {
            // Converting db records into C# objects and returning them to the view.
            var data = await _context.LeaveTypes.ToListAsync();

            // Convert data model to view model using AutoMapper.
            var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

            return viewData;
        }

        public async Task<T?> Get<T>(int id) where T : class
        {
            // Get the leave type by id from the database.
            // Parameterizaiton helps to prevent SQL injection attacks.
            var data = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                return null;
            }

            var viewData = _mapper.Map<T>(data);

            return viewData;
        }

        public async Task Remove(int id)
        {
            // Get the leave type by id from the database.
            var data = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);

            // Remove data and save the changes to the database.
            if (data != null)
            {
                _context.LeaveTypes.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Create(LeaveTypeCreateVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Add(leaveType);
            await _context.SaveChangesAsync();

        }
        public async Task Edit(LeaveTypeEditVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();
        }

        public bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }

        public async Task<bool> CheckIfLeaveTypeExists(string name)
        {
            var lowerCaseName = name.ToLower();
            return await _context.LeaveTypes.AnyAsync(q => q.Name.Equals(lowerCaseName));
        }

        public async Task<bool> CheckIfLeaveTypeExistsForEdits(LeaveTypeEditVM leaveTypeEdit)
        {
            var lowerCaseName = leaveTypeEdit.Name.ToLower();
            return await _context.LeaveTypes.AnyAsync(q => q.Name.Equals(lowerCaseName) && q.Id != leaveTypeEdit.Id);
        }

    }
}
