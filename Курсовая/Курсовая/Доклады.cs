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

    public partial class Доклады
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Доклады()
        {
            this.Название = "Семейные традиции";
            this.Направление = "Моя семья";
            this.Публикация = true;
            this.Денежный_взнос = 400m;
            this.Количество_минут = 9D;
            this.Баллы = 10;
        }


        [DisplayName(displayName: "ID доклада")]
        public int ID_доклада { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите название")]
        public string Название { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите направление")]
        public string Направление { get; set; }
        public bool Публикация { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите сумму денежного взноса")]
        [DisplayName(displayName: "Денежный взнос")]
        public decimal Денежный_взнос { get; set; }

        [DisplayName(displayName: "Количество минут")]
        public Nullable<double> Количество_минут { get; set; }

        public Nullable<int> Баллы { get; set; }

        [DisplayName(displayName: "ID докладчика")]
        public int ID_докладчика { get; set; }
    
        public virtual Докладчики Докладчики { get; set; }
    }
}
