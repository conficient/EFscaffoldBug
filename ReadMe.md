# EF Core Scaffold Bug

See [Issue #25292](https://github.com/dotnet/efcore/issues/25292) in EFcore repo.

When a builder has a column with the same name as a relationship (differing only in case) the 
resulting scaffolding code will error when the model is created.

## Usage

 1. Create a database on an MS SQL Server 2008 or later using `/Database/TestDB.sql`
 2. Amend the server of the connection string in `Program.cs` to connect to this database.
 3. Attempt to run the program.

### Notes

The generated code is in the `/Generated` folder. The command used to scaffold this code is in `scaffold.cmd`

## Expected Result

I would expect the code to run and return an empty list of Partners 

## Actual Result

A `NullReferenceException` is thrown:

```
Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.InversePropertyAttributeConvention.ConfigureInverseNavigation(IConventionEntityTypeBuilder entityTypeBuilder, MemberInfo navigationMemberInfo, IConventionEntityTypeBuilder targetEntityTypeBuilder, InversePropertyAttribute attribute)
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.InversePropertyAttributeConvention.Process(IConventionEntityTypeBuilder entityTypeBuilder, MemberInfo navigationMemberInfo, Type targetClrType, InversePropertyAttribute attribute)
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.InversePropertyAttributeConvention.ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder, MemberInfo navigationMemberInfo, Type targetClrType, InversePropertyAttribute attribute, IConventionContext`1 context)
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.NavigationAttributeConventionBase`1.ProcessEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder, IConventionContext`1 context)
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher.ImmediateConventionScope.OnEntityTypeAdded(IConventionEntityTypeBuilder entityTypeBuilder)
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher.OnEntityTypeAddedNode.Run(ConventionDispatcher dispatcher)
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher.DelayedConventionScope.Run(ConventionDispatcher dispatcher)
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher.ConventionBatch.Run()
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher.ConventionBatch.Dispose()
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher.ImmediateConventionScope.OnModelInitialized(IConventionModelBuilder modelBuilder)
   at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher.OnModelInitialized(IConventionModelBuilder modelBuilder)
   at Microsoft.EntityFrameworkCore.Metadata.Internal.Model..ctor(ConventionSet conventions, ModelDependencies modelDependencies)
   at Microsoft.EntityFrameworkCore.ModelBuilder..ctor(ConventionSet conventions, ModelDependencies modelDependencies, Boolean _)
   at Microsoft.EntityFrameworkCore.ModelBuilder..ctor(ConventionSet conventions, ModelDependencies modelDependencies)
   at Microsoft.EntityFrameworkCore.Infrastructure.ModelSource.CreateModel(DbContext context, IConventionSetBuilder conventionSetBuilder, ModelDependencies modelDependencies)
   at Microsoft.EntityFrameworkCore.Infrastructure.ModelSource.GetModel(DbContext context, IConventionSetBuilder conventionSetBuilder, ModelDependencies modelDependencies)
   at Microsoft.EntityFrameworkCore.Internal.DbContextServices.CreateModel()
   at Microsoft.EntityFrameworkCore.Internal.DbContextServices.get_Model()
   at Microsoft.EntityFrameworkCore.Infrastructure.EntityFrameworkServicesBuilder.<>c.<TryAddCoreServices>b__7_3(IServiceProvider p)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitFactory(FactoryCallSite factoryCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite callSite, RuntimeResolverContext context, ServiceProviderEngineScope serviceProviderEngine, RuntimeResolverLock lockType)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite singletonCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite constructorCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache(ServiceCallSite callSite, RuntimeResolverContext context, ServiceProviderEngineScope serviceProviderEngine, RuntimeResolverLock lockType)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache(ServiceCallSite singletonCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite callSite, ServiceProviderEngineScope scope)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.DynamicServiceProviderEngine.<>c__DisplayClass1_0.<RealizeService>b__0(ServiceProviderEngineScope scope)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope.GetService(Type serviceType)
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider provider, Type serviceType)
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T](IServiceProvider provider)
   at Microsoft.EntityFrameworkCore.DbContext.get_DbContextDependencies()
   at Microsoft.EntityFrameworkCore.DbContext.get_InternalServiceProvider()
   at Microsoft.EntityFrameworkCore.DbContext.get_DbContextDependencies()
   at Microsoft.EntityFrameworkCore.DbContext.get_Model()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.get_EntityType()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.CheckState()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.get_EntityQueryable()
   at Microsoft.EntityFrameworkCore.Internal.InternalDbSet`1.System.Collections.Generic.IAsyncEnumerable<TEntity>.GetAsyncEnumerator(CancellationToken cancellationToken)
   at System.Runtime.CompilerServices.ConfiguredCancelableAsyncEnumerable`1.GetAsyncEnumerator()
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync[TSource](IQueryable`1 source, CancellationToken cancellationToken)
   at EFscaffoldBug.Program.Main() in C:\Users\Howard.CONFICIENT\source\repos\EFscaffoldBug\EFscaffoldBug\Program.cs:line 24
   at EFscaffoldBug.Program.<Main>()
```

## Workaround

Amend then generated code so the name clash is avoided:

```c#
   [Column("CPSChargePartner", TypeName = "smallmoney")]
   public decimal? CPSChargeForPartner { get; set; }
```
