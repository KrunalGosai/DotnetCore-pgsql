using System;
using System.Data;
using Core.Controllers;
using Npgsql;

namespace Core.Library
{
    public class Values
    {
        dbop dbop;
        public Values()
        {
            dbop = new dbop();
            
        }

        public DataTable GetAllRecords()
        {
            return dbop.GetData("select * from demo",null);
        }

        public int InsertContact(contact contact, object image)
        {
            NpgsqlParameter[] Params = new NpgsqlParameter[]{
                new NpgsqlParameter("@firstName",contact.firstName),
                new NpgsqlParameter("@lastName",contact.lastName),
                new NpgsqlParameter("@gender",contact.gender),
                new NpgsqlParameter("@designation",contact.designation),
                new NpgsqlParameter("@mobile",contact.mobile)
            };
            return dbop.ExecNonQuery("insert into demo (firstName,lastName,gender,designation,mobile) "+ 
            "values (@firstName, @lastName, @gender, @designation, @mobile)",Params);
        }
    }

}