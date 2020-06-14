using System.IdentityModel.Tokens.Jwt;

namespace DoctorsHelper.ArterialPressure.BL.Jwt
{
    /// <summary> Конфигурация <see cref="JwtSecurityToken"/> </summary>
    public class JwtSecurityTokenConfiguration
    {
        /// <summary> Секрет </summary>
        public string Secret { get; set; }
    }
}
