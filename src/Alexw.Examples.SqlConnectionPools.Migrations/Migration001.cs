using System;
using System.Collections.Generic;
using FluentMigrator;

namespace Alexw.Examples.SqlConnectionPools.Migrations
{
    [Migration(1)]
    public class Migration001 : Migration
    {
        public override void Up()
        {
            Create.Table("Example")
                .WithColumn("Id").AsString().Indexed("Idx_Example_Id").PrimaryKey("Pk_Example_Id")
                .WithColumn("Data").AsString();

            for (var i = 0; i < 1000000; i++)
            {
                Insert.IntoTable("Example")
                    .Row(new Dictionary<string, object>
                    {
                        {"Id", Guid.NewGuid().ToString()},
                        {"Data", "{ \"hello\" \"world\", \"data\" : [\"" + Guid.NewGuid() + "\"] }"}
                    });
            }
        }

        public override void Down()
        {
            Delete.FromTable("Example");
            Delete.Table("Example");
        }
    }
}
