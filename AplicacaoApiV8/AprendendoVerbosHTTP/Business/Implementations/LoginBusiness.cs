using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Data.Converters;
using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Repository;
using AprendendoVerbosHTTP.Security.Configuration;

namespace AprendendoVerbosHTTP.Business.Implementations
{
    public class LoginBusiness : ILoginBusiness
    {
        private IUsuarioRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfiguration;
        private readonly UsuarioConverter _converter;

        public LoginBusiness(IUsuarioRepository repository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfiguration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfiguration = tokenConfiguration;
            _converter = new UsuarioConverter();
        }

        public object FindByLogin(UsuarioVO usuario)
        {
            bool credentialsIsValid = false;
            if (usuario != null && !string.IsNullOrWhiteSpace(usuario.Login))
            {
                var baseUsuario = _repository.FindByLogin(usuario.Login);
                credentialsIsValid = (baseUsuario != null && baseUsuario.Login.Equals(usuario.Login) && baseUsuario.AccessKey.Equals(usuario.AccessKey));
            }

            if (credentialsIsValid) {

                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Login, "Login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Login)
                    }
                );

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObject(createDate, expirationDate, token);
            }
            else
            {
                return ExceptionObject();
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor()
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object ExceptionObject()
        {
            return new
            {
                autenticated = false,
                message = "Failed to autheticate"
            };
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:ss:mm"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}
