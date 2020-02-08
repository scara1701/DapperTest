using DapperTest.SQLDataAccessDemo.Models;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Linq;

namespace DapperTest.SQLDataAccessDemo
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConVal("SampleDB")))
            {
                //.Query is part of Dapper.sqlmapper

                //don't do this - sql injection
                //return connection.Query<Person>($"Select * from people where LastName ='{lastName}'").ToList();

                //stored procedure
                return connection.Query<Person>("dbo.People_GetByLastName @LastName", new { LastName = lastName }).ToList();
            }
        }

        public void InsertPerson(string firstName, string lastName, string emailAddress)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConVal("SampleDB")))
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress });
                connection.Execute("dbo.People_Insert @FirstName, @LastName, @EmailAddress", people);
            }
        }
    }
}
