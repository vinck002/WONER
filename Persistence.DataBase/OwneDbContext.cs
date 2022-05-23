using Microsoft.EntityFrameworkCore;
//using Persistence.DataBase.Moldels;
using Persistence.DataBase.RealEstateMoldels;
using Persistence.DataBase.RealEstateMoldels.Dto;
using Persistence.DataBase.Web;
using Services.RealEstate.Owner.Dto;

namespace OwnerDataExt
{
    public class OwneDbContext : DbContext
    {
        string StringConnection;
       
        
        public DbSet<RealEstateFPaymentPlanModel> RealEstateFPaymentPlan { get; set; }
        public DbSet<RealEstatePmtTransactionModel> RealEstatePmtTransaction { get; set; }
        //public DbSet<RealEstateFPaymentMadeModel> RealEstateFPaymentMade { get; set; }

        public DbSet<CurrencyRatedModel> CurrencyRate { get; set; }
        public virtual DbSet<RealEstateProcessContractDto> RealEstateProcessContractDto { get; set; }
        public virtual DbSet<OwnerInfoDto> OwnerInfoDto { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }
        public DbSet<RealEstateHoldInstallment> RealEstateHoldInstallment { get; set; }
        public DbSet<RealEstatePaymentFrecuencyModel> RealEstatePaymentFrecuency { get; set; }
        public DbSet<RealEstatePropertyModel> RealEstateProperty { get; set; }
        public DbSet<RealEstateLocationModel> RealEstateLocation { get; set; }
        public DbSet<RealEstatePropertyTypeModel> RealEstatePropertyType { get; set; }
        public DbSet<RealEstateProjectTypeModel> RealEstateProjectType { get; set; }


        public DbSet<PaymentMethodModel> PaymentMethod { get; set; }
        public DbSet<RealEstateRegistryModel> RealEstateRegistry { get; set; }

        public DbSet<RealEstateContactInfoModel> RealEstateContactInfo { get; set; }
        public DbSet<RealEstateContactTypeModel> RealEstateContactType { get; set; }
        public DbSet<RealEstateBankTranferenceModel> RealEstateBanksTransference { get; set; }
        public DbSet<RealEstatedBankModel> RealEstatedBank { get; set; }
        public DbSet<RealEstateRegOwneInfoModel> RealEstateRegOwneInfo { get; set; }
        public DbSet<RealEstateAnualBenefitModel> RealEstateAnualBenefit { get; set; }
        public DbSet<RealEstateTransactionTypeModel> RealEstateTransactionType { get; set; }

        public DbSet<RealEstateConfig> RealEstateConfig { get; set; }

        public DbSet<RealEstateTransactionModel> RealEstateTransaction { get; set; }
        public DbSet<RealEstateDocumentsModel> RealEstateDocuments { get; set; }

        //public DbSet<RealEstateDocumentsTypeModel> RealEstateDocumentsType { get; set; }
        //public DbSet<RealEstateDocumentSource> RealEstateDocumentSource { get; set; }


        public DbSet<RealEstatePaymentHistoryModel> RealEstatePaymentHistory { get; set; }



        public OwneDbContext()
        {
            
            Connection con = new Connection(false); //true para trabajar en DEMO, false= Live
            StringConnection = con.GetConection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(StringConnection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OwnerInfoDto>().HasNoKey();
            modelBuilder.Entity<RealEstateProcessContractDto>().HasNoKey();

            //modelBuilder.Entity<RealEstatePropertyOBenefitModel>().HasKey(pr => new { pr.RealEstateAnualBenefitID, pr.RealEstatePropertyID });

            //modelBuilder.Entity<RealEstatePropertyOBenefitModel>()
            //               .HasOne<RealEstateAnualBenefitModel>(pr => pr.RealEstateAnualBenefit)
            //               .WithMany(p => p.RealEstatePropertyOBenefit)
            //               .HasForeignKey(pr => pr.RealEstateAnualBenefitID);


            //modelBuilder.Entity<RealEstateAnualBenefitModel>()
            //    .HasOne<UserModel>(usr => usr.User)
            //    .WithMany(f => f.RealEstateAnualBenefit)
            //    .HasForeignKey(k => k.UserId);

            //modelBuilder.Entity<RealEstatePropertyModel>()
            //.HasOne<RealEstateLocationModel>(l => l.RealEstateLocation)
            //.WithMany(g => g.RealEstateProperty)
            //.HasForeignKey(s => s.RealEstateLocationID);

        }


    }
}
