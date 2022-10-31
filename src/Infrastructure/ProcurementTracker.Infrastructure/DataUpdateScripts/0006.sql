BEGIN TRANSACTION;
GO

ALTER TABLE [PurchaseRequest] DROP CONSTRAINT [FK_PurchaseRequest_User_LastUpdatedById1];
GO

EXEC sp_rename N'[PurchaseRequest].[LastUpdatedById1]', N'StatusChangedById', N'COLUMN';
GO

EXEC sp_rename N'[PurchaseRequest].[IX_PurchaseRequest_LastUpdatedById1]', N'IX_PurchaseRequest_StatusChangedById', N'INDEX';
GO

ALTER TABLE [PurchaseRequest] ADD CONSTRAINT [FK_PurchaseRequest_User_StatusChangedById] FOREIGN KEY ([StatusChangedById]) REFERENCES [User] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221031161340_JobApp00006', N'6.0.10');
GO

COMMIT;
GO

