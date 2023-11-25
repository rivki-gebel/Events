using Api_events;
using Api_events.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest
{
    public class EventsControllerTest
    {
        [Fact]
        public void Get_ReturnOk()
        {
            var controller = new EventsController();
            var result = controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Get_ReturnOkObjectResult() 
        { 
            var controller = new EventsController();
            var result = controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetById_IsNotFoundResult()
        {
            int id = 8;
            var controller = new EventsController();
            var result = controller.Get(id);
            Assert.IsType<NotFoundResult>(result);
        }
      



    }
}