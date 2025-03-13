using EF_CodeFirst.DB_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.DB_Context
{
    public partial class MokManagementContext : DbContext
    {


        public MokManagementContext():base("name=MokManagementContext")
        {
            //nlog = LogManager.GetCurrentClassLogger();
            //public Logger nlog;

            
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException dbupex)
            {
                //추가항목에 대한 예외처리를 하도록 합니다. 
                if (dbupex.InnerException != null)
                {
                    //nlog.Fatal(dbupex.InnerException);
                }

                throw;
            }
            catch (DbEntityValidationException dbEx)
            {

                if (dbEx.InnerException != null)
                {
                    //nlog.Fatal(dbEx.InnerException);
                }


                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //nlog.Debug(string.Format("Class: {0}, Property: {1}, Error: {2}",
                        //    validationErrors.Entry.Entity.GetType().FullName,
                        //    validationError.PropertyName,
                        //    validationError.ErrorMessage));
                    }
                }

                throw;  // You can also choose to handle the exception here...
            }
        }

        public virtual DbSet<MK_Info> MK_Info { get; set; }
        public virtual DbSet<MK_Info_Box> MK_Info_Box { get; set; }
        public virtual DbSet<MK_Info_SP> MK_Info_SP { get; set; }
        public virtual DbSet<MK_InOut> MK_InOut { get; set; }
        public virtual DbSet<MK_InOut_Log> MK_InOut_Log { get; set; }
        public virtual DbSet<MK_SubContract> MK_SubContract { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MK_Info>()
                .Property(e => e.MI_Name)
                .IsUnicode(false);

            modelBuilder.Entity<MK_Info>()
                .Property(e => e.MI_Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MK_Info>()
                .HasMany(e => e.MK_Info_Box)
                .WithRequired(e => e.MK_Info)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MK_Info>()
                .HasMany(e => e.MK_Info_SP)
                .WithRequired(e => e.MK_Info)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MK_Info>()
                .HasMany(e => e.MK_InOut_Log)
                .WithRequired(e => e.MK_Info)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MK_Info>()
                .HasMany(e => e.MK_InOut)
                .WithRequired(e => e.MK_Info)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MK_Info_Box>()
                .Property(e => e.MIB_Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MK_Info_Box>()
                .Property(e => e.MIB_Bigo)
                .IsUnicode(false);

            modelBuilder.Entity<MK_Info_Box>()
                .Property(e => e.MIB_FileName)
                .IsUnicode(false);

            modelBuilder.Entity<MK_Info_Box>()
                .Property(e => e.MIB_FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<MK_Info_SP>()
                .Property(e => e.MIS_Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MK_Info_SP>()
                .Property(e => e.MIS_Bigo)
                .IsUnicode(false);

            modelBuilder.Entity<MK_Info_SP>()
                .Property(e => e.MIS_FileName)
                .IsUnicode(false);

            modelBuilder.Entity<MK_Info_SP>()
                .Property(e => e.MIS_FilePath)
                .IsUnicode(false);

            modelBuilder.Entity<MK_InOut_Log>()
                .Property(e => e.IOL_Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MK_SubContract>()
                .Property(e => e.SC_Name)
                .IsUnicode(false);

            modelBuilder.Entity<MK_SubContract>()
                .Property(e => e.SC_Tel)
                .IsUnicode(false);

            modelBuilder.Entity<MK_SubContract>()
                .Property(e => e.SC_Address)
                .IsUnicode(false);

            modelBuilder.Entity<MK_SubContract>()
                .Property(e => e.SC_Bigo)
                .IsFixedLength();

            modelBuilder.Entity<MK_SubContract>()
                .HasMany(e => e.MK_InOut)
                .WithRequired(e => e.MK_SubContract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MK_SubContract>()
                .HasMany(e => e.MK_InOut_Log)
                .WithRequired(e => e.MK_SubContract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MK_SubContract>()
                .HasOptional(e => e.MK_SubContract1)
                .WithRequired(e => e.MK_SubContract2);
        }

     
    }
}
