using System;
using System.Data;
using Npgsql;

namespace Core.Library
{
    public class dbop
    {
        private string connectionString = "User ID=postgres;Password=postgres;Server=localhost;Port=5432;Database=demo;Integrated Security=true;Pooling=true;";
        //"userid=postgres;host=localhost;port=5432;password=postgres;database=demo;"; 
        NpgsqlConnection con;
        public dbop()
        {
            con = new NpgsqlConnection(connectionString);

        }

        public int ExecNonQuery(string SqlQuery, NpgsqlParameter[] Params,bool isStoreProcedure = false)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(SqlQuery,con);
                if(isStoreProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                else 
                    cmd.CommandType = CommandType.Text;
                if(Params.Length > 0)
                    cmd.Parameters.AddRange(Params);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetData(string SqlQuery, NpgsqlParameter[] Params,bool isStoreProcedure = false)
        {
            try
            {
                DataTable dt = new DataTable();
                NpgsqlCommand cmd = new NpgsqlCommand(SqlQuery,con);
                if(isStoreProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                if(Params != null && Params.Length > 0)
                    cmd.Parameters.AddRange(Params);
                NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}
