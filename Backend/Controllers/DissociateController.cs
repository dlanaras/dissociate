using Dissociate.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Dissociate.Contexts;
using Microsoft.AspNetCore.Cors;
using System.Net.WebSockets;

namespace Dissociate.Controllers
{

    [EnableCors("MyAllowSpecificOrigins")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DissociateController : ControllerBase
    {
        private readonly DissociateContext _context;

        public DissociateController(DissociateContext context)
        {
            _context = context;
        }

        private bool HasSession()
        {
            return HttpContext.Session.TryGetValue("UserId", out _);
        }

        [HttpPost]
        public ActionResult Login([FromBody] LoginCreds loginCreds)
        {
            if (!HasSession())
            {
                var user = _context.TblUsers.FirstOrDefault(a => a.Email.Equals(loginCreds.Email) && a.Password.Equals(loginCreds.Password));
                if (user != null)
                {
                    HttpContext.Session.SetString("UserId", user.Username);
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        public ActionResult<List<TblUserDto>> GetUsers()
        {
            if (!HasSession())
            {
                return Unauthorized();
            }

            var users = _context.TblUsers.ToList();

            var userDtos = new List<TblUserDto>();
            foreach (var user in users)
            {
                userDtos.Add(new TblUserDto(user));
            }
            return userDtos;
        }

        [HttpGet]
        public ActionResult<List<TblMessageDto>> GetMessagesBetweenUsers(int idUser1, int idUser2)
        {
            if (!HasSession())
            {
                return Unauthorized();
            }

            var messages = _context.TblMessages
                .Where(a => (a.IdReceiveUser == idUser1 && a.IdSendUser == idUser2) ||
                (a.IdReceiveUser == idUser2 && a.IdSendUser == idUser1))
                .ToList();

            List<TblMessageDto> messagesDto = new List<TblMessageDto>();

            foreach (var message in messages)
            {
                messagesDto.Add(new TblMessageDto(message));
            }

            return messagesDto;
        }

        [HttpGet]
        public bool IsLoggedIn()
        {
            return HasSession();
        }

        [HttpDelete]
        public void Loggout()
        {
            HttpContext.Session.Clear();
            if (Request.Cookies[".AspNetCore.Session"] != null)
            {
                Response.Cookies.Delete(".AspNetCore.Session");
            }
        }

        [HttpGet]
        public async Task Ws()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await Echo(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        private async Task Echo(WebSocket webSocket)
        {
            var bugger = new byte[1024 * 4];
            var receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(bugger), CancellationToken.None);

            while (!receiveResult.CloseStatus.HasValue)
            {
                SaveMessageToDb(bugger);

                await webSocket.SendAsync(
                    new ArraySegment<byte>(bugger, 0, receiveResult.Count),
                    receiveResult.MessageType,
                    receiveResult.EndOfMessage,
                    CancellationToken.None);

                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(bugger), CancellationToken.None);
            }

            await webSocket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription,
                CancellationToken.None);

            await _context.SaveChangesAsync();
        }

        private void SaveMessageToDb(byte[] message)
        {
            /*_context.Messages.Add(new Message
            {
                Content = System.Text.Encoding.Default.GetString(message),
                Date = DateTime.UtcNow
            });*/
        }
    }
}