using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;

public abstract class SqlHelper
{
    public static SqlConnection getConnection()
    {
        return new SqlConnection(ConfigurationManager.ConnectionStrings["TelericDemoConnectionString"].ToString());
    }

    /// <summary>
    /// Listing function
    /// </summary>
    /// <remarks>
    /// this function is used to create list of any entity
    /// </remarks>
    /// <param name="StrSpName">used to get the required list from database</param>
    /// <returns>dataset containing required data for listing an entity</returns>
    //public static DataSet ListView(string StrSpName)
    //{
    //    SqlCommand Cmd = new SqlCommand(StrSpName, getConnection());
    //    Cmd.CommandType = CommandType.StoredProcedure;

    //    SqlDataAdapter DA = new SqlDataAdapter();
    //    DA.SelectCommand = Cmd;
    //    DataSet DS = new DataSet();
    //    DA.Fill(DS);

    //    DA.Dispose();
    //    DS.Dispose();
    //    Cmd.Dispose();

    //    return DS;
    //}

    public static void ExecuteSP(object[] dbCallIngrediats)
    {
        SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < dbCallIngrediats.Length; i += 2)
            {
                string parValue = null;
                if (dbCallIngrediats[i + 1] != null)
                    parValue = dbCallIngrediats[i + 1].ToString();

                cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
            }
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Dispose();
        }
    }
    public static void ExecuteSPWithType(object[] dbCallIngrediats)
    {
        SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < dbCallIngrediats.Length; i += 3)
            {
                SqlParameter prm = new SqlParameter(dbCallIngrediats[i].ToString(), (SqlDbType)dbCallIngrediats[i + 1]);
                prm.Value = dbCallIngrediats[i + 2].ToString();
                cmd.Parameters.Add(prm);
            }
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Dispose();
        }
    }
    public static DataTable ExecuteSPReturnDT(object[] dbCallIngrediats)
    {
        SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < dbCallIngrediats.Length; i += 2)
            {
                string parValue = null;
                if (dbCallIngrediats[i + 1] != null)
                    parValue = dbCallIngrediats[i + 1].ToString();
                cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
            }
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Dispose();
            da.Dispose();
        }
        return dt;
    }

    public static DataTable ExecuteSPReturnDT_Test(object[] dbCallIngrediats)
    {
        SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < dbCallIngrediats.Length; i += 2)
            {
                //string parValue = null;
                if (dbCallIngrediats[i + 1] != null)
                    //parValue = dbCallIngrediats[i + 1];
                    cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), dbCallIngrediats[i + 1]);
            }
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Dispose();
            da.Dispose();
        }
        return dt;
    }
    public static DataSet ExecuteSPReturnDS(object[] dbCallIngrediats)
    {
        SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < dbCallIngrediats.Length; i += 2)
            {
                string parValue = null;
                if (dbCallIngrediats[i + 1] != null)
                    parValue = dbCallIngrediats[i + 1].ToString();
                cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
            }
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Dispose();
            da.Dispose();
        }
        return ds;
    }
    public static object ExecuteScalarSP(object[] dbCallIngrediats)
    {
        SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
        object ReturnValue = new object();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < dbCallIngrediats.Length; i += 2)
            {
                string parValue = null;
                if (dbCallIngrediats[i + 1] != null)
                    parValue = dbCallIngrediats[i + 1].ToString();
                cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
            }
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            ReturnValue = cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Dispose();
        }
        return ReturnValue;
    }
    public static object ExecuteSPReturnString(object[] dbCallIngrediats)
    {
        SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
        object ObjValue = string.Empty;
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < dbCallIngrediats.Length; i += 2)
            {
                string parValue = null;
                if (dbCallIngrediats[i + 1] != null)
                    parValue = dbCallIngrediats[i + 1].ToString();

                cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
            }
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            ObjValue = cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Dispose();
        }
        return ObjValue;
    }
    public static DataTable ExecuteSP_NotStringValueForDT(object[] dbCallIngrediats)
    {
        SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < dbCallIngrediats.Length; i += 2)
            {
                if (dbCallIngrediats[i + 1] == null) continue;
                cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), dbCallIngrediats[i + 1]);
            }
            //cmd.Connection.Open();
            da.Fill(dt);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }
        return dt;
    }
    public static object ExecuteSPReturnScaler(object[] dbCallIngrediats)
    {
        SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
        object ReturnValue = new object();
        try
        {
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 1; i < dbCallIngrediats.Length; i += 2)
            {
                string parValue = null;
                if (dbCallIngrediats[i + 1] != null)
                    parValue = dbCallIngrediats[i + 1].ToString();

                cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
            }
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();
            ReturnValue = cmd.ExecuteScalar();
        }
        catch (Exception ex)

        { throw ex; }
        finally
        {
            if (cmd.Connection.State == ConnectionState.Open)
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }
        return ReturnValue;
    }
}
public static class GenericClass
{
    /// <summary>
    /// Generic Insert Method
    /// </summary>
    /// <param name="dbValues"></param>
    /// <returns></returns>
    public static int Insert(object[] dbValues)
    {
        int returnVal = 0;
        try
        {
            returnVal = Convert.ToInt32(SqlHelper.ExecuteScalarSP(dbValues).ToString());
        }
        catch (System.FormatException ex)
        {
            throw ex;
        }
        catch (Exception e)
        {
            throw e;
        }
        return returnVal;
    }

    /// <summary>
    /// Generic Update Method
    /// </summary>
    /// <param name="dbValues"></param>
    /// <returns></returns>
    public static int Update(object[] dbValues)
    {
        int ReturnVal = 0;
        try
        {
            ReturnVal = Convert.ToInt32(SqlHelper.ExecuteScalarSP(dbValues).ToString());
        }
        catch (System.FormatException ex)
        {
            throw ex;
        }
        catch (Exception e)
        {
            throw e;
        }
        return ReturnVal;
    }

    /// <summary>
    /// Generic Delete Method
    /// </summary>
    /// <param name="dbValues"></param>
    /// <returns></returns>
    public static int Delete(object[] dbValues)
    {
        int ReturnVal = 0;
        try
        {
            ReturnVal = Convert.ToInt32(SqlHelper.ExecuteScalarSP(dbValues).ToString());
        }
        catch (System.FormatException ex)
        {
            throw ex;
        }
        catch (Exception e)
        {
            throw e;
        }
        return ReturnVal;
    }

    /// <summary>
    /// Generic Select Method, return DataTable
    /// </summary>
    /// <param name="dbValues"></param>
    /// <returns></returns>
    public static DataTable SelectDT(object[] dbValues)
    {
        DataTable DT = new DataTable();
        try
        {
            DT = SqlHelper.ExecuteSPReturnDT(dbValues);
        }
        catch (System.FormatException ex)
        {
            throw ex;
        }
        catch (Exception e)
        {
            throw e;
        }
        return DT;
    }

    /// <summary>
    /// Generic Select Method, returns DataSet
    /// </summary>
    /// <param name="dbValues"></param>
    /// <returns></returns>
    public static DataSet SelectDS(object[] dbValues)
    {
        DataSet DS = new DataSet();
        try
        {
            DS = SqlHelper.ExecuteSPReturnDS(dbValues);
        }
        catch (System.FormatException ex)
        {
            throw ex;
        }
        catch (Exception e)
        {
            throw e;
        }
        return DS;
    }
}
