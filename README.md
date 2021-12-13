# Employee-WebApi
Employee Code Challenge Project to Build an employee management system that consolidates all the relevant information on a company’s human resources. Using ASP.net 5 and Postgresql to create RESTful Api service.
============================================================================
============================================================================

1. Estimated time to complete assessment: 5hrs span over 7 days

2. Research time: 1hr

3. Project implementation: 4hrs

============================================================================

Implementation:

A. Project setup and configuration
B. Git repo created
C. Initial commit 
D. Api key implemented
E. Swagger doc configured
F. Admin services implementation completed
G. Employee services implementation completed
H. Ran Database migration
I. Api testing done!
J. Git push done!
K. Git pull request
L. Merge to master from dev branch done
============================================================================

Project TargetFramework = net5.0
============================================================================

NOTE: The following configuration files and settings are essential to run the service.
Configuration file: appsettings.json

Api-Key: key = "ApiKey", Value = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"
And should be passed in the header
AppConfigs.ApiKeyConfig.Secret : holds Api-key value. 
============================================================================


AppConfigs.ConnectionStrings : holds CONNECTION VALUES for Npgsql connections
Run Db Migration with add-migration and update-database
============================================================================

Log files can be found in \Logs in the root directory of the application.
Directory may be change by editing the nlog.config file

Unit Test was not implemented due to time constraint
============================================================================