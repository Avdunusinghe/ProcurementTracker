BEGIN TRANSACTION;
GO

ALTER TABLE [SupplierProduct] DROP CONSTRAINT [FK_SupplierProduct_Product_SupplierId];
GO

CREATE INDEX [IX_SupplierProduct_ProductId] ON [SupplierProduct] ([ProductId]);
GO

ALTER TABLE [SupplierProduct] ADD CONSTRAINT [FK_SupplierProduct_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221031155852_JobApp00005', N'6.0.10');
GO

COMMIT;
GO

