using System.Security.Claims;
using System.Text.Json;

namespace MFATest.Authorities
{

    public interface IAuthority
    {
        string[] Payload { get; }
        Claim[] OnVerify(Claim[] claims, JsonDocument payload, string identifier, out bool valid);
        Claim[] OnForward(Claim[] claims);
    }


    public interface IAuthenticator
    {
        Claim[] GetAuthenticationClaims(string identifier);
    }
}
