using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    // I don't need id in creating a new leave type.
    // It will be defined by the database.
    public class LeaveTypeCreateVM
    {
        [Required]
        [Length(4, 150, ErrorMessage="You have violated langth requirements")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1,90)]
        public int NumberOfDays { get; set; }
    }
}
