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

        [HttpGet]
        [Route("AddStudent")]
        public async Task<bool>AddStudent(PersonalDetail person)
        {

            return true;
        }


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