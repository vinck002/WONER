using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.DataBase.Migrations
{
    public partial class RealEstateMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatedBank",
                columns: table => new
                {
                    RealEstatedBankID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(nullable: true),
                    BankAddress = table.Column<string>(nullable: true),
                    SwiftCode = table.Column<string>(nullable: true),
                    RoutingCode = table.Column<string>(nullable: true),
                    CretionDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatedBank", x => x.RealEstatedBankID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateDocumentSource",
                columns: table => new
                {
                    RealEstateDocumentSourceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateDocumentSource", x => x.RealEstateDocumentSourceID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateLocation",
                columns: table => new
                {
                    RealEstateLocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateLocation", x => x.RealEstateLocationID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePaymentFrecuency",
                columns: table => new
                {
                    RealEstatePaymentFrecuencyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    FrecuenceValue = table.Column<int>(nullable: false),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePaymentFrecuency", x => x.RealEstatePaymentFrecuencyID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePhoneType",
                columns: table => new
                {
                    RealEstatePhoneTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePhoneType", x => x.RealEstatePhoneTypeID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateProjectType",
                columns: table => new
                {
                    RealEstateProjectTypeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateProjectType", x => x.RealEstateProjectTypeID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateTransactionType",
                columns: table => new
                {
                    RealEstateTransactionTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(maxLength: 2, nullable: true),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateTransactionType", x => x.RealEstateTransactionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "RealStateDocumentsType",
                columns: table => new
                {
                    RealStateDocumentsTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 30, nullable: true),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealStateDocumentsType", x => x.RealStateDocumentsTypeID);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateRegistry",
                columns: table => new
                {
                    RealEstateRegistryID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistryDescription = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    PaymentMethodID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateRegistry", x => x.RealEstateRegistryID);
                    table.ForeignKey(
                        name: "FK_RealEstateRegistry_PaymentMethod_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePropertyType",
                columns: table => new
                {
                    RealEstatePropertyTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false),
                    RealEstateProjectTypeID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePropertyType", x => x.RealEstatePropertyTypeID);
                    table.ForeignKey(
                        name: "FK_RealEstatePropertyType_RealEstateProjectType_RealEstateProjectTypeID",
                        column: x => x.RealEstateProjectTypeID,
                        principalTable: "RealEstateProjectType",
                        principalColumn: "RealEstateProjectTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateAnualBenefit",
                columns: table => new
                {
                    RealEstateAnualBenefitID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnualBenefit = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Active = table.Column<int>(nullable: false),
                    EfectiveDate = table.Column<DateTime>(nullable: false),
                    RealEstateRegistryID = table.Column<long>(nullable: false),
                    RealEstatePaymentFrecuencyID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateAnualBenefit", x => x.RealEstateAnualBenefitID);
                    table.ForeignKey(
                        name: "FK_RealEstateAnualBenefit_RealEstatePaymentFrecuency_RealEstatePaymentFrecuencyID",
                        column: x => x.RealEstatePaymentFrecuencyID,
                        principalTable: "RealEstatePaymentFrecuency",
                        principalColumn: "RealEstatePaymentFrecuencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateAnualBenefit_RealEstateRegistry_RealEstateRegistryID",
                        column: x => x.RealEstateRegistryID,
                        principalTable: "RealEstateRegistry",
                        principalColumn: "RealEstateRegistryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateBanksTransference",
                columns: table => new
                {
                    RealEstateBanksTransferenceID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<long>(nullable: false),
                    BeneficiaryAddress = table.Column<string>(nullable: true),
                    RealStateRegistryID = table.Column<long>(nullable: false),
                    RealEstateRegistryID = table.Column<long>(nullable: true),
                    RealEstatedBankID = table.Column<int>(nullable: false),
                    IntermediaryBank = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateBanksTransference", x => x.RealEstateBanksTransferenceID);
                    table.ForeignKey(
                        name: "FK_RealEstateBanksTransference_RealEstateRegistry_RealEstateRegistryID",
                        column: x => x.RealEstateRegistryID,
                        principalTable: "RealEstateRegistry",
                        principalColumn: "RealEstateRegistryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstateBanksTransference_RealEstatedBank_RealEstatedBankID",
                        column: x => x.RealEstatedBankID,
                        principalTable: "RealEstatedBank",
                        principalColumn: "RealEstatedBankID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateContactInfo",
                columns: table => new
                {
                    RealEstateContactInfoID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(nullable: true),
                    Extension = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    RealEstatePhoneTypeID = table.Column<int>(nullable: false),
                    RealEstateRegistryID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateContactInfo", x => x.RealEstateContactInfoID);
                    table.ForeignKey(
                        name: "FK_RealEstateContactInfo_RealEstatePhoneType_RealEstatePhoneTypeID",
                        column: x => x.RealEstatePhoneTypeID,
                        principalTable: "RealEstatePhoneType",
                        principalColumn: "RealEstatePhoneTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateContactInfo_RealEstateRegistry_RealEstateRegistryID",
                        column: x => x.RealEstateRegistryID,
                        principalTable: "RealEstateRegistry",
                        principalColumn: "RealEstateRegistryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePaymentHistory",
                columns: table => new
                {
                    RealEstatePaymentHistory = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(nullable: false),
                    EfectiveDate = table.Column<DateTime>(nullable: false),
                    RealEstateRegistryID = table.Column<long>(nullable: false),
                    processCode = table.Column<long>(nullable: false),
                    Reference = table.Column<string>(nullable: true),
                    UserID = table.Column<long>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePaymentHistory", x => x.RealEstatePaymentHistory);
                    table.ForeignKey(
                        name: "FK_RealEstatePaymentHistory_RealEstateRegistry_RealEstateRegistryID",
                        column: x => x.RealEstateRegistryID,
                        principalTable: "RealEstateRegistry",
                        principalColumn: "RealEstateRegistryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateRegOwneInfo",
                columns: table => new
                {
                    RealEstateRegOwneInfoID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DocumentID = table.Column<string>(maxLength: 30, nullable: true),
                    RealEstateRegistryID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateRegOwneInfo", x => x.RealEstateRegOwneInfoID);
                    table.ForeignKey(
                        name: "FK_RealEstateRegOwneInfo_RealEstateRegistry_RealEstateRegistryID",
                        column: x => x.RealEstateRegistryID,
                        principalTable: "RealEstateRegistry",
                        principalColumn: "RealEstateRegistryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateTransaction",
                columns: table => new
                {
                    RealEstateTransactionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(maxLength: 25, nullable: true),
                    UserID = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Active = table.Column<int>(nullable: false),
                    RealEstateRegistryID = table.Column<long>(nullable: false),
                    RealEstateTransactionTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateTransaction", x => x.RealEstateTransactionID);
                    table.ForeignKey(
                        name: "FK_RealEstateTransaction_RealEstateRegistry_RealEstateRegistryID",
                        column: x => x.RealEstateRegistryID,
                        principalTable: "RealEstateRegistry",
                        principalColumn: "RealEstateRegistryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateTransaction_RealEstateTransactionType_RealEstateTransactionTypeID",
                        column: x => x.RealEstateTransactionTypeID,
                        principalTable: "RealEstateTransactionType",
                        principalColumn: "RealEstateTransactionTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealStateDocuments",
                columns: table => new
                {
                    RealStateDocumentsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    RealEstateRegistryID = table.Column<long>(nullable: false),
                    ReferenceID = table.Column<long>(nullable: false),
                    RealStateDocumentsTypeID = table.Column<int>(nullable: false),
                    RealEstateDocumentSourceID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealStateDocuments", x => x.RealStateDocumentsID);
                    table.ForeignKey(
                        name: "FK_RealStateDocuments_RealEstateDocumentSource_RealEstateDocumentSourceID",
                        column: x => x.RealEstateDocumentSourceID,
                        principalTable: "RealEstateDocumentSource",
                        principalColumn: "RealEstateDocumentSourceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealStateDocuments_RealEstateRegistry_RealEstateRegistryID",
                        column: x => x.RealEstateRegistryID,
                        principalTable: "RealEstateRegistry",
                        principalColumn: "RealEstateRegistryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealStateDocuments_RealStateDocumentsType_RealStateDocumentsTypeID",
                        column: x => x.RealStateDocumentsTypeID,
                        principalTable: "RealStateDocumentsType",
                        principalColumn: "RealStateDocumentsTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateProperty",
                columns: table => new
                {
                    RealEstatePropertyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<int>(nullable: false),
                    RealEstateLocationID = table.Column<int>(nullable: false),
                    RealEstatePropertyTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateProperty", x => x.RealEstatePropertyID);
                    table.ForeignKey(
                        name: "FK_RealEstateProperty_RealEstateLocation_RealEstateLocationID",
                        column: x => x.RealEstateLocationID,
                        principalTable: "RealEstateLocation",
                        principalColumn: "RealEstateLocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateProperty_RealEstatePropertyType_RealEstatePropertyTypeID",
                        column: x => x.RealEstatePropertyTypeID,
                        principalTable: "RealEstatePropertyType",
                        principalColumn: "RealEstatePropertyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePropertyOBenefit",
                columns: table => new
                {
                    RealEstateAnualBenefitID = table.Column<long>(nullable: false),
                    RealEstatePropertyID = table.Column<long>(nullable: false),
                    Active = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePropertyOBenefit", x => new { x.RealEstateAnualBenefitID, x.RealEstatePropertyID });
                    table.ForeignKey(
                        name: "FK_RealEstatePropertyOBenefit_RealEstateAnualBenefit_RealEstateAnualBenefitID",
                        column: x => x.RealEstateAnualBenefitID,
                        principalTable: "RealEstateAnualBenefit",
                        principalColumn: "RealEstateAnualBenefitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstatePropertyOBenefit_RealEstateProperty_RealEstatePropertyID",
                        column: x => x.RealEstatePropertyID,
                        principalTable: "RealEstateProperty",
                        principalColumn: "RealEstatePropertyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateAnualBenefit_RealEstatePaymentFrecuencyID",
                table: "RealEstateAnualBenefit",
                column: "RealEstatePaymentFrecuencyID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateAnualBenefit_RealEstateRegistryID",
                table: "RealEstateAnualBenefit",
                column: "RealEstateRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateBanksTransference_RealEstateRegistryID",
                table: "RealEstateBanksTransference",
                column: "RealEstateRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateBanksTransference_RealEstatedBankID",
                table: "RealEstateBanksTransference",
                column: "RealEstatedBankID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateContactInfo_RealEstatePhoneTypeID",
                table: "RealEstateContactInfo",
                column: "RealEstatePhoneTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateContactInfo_RealEstateRegistryID",
                table: "RealEstateContactInfo",
                column: "RealEstateRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatePaymentHistory_RealEstateRegistryID",
                table: "RealEstatePaymentHistory",
                column: "RealEstateRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_RealEstateLocationID",
                table: "RealEstateProperty",
                column: "RealEstateLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_RealEstatePropertyTypeID",
                table: "RealEstateProperty",
                column: "RealEstatePropertyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatePropertyOBenefit_RealEstatePropertyID",
                table: "RealEstatePropertyOBenefit",
                column: "RealEstatePropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatePropertyType_RealEstateProjectTypeID",
                table: "RealEstatePropertyType",
                column: "RealEstateProjectTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateRegistry_PaymentMethodID",
                table: "RealEstateRegistry",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateRegOwneInfo_RealEstateRegistryID",
                table: "RealEstateRegOwneInfo",
                column: "RealEstateRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateTransaction_RealEstateRegistryID",
                table: "RealEstateTransaction",
                column: "RealEstateRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateTransaction_RealEstateTransactionTypeID",
                table: "RealEstateTransaction",
                column: "RealEstateTransactionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RealStateDocuments_RealEstateDocumentSourceID",
                table: "RealStateDocuments",
                column: "RealEstateDocumentSourceID");

            migrationBuilder.CreateIndex(
                name: "IX_RealStateDocuments_RealEstateRegistryID",
                table: "RealStateDocuments",
                column: "RealEstateRegistryID");

            migrationBuilder.CreateIndex(
                name: "IX_RealStateDocuments_RealStateDocumentsTypeID",
                table: "RealStateDocuments",
                column: "RealStateDocumentsTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateBanksTransference");

            migrationBuilder.DropTable(
                name: "RealEstateContactInfo");

            migrationBuilder.DropTable(
                name: "RealEstatePaymentHistory");

            migrationBuilder.DropTable(
                name: "RealEstatePropertyOBenefit");

            migrationBuilder.DropTable(
                name: "RealEstateRegOwneInfo");

            migrationBuilder.DropTable(
                name: "RealEstateTransaction");

            migrationBuilder.DropTable(
                name: "RealStateDocuments");

            migrationBuilder.DropTable(
                name: "RealEstatedBank");

            migrationBuilder.DropTable(
                name: "RealEstatePhoneType");

            migrationBuilder.DropTable(
                name: "RealEstateAnualBenefit");

            migrationBuilder.DropTable(
                name: "RealEstateProperty");

            migrationBuilder.DropTable(
                name: "RealEstateTransactionType");

            migrationBuilder.DropTable(
                name: "RealEstateDocumentSource");

            migrationBuilder.DropTable(
                name: "RealStateDocumentsType");

            migrationBuilder.DropTable(
                name: "RealEstatePaymentFrecuency");

            migrationBuilder.DropTable(
                name: "RealEstateRegistry");

            migrationBuilder.DropTable(
                name: "RealEstateLocation");

            migrationBuilder.DropTable(
                name: "RealEstatePropertyType");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "RealEstateProjectType");
        }
    }
}
