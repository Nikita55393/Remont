//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Remont
{
    using System;
    using System.Collections.Generic;
    
    public partial class Отчёт
    {
        public int Код_отчёта { get; set; }
        public string Количество_гот_заяврок { get; set; }
        public string Время_выполнения { get; set; }
        public Nullable<int> Код_заявки { get; set; }
        public Nullable<int> Код_доп { get; set; }
    
        public virtual Доп_материал Доп_материал { get; set; }
        public virtual Заявка1 Заявка1 { get; set; }
    }
}
