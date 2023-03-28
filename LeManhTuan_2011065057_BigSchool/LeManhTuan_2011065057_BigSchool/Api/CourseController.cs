using LeManhTuan_2011065057_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeManhTuan_2011065057_BigSchool.Api
{
    public class CourseController : ApiController
    {
        public ApplicationDbContext _dbContext { get; set; }

    public CourseController()
    {
        _dbContext = new ApplicationDbContext();
    }

    [HttpDelete]
    public IHttpActionResult Cancel(int id)
    {
        var userId = User.Identity.GetUserId();
        var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerID == userId);
        if (course.IsDeleted)
        {
            return NotFound();
        }
        course.IsDeleted = true;
        _dbContext.SaveChanges();
        return Ok();
    }
}
}
