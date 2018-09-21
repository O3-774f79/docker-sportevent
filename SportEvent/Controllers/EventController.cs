using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportEvent.Bll.Interfaces;
using SportEvent.Bll.Model;
using SportEvent.Extensions;

namespace SportEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(BasicAuthAttribute))]
    public class EventController : ControllerBase
    {

        #region [Fields]

        /// <summary>
        /// The event interface.
        /// </summary>
        private IEvent _event;

        #endregion

        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the <see cref="EventController" /> class.
        /// </summary>
        /// <param name="@event">The interface event..</param>
        public EventController(IEvent @event)
        {
            _event = @event;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Create sport event.
        /// </summary>
        /// <param name="model">The event model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddEvent")]
        public IActionResult AddEvent(EventModel model)
        {
            return Ok(_event.AddEvent(model));
        }

        #endregion

    }
}