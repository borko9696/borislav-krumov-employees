using System;

namespace SirmaSolution.Data
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }

        public int ProjectId { get; set; }

        public DateTime DataFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
