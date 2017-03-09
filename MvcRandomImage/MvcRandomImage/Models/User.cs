using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcRandomImage.Models
{
    /// <summary>
    /// User model
    /// </summary>
    [Table("Users")]
    public class User
    {
        /// <summary>
        /// user key
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Holds username
        /// </summary>
        [Required(ErrorMessage ="Please provide a valid Username")]
        public string Username { get; set; }

        /// <summary>
        /// Holds user password
        /// </summary>
        [Required(ErrorMessage ="Please provide a valid Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}