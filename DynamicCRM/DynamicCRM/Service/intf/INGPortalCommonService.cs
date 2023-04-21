
namespace UoPeople.NGPortal.Service
{
    public interface INGPortalCommonService
    {
        
        Task<string> InsertStudent(string studentId);
        Task<string> UpdateStudent(string studentId);
        Task<string> DeleteStudent(string studentId);


    }
}