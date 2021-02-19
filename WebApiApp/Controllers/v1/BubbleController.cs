using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.BubbleCommands;
using Application.Features.Queries.BubbleQueries;
using Application.Features.Commands.BubbleMemberCommands;
using Application.Features.Queries.BubbleMemberQueries;
using MediatR;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using static Domain.CommonCodes.CommonEnums;

namespace WebApiApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class BubbleController : BaseApiController
    {
        [HttpPost("createUpdateBubble")]
        public async Task<IActionResult> CreateUpdateBubble(CreateUpdateBubbleCommand command)
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
        [HttpPost("deleteBubble")]
        public async Task<IActionResult> DeleteBubble(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteBubbleCommand { Id = id }));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("getAllBubbles")]
        public async Task<IActionResult> GetAllBubbles()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllBubbleQuery()));

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBubbleByBubbleId(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new GetBubbleByBubbleIdQuery { Id = id }));

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("name/type/Size")]
        public async Task<IActionResult> GetBubbleByActiveDate(string membername, BubbleType type, string size)
        {
            try
            {
                return Ok(await Mediator.Send(new GetBubbleByfilterQuery { Name = membername, Bubbletype = type, Size = size }));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("addBubbleMembers")]
        public async Task<IActionResult> AddBubbleMembers(AddBubbleMemberCommand command)
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
        [HttpPost("deleteBubbleMembers")]
        public async Task<IActionResult> DeleteBubbleMembers(DeleteMembersCommand command)
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
        [HttpGet("getAllBubbleMembers")]
        public async Task<IActionResult> GetAllBubbleMembers()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllBubbleMembersQuery()));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("getAllBubbleMembersByBubbleId")]
        public async Task<IActionResult> GetAllBubbleMembersByBubbleId(int bubbleId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetBubbleMembersByBubbleIdQuery { BubbleId = bubbleId }));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("CountBubbleMembersByBubbleId")]
        public async Task<IActionResult> CountBubbleMembersByBubbleId(int bubbleId)
        {
            try
            {
                return Ok(await Mediator.Send(new CountBubbleMembersByBubbleIdQuery { BubbleId = bubbleId }));
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        [HttpGet("defineBubbleMembers")]
        public async Task<IActionResult> DefineBubbleMembers(int bubbleId,int memberlength)
        {
            try
            {
                return Ok(await Mediator.Send(new DefineBubbleMembersQuery { BubbleId = bubbleId,MemberLength=memberlength }));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
