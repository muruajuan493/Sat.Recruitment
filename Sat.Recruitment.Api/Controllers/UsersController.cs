using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Core.BussinesServices.User.Contexto;
using Sat.Recruitment.Core.DTOs.Requests.User;
using Sat.Recruitment.Core.DTOs.Responses.User;
using Sat.Recruitment.Core.Interfaces.Services;
using Sat.Recruitment.Core.Utils.Exceptions.Models;
using System;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("get-user")]
        public DtoGetUserResponse GetUser(DtoGetUserRequest request)
        {
            var dtoResponse = new DtoGetUserResponse();

            try
            {
                var context = new ContextGetUser()
                {
                    IdUser = request.IdUser
                };
                var respuestaServicio = _userService.GetUser(context);
                dtoResponse.ValidarErrores(respuestaServicio);

                if (dtoResponse is not null)
                {
                    dtoResponse.User = respuestaServicio.User;
                }
            }
            catch (ResponseException) { }
            catch (Exception ex) { dtoResponse.GenerarError(ex); }
            finally { dtoResponse.Completar(); }

            return dtoResponse;
        }

        [HttpPost("get-users")]
        public DtoGetUsersResponse GetUsers(DtoGetUsersRequest request)
        {
            var dtoResponse = new DtoGetUsersResponse();

            try
            {
                var context = new ContextGetUsers();
                var respuestaServicio = _userService.GetUsers(context);
                dtoResponse.ValidarErrores(respuestaServicio);

                if (dtoResponse is not null)
                {
                    dtoResponse.Users = respuestaServicio.Users;
                }
            }
            catch (ResponseException) { }
            catch (Exception ex) { dtoResponse.GenerarError(ex); }
            finally { dtoResponse.Completar(); }

            return dtoResponse;
        }

        [HttpPost("create-user")]
        public DtoCreateUserResponse CreateUser(DtoCreateUserRequest request)
        {
            var dtoResponse = new DtoCreateUserResponse();

            try
            {
                var context = new ContextCreateUser()
                {
                    User = new()
                    {
                        Name = request.Name,
                        Email = request.Email,
                        Address = request.Address,
                        Phone = request.Phone,
                        UserType = request.UserType,
                        Money = decimal.Parse(request.Money)
                    }
                };
                var respuestaServicio = _userService.CreateUser(context);
                dtoResponse.ValidarErrores(respuestaServicio);

                if (dtoResponse is not null)
                {
                    dtoResponse.User = respuestaServicio.User;
                }
            }
            catch (ResponseException) { }
            catch (Exception ex) { dtoResponse.GenerarError(ex); }
            finally { dtoResponse.Completar(); }

            return dtoResponse;
        }
    }
}
