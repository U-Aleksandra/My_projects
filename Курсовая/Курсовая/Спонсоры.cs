//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Курсовая
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Спонсоры
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Спонсоры()
        {
            this.Название_компании = "Областное государственное учреждение редакция газеты \"Родина Ильича\"";
            this.Представитель = "Николаев В. Д.";
            this.Спонсорский_пакет = "Бронзовый спонсор";
            this.Сумма = 30000m;
        }

        [Required(ErrorMessage = "Пожалуйста, введите ID спонсора")]
        [DisplayName(displayName: "ID спонсора")]
        public int ID_спонсора { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название компании")]
        [DisplayName(displayName: "Название компании")]
        public string Название_компании { get; set; }
        public string Представитель { get; set; }

        [DisplayName(displayName: "Спонсорский пакет")]
        public string Спонсорский_пакет { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите сумму")]
        public decimal Сумма { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ID конференции")]
        [DisplayName(displayName: "ID конференции")]
        public int ID_конференции { get; set; }
    
        public virtual Конференция Конференция { get; set; }
    }
}
