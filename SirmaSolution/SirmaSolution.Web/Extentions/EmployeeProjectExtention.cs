using SirmaSolution.Data;
using System;
    
namespace SirmaSolution.Web.Extentions
{
    public static class EmployeeProjectExtention
    {
        public static EmployeeProject ToEmployeeProject(this string data)
        {
            var parseData = data.Split(", ");

            try
            {
                return new EmployeeProject {
                    EmployeeId = int.Parse(parseData[0]),
                    ProjectId = int.Parse(parseData[1]),
                    DataFrom = DateTime.Parse(parseData[2]),
                    DateTo = parseData[3] != "NULL" ? DateTime.Parse(parseData[3]) : (DateTime?)null };

            }
            catch (Exception)
            {
                //Retrieve the exception
                throw;
            }
        }
    }
}
