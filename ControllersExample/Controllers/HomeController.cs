using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    // class has to be public
    public class Homecontroller: Controller
    {
        // this approach enable the method with the route attribute is called attribute routing
        [Route("api/sayhello")] 
        public string method1()
        {
            return "Hello from method1";

        }
    }
}
