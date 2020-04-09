using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTestWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentApiController:ControllerBase
    {
        [HttpGet]
        [Route("GetStudents")]
        public async Task<IActionResult> GetStudents(string Id)
        {
            List<PersonalDetail> students = new List<PersonalDetail>
           {
           new PersonalDetail{
                              RegNo = "2017-0001",
                              Name = "Nishan",
                              Address = "Kathmandu",
                              PhoneNo = "9849845061",
                              AdmissionDate = DateTime.Now
                              },
           new PersonalDetail{
                              RegNo = "2017-0002",
                              Name = "Namrata Rai",
                              Address = "Bhaktapur",
                              PhoneNo = "9849845062",
                              AdmissionDate = DateTime.Now
                             },
           };
          

            return Ok(students);

        }

   
        [Route("AddStudent")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [EnableCors]
        public async Task<IActionResult> AddStudent()
        {
            await Task.FromResult(0);
            return Ok();
        }


        //    [HttpPost]

        //    public async Task<IActionResult> Test(string name)
        //    {

        //        await Task.FromResult(0);
        //        try
        //        {
        //            string sPostValue1 = "";
        //            string sPostValue2 = "";
        //            string sPostValue3 = "";
        //            {
        //                MemoryStream stream = new MemoryStream();
        //                Request.Body.CopyTo(stream);
        //                stream.Position = 0;
        //                using (StreamReader reader = new StreamReader(stream))
        //                {
        //                    string requestBody = reader.ReadToEnd();
        //                    if (requestBody.Length > 0)
        //                    {
        //                        var obj = JsonConvert.DeserializeObject<P>(requestBody);
        //                        if (obj != null)
        //                        {
        //                            sPostValue1 = obj.name;

        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch(Exception ex)
        //        {

        //        }

        ////        List<string> lstString = new List<string>
        ////{
        ////    sPostValue1,
        ////    sPostValue2,
        ////    sPostValue3
        ////};
        //       // return new JsonResult(lstString);
        //        return View();
        //    }

    }
}
public class PersonalDetail
{
    public string RegNo { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNo { get; set; }
    public DateTime AdmissionDate { get; set; }
}