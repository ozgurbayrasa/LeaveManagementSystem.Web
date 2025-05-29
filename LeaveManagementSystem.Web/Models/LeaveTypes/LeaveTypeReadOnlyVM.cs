using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVm
    {

        public string Name { get; set; } = string.Empty;

        [Display(Name = "Maximum Allocation of Days")]
        public int Days { get; set; }
    }

}
