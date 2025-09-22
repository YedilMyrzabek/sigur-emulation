using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace sigur_emulation.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAreaIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Удаляем внешний ключ
            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Areas_AreaId",
                table: "Personnels");

            // 2. Удаляем индекс на AreaId если он есть
            migrationBuilder.DropIndex(
                name: "IX_Personnels_AreaId",
                table: "Personnels");

            // 3. Изменяем тип колонки AreaId в Personnels на string
            migrationBuilder.AlterColumn<string>(
                name: "AreaId",
                table: "Personnels",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            // 4. Для Areas используем сырой SQL чтобы правильно обработать IDENTITY
            // Сначала удаляем IDENTITY, потом меняем тип
            migrationBuilder.Sql(@"
                -- Удаляем первичный ключ
                ALTER TABLE ""Areas"" DROP CONSTRAINT ""PK_Areas"";
                
                -- Удаляем уникальный индекс если есть
                DROP INDEX IF EXISTS ""IX_Areas_Id"";
                
                -- Создаем временную колонку для хранения строковых значений
                ALTER TABLE ""Areas"" ADD COLUMN ""TempId"" text;
                
                -- Копируем значения, преобразуя в строку
                UPDATE ""Areas"" SET ""TempId"" = ""Id""::text;
                
                -- Удаляем старую колонку с IDENTITY
                ALTER TABLE ""Areas"" DROP COLUMN ""Id"";
                
                -- Переименовываем временную колонку
                ALTER TABLE ""Areas"" RENAME COLUMN ""TempId"" TO ""Id"";
                
                -- Делаем колонку NOT NULL
                ALTER TABLE ""Areas"" ALTER COLUMN ""Id"" SET NOT NULL;
                
                -- Восстанавливаем первичный ключ
                ALTER TABLE ""Areas"" ADD CONSTRAINT ""PK_Areas"" PRIMARY KEY (""Id"");
                
                -- Восстанавливаем уникальный индекс
                CREATE UNIQUE INDEX ""IX_Areas_Id"" ON ""Areas"" (""Id"");
            ");

            // 5. Создаем индекс обратно для Personnels
            migrationBuilder.CreateIndex(
                name: "IX_Personnels_AreaId",
                table: "Personnels",
                column: "AreaId");

            // 6. Восстанавливаем внешний ключ
            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Areas_AreaId",
                table: "Personnels",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 1. Удаляем внешний ключ
            migrationBuilder.DropForeignKey(
                name: "FK_Personnels_Areas_AreaId",
                table: "Personnels");

            // 2. Удаляем индекс
            migrationBuilder.DropIndex(
                name: "IX_Personnels_AreaId",
                table: "Personnels");

            // 3. Изменяем тип колонки AreaId обратно на int
            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Personnels",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            // 4. Для Areas используем сырой SQL для возврата к integer с IDENTITY
            migrationBuilder.Sql(@"
                -- Удаляем первичный ключ
                ALTER TABLE ""Areas"" DROP CONSTRAINT ""PK_Areas"";
                
                -- Удаляем индекс
                DROP INDEX IF EXISTS ""IX_Areas_Id"";
                
                -- Создаем временную колонку integer
                ALTER TABLE ""Areas"" ADD COLUMN ""TempId"" integer;
                
                -- Копируем значения, преобразуя в integer (если возможно)
                UPDATE ""Areas"" SET ""TempId"" = ""Id""::integer WHERE ""Id"" ~ '^[0-9]+$';
                
                -- Удаляем старую колонку
                ALTER TABLE ""Areas"" DROP COLUMN ""Id"";
                
                -- Переименовываем временную колонку
                ALTER TABLE ""Areas"" RENAME COLUMN ""TempId"" TO ""Id"";
                
                -- Делаем колонку NOT NULL и добавляем IDENTITY
                ALTER TABLE ""Areas"" ALTER COLUMN ""Id"" SET NOT NULL;
                ALTER TABLE ""Areas"" ALTER COLUMN ""Id"" ADD GENERATED BY DEFAULT AS IDENTITY;
                
                -- Восстанавливаем первичный ключ
                ALTER TABLE ""Areas"" ADD CONSTRAINT ""PK_Areas"" PRIMARY KEY (""Id"");
                
                -- Восстанавливаем уникальный индекс
                CREATE UNIQUE INDEX ""IX_Areas_Id"" ON ""Areas"" (""Id"");
            ");

            // 5. Создаем индекс обратно
            migrationBuilder.CreateIndex(
                name: "IX_Personnels_AreaId",
                table: "Personnels",
                column: "AreaId");

            // 6. Восстанавливаем внешний ключ
            migrationBuilder.AddForeignKey(
                name: "FK_Personnels_Areas_AreaId",
                table: "Personnels",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}