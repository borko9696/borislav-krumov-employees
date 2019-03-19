namespace SirmaSolution.Service
{
    using SirmaSolution.Data;
    using SirmaSolution.Data.ViewModels;
    using System.Collections.Generic;

    public interface IEmployeeProjectService
    {
        List<HomeViewModel> FindPairsEmployees(List<EmployeeProject> data);
    }
}
