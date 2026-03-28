using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataModel.Migrations
{
    /// <inheritdoc />
    public partial class LibraryDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookID", "Author", "ISBN", "LoanDuration", "LoanType", "Title" },
                values: new object[,]
                {
                    { 1, "Suzanne Collins", "9780439023481.00", 28, 1, "The Hunger Gamer" },
                    { 2, "George Orwell", "1110141036141.00", 28, 1, "1984" },
                    { 3, "Aldous Huxely", "2220060929871.00", 1, 0, "Brave New World" },
                    { 4, "Athur Conan Doyle", "1234564389.00", 28, 1, "The Hound of the Baskervilles" },
                    { 5, "Leonardo da Vinci", "123456789196.00", 1, 0, "Literary works of Leonardo da Vinci" },
                    { 6, "Eoin Colfer", "9780786851478.00", 28, 1, "The Arctic Incident" },
                    { 7, "P.W Atkins", "716720736.00", 1, 0, "Physical Chemistry" },
                    { 8, "Roger Freedman", "716746476.00", 28, 1, "Universe" }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "MemberID", "FirstName", "SecondName" },
                values: new object[,]
                {
                    { 1, "Elizabeth", "Anderson" },
                    { 2, "Catherine", "Autier Miconi" },
                    { 3, "Thomas", "Axen" },
                    { 4, "Jean Phillipe", "Bagel" },
                    { 5, "Anna", "Bedecs" },
                    { 6, "John", "Edwards" },
                    { 7, "Alexanger", "Eggerer" },
                    { 8, "Michael", "Entin" },
                    { 9, "Daniel", "Goldschmidt" },
                    { 10, "Antonio", "Gratacos Silsona" },
                    { 11, "Carlos", "Grilo" },
                    { 12, "Jonas", "Hasselberg" }
                });

            migrationBuilder.InsertData(
                table: "Loan",
                columns: new[] { "BookID", "MemberID", "LoanIssueDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2026, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 5, new DateTime(2026, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 6, new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 8, new DateTime(2026, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Loan",
                keyColumns: new[] { "BookID", "MemberID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Loan",
                keyColumns: new[] { "BookID", "MemberID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Loan",
                keyColumns: new[] { "BookID", "MemberID" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Loan",
                keyColumns: new[] { "BookID", "MemberID" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "Loan",
                keyColumns: new[] { "BookID", "MemberID" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "BookID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberID",
                keyValue: 8);
        }
    }
}
