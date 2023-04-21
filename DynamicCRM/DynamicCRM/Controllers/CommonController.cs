

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using UoPeople.NGPortal.Service.Repository.MSDynamics.Connection;

namespace UoPeople.NGPortal.Service.Controllers
{
    [ApiController]
    public class CommonController : ControllerBase
    {

        private readonly INGPortalCommonService portalService;

        public CommonController(INGPortalCommonService portalService)
        {
            this.portalService = portalService;
        }
                
        [HttpGet]
        [Route("/common/{studentID}/InsertStudent")] 
        public async Task<ActionResult<string>> InsertStudent([FromRoute][Required] string studentID)
        {
            string notifeData = await portalService.InsertStudent(studentID);
            return Ok(notifeData);
        }

        [HttpGet]
        [Route("/common/{studentID}/UpdateStudent")]
        public async Task<ActionResult<string>> UpdateStudent([FromRoute][Required] string studentID)
        {
            string notifeData = await portalService.UpdateStudent(studentID);
            return Ok(notifeData);
        }

        [HttpGet]
        [Route("/common/{studentID}/DeleteStudent")]
        public async Task<ActionResult<string>> DeleteStudent([FromRoute][Required] string studentID)
        {
            string notifeData = await portalService.DeleteStudent(studentID);
            return Ok(notifeData);
        }
    }
}