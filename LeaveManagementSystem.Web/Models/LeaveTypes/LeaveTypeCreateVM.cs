namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    // I don't need id in creating a new leave type.
    // It will be defined by the database.
    public class LeaveTypeCreateVM
    {
        public string Name { get; set; } = string.Empty;
        public int NumberOfDays { get; set; }
    }
}
