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


Deploying to Azure
------------------

Used "MySQL in App". Not suitable for production.
Export the MySQL database from phpMyAdmin.
Publish solution in Visual Studio (no database or migrations). Web page will show error (because of db).
Go into "MySQL in App" in the app in Azure and click on "Manage" to go into Azure phpMyAdmin.
Since MySql is only started with the main site, do make sure that the main site is running (simplest 
way is to turn on AlwaysOn) before using phpMyAdmin. This not possible on the Free option. 
Import the database from the file just exported.
Find the connection string from:
	Go to Advanced Tools click Go (goes to new tab)
	In ‘Kudu’, click ‘Debug console’ (you can use console to change username and password as well),
	browse to ‘D:\home\data\mysql\’ and locate file ‘MYSQLCONNSTR_localdb.ini’. In this file, you 
	have connection string for MySQL db containing credentials.
It isn't quite right but it is always:
	server=localhost;port=49480;database=localdb;uid=azure;password=xxxxx; 
	The port is different for each application. Find the port in Azure phpMyAdmin
	by looking at the current server in the top left corner.
	Docs say "the port number may vary for each application life cycle depending on its availability
	at startup time". Think this is ok for demos but will change if I change the app plan or if Azure 
	upgrade things (not really sure). 
	The port info is also available as an env variable WEBSITE_MYSQL_PORT to the site. 
	I think you should really create connect string in the C# rather than use the Azure connection
	string. I have added code to IdentityModels.cs. This is better because port number can change. 
	(As long as format of "MYSQLCONNSTR_localdb" doesn't change.....).
	As a fall back if the above causes a problem you can put the above connection string in the 
	Azure Configuration page (with correct password) as "DefaultConnection". (Change type to Custom
	so when you connect to PHPMyAdmin it will force it to use MYSQLCONNSTR_localdb and connect to
	the MySQL in App server).
Refresh page. It should now work.

See https://github.com/projectkudu/kudu/wiki/MySQL-in-app for more details
