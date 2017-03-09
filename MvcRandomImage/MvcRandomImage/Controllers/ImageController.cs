using MvcRandomImage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRandomImage.Controllers
{
    /// <summary>
    /// Image Controller provides functionality to display images.
    /// </summary>
    public class ImageController : Controller
    {
        /// <summary>
        /// Variable for the image directory
        /// </summary>
        private string ImagePath = "/Images/";
        
        /// <summary>
        /// Displays random image
        /// </summary>
        /// <param name="ImageModel">Image model</param>
        /// <returns>Show image page</returns>
        public ActionResult Show(Image ImageModel)
        {
            return View();
        }

        /// <summary>
        /// Gets a random image
        /// </summary>
        /// <param name="ImageModel">Image model</param>
        /// <returns>Json containing Image path, like and dislike url</returns>
        public ActionResult Get(Image ImageModel)
        {
            ImageModel.GetImage();

            if (ImageModel.ImageId == 0 || ImageModel.ImageName == null)
            {
                return Json(new
                {
                    Success = false,
                    Message =  "Currently we are uploading images. Check back later."
                }, JsonRequestBehavior.AllowGet);
            }

            String ImagePath = this.ImagePath.ToString();
            String ImageId = ImageModel.ImageId.ToString();
            String ImageName = ImageModel.ImageName.ToString();
            
            return Json(new {
                Success = true,
                ImagePath = Url.Content(ImagePath + ImageName),
                LikeUrl = Url.RouteUrl("LikeImage", new { ImageId = ImageId, like = 1 }),
                DisLikeUrl = Url.RouteUrl("LikeImage", new { ImageId = ImageId, like = 0 })
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Displays images liked by the user
        /// </summary>
        /// <param name="ImageModel">Image model</param>
        /// <returns>Liked images page</returns>
        public ActionResult Liked(Image ImageModel)
        {
            ViewBag.ImagePath = this.ImagePath;
            int UserId = Int32.Parse(Session["UserId"].ToString());

            DataSet ds = ImageModel.GetLikedImages(UserId);

            if (ds.Tables[0].Rows.Count == 0)
            {
                ViewBag.ImageList = null;
            }
            else
            {
                ViewBag.ImageList = ds.Tables[0];
            }

            return View();
        }

        /// <summary>
        /// Display images disliked by the user
        /// </summary>
        /// <param name="ImageModel">Image model</param>
        /// <returns>Disliked images page</returns>
        public ActionResult DisLiked(Image ImageModel)
        {
            ViewBag.ImagePath = this.ImagePath;
            int UserId = Int32.Parse(Session["UserId"].ToString());

            DataSet ds = ImageModel.GetDisLikedImages(UserId);

            if (ds.Tables[0].Rows.Count == 0)
            {
                ViewBag.ImageList = null;
            }
            else
            {
                ViewBag.ImageList = ds.Tables[0];
            }

            return View();
        }
    }
}