using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using IPT.TestProject.Domain.Entities;

namespace IPT.TestProject.Application.Services.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly UserManager<User> _userManager;

        public UpdateUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) throw new Exception("No user found");

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            var update = await _userManager.UpdateAsync(user);

            if (!update.Succeeded) throw new Exception("Update failed");

            return Unit.Value;
        }
    }
}
