using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO users (Name) VALUES 
                ('John Smith'),
                ('Emily Johnson'),
                ('Michael Brown'),
                ('Sarah Davis'),
                ('David Wilson');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM users 
                WHERE Name IN ('John Smith', 'Emily Johnson', 'Michael Brown', 'Sarah Davis', 'David Wilson');
            ");
        }
    }
}
