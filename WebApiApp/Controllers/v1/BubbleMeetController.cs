using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.BubbleMeetCommands;
using Application.Features.Queries.BubbleMeetQueries;
using MediatR;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using static Domain.CommonCodes.CommonEnums;

namespace WebApiApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BubbleMeetController : BaseApiController
    {
        [HttpPost("createUpdateBubbleMeet")]
        public async Task<IActionResult> CreateUpdateBubbleMeet(CreateUpdateBubbleMeetCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("deleteBubbleMeet")]
        public async Task<IActionResult> DeleteBubbleMeet(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteBubbleMeetCommand { Id = id }));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("getAllBubbleMeet")]
        public async Task<IActionResult> GetAllBubbleMeet()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllBubbleMeetQuery()));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("getBubbleMeetWithFilters")]
        public async Task<IActionResult> GetBubbleMeetWithFilters(string title)
        {
            try
            {
                return Ok(await Mediator.Send(new GetBubbleMeetWithFiltersQuery { Title = title }));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
