BEGIN TRANSACTION;
GO

ALTER TABLE [PurchaseRequest] ADD [TotalPrice] decimal(18,2) NOT NULL DEFAULT 0.0;
GO

CREATE INDEX [IX_PurchaseRequest_ProductId] ON [PurchaseRequest] ([ProductId]);
GO

ALTER TABLE [PurchaseRequest] ADD CONSTRAINT [FK_PurchaseRequest_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221031142740_JobApp00002', N'6.0.10');
GO

COMMIT;
GO

