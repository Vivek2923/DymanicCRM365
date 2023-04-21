


using UoPeople.NGPortal.Service.Repository.MSDynamics;
using static UoPeople.NGPortal.Utility.Constants;

namespace UoPeople.NGPortal.Service
{
    public class NGPortalCommonService : INGPortalCommonService
    {
        private readonly IDynamicsRepository dynamicsRepository;
        public NGPortalCommonService(IDynamicsRepository dynamicsRepository)
        {
            this.dynamicsRepository = dynamicsRepository;
        }
       
        public async Task<string> InsertStudent(string studentID)
        {
            string myCase = await dynamicsRepository.Insert(studentID);
            return myCase;
        }

        public async Task<string> UpdateStudent(string studentID)
        {
            string myCase = await dynamicsRepository.Update(studentID);
            return myCase;
        }


        public async Task<string> DeleteStudent(string studentID)
        {
            string myCase = await dynamicsRepository.Delete(studentID);
            return myCase;
        }
    }
}
