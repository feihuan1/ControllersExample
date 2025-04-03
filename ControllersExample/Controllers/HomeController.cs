using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

// content result is a type of Action result
// almost all content can represented by content result, it just need content and contentType

// json result can represent an object in JSON format
// auto set contentType to application/json

// file result sends the content of file as response
// downloading movie, zip, pdf, game... 
// three types:
// 1. VirtualFileResult, return new VirtualFileResult("file relative path", "content type") file in wwwroot
// 2. PhysicalFileResult, return new PhysicalFileResult("file ABSOLUTE path", "content type") file outside of wwwroot
// 3. FileContentResult, return new FileContentResult(byte_array, "content type") // image from database

// IActionResult is the parent for all action result classes such as  ContentResult JsonResult RedirectResul StatusCodeResult ViewResult
// it can return any subtype of IActionResult



namespace ControllersExample.Controllers
{
    // class has to be public
    [Controller]// if this attribute added, dont have to surfix class with Controller
    // controller is a child of ControllerBase!!
    public class Homecontroller : Controller
    {
        // this approach enable the method with the route attribute is called attribute routing
        [Route("sayhello1")]
        [Route("sayhello2")] // all route attribute will fire this method!!
        public string method1()
        {
            return "Hello from method1";
        }

        [Route("home")]
        [Route("/")]
        public ContentResult Index()// specific return type
        {
            // this way dont need inherit Controller
            // return new ContentResult() { Content = "Hello from index", ContentType = "text/plain" };
            // this method in Controller class, just pass value as arguments
            return Content("<h1>Hello from index</h1> <h3>This is the second line<h3>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()// specific return type
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Eric",
                LastName = "Peng",
                Age = 37
            };

            // pro verson
            return Json(person);// Json method returnd JsonResult

            //// fancy version
            //return new JsonResult(person);

            // pain in ass version
            //return "{\"key\" : \"value\" }";
        }

        //[Route("contact-us/{mobile:regex(^\\d{{10}}$)}")] // need excape \ and {} , just double it!
        [Route("file-download")]
        public VirtualFileResult FileDownload()// specific return type
        {
            // relative path wwwroot
            //return new VirtualFileResult("/sample.pdf", "application/pdf");
            return File("/sample.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()// specific return type
        {
            // absolute path from root of pc root
            //return new PhysicalFileResult("C:\\Users\\feihuan.peng\\OneDrive - Spreetail\\Desktop\\coverage.pdf", "application/pdf");
            return PhysicalFile("C:\\Users\\feihuan.peng\\OneDrive - Spreetail\\Desktop\\coverage.pdf", "application/pdf");
        }

        [Route("file-download3")]
        //public FileContentResult FileDownload3() // specific return type
        public IActionResult FileDownload3()
        {
            // this return a byte array
            byte[] bytes = System.IO.File.ReadAllBytes("C:\\Users\\feihuan.peng\\OneDrive - Spreetail\\Desktop\\coverage.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }
    }
}
