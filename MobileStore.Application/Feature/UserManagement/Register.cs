using Application.Features.Login;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MobileStore.Application.Interfaces;
using System.Net;

namespace Application.Features.Register
{
    public class RegisterHandler : IRequestHandler<RegisterHandlerInput, RegisterHandlerOutput>
    {

        private readonly ILogger<RegisterHandler> _logger;
        private readonly IUserRepository _reposatory;

        public RegisterHandler(ILogger<RegisterHandler> logger, IUserRepository reposatory)
        {
            _logger = logger;
            _reposatory = reposatory;

        }
        public async Task<RegisterHandlerOutput> Handle(RegisterHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling Register business logic");
            RegisterHandlerOutput output = new RegisterHandlerOutput();
            var message = await _reposatory.RegisterAsync(request.newUser);
            output.Message = message;
            return output;
        }
    }
}
