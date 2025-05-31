using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using LeaveManagementSystem.Web.Services;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController(ILeaveTypesService _leaveTypesService) : Controller
    {
        
        private const string NameExistsValidationMessage = "This leave type already exists.";


        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            
            var viewData = await _leaveTypesService.GetAllAsync();
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // Since id is nullable, we need to check if it has a value before proceeding.
            if (id == null)
            {
                return NotFound();
            }


            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);


            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] // This attribute helps to prevent CSRF attacks.

        // Binding might be dangerous for overposting attacks.
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
        {

            if (await _leaveTypesService.CheckIfLeaveTypeExists(leaveTypeCreate.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                await _leaveTypesService.Create(leaveTypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

        

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Since id is nullable, we need to check if it has a value before proceeding.
            if (id == null)
            {
                return NotFound();
            }


            var leaveType = await _leaveTypesService.Get<LeaveTypeEditVM>(id.Value);


            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            if (await _leaveTypesService.CheckIfLeaveTypeExistsForEdits(leaveTypeEdit))
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypesService.Edit(leaveTypeEdit);
                }
                // If two person accesses the same record at the same time,
                // one of them will get a concurrency exception.
                catch (DbUpdateConcurrencyException)
                {
                    // If the record with the given id does not exist, return NotFound.
                    if (!_leaveTypesService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    // If the record exists, we can log the error or handle it accordingly.
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }

        

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }


            return View(leaveType);
        }

        // Action name is specified because this method name can't be Delete.
        // We also have Delete method with the same name and same parameter type.
        // So, we need to specify a different action name for this method.

        // Method name and action name can be different.

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypesService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
