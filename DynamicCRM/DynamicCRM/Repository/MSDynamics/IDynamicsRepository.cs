

namespace UoPeople.NGPortal.Service.Repository.MSDynamics
{
    public interface IDynamicsRepository
    {       

        Task<string> Insert(string studentID);
        Task<string> Update(string studentID);
        Task<string> Delete(string studentID);


    }
}