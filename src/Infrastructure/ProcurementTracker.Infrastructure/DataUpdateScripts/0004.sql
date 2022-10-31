BEGIN TRANSACTION;
GO

ALTER TABLE [PurchaseRequest] DROP CONSTRAINT [FK_PurchaseRequest_Product_ProductId];
GO

DROP INDEX [IX_PurchaseRequest_ProductId] ON [PurchaseRequest];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PurchaseRequest]') AND [c].[name] = N'ProductId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [PurchaseRequest] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [PurchaseRequest] DROP COLUMN [ProductId];
GO

CREATE INDEX [IX_PurchaseRequestProductItem_ProductId] ON [PurchaseRequestProductItem] ([ProductId]);
GO

ALTER TABLE [PurchaseRequestProductItem] ADD CONSTRAINT [FK_PurchaseRequestProductItem_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221031145642_JobApp00004', N'6.0.10');
GO

COMMIT;
GO

