using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRandomImage.Controllers
{
    /// <summary>
    /// Like Controller provides functionality to like or dislike an image.
    /// </summary>
    public class LikeController : ImageController
    {
        /// <summary>
        /// Performs like or dislike action on an image
        /// </summary>
        /// <param name="ImageModel">Like model</param>
        /// <param name="imageId">Image key</param>
        /// <param name="like">User input: 1-Like; 0-Dislike </param>
        /// <returns>Json with success or failure response</returns>
        public ActionResult Like(Models.Like ImageModel, string imageId, string like)
        {
            int UserId = Int32.Parse(Session["UserId"].ToString());
            int ImageId = Int32.Parse(imageId);
            bool Like = like == "1";
            ImageModel.SetLike(UserId, ImageId, Like);
            ViewBag.Like = Like;

            string Message = "You have disliked this image.";

            if (Like)
            {
                Message = "You have liked this image.";
            }

            // TODO: Handle errors and returned failure message.

            return Json(new
            {
                Success = true,
                Message = Message
            }, JsonRequestBehavior.AllowGet);
        }
    }
}