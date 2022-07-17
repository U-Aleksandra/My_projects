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

    public partial class Место_проведения
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Место_проведения()
        {
            this.Адрес = "ул. Северный Венец, 32";
            this.Название = "Ульяновский государственный технический университет";
            this.Стоимость_аренды = 0m;
            this.Зона = new HashSet<Зона>();
        }


        [DisplayName(displayName: "ID места проведения")]
        public int ID_места_проведения { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите адрес")]
        public string Адрес { get; set; }
        public string Название { get; set; }

        [DisplayName(displayName: "Стоимость аренды")]
        public Nullable<decimal> Стоимость_аренды { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите дату аренды")]
        [DisplayName(displayName: "Дата аренды")]
        [DataType(DataType.Date)]
        public System.DateTime Дата_аренды { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ID конференции")]
        [DisplayName(displayName: "ID конференции")]
        public Nullable<int> ID_конференции { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Зона> Зона { get; set; }
        public virtual Конференция Конференция { get; set; }
    }
}
