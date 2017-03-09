using MvcRandomImage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcRandomImage.Models
{
    /// <summary>
    /// Image model
    /// </summary>
    [Table("Images")]
    public class Image
    {
        /// <summary>
        /// ImageId variable
        /// </summary>
        [Key]
        public int ImageId { get; set; }

        /// <summary>
        /// Imagename variable
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Retrieves random Image
        /// </summary>
        public void GetImage()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString);

            string sql = "select top 1 ImageId, ImageName from Images Order by NEWID()";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
           
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                this.ImageId = Int32.Parse(rdr["ImageId"].ToString());
                this.ImageName = rdr["ImageName"].ToString();
            }
        }

        /// <summary>
        /// Retrieves all the images liked by the user
        /// </summary>
        /// <param name="UserId">Id of logged in user</param>
        /// <returns>Dataset of image details</returns>
        public DataSet GetLikedImages(int UserId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("USP_GetUserLikedImages", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                    con.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds;
                }

            }
        }

        /// <summary>
        /// Retrieves all the images disliked by the user 
        /// </summary>
        /// <param name="UserId">Id of logged in user</param>
        /// <returns>Dataset of image details</returns>
        public DataSet GetDisLikedImages(int UserId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("USP_GetUserDisLikedImages", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;

                    con.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds;
                }

            }
        }
    }
}