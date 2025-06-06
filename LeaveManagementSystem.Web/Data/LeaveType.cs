﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveType : BaseEntity
    {

        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }
        public int NumberOfDays { get; set; }

    }
}
