using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Commands.PodCommands;
using MediatR;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using static Domain.CommonCodes.CommonEnums;
using Application.Features.Queries.PodQueries;
using System.Net;
using System.Text;

namespace WebApiApp.Controllers.v1
{

    [ApiVersion("1.0")]
    public class PodController : BaseApiController
    {
        [HttpPost("createUpdatePod")]
        public async Task<IActionResult> CreateUpdatePod(CreateUpdatePodCommand command)
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

        [HttpPost("deletePod")]
        public async Task<IActionResult> DeletePod(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new DeletePodCommand { Id = id }));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("getAllPod")]
        public async Task<IActionResult> GetAllPod()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllPodQuery()));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("getPodWithFilters")]
        public async Task<IActionResult> GetPodWithFilters(string name)
        {
            try
            {
                return Ok(await Mediator.Send(new GetPodWithFiltersQuery {PName = name }));
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public string SendNotification(string deviceId, string message)
        //{
        //    string ApiKey = "server api key";
        //    var userId = "application number";
        //    var value = message;
        //    WebRequest tRequest;
        //    tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
        //    tRequest.Method = "post";
        //    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
        //    tRequest.Headers.Add(string.Format("Authorization: key={0}", ApiKey));
        //    tRequest.Headers.Add(string.Format("Sender: id={0}", userId));
        //    string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + deviceId + "";
        //    Console.WriteLine(postData);
        //    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //    tRequest.ContentLength = byteArray.Length;
        //    Stream dataStream = tRequest.GetRequestStream();
        //    dataStream.Write(byteArray, 0, byteArray.Length);
        //    dataStream.Close();
        //    WebResponse tResponse = tRequest.GetResponse();
        //    dataStream = tResponse.GetResponseStream();
        //    StreamReader tReader = new StreamReader(dataStream);
        //    String sResponseFromServer = tReader.ReadToEnd();
        //    tReader.Close();
        //    dataStream.Close();
        //    tResponse.Close();
        //    return sResponseFromServer;
        //}
    }
}


