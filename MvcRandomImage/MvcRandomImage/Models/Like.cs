using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcRandomImage.Models
{
    /// <summary>
    /// Inserts user like
    /// </summary>
    [Table("Likes")]
    public class Like
    {
        /// <summary>
        /// Variable for the userid
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Variable for the imageid
        /// </summary>
        public int ImageId { get; set; }

        /// <summary>
        /// Variable for the storing user likes or dislikes
        /// </summary>
        public int Likes { get; set; }

        /// <summary>
        /// Inserts or updates user likes and dislikes 
        /// </summary>
        /// <param name="UserId">user key</param>
        /// <param name="ImageId">image key</param>
        /// <param name="Like">user likes</param>
        public void SetLike(int UserId, int ImageId, bool Like)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("USP_InsertUserLikes", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                    cmd.Parameters.Add("@ImageId", SqlDbType.Int).Value = ImageId;
                    cmd.Parameters.Add("@Like", SqlDbType.Bit).Value = Like;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}