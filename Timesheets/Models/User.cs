using System;

namespace Timesheets.Models
{
    /// <summary>
    /// Информация о ползователе системы
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
