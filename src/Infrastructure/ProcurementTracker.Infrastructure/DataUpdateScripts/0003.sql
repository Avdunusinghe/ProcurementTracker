BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchaseRequest]') AND [c].[name] = N'TotalPrice');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [PurchaseRequest] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [PurchaseRequest] ALTER COLUMN [TotalPrice] decimal(14,2) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221031143139_JobApp00003', N'6.0.10');
GO

COMMIT;
GO

