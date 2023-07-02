## Fintech
This a desktop app designed and built to mock functionalities of a bank desktop App. Building the Admin Panel for it.

## Nuget packages used
ShortId - for generating short unique codes.  
Dapper - for mapping the classes to database.  
EmailValidator - For validating Emails.  
FluentEmail - For sending emails to the users.  
IdGen - used for generating unique numbers (generates account number for the user).  
botCypt - used for Encrypting users passwords.  
FluentEmail.Razor - for creating Email templates.  
mssql database - for storage.  
Guna ui - for the user interface.  

## Functionalites
-user is able to create an account and the account number is Emailed to them.  
-user is able to deposit money in the account.  
-user is able to able for a loan and wait for approval.  
-user is able to update his/her details.  
-user is to withdrawal money.   
-Password resetting is done the email where user recieves a verification for reseting the password.  

## Contents
Utils.cs - contains the utils functions such as hashing password mailing and validating emails.  
DataAccess.cs contains functions for interacting with the database.  
Forms folder - contains the winsforms for the UI.  
Sender.cs - contains the basic configuration of the fluentEmail.  
User.cs - used by dapper for mapping to user's table in the database.    
ResetCode - used for dapper for mapping to the reset table in the database.  

## Configurations.
[x] Create an App.config and include your database configuration.  
[x] Create an email(optional) and generate an app password for your email. For the mailing function to work. 


Working on the Admin App.





