BEGIN TRANSACTION;
GO

ALTER TABLE [PurchaseRequestProductItem] ADD [NumberOfItem] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221101030836_JobApp00007', N'6.0.10');
GO

COMMIT;
GO

