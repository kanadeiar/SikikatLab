using System.ComponentModel.DataAnnotations;
using SilikatLab.lib.Models.Base;

namespace SilikatLab.lib.Models
{
    /// <summary> Логин пользователя </summary>
    public class UserLogin : Entity
    {
        private string _Login;

        /// <summary> Логин пользователя </summary>
        [Required, MaxLength(30)]
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        private string _Password;

        /// <summary> Пароль </summary>
        [Required, MaxLength(20)]
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }
        /// <summary> Пользователь - лаборант </summary>
        public virtual Laboratorian Laboratorian { get; set; }

        private AccessLevel _Access;

        /// <summary> Уровень доступа </summary>
        public AccessLevel Access
        {
            get => _Access;
            set => Set(ref _Access, value);
        }
        
        /// <summary> Уровень доступа </summary>
        public enum AccessLevel
        {
            None = 0,
            Edit,
            Control,
        }
    }
}
