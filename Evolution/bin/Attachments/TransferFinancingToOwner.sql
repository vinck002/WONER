/*Transferir pago*/
set nocount on
DECLARE @StartDate1 date= convert(varchar,year(getdate()))+'-'+convert(varchar,month(getdate()))+'-01',
@StartDate15 date=convert(varchar,year(getdate()))+'-'+convert(varchar,month(getdate()))+'-15',
@LastDate date = dateadd(dd,day(getdate()) * -1,getdate())
------------------------------------------------------------------------------------------------
INSERT  INTO multifinance
SELECT 
Id,Agreementid,signerfirstname,signerlastname,amount,term,apr,initialpmt,periodicpmt,
REMARKS = 'Original Charge_Start= ' +convert(varchar,CHARGE_START,101) +' From DTS',
ID_PAYMENTTYPE,ID_CURRENCY,CONTRACT_SEQUENCE,CC_NUMBER,EXPIRATION_DATE,SECRET_CODE,
CHARGE_START = CASE WHEN CHARGE_START > @LastDate THEN CHARGE_START ELSE /**/ case when DAY_OF_CHARGE = 1 then @StartDate1 else @StartDate15 end /**/END,
CHARGE_END,FROZEN_START,FROZEN_END,ID_PAYMENTMETHOD,DAY_OF_CHARGE,UPGRADE,CREATION_DATE,
ACTIVE,ID_USER,ID_CONTRACTCHARGE,FREQUENCY,Sequence,OLD_CONTRACT_SEQUENCE,CHARGE_START_SOURCE,SourceID,
Loan_Amount,MultiFinanceHistoryID,CHARGE_END_PAYOFF,BillingAddress,BillingCity,BillingZipCode,BillingCountryID,
BillingStateID,BuyerID,PreviousMultifinanceID,DTSMultiFinanceID=Id
FROM DTS.DBO.MultiFinance M
WHERE M.Agreementid in (select C.Agreementid from CompanyContract C where C.Active = 1 and C.CompanyPercentID not in(6,7,8,11) )
and not exists (select MF.id from MultiFinance Mf where MF.Id = M.Id)
and M.ACTIVE =1
and isnull(M.CHARGE_END_PAYOFF,M.CHARGE_END) > @LastDate
and M.apr > 0
--order by  M.Id
--==================================================================================================


