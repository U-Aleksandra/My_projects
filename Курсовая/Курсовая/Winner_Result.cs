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
    using System.ComponentModel;

    public partial class Winner_Result
    {
        public string Фамилия { get; set; }
        public string Имя { get; set; }

        [DisplayName(displayName:"Учебное заведение")]
        public string Учебное_заведение { get; set; }
        public string Название { get; set; }
        public string Направление { get; set; }
        public Nullable<int> Баллы { get; set; }
    }
}
