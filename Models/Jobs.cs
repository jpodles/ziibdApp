using System.Collections.Generic;



namespace ziibdApp.Models
{
    public partial class Jobs
    {
        public Jobs()
        {
            Employees = new HashSet<Employees>();
            JobHistory = new HashSet<JobHistory>();
        }

        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public int? MinSalary { get; set; }
        public int? MaxSalary { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<JobHistory> JobHistory { get; set; }
    }
}
