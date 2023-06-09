﻿using Books.Business.Interfaces;
using Books.Business.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
    public class UsersV2Controller : BaseApiController
    {

        private readonly IUsersService _usersService;
        private readonly ILogger<UsersController> _logger;
        protected APIResponse _aPIResponse;


        public UsersV2Controller(IUsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService ??
                throw new ArgumentNullException(nameof(usersService));
            _logger = logger;

            _aPIResponse = new APIResponse();
        }

        [HttpGet]
        [Route("{username}")]
        public async Task<MemberDto> GetbyUserName(string username)
        {
            return await _usersService.Get(username);
        }
    }
}
