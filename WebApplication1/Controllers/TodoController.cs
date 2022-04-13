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
    public class TodoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TodoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select todoId, userId, list, projectId from dbo.todo";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
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
        public JsonResult GetTodo(int id)
        {
            string query = @"
                            select todoId, userId, list, projectId from dbo.todo where projectId=" + id;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
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


        [HttpPut("{id:int}")]
        public JsonResult UpdateTodo(int id, todo to_do)
        {

            string query = @"UPDATE dbo.todo SET list = '" + to_do.list + @"' WHERE projectId = '" + id + @"' and todoId = '" + to_do.todoId + @"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
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

            return new JsonResult("updated");
        }

        [HttpDelete("{id:int}")]
        public JsonResult DelTodo(int id)
        {
            string query = @"
                            DELETE FROM dbo.todo WHERE projectId=" + id;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
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
        public JsonResult Post(todo to_do)
        {
            string query = @"
                    insert into dbo.todo 
                    (userId, list, projectId)
                    values
                    (
                    '" + to_do.userId + @"'
                    ,'" + to_do.list + @"'
                    ,'" + to_do.projectId + @"'
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TodoAppCon");
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
