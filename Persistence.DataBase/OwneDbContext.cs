using Microsoft.EntityFrameworkCore;
//using Persistence.DataBase.Moldels;
using Persistence.DataBase.RealEstateMoldels;
using Persistence.DataBase.RealEstateMoldels.Dto;

namespace OwnerDataExt
{
    public class OwneDbContext : DbContext
    {
        string StringConnection;

        public virtual DbSet<Prop_Proj_Loc_Dto> Prop_Proj_Loc_Dto { get; set; }
        public DbSet<RealEstatePaymentFrecuencyModel> RealEstatePaymentFrecuency { get; set; }
        public DbSet<RealEstatePropertyModel> RealEstateProperty { get; set; }
        public DbSet<RealEstateLocationModel> RealEstateLocation { get; set; }
        public DbSet<RealEstatePropertyTypeModel> RealEstatePropertyType { get; set; }
        public DbSet<RealEstateProjectTypeModel> RealEstateProjectType { get; set; }


        public DbSet<PaymentMethodModel> PaymentMethod { get; set; }
        public DbSet<RealEstateRegistryModel> RealEstateRegistry { get; set; }
        public DbSet<RealEstatePropertyOBenefitModel> RealEstatePropertyOBenefit{ get; set; }

        public DbSet<RealEstateContactInfoModel> RealEstateContactInfo { get; set; }
        public DbSet<RealEstatePhoneTypeModel> RealEstatePhoneType { get; set; }
        public DbSet<RealEstateBanksTransferenceModel> RealEstateBanksTransference { get; set; }
        public DbSet<RealEstatedBankModel> RealEstatedBank { get; set; }
        public DbSet<RealEstateRegOwneInfoModel> RealEstateRegOwneInfo { get; set; }
        public DbSet<RealEstateAnualBenefitModel> RealEstateAnualBenefit { get; set; }
        public DbSet<RealEstateTransactionTypeModel> RealEstateTransactionType { get; set; }



        public DbSet<RealEstateTransactionModel> RealEstateTransaction { get; set; }
        public DbSet<RealStateDocumentsModel> RealStateDocuments { get; set; }

        public DbSet<RealStateDocumentsTypeModel> RealStateDocumentsType { get; set; }
        public DbSet<RealEstateDocumentSource> RealEstateDocumentSource { get; set; }


        public DbSet<RealEstatePaymentHistoryModel> RealEstatePaymentHistory { get; set; }



        public OwneDbContext()
        {
            Connection con = new Connection(true);
            StringConnection = con.GetConection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(StringConnection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prop_Proj_Loc_Dto>().HasNoKey();
            //modelBuilder.Entity<RealEstatePropertyTypeModel>()
            //.HasOne<RealEstateProjectTypeModel>(prot => prot.RealEstateProjectType)
            //.WithMany(pjt => pjt.RealEstatePropertyType)
            //.HasForeignKey(prot => prot.RealEstateProjectTypeID);

            modelBuilder.Entity<RealEstatePropertyOBenefitModel>().HasKey(pr => new { pr.RealEstateAnualBenefitID, pr.RealEstatePropertyID });


        //    modelBuilder.Entity<RealEstatePropertyOBenefitModel>()
        //        .HasOne<RealEstatePropertyModel>(pr => pr.RealEstateProperty)
        //        .WithMany(p => p.RealEstatePropertyOBenefit)
        //        .HasForeignKey(pr => pr.RealEstatePropertyID);

        //    modelBuilder.Entity<RealEstatePropertyOBenefitModel>()
        //                   .HasOne<RealEstateAnualBenefitModel>(pr => pr.RealEstateAnualBenefit)
        //                   .WithMany(p => p.RealEstatePropertyOBenefit)
        //                   .HasForeignKey(pr => pr.RealEstateAnualBenefitID);
       }


    }
}
