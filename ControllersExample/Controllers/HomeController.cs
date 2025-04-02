using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    // class has to be public
    [Controller]// if this attribute added, dont have to surfix class with Controller
    public class Homecontroller: Controller
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
        public string Index()
        {
            return "hello from index";
        }
        
        [Route("about")]
        public string About()
        {
            return "hello from about";
        }
        
        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")] // need excape \ and {} , just double it!
        public string Contact()
        {
            return "hello from contact";
        }

    }
}
