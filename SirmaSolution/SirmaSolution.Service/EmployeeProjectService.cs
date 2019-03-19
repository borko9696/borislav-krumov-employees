namespace SirmaSolution.Service
{
    using SirmaSolution.Data;
    using SirmaSolution.Data.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeProjectService : IEmployeeProjectService
    {
        public List<HomeViewModel> FindPairsEmployees(List<EmployeeProject> data)
        {
            var today = DateTime.Today;

            var projects = new List<HomeViewModel>();
            for (var i = 0; i < data.Count; i++)
            {
                var currentEmployee = data[i];

                for (var j = i + 1; j < data.Count; j++)
                {
                    var nextEmployee = data[j];

                    if (currentEmployee.ProjectId != nextEmployee.ProjectId)
                    {
                        continue;
                    }

                    var endDate = currentEmployee.DateTo != null ? currentEmployee.DateTo : today;
                    var startDateNextWorker = nextEmployee.DataFrom;

                    if (startDateNextWorker >= currentEmployee.DataFrom && startDateNextWorker <= currentEmployee.DateTo)
                    {

                        var workingTimeBoth = Math.Floor(((endDate - nextEmployee.DataFrom).Value.TotalMilliseconds) / 86400000);

                        projects.Add(new HomeViewModel {
                            FirstEmpoyeeId = currentEmployee.EmployeeId,
                            SecondEmployeeId = nextEmployee.EmployeeId,
                            ProjectId = currentEmployee.ProjectId,
                            DaysWorked = Convert.ToInt32(workingTimeBoth)
                        });
                    }
                }
            }

            return projects.OrderByDescending(x => x.DaysWorked).ToList();
        }
    }
}