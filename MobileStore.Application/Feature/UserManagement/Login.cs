using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MobileStore.Application.Auth.JWT_Auth;
using MobileStore.Application.Feature.Items.Command;
using MobileStore.Application.Interfaces;
using System.Net;


namespace Application.Features.Login
{
    public class LoginHandler : IRequestHandler<LoginHandlerInput, LoginHandlerOutput>
    {

        private readonly ILogger<LoginHandler> _logger;
        private readonly IUserRepository _reposatory;
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginHandler(ILogger<LoginHandler> logger, IUserRepository reposatory, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _reposatory = reposatory;
            _contextAccessor = contextAccessor;
        }
        public async Task<LoginHandlerOutput> Handle(LoginHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling Login business logic");
            LoginHandlerOutput output = new LoginHandlerOutput();

            var Token=await _reposatory.LoginAsync(request.userLogin);

            if (Token == null)
            {
                throw new WebException("Can Not Complete Login Process (Can not generate Token) ");

            }

            string greeting = DateTime.Now.Hour < 12 ? "Good morning" : DateTime.Now.Hour < 18 ? "Good afternoon" : "Good evening";
            output.message = $"{greeting}, user!";

            output.token = Token;
            return output;

        }
    }
}
