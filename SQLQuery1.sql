USE [C:\USERS\AMINA\SOURCE\REPOS\STUDENTINTERNSHIP\STUDENTINTERNSHIP\APP_DATA\DATABASE1.MDF]
GO

DECLARE	@return_value Int,
		@result int

EXEC	@return_value = [dbo].[getStudentPK]
		@student_no = 49536,
		@result = @result OUTPUT

SELECT	@result as N'@result'

SELECT	@return_value as 'Return Value'

GO
