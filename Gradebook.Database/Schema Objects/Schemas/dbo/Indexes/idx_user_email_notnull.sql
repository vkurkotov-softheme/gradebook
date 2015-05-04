CREATE UNIQUE NONCLUSTERED INDEX [idx_user_email_notnull]
	ON [dbo].[User]
	([Email])
	WHERE [Email] IS NOT NULL;
