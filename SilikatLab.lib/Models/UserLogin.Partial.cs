using System.ComponentModel.DataAnnotations.Schema;

namespace SilikatLab.lib.Models
{
    public partial class UserLogin
    {
        /// <summary> Уровень доступа в строке </summary>
        [NotMapped]
        public string AccessLevelString =>
            (Access) switch
            {
                AccessLevel.None => "Просмотр",
                AccessLevel.Edit => "Редактирование",
                AccessLevel.Control => "Управление",
                _ => "Неизвестный",
            };
    }
}