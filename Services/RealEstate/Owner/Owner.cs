using Microsoft.EntityFrameworkCore;
using OwnerDataExt;
using Persistence.DataBase.RealEstateMoldels;
using Persistence.DataBase.RealEstateMoldels.Dto;
using Services.RealEstate.Owner.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RealEstate.Owner
{
    public class Owner
    {
        public PaymentMethodFrequency PaymentMethodFrequency;
       public InitialConfigProcessDto LoadConfiguration()
        {
            using (var ctx = new OwneDbContext())
            {
                InitialConfigProcessDto config = new InitialConfigProcessDto();
                config.RealEstateConfig = ctx.RealEstateConfig.FirstOrDefault();
                config.realEstatePropertyTypeModels = ctx.RealEstatePropertyType.ToList();
                return config;
            }

         
        }

        //**********************************************methods for OWNER BENEFIT ComboS****************************************
        public PaymentMethodFrequency GetPaymentMethodFrequency()
        {
            using (var ctx = new OwneDbContext())
            {
                PaymentMethodFrequency = new PaymentMethodFrequency();
                PaymentMethodFrequency.PaymentMethod = ctx.PaymentMethod.ToList();
                PaymentMethodFrequency.RealEstatePaymentFrecuency = ctx.RealEstatePaymentFrecuency.ToList();
                PaymentMethodFrequency.RealEstateContactType = ctx.RealEstateContactType.ToList(); // se agrego para cargar esta informacion de "CONTACT" para contact type
                return PaymentMethodFrequency;
            }
        }


        //*******************RETORNA LISTA DE PROPIEDADES QUE NO ESTEN VINCULADAS A UN CONTRATO REAL ESTATE(OWNER)***********************************
        public List<RealEstatePropertyModel> GetPropertyAndType()
        {
            using (var ctx = new OwneDbContext())
            {
               
                var lstAvailableProperties = ctx.RealEstateProperty.FromSqlRaw("SP_RealEstateAvailableProperty").ToList();
                return lstAvailableProperties;
            }
        }
        //****************************************************************************************************************************************************
        public List<RealEstateProjectTypeModel> GetPropertyAndTypeByID(int Id)
        {
            using (var ctx = new OwneDbContext())
            {

                var properties = ctx.RealEstateProjectType
                    .Include(pt => pt.RealEstatePropertyType)
                     .ThenInclude(pro => pro.RealEstateProperty)
                      .ThenInclude(loc => loc.RealEstateLocation)
                     .Where(x => x.RealEstateProjectTypeID == Id)
                    .ToList();

                return properties;
            }
        }

     
        //*****************************************EF-CORE UPDATE O INSERT  REGISTRY ENTITIES ************************************************************

        public void InsertOrUpdate1(RealEstateRegistryModel entity)
        {

            using (var ctx = new OwneDbContext())
            {

                entity.RealEstateAnualBenefit.ToList().ForEach(y =>
                {
                    ctx.ChangeTracker.TrackGraph(y, e =>
                    {
                        if (e.Entry.IsKeySet)
                        {
                         //a.Add(e.Entry.State.ToString());
                         //= EntityState.Unchanged;
                        }
                        else
                        {
                            e.Entry.State = EntityState.Added;
                        }
                    });
                }

                );
                var result = ctx.Update(entity);
               ctx.SaveChanges();
                
            }
         
        }
        //*****************************************EF-CORE UPDATE O INSERT anual Benefit  ************************************************************

        public void InsertOrUpdateBenefit(RealEstateAnualBenefitModel entity)
        {
            using (var ctx = new OwneDbContext())
            {
                ctx.Update(entity);
                ctx.SaveChanges();
            }

        }

        //*****************************************Remove List Property************************************************************
        public void RemoveEntity(DbContext ctx, List<RealEstateAnualBenefitModel> entities)
        {
            ctx.RemoveRange(entities);
            ctx.SaveChanges();
        }

        public void RemoveEntity1(List<RealEstateAnualBenefitModel> entities)
        {
            using (var ctx = new OwneDbContext())
            {
                ctx.RemoveRange(entities);
                ctx.SaveChanges();
            }
           
        }


        //**************************************************Buscar los contratos por ID y retornar enTidad registry e incluir todas las entidades relacionada
        public RealEstateRegistryModel GetRealEstateRegistryById1(Int64 Id)//para las transacciones
        {
            using (var ctx = new OwneDbContext())
            {
                var OwnerRegistry = ctx.RealEstateRegistry.Where(x => x.RealEstateRegistryID == Id && x.Active == 1)
                  .Include(o => o.RealEstateRegOwneInfo)
                  .Include(t => t.RealEstateBanksTransference)
                  .Include(ben => ben.RealEstateAnualBenefit).ThenInclude(p => p.RealEstateProperty)
                  .Include(Ab => Ab.RealEstateAnualBenefit).ThenInclude(tr => tr.RealEstateTransaction).ThenInclude(trt => trt.RealEstateTransactionType)
                  .Include(i => i.RealEstateContactInfo).ThenInclude(ct => ct.RealEstateContactType)
                  .Include(d => d.RealEstateAnualBenefit).ThenInclude(ttr => ttr.RealEstateTransaction).ThenInclude(doc => doc.RealEstateDocuments)
                  .Include(pf => pf.RealEstateAnualBenefit).ThenInclude(pfr => pfr.RealEstatePaymentFrecuency)
                  .Include(benH=> benH.RealEstateAnualBenefit).ThenInclude(Hld=>Hld.RealEstateHoldInstallment)
                  
                  //.Include(usr => usr.RealEstateAnualBenefit).ThenInclude(u => u.User)
                  .FirstOrDefault();
                return OwnerRegistry;

              
            }
        }
        public RealEstateRegistryModel GetRealEstateRegistryById(Int64 Id)
        {
            using (var ctx = new OwneDbContext())
            {
                var OwnerRegistry = ctx.RealEstateRegistry.Where(x => x.RealEstateRegistryID == Id )
                  .Include(o => o.RealEstateRegOwneInfo)
                  .Include(t => t.RealEstateBanksTransference)
                  .Include(ben => ben.RealEstateAnualBenefit).ThenInclude(p => p.RealEstateProperty)
                  .Include(Ab => Ab.RealEstateAnualBenefit).ThenInclude(tr => tr.RealEstateTransaction).ThenInclude(trt => trt.RealEstateTransactionType)
                  .Include(i => i.RealEstateContactInfo).ThenInclude(ct => ct.RealEstateContactType)
                  .Include(d => d.RealEstateAnualBenefit).ThenInclude(ttr => ttr.RealEstateTransaction).ThenInclude(doc => doc.RealEstateDocuments)
                  .Include(pf => pf.RealEstateAnualBenefit).ThenInclude(pfr => pfr.RealEstatePaymentFrecuency)
                  .Include(benH => benH.RealEstateAnualBenefit).ThenInclude(Hld => Hld.RealEstateHoldInstallment)
                  .Include(FFplan => FFplan.RealEstateAnualBenefit).ThenInclude(fp => fp.RealEstateFPaymentPlan)
                                                                        .ThenInclude(prmt=>prmt.RealEstatePmtTransaction)
                                                                           //.ThenInclude(traM=>traM.RealEstateFPaymentMade) //por si acaso
                  //.Include(usr => usr.RealEstateAnualBenefit).ThenInclude(u => u.User)
                  .FirstOrDefault();
                return OwnerRegistry;


            }
        }




        //**********************************************************************************************************************************

        //---------------------------*********************SEARCHIN OWNER con la informacion del REOwner*****************************************
        public  List<OwnerInfoDto> SearhOwnerInfo(OwnerInfoDto _ownerInfoDto,int opc = 0, string property = "")
        {
        using (var ctx= new OwneDbContext())
            {
                var result = ctx.OwnerInfoDto.FromSqlRaw($"RealEstateSerchOwner '{_ownerInfoDto.DocumentID}','{_ownerInfoDto.Name}','{_ownerInfoDto.Name}','{_ownerInfoDto.ContractReference}','{_ownerInfoDto.PropertyDescription}',{opc}")
                    .ToList();
                return result;
            }
        }

        ////---------------------------*********************pagar los pago Futuros seccion de pagos formulario registry*****************************************
        public List<RealEstateFPaymentPlanModel> PaidFutures(List<RealEstatePmtTransactionModel> fpayment,Int64 anualBenefitID)
        {
            using (var ctx = new OwneDbContext())
            {
                fpayment.ToList().ForEach(x => {
                    ctx.RealEstatePmtTransaction.Add(x);
                   } 
                );
                ctx.SaveChanges();

                return ctx.RealEstateFPaymentPlan.Where(x => x.Active == 1 && x.RealEstateAnualBenefitID == anualBenefitID)
                  .Include(Fpm=>Fpm.RealEstatePmtTransaction)
                 .ToList();

            }
        }

        public List<RealEstatePropertyTypeModel> getPropertyFilter()
        {
            using (var ctx = new OwneDbContext())
            {
                List<RealEstatePropertyTypeModel> result = ctx.RealEstatePropertyType
                    .Include(x=>x.RealEstateProperty)
                    .ToList();
                return result;
            }
        }
        //*-****************************************Get Anual Benefit*************************************************

        public RealEstateAnualBenefitModel GetAnualBenefit(Int64 SelectedAnualBenefit)
        {
            using (var ctx = new OwneDbContext())
            {
                RealEstateAnualBenefitModel result = ctx.RealEstateAnualBenefit
                    .Where(h=>h.RealEstateAnualBenefitID == SelectedAnualBenefit)
                    .Include(x=>x.RealEstateProperty)
                    .Include(t=>t.RealEstateTransaction)
                        .ThenInclude(tt=>tt.RealEstateTransactionType)
                    .FirstOrDefault();
                return result;
            }
        }



        //*-****************************************Get transaction type*************************************************

        public List<RealEstateTransactionTypeModel> getTransType()
        {
            using (var ctx = new OwneDbContext())
            {
                List<RealEstateTransactionTypeModel> result = ctx.RealEstateTransactionType
                    .ToList();
                return result;
            }
        }

        //*-****************************************storeProcedure*************************************************


        //*******************RETORNA LISTA DE PROPIEDADES QUE NO ESTEN VINCULADAS A UN CONTRATO REAL ESTATE(OWNER)***********************************
        public List<RealEstateProcessContractDto> GetAllRealEstateContractProperty(int year, int PropertyType, string propertyDesc,string ContractRef)
        {
            using (var ctx = new OwneDbContext())
            {

                var lst = ctx.RealEstateProcessContractDto.FromSqlRaw($"SP_RealEstateGetAllContractProperty_V1 {year},{PropertyType},'{propertyDesc}','{ContractRef}' ").ToList();
                return lst;
            }
        }

        //*******************RETORNA LISTA DE USUARIOS***********************************
        public List<UserModel> GetAllUsers()
            {
            using (var ctx = new OwneDbContext())
            {

                var lst = ctx.Users.FromSqlRaw($"realEstateGetUsers ").ToList();
                return lst;
            }
        }

        //*******************RETORNA LISTA DE USUARIOS***********************************
        public List<UserModel> GetAuthorizationkey(string Pass = "null")
        {
            using (var ctx = new OwneDbContext())
            {

                var lst = ctx.Users.FromSqlRaw($"SP_RealEstateAuthorizationkey '{Pass}'").ToList();
                return lst;
            }
        }
        //****************************************************************************************************************************************************
    }
}
