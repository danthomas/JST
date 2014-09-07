/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\Data\Security.AccountType.sql
:r .\Data\Security.Account.sql
:r .\Data\Competitors.WorkoutType.sql
:r .\Data\Competitors.WorkoutDate.sql
:r .\Data\Competitors.Workout.sql
:r .\Data\Competitors.Result.sql