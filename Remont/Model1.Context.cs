﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProgramEntities11 : DbContext
    {
        public ProgramEntities11()
            : base("name=ProgramEntities11")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Вид> Вид { get; set; }
        public virtual DbSet<Доп_материал> Доп_материал { get; set; }
        public virtual DbSet<Заявка1> Заявка1 { get; set; }
        public virtual DbSet<Материал> Материал { get; set; }
        public virtual DbSet<Оргтехника> Оргтехника { get; set; }
        public virtual DbSet<Отчёт> Отчёт { get; set; }
        public virtual DbSet<Пользователь> Пользователь { get; set; }
        public virtual DbSet<Статус> Статус { get; set; }
        public virtual DbSet<Тип_пользователя> Тип_пользователя { get; set; }
    }
}