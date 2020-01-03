To convert to MySql:

Delete migration files but NOT Configuration.cs

In Manage Nuget Packages:
  Install:	MySql.Data v 8.0.18 (latest)
			MySql.Data.EntityFramework v 8.0.18 (latest) - have to be the same version
			MySql.Data.Entity v 6.10.9 is compaitble but is not needed

Change the connection string to:
 <add name="DefaultConnection" connectionString="server=localhost;port=3306;database=GymTime;uid=root;password=" providerName="MySql.Data.MySqlClient"></add>

(Remove MSSQL connection string)

Remove all references to MSSQL in Web.config:
	1) parameter
	2) provider invariantName (only one allowed per database)

To stop getting the max key length > 767 chars error:

In the DBContext class add the annotation:
	[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

and in the Configuration.cs file add:
	SetHistoryContextFactory(MySqlProviderInvariantName.ProviderName, (connection, schema) => new MySqlHistoryContext(connection, schema));

To stop getting the SqlGenerator error:
In the Configuration.cs file add: 
	 SetSqlGenerator(MySqlProviderInvariantName.ProviderName, new MySqlMigrationSqlGenerator()); // i.e. ProviderName = "MySql.Data.MySqlClient"
(think it needs to be before the History line)

Build the project

In the Package Manager Console:
  add-migration "Initial"
	change the max-length to 191 on the following properties: AspNetRoles.Name, AspNetUsers.Email, AspNetUsers.Name (to stop the > 767 chars error)

  update-database
	(this will seed the database with classes and roles (admin and user))

Then run the app and register a user that will be the administrator.
Manually adjust table AspNetUserRoles to make the user an admin.
