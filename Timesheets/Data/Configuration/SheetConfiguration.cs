using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models;

namespace Timesheets.Data.Configuration
{
    public class SheetConfiguration : IEntityTypeConfiguration<Sheet>
    {
        public void Configure(EntityTypeBuilder<Sheet> builder)
        {
            builder.ToTable("Sheet");

            builder
                .HasOne(sheet => sheet.Invoice)
                .WithMany(invoice => invoice.Sheet)
                .HasForeignKey("InvoiceId");

            builder.HasOne(sheet => sheet.Employee)
                .WithMany(employee => employee.Sheets)
                .HasForeignKey("EmployeeId");

            builder.HasOne(sheet => sheet.Contract)
                .WithMany(contract => contract.Sheets)
                .HasForeignKey("ContractId");

            builder.HasOne(sheet => sheet.Service)
                .WithMany(service => service.Sheets)
                .HasForeignKey("ServiceId");
        }
    }
}
