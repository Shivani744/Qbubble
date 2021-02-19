using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.UserCommands;
using Application.Features.Queries.UserQueries;
using MediatR;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApiApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        [Obsolete]
        private readonly IHostingEnvironment _appEnvironment;
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create/{ufile}")]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {

            // }
            return Ok(await Mediator.Send(command));
            //var image = ufile;
            //if (image != null)
            //{
            //    var formCollection = await Request.ReadFormAsync();
            //    var file = formCollection.Files.FirstOrDefault();
            //    //var files = HttpContext.Request.Form.Files;
            //    //foreach (var Image in files)
            //    //{
            //    if (file != null && file.Length > 0)
            //    {
            //        var fileimg = file;
            //        //There is an error here
            //        var uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\img");
            //        if (fileimg.Length > 0)
            //        {
            //            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
            //            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
            //            {
            //                await file.CopyToAsync(fileStream);
            //                ufile = fileName;
            //            }

            //        }
            //    }
            //    return Ok(await Mediator.Send(new UploadUserProfilepic { ImageUrl = ufile }));
            //}
        }

        /// <summary>
        /// Get Message.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="phone"></param>
        /// <returns></returns>

        [HttpGet("Login/{phone}")]
        public async Task<IActionResult> Login(string phone)
        {
            return Ok(await Mediator.Send(new GetUserByUserNameAndPhone { phone = phone }));
        }

        [HttpGet("VerifyNumber/{otp}")]
        public async Task<IActionResult> VerifyNumber(string otp)
        {
            return Ok(await Mediator.Send(new GetUserOtp { Otp = otp }));
        }
        ///<summary>
        /// Add or update the profile photo for current user 
        ///</summary>
        /// <returns>Profile photo path</returns>
        [HttpPost("upload/{ufile}/{id}")]
        public async Task<ActionResult> SetProfilePhoto([FromForm] string ufile,int id)
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.FirstOrDefault();
                if (file != null && file.Length > 0)
                {
                    var uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\img");
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            ufile = fileName;
                        }
                    }
                }
                return Ok(await Mediator.Send( new UploadUserProfilepic { ImageUrl = ufile,Id=id }));
            }
            catch (Exception ex)
            {
                throw;
            
            }
        }

        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }
        /// <summary>
        /// Gets Product Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }
        /// <summary>
        /// Deletes Product Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteUserByIdCommand { Id = id }));
        }
        /// <summary>
        /// Updates the Product Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateUserCommand command,int id)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
