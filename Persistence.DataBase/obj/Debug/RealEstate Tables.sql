
CREATE TABLE [RealEstatedBank] (
    [RealEstatedBankID] int NOT NULL IDENTITY,
    [BankName] nvarchar(max) NULL,
    [BankAddress] nvarchar(max) NULL,
    [SwiftCode] nvarchar(max) NULL,
    [RoutingCode] nvarchar(max) NULL,
    [CretionDate] datetime2 NOT NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_RealEstatedBank] PRIMARY KEY ([RealEstatedBankID])
);

GO

CREATE TABLE [RealEstateDocumentSource] (
    [RealEstateDocumentSourceID] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_RealEstateDocumentSource] PRIMARY KEY ([RealEstateDocumentSourceID])
);

GO

CREATE TABLE [RealEstateLocation] (
    [RealStateLocationID] bigint NOT NULL IDENTITY,
    [description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_RealEstateLocation] PRIMARY KEY ([RealStateLocationID])
);

GO

CREATE TABLE [RealEstatePaymentFrecuency] (
    [RealEstatePaymentFrecuencyID] bigint NOT NULL IDENTITY,
    [description] nvarchar(max) NULL,
    [FrecuenceValue] int NOT NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_RealEstatePaymentFrecuency] PRIMARY KEY ([RealEstatePaymentFrecuencyID])
);

GO

CREATE TABLE [RealEstatePhoneType] (
    [RealEstatePhoneTypeID] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_RealEstatePhoneType] PRIMARY KEY ([RealEstatePhoneTypeID])
);

GO

CREATE TABLE [RealEstateProjectType] (
    [RealEstateProjectTypeID] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_RealEstateProjectType] PRIMARY KEY ([RealEstateProjectTypeID])
);

GO

CREATE TABLE [RealEstateTransactionType] (
    [RealEstateTransactionTypeID] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Type] nvarchar(2) NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_RealEstateTransactionType] PRIMARY KEY ([RealEstateTransactionTypeID])
);

GO

CREATE TABLE [RealStateDocumentsType] (
    [RealStateDocumentsTypeID] int NOT NULL IDENTITY,
    [Description] nvarchar(30) NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_RealStateDocumentsType] PRIMARY KEY ([RealStateDocumentsTypeID])
);

GO

CREATE TABLE [RealEstateRegistry] (
    [RealEstateRegistryID] bigint NOT NULL IDENTITY,
    [RegistryDescription] nvarchar(max) NULL,
    [Reference] nvarchar(max) NULL,
    [CreationDate] datetime2 NOT NULL,
    [Active] int NOT NULL,
    [UserId] bigint NOT NULL,
    [RealEstatePaymentFrecuencyID] bigint NOT NULL,
    CONSTRAINT [PK_RealEstateRegistry] PRIMARY KEY ([RealEstateRegistryID]),
    CONSTRAINT [FK_RealEstateRegistry_RealEstatePaymentFrecuency_RealEstatePaymentFrecuencyID] FOREIGN KEY ([RealEstatePaymentFrecuencyID]) REFERENCES [RealEstatePaymentFrecuency] ([RealEstatePaymentFrecuencyID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstatePropertyType] (
    [RealEstatePropertyTypeID] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    [RealEstateProjectTypeID] bigint NOT NULL,
    CONSTRAINT [PK_RealEstatePropertyType] PRIMARY KEY ([RealEstatePropertyTypeID]),
    CONSTRAINT [FK_RealEstatePropertyType_RealEstateProjectType_RealEstateProjectTypeID] FOREIGN KEY ([RealEstateProjectTypeID]) REFERENCES [RealEstateProjectType] ([RealEstateProjectTypeID]) ON DELETE CASCADE
);

GO

CREATE TABLE [PaymentMethod] (
    [PaymentMethodID] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    [RealEstateRegistryModelRealEstateRegistryID] bigint NULL,
    CONSTRAINT [PK_PaymentMethod] PRIMARY KEY ([PaymentMethodID]),
    CONSTRAINT [FK_PaymentMethod_RealEstateRegistry_RealEstateRegistryModelRealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryModelRealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [RealEstateAnualBenefit] (
    [RealEstateAnualBenefitID] bigint NOT NULL IDENTITY,
    [Monto] decimal(18,2) NOT NULL,
    [Active] int NOT NULL,
    [Date] datetime2 NOT NULL,
    [RealEstateRegistryID] bigint NOT NULL,
    CONSTRAINT [PK_RealEstateAnualBenefit] PRIMARY KEY ([RealEstateAnualBenefitID]),
    CONSTRAINT [FK_RealEstateAnualBenefit_RealEstateRegistry_RealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstateBanksTransference] (
    [RealEstateBanksTransferenceID] bigint NOT NULL IDENTITY,
    [AccountName] nvarchar(max) NULL,
    [AccountNumber] int NOT NULL,
    [BeneficiaryAddress] nvarchar(max) NULL,
    [RealStateRegistryID] bigint NOT NULL,
    [RealEstatedBankID] int NOT NULL,
    [IntermediaryBank] nvarchar(max) NULL,
    [RealEstateRegistryModelRealEstateRegistryID] bigint NULL,
    CONSTRAINT [PK_RealEstateBanksTransference] PRIMARY KEY ([RealEstateBanksTransferenceID]),
    CONSTRAINT [FK_RealEstateBanksTransference_RealEstateRegistry_RealEstateRegistryModelRealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryModelRealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_RealEstateBanksTransference_RealEstatedBank_RealEstatedBankID] FOREIGN KEY ([RealEstatedBankID]) REFERENCES [RealEstatedBank] ([RealEstatedBankID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstateContactInfo] (
    [RealStateContactInfoID] bigint NOT NULL IDENTITY,
    [Phone] nvarchar(max) NULL,
    [Extension] int NOT NULL,
    [Status] int NOT NULL,
    [RealEstatePhoneTypeID] int NOT NULL,
    [RealEstateRegistryID] bigint NOT NULL,
    CONSTRAINT [PK_RealEstateContactInfo] PRIMARY KEY ([RealStateContactInfoID]),
    CONSTRAINT [FK_RealEstateContactInfo_RealEstatePhoneType_RealEstatePhoneTypeID] FOREIGN KEY ([RealEstatePhoneTypeID]) REFERENCES [RealEstatePhoneType] ([RealEstatePhoneTypeID]) ON DELETE CASCADE,
    CONSTRAINT [FK_RealEstateContactInfo_RealEstateRegistry_RealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstatePaymentHistory] (
    [RealEstatePaymentHistory] bigint NOT NULL IDENTITY,
    [Amount] decimal(18,2) NOT NULL,
    [EfectiveDate] datetime2 NOT NULL,
    [RealEstateRegistryID] bigint NOT NULL,
    [processCode] bigint NOT NULL,
    [Reference] nvarchar(max) NULL,
    [UserID] bigint NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_RealEstatePaymentHistory] PRIMARY KEY ([RealEstatePaymentHistory]),
    CONSTRAINT [FK_RealEstatePaymentHistory_RealEstateRegistry_RealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstateRegOwneInfo] (
    [RealStateRegOwneInfoID] bigint NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [RealEstateRegistryID] bigint NOT NULL,
    CONSTRAINT [PK_RealEstateRegOwneInfo] PRIMARY KEY ([RealStateRegOwneInfoID]),
    CONSTRAINT [FK_RealEstateRegOwneInfo_RealEstateRegistry_RealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstateTransaction] (
    [RealEstateTransactionID] bigint NOT NULL IDENTITY,
    [TransDate] datetime2 NOT NULL,
    [Description] nvarchar(max) NULL,
    [Reference] nvarchar(25) NULL,
    [UserID] bigint NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    [Active] int NOT NULL,
    [RealEstateRegistryID] bigint NOT NULL,
    [RealEstateTransactionTypeID] int NOT NULL,
    CONSTRAINT [PK_RealEstateTransaction] PRIMARY KEY ([RealEstateTransactionID]),
    CONSTRAINT [FK_RealEstateTransaction_RealEstateRegistry_RealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_RealEstateTransaction_RealEstateTransactionType_RealEstateTransactionTypeID] FOREIGN KEY ([RealEstateTransactionTypeID]) REFERENCES [RealEstateTransactionType] ([RealEstateTransactionTypeID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealStateDocuments] (
    [RealStateDocumentsID] bigint NOT NULL IDENTITY,
    [FileName] nvarchar(max) NULL,
    [FilePath] nvarchar(max) NULL,
    [RealEstateRegistryID] bigint NOT NULL,
    [ReferenceID] bigint NOT NULL,
    [RealStateDocumentsTypeID] int NOT NULL,
    [RealEstateDocumentSourceID] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_RealStateDocuments] PRIMARY KEY ([RealStateDocumentsID]),
    CONSTRAINT [FK_RealStateDocuments_RealEstateDocumentSource_RealEstateDocumentSourceID] FOREIGN KEY ([RealEstateDocumentSourceID]) REFERENCES [RealEstateDocumentSource] ([RealEstateDocumentSourceID]) ON DELETE CASCADE,
    CONSTRAINT [FK_RealStateDocuments_RealEstateRegistry_RealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_RealStateDocuments_RealStateDocumentsType_RealStateDocumentsTypeID] FOREIGN KEY ([RealStateDocumentsTypeID]) REFERENCES [RealStateDocumentsType] ([RealStateDocumentsTypeID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstateProperty] (
    [RealStatePropertyID] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    [RealEstatePTypeID] bigint NOT NULL,
    [RealEstatePropertyTypeID] bigint NULL,
    [RealStateLocationID] bigint NOT NULL,
    [RealEstateLocationRealStateLocationID] bigint NULL,
    CONSTRAINT [PK_RealEstateProperty] PRIMARY KEY ([RealStatePropertyID]),
    CONSTRAINT [FK_RealEstateProperty_RealEstateLocation_RealEstateLocationRealStateLocationID] FOREIGN KEY ([RealEstateLocationRealStateLocationID]) REFERENCES [RealEstateLocation] ([RealStateLocationID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_RealEstateProperty_RealEstatePropertyType_RealEstatePropertyTypeID] FOREIGN KEY ([RealEstatePropertyTypeID]) REFERENCES [RealEstatePropertyType] ([RealEstatePropertyTypeID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [RealEstatePropertyRegistry] (
    [RealEstateRegistryID] bigint NOT NULL,
    [RealEstatePropertyID] bigint NOT NULL,
    [Active] int NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_RealEstatePropertyRegistry] PRIMARY KEY ([RealEstateRegistryID], [RealEstatePropertyID]),
    CONSTRAINT [FK_RealEstatePropertyRegistry_RealEstateProperty_RealEstatePropertyID] FOREIGN KEY ([RealEstatePropertyID]) REFERENCES [RealEstateProperty] ([RealStatePropertyID]) ON DELETE CASCADE,
    CONSTRAINT [FK_RealEstatePropertyRegistry_RealEstateRegistry_RealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_PaymentMethod_RealEstateRegistryModelRealEstateRegistryID] ON [PaymentMethod] ([RealEstateRegistryModelRealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstateAnualBenefit_RealEstateRegistryID] ON [RealEstateAnualBenefit] ([RealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstateBanksTransference_RealEstateRegistryModelRealEstateRegistryID] ON [RealEstateBanksTransference] ([RealEstateRegistryModelRealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstateBanksTransference_RealEstatedBankID] ON [RealEstateBanksTransference] ([RealEstatedBankID]);

GO

CREATE INDEX [IX_RealEstateContactInfo_RealEstatePhoneTypeID] ON [RealEstateContactInfo] ([RealEstatePhoneTypeID]);

GO

CREATE INDEX [IX_RealEstateContactInfo_RealEstateRegistryID] ON [RealEstateContactInfo] ([RealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstatePaymentHistory_RealEstateRegistryID] ON [RealEstatePaymentHistory] ([RealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstateProperty_RealEstateLocationRealStateLocationID] ON [RealEstateProperty] ([RealEstateLocationRealStateLocationID]);

GO

CREATE INDEX [IX_RealEstateProperty_RealEstatePropertyTypeID] ON [RealEstateProperty] ([RealEstatePropertyTypeID]);

GO

CREATE INDEX [IX_RealEstatePropertyRegistry_RealEstatePropertyID] ON [RealEstatePropertyRegistry] ([RealEstatePropertyID]);

GO

CREATE INDEX [IX_RealEstatePropertyType_RealEstateProjectTypeID] ON [RealEstatePropertyType] ([RealEstateProjectTypeID]);

GO

CREATE INDEX [IX_RealEstateRegistry_RealEstatePaymentFrecuencyID] ON [RealEstateRegistry] ([RealEstatePaymentFrecuencyID]);

GO

CREATE INDEX [IX_RealEstateRegOwneInfo_RealEstateRegistryID] ON [RealEstateRegOwneInfo] ([RealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstateTransaction_RealEstateRegistryID] ON [RealEstateTransaction] ([RealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstateTransaction_RealEstateTransactionTypeID] ON [RealEstateTransaction] ([RealEstateTransactionTypeID]);

GO

CREATE INDEX [IX_RealStateDocuments_RealEstateDocumentSourceID] ON [RealStateDocuments] ([RealEstateDocumentSourceID]);

GO

CREATE INDEX [IX_RealStateDocuments_RealEstateRegistryID] ON [RealStateDocuments] ([RealEstateRegistryID]);

GO

CREATE INDEX [IX_RealStateDocuments_RealStateDocumentsTypeID] ON [RealStateDocuments] ([RealStateDocumentsTypeID]);

GO


