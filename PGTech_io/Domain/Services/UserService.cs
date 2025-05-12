using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PGTech_io.Components.Constants;
using PGTech_io.Data;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.Services;

public class UserService()
{
    private UserManager<ApplicationUser> _userManager;
    private AuthenticationStateProvider _authenticationStateProvider;
    
    public UserService(UserManager<ApplicationUser> userManager, AuthenticationStateProvider authenticationStateProvider) : this()
    {
        _userManager = userManager;
        _authenticationStateProvider = authenticationStateProvider;
    }
    
    public async Task<string> obtainUserNameByUserId(string userId)
    {
        var result = await _userManager.FindByIdAsync(userId);
        string? userName = result.UserName;
        return userName.ToString();
    }

    public async Task<string> UserName()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        
        var userId = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;    
        return userId;
    }
}