IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [PaymentMethod] (
    [PaymentMethodID] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_PaymentMethod] PRIMARY KEY ([PaymentMethodID])
);

GO

CREATE TABLE [Prop_Proj_Loc_Dto] (

);

GO

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
    [RealEstateLocationID] int NOT NULL IDENTITY,
    [description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_RealEstateLocation] PRIMARY KEY ([RealEstateLocationID])
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
    [PaymentMethodID] bigint NULL,
    CONSTRAINT [PK_RealEstateRegistry] PRIMARY KEY ([RealEstateRegistryID]),
    CONSTRAINT [FK_RealEstateRegistry_PaymentMethod_PaymentMethodID] FOREIGN KEY ([PaymentMethodID]) REFERENCES [PaymentMethod] ([PaymentMethodID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [RealEstatePropertyType] (
    [RealEstatePropertyTypeID] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    [RealEstateProjectTypeID] bigint NOT NULL,
    CONSTRAINT [PK_RealEstatePropertyType] PRIMARY KEY ([RealEstatePropertyTypeID]),
    CONSTRAINT [FK_RealEstatePropertyType_RealEstateProjectType_RealEstateProjectTypeID] FOREIGN KEY ([RealEstateProjectTypeID]) REFERENCES [RealEstateProjectType] ([RealEstateProjectTypeID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstateAnualBenefit] (
    [RealEstateAnualBenefitID] bigint NOT NULL IDENTITY,
    [AnnualBenefit] decimal(18,2) NOT NULL,
    [Amount] decimal(18,2) NOT NULL,
    [Active] int NOT NULL,
    [EfectiveDate] datetime2 NOT NULL,
    [RealEstateRegistryID] bigint NOT NULL,
    [RealEstatePaymentFrecuencyID] bigint NOT NULL,
    CONSTRAINT [PK_RealEstateAnualBenefit] PRIMARY KEY ([RealEstateAnualBenefitID]),
    CONSTRAINT [FK_RealEstateAnualBenefit_RealEstatePaymentFrecuency_RealEstatePaymentFrecuencyID] FOREIGN KEY ([RealEstatePaymentFrecuencyID]) REFERENCES [RealEstatePaymentFrecuency] ([RealEstatePaymentFrecuencyID]) ON DELETE CASCADE,
    CONSTRAINT [FK_RealEstateAnualBenefit_RealEstateRegistry_RealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstateBanksTransference] (
    [RealEstateBanksTransferenceID] bigint NOT NULL IDENTITY,
    [AccountName] nvarchar(max) NULL,
    [AccountNumber] bigint NOT NULL,
    [BeneficiaryAddress] nvarchar(max) NULL,
    [RealStateRegistryID] bigint NOT NULL,
    [RealEstateRegistryID] bigint NULL,
    [RealEstatedBankID] int NOT NULL,
    [IntermediaryBank] nvarchar(max) NULL,
    CONSTRAINT [PK_RealEstateBanksTransference] PRIMARY KEY ([RealEstateBanksTransferenceID]),
    CONSTRAINT [FK_RealEstateBanksTransference_RealEstateRegistry_RealEstateRegistryID] FOREIGN KEY ([RealEstateRegistryID]) REFERENCES [RealEstateRegistry] ([RealEstateRegistryID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_RealEstateBanksTransference_RealEstatedBank_RealEstatedBankID] FOREIGN KEY ([RealEstatedBankID]) REFERENCES [RealEstatedBank] ([RealEstatedBankID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstateContactInfo] (
    [RealEstateContactInfoID] bigint NOT NULL IDENTITY,
    [Phone] nvarchar(max) NULL,
    [Extension] int NOT NULL,
    [Email] nvarchar(max) NULL,
    [Status] int NOT NULL,
    [RealEstatePhoneTypeID] int NOT NULL,
    [RealEstateRegistryID] bigint NOT NULL,
    CONSTRAINT [PK_RealEstateContactInfo] PRIMARY KEY ([RealEstateContactInfoID]),
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
    [RealEstateRegOwneInfoID] bigint NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [DocumentID] nvarchar(30) NULL,
    [RealEstateRegistryID] bigint NOT NULL,
    CONSTRAINT [PK_RealEstateRegOwneInfo] PRIMARY KEY ([RealEstateRegOwneInfoID]),
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
    [RealEstatePropertyID] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    [Active] int NOT NULL,
    [RealEstateLocationID] int NOT NULL,
    [RealEstatePropertyTypeID] int NOT NULL,
    CONSTRAINT [PK_RealEstateProperty] PRIMARY KEY ([RealEstatePropertyID]),
    CONSTRAINT [FK_RealEstateProperty_RealEstateLocation_RealEstateLocationID] FOREIGN KEY ([RealEstateLocationID]) REFERENCES [RealEstateLocation] ([RealEstateLocationID]) ON DELETE CASCADE,
    CONSTRAINT [FK_RealEstateProperty_RealEstatePropertyType_RealEstatePropertyTypeID] FOREIGN KEY ([RealEstatePropertyTypeID]) REFERENCES [RealEstatePropertyType] ([RealEstatePropertyTypeID]) ON DELETE CASCADE
);

GO

CREATE TABLE [RealEstatePropertyOBenefit] (
    [RealEstateAnualBenefitID] bigint NOT NULL,
    [RealEstatePropertyID] bigint NOT NULL,
    [Active] int NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_RealEstatePropertyOBenefit] PRIMARY KEY ([RealEstateAnualBenefitID], [RealEstatePropertyID]),
    CONSTRAINT [FK_RealEstatePropertyOBenefit_RealEstateAnualBenefit_RealEstateAnualBenefitID] FOREIGN KEY ([RealEstateAnualBenefitID]) REFERENCES [RealEstateAnualBenefit] ([RealEstateAnualBenefitID]) ON DELETE CASCADE,
    CONSTRAINT [FK_RealEstatePropertyOBenefit_RealEstateProperty_RealEstatePropertyID] FOREIGN KEY ([RealEstatePropertyID]) REFERENCES [RealEstateProperty] ([RealEstatePropertyID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_RealEstateAnualBenefit_RealEstatePaymentFrecuencyID] ON [RealEstateAnualBenefit] ([RealEstatePaymentFrecuencyID]);

GO

CREATE INDEX [IX_RealEstateAnualBenefit_RealEstateRegistryID] ON [RealEstateAnualBenefit] ([RealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstateBanksTransference_RealEstateRegistryID] ON [RealEstateBanksTransference] ([RealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstateBanksTransference_RealEstatedBankID] ON [RealEstateBanksTransference] ([RealEstatedBankID]);

GO

CREATE INDEX [IX_RealEstateContactInfo_RealEstatePhoneTypeID] ON [RealEstateContactInfo] ([RealEstatePhoneTypeID]);

GO

CREATE INDEX [IX_RealEstateContactInfo_RealEstateRegistryID] ON [RealEstateContactInfo] ([RealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstatePaymentHistory_RealEstateRegistryID] ON [RealEstatePaymentHistory] ([RealEstateRegistryID]);

GO

CREATE INDEX [IX_RealEstateProperty_RealEstateLocationID] ON [RealEstateProperty] ([RealEstateLocationID]);

GO

CREATE INDEX [IX_RealEstateProperty_RealEstatePropertyTypeID] ON [RealEstateProperty] ([RealEstatePropertyTypeID]);

GO

CREATE INDEX [IX_RealEstatePropertyOBenefit_RealEstatePropertyID] ON [RealEstatePropertyOBenefit] ([RealEstatePropertyID]);

GO

CREATE INDEX [IX_RealEstatePropertyType_RealEstateProjectTypeID] ON [RealEstatePropertyType] ([RealEstateProjectTypeID]);

GO

CREATE INDEX [IX_RealEstateRegistry_PaymentMethodID] ON [RealEstateRegistry] ([PaymentMethodID]);

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

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211213215114_RealEstateMigra', N'3.1.21');

GO

