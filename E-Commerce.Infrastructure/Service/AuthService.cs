using E_Commerce.Application.DTOs.AuthDTO;
using E_Commerce.Application.Interface;
using E_Commerce.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public AuthService(ITokenService tokenService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                throw new Exception("Invalid email or password");
            }

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = _tokenService.CreateToken(user)
            };

        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User registration failed");
            }
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}
