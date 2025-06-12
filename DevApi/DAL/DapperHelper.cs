using Dapper;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class DBHelperDapper
    {
        private static string connectionString = string.Empty;
        public static string connection()
        {
            try
            {
                //return connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                //return connectionString = "Server=localhost;Database=TAXDB;User Id=sa;Password=123456;TrustServerCertificate=true;";
                return connectionString = "Server=68.178.164.44,1437\\DIVIKA;Database=GetRise_Dev;User Id=sa;Password=M@tpuchbha!@213$;TrustServerCertificate=true;";
                //return connectionString = "Server=DESKTOP-SV7IOP0\\LOCALHOST;Database=TAXDB;User Id=sa;Password=123456;TrustServerCertificate=true;";

            }
            catch (Exception)
            {
                //todo error handling  mechanism
                throw;
            }
        }

        /*getting details fro datatbase list*/
        public static List<TClass> DAGetDetailsInList<TClass>(string _qry)
        {
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    IList<TClass> myList = SqlMapper.Query<TClass>(con, _qry).ToList();
                    return myList.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static TClass DAGetDetails<TClass>(string _qry)
        {
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    TClass myList = SqlMapper.Query<TClass>(con, _qry).FirstOrDefault();
                    return myList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public static int DAAdd<T>(string Procname, T param)
        {
            int _iresult = 0;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    _iresult = con.Execute(Procname, param, commandType: System.Data.CommandType.StoredProcedure);
                    return _iresult;
                }
                catch (Exception ex)
                {
                    return _iresult;
                }
            }
        }

        public static int DAAdd(string Procname, DynamicParameters param)
        {
            int _iresult = 0;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    _iresult = con.Execute(Procname, param, commandType: System.Data.CommandType.StoredProcedure);
                    return _iresult;
                }
                catch (Exception ex)
                {
                    return _iresult;
                }
            }
        }

        public static TClass GetAllModel<TClass>(string _procame, DynamicParameters param)
        {
            TClass _objMOdel;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    using (SqlConnection objConnection = new SqlConnection(connection()))
                    {
                        _objMOdel = SqlMapper.Query<TClass>(objConnection, _procame, param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    }
                    return _objMOdel;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public static List<T> GetAllModelList<T>(string spName, DynamicParameters p)
        {
            List<T> recordList = new List<T>();
            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                recordList = SqlMapper.Query<T>(objConnection, spName, p, commandType: System.Data.CommandType.StoredProcedure).ToList();
                objConnection.Close();
            }
            return recordList;
        }

        public static TResponse GetAllModelNew<TRequest, TResponse>(string procName, DynamicParameters param)
        {
            TResponse result;
            using (SqlConnection con = new SqlConnection(connection()))
            {
                try
                {
                    result = SqlMapper.Query<TResponse>(con, procName, param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static T GetModelFromJson<T>(string spName, DynamicParameters p)
        {
            using (SqlConnection objConnection = new SqlConnection(connection()))
            {
                objConnection.Open();
                // Assumes the stored procedure returns a single row with a single column containing the JSON string
                var json = objConnection.QueryFirstOrDefault<string>(spName, p, commandType: System.Data.CommandType.StoredProcedure);
                objConnection.Close();
                if (!string.IsNullOrEmpty(json))
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                }
                return default;
            }
        }
    }
} 