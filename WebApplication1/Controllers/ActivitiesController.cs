using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ActivitiesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select activityId, activityName, userId, description, activityTime from dbo.activities";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ActivitiesAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("{id:int}")]
        public JsonResult GetActivity(int id)
        {
            string query = @"
                            SELECT activityId, activityName, userId, description, activityTime FROM dbo.activities WHERE userId=" + id;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ActivitiesAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpDelete("{id:int}")]
        public JsonResult DelActivity(int id)
        {
            string query = @"
                            DELETE FROM dbo.activities WHERE activityId=" + id;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ActivitiesAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        [HttpPost]
        public JsonResult Post(Activities activity)
        {
            string query = @"
                    insert into dbo.activities 
                    (activityName, userId, description, activityTime)
                    values
                    (
                    '" + activity.activityName + @"'
                    ,'" + activity.userId + @"'
                    ,'" + activity.description + @"'
                    ,'" + activity.activityTime + @"'
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ActivitiesAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


    }
}
