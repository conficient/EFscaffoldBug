
dotnet ef dbcontext scaffold "Server=ServerName;Database=Test;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer --force  --namespace TestDB --context TestDBcontext --use-database-names --data-annotations --output-dir Generated > scaffold.log
