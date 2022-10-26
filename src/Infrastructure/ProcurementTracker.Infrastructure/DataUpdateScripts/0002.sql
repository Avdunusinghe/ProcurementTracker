BEGIN TRANSACTION;
GO

ALTER TABLE [SupplierProduct] ADD CONSTRAINT [FK_SupplierProduct_Product_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221025164826_JobApp00002', N'6.0.10');
GO

COMMIT;
GO

