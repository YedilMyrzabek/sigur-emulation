using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using sigur_emulation.Models;


namespace sigur_emulation.Controller;

[ApiController]
[Route("api/v1")]
public class SigurAuthController : ControllerBase
{
    [HttpPost("users/auth")]
    public async Task<IActionResult> AuthUser()
    {
        var result = new SigurAuth
        {
            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMmIwYzgyYS1lMDgzLTQ1MTktYjE3NS1iMjY1NmZlNmM1OWQiLCJsb2dpbiI6ImFkbWluIiwicGVybWlzc2lvbnMiOiIvLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLy8vLzMvLy8vLy8vLy8vOEIiLCJyb2xlcyI6ImFkbWluIiwiYXVkIjoiZG1tcy5tcyIsImlzcyI6ImRtbXMubXMiLCJleHAiOjE3NTg1NDkwOTUsIm5iZiI6MTc1ODU0NTQ5NSwiaWF0IjoxNzU4NTQ1NDk1fQ.tyFLYcqwaw6CgjkKI-A_UY9TDsVBS3SvQ3OshPn4sZM",
            RefreshToken = "",
            ExpiresAt = DateTime.Now,
            RefreshExpiresAt = DateTime.Now
        };

        return Ok(result);
    }
}