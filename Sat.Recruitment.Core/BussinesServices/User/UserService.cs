using Sat.Recruitment.Core.BussinesServices.User.Contexto;
using Sat.Recruitment.Core.BussinesServices.User.Resultado;
using Sat.Recruitment.Core.DTOs.Entities;
using Sat.Recruitment.Core.Entities.User;
using Sat.Recruitment.Core.Entities.User.Validations;
using Sat.Recruitment.Core.Generics.Mappers;
using Sat.Recruitment.Core.Interfaces.Repositories;
using Sat.Recruitment.Core.Interfaces.Services;
using Sat.Recruitment.Core.Utils.Exceptions.Handlers;
using Sat.Recruitment.Core.Utils.Exceptions.Models;
using Sat.Recruitment.Core.Utils.Extensions;

namespace Sat.Recruitment.Core.BussinesServices.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRespository;

        public UserService(IUserRepository userRespository)
        {
            _userRespository = userRespository;
        }

        public ResultGetUser GetUser(ContextGetUser contexto)
        {
            ResultGetUser resultado = new(contexto);

            try
            {
                if (contexto.IdUser.IsEmpty())
                    throw AppExceptionHandler.NewException("The parameter is invalid.");

                UserEntity? user = _userRespository.GetById(contexto.IdUser) ?? throw AppExceptionHandler.NewException("Requested user not found.");

                resultado.User = MapperUser(user);
            }
            catch (AppException ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.Excepciones.Add(ex);
            }
            catch (Exception ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.TieneExcepciones = true;
                resultado.Excepciones.Add(AppExceptionHandler.NewException(ex.Message));
            }
            finally { resultado.MarcarFin(); }

            return resultado;
        }

        public ResultGetUsers GetUsers(ContextGetUsers contexto)
        {
            ResultGetUsers resultado = new(contexto);

            try
            {
                List<UserEntity>? users = _userRespository.GetAll().ToList() ?? throw AppExceptionHandler.NewException("User already exists.");

                resultado.Users = MapperUsers(users);
            }
            catch (AppException ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.Excepciones.Add(ex);
            }
            catch (Exception ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.TieneExcepciones = true;
                resultado.Excepciones.Add(AppExceptionHandler.NewException(ex.Message));
            }
            finally { resultado.MarcarFin(); }

            return resultado;
        }

        public ResultCreateUser CreateUser(ContextCreateUser contexto)
        {
            ResultCreateUser resultado = new(contexto);
            try
            {
                ValidationCreateUser validation = new();
                var validatorResult = validation.Validate(contexto.User);
                if (validatorResult.IsValid)
                {
                    ApplyBonusUser(contexto.User);
                    NormalizeUserEmail(contexto.User);

                    UserDto newUser = SaveNewUser(contexto.User);

                    resultado.User = newUser;
                }
                else
                {
                    throw AppExceptionHandler.NewException(validatorResult.Errors[0].ErrorMessage);
                }
            }
            catch (AppException ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.Excepciones.Add(ex);
            }
            catch (Exception ex)
            {
                resultado.Exito = false;
                resultado.Mensaje = ex.Message;
                resultado.TieneExcepciones = true;
                resultado.Excepciones.Add(AppExceptionHandler.NewException(ex.Message));
            }
            finally { resultado.MarcarFin(); }

            return resultado;
        }

        #region Common Private
        private static void ApplyBonusUser(UserEntity user)
        {
            switch (user.UserType)
            {
                case "Normal":
                    BonusNomalUser(user);
                    break;
                case "SuperUser":
                    BonusSuperUser(user);
                    break;
                case "Premium":
                    BonusPremiumUser(user);
                    break;
            }
        }
        private static void BonusNomalUser(UserEntity user)
        {
            if (user.Money >= 10 && user.Money <= 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                user.Money *= percentage;
            }
            else if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.8);
                user.Money *= percentage;
            }
        }
        private static void BonusSuperUser(UserEntity user)
        {
            if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(1);
                user.Money *= percentage;
            }
        }
        private static void BonusPremiumUser(UserEntity user)
        {
            if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(2);
                user.Money *= percentage;
            }
        }

        private static void NormalizeUserEmail(UserEntity user)
        {
            var aux = user.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
            user.Email = string.Join("@", new string[] { aux[0], aux[1] });
        }

        private UserDto SaveNewUser(UserEntity user)
        {
            if (DuplicateUserValidation(user))
                throw AppExceptionHandler.NewException("User already exists.");

            _userRespository.Insert(user);
            _userRespository.SaveChanges();

            return MapperUser(user);
        }

        private bool DuplicateUserValidation(UserEntity user)
        {
            return _userRespository.ValidateDuplicateUser(user);
        }

        private static List<UserDto> MapperUsers(List<UserEntity> users)
        {
            return users.Select(d => MapperUser(d)).ToList();
        }

        private static UserDto MapperUser(UserEntity user)
        {
            return BaseMapper<UserDto, UserEntity>.EntityToDto(user);
        }
        #endregion
    }
}
