﻿using MediatR;
using Piano.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.BusinessLogic.Commands.Users.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly PianoContext _pianoContext;

        public CreateUserHandler(PianoContext pianoContext)
        {
            _pianoContext = pianoContext;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           await _pianoContext.Users.AddAsync(new Entities.User
            {
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
                UserId = Guid.NewGuid(),
            }, cancellationToken);

            await _pianoContext.SaveChangesAsync();

            return default;
        }
    }
}
