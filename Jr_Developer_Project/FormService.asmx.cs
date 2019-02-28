using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Jr_Developer_Project
{
    /// <summary>
    /// Summary description for FormService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FormService : WebService
    {

        [WebMethod]
        public void GetFormDescriptions()
        {
            string cs = ConfigurationManager.ConnectionStrings["FormDB"].ConnectionString;
            List<Form> formDescriptions = new List<Form>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetFormDescriptions", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Form form = new Form();
                    form.FormId = Convert.ToInt32(rdr["FormId"]);
                    form.Name = rdr["Name"].ToString();
                    form.Description = rdr["Description"].ToString();
                    form.Date = Convert.ToDateTime(rdr["Date"]);
                    formDescriptions.Add(form);
                }
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(formDescriptions));

        }
    }
}
