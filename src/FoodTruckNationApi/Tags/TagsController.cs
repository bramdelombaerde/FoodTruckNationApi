using System.Collections.Generic;
using AutoMapper;
using FoodTruckNation.Core.AppInterfaces;
using FoodTruckNation.Core.Domain;
using Framework.ApiUtil.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FoodTruckNationApi.Tags
{

    /// <summary>
    /// Controller for API endpoints dealing with tags
    /// </summary>
    [Produces("application/json")]
    [Route("api/Tags")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class TagsController : ApiControllerBase
    {

        /// <summary>
        /// Creates a new TagsController
        /// </summary>
        /// <param name="logger">An ILoggerFactory of the factory class used to create an ILogger instance for use in this controller</param>
        /// <param name="mapper">An Automapper IMapper instance used to perform object mapping in the controller</param>
        /// <param name="tagService">An iTagService instance of the tag service object where the business logic for tag functions resides</param>
        public TagsController(ILogger<TagsController> logger, IMapper mapper, ITagService tagService)
            : base(logger, mapper)
        {
            _tagService = tagService;
        }


        private readonly ITagService _tagService;


        /// <summary>
        /// Gets a list of all of the tags in the system
        /// </summary>
        /// <param name="inUseOnly"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery]bool inUseOnly = false)
        {
            // Since we have just one filter possibility, we'll leave this as a simple if statement
            // If we had more/more complex filter criteria, then splitting the logic into multiple methods would be in order
            IList<Tag> tags = null;
            if (inUseOnly)
            {
                tags = _tagService.GetTagsInUse();
            }
            else
            {
                tags = _tagService.GetAllTags();
            }

            var models = _mapper.Map<IList<Tag>, List<string>>(tags);
            return Ok(models);
            
        }



    }
}