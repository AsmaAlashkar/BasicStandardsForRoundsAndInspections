BEGIN TRANSACTION;
GO

ALTER TABLE [Results] DROP CONSTRAINT [FK_Results_ResultTypes_ResultTypeId];
GO

ALTER TABLE [ResultTypes] DROP CONSTRAINT [FK_ResultTypes_SubStandards_SubStandardId];
GO

DROP TABLE [SubStandardResults];
GO

DROP INDEX [IX_ResultTypes_SubStandardId] ON [ResultTypes];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[SubStandards]') AND [c].[name] = N'SelectedResultType');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [SubStandards] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [SubStandards] DROP COLUMN [SelectedResultType];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ResultTypes]') AND [c].[name] = N'SubStandardId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ResultTypes] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [ResultTypes] DROP COLUMN [SubStandardId];
GO

EXEC sp_rename N'[Results].[Type]', N'Comment', N'COLUMN';
GO

ALTER TABLE [SubStandards] ADD [ResultTypeId] int NULL;
GO

ALTER TABLE [SubStandards] ADD [ResultTypeId1] int NULL;
GO

ALTER TABLE [ResultTypes] ADD [NameAr] nvarchar(max) NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Results]') AND [c].[name] = N'Description');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Results] DROP CONSTRAINT [' + @var2 + '];');
UPDATE [Results] SET [Description] = N'' WHERE [Description] IS NULL;
ALTER TABLE [Results] ALTER COLUMN [Description] nvarchar(max) NOT NULL;
ALTER TABLE [Results] ADD DEFAULT N'' FOR [Description];
GO

ALTER TABLE [Results] ADD [DescriptionAr] nvarchar(max) NULL;
GO

ALTER TABLE [Results] ADD [ResultTypeId1] int NULL;
GO

ALTER TABLE [Results] ADD [SubStandardId] int NULL;
GO

CREATE INDEX [IX_SubStandards_ResultTypeId] ON [SubStandards] ([ResultTypeId]);
GO

CREATE INDEX [IX_SubStandards_ResultTypeId1] ON [SubStandards] ([ResultTypeId1]);
GO

CREATE INDEX [IX_Results_ResultTypeId1] ON [Results] ([ResultTypeId1]);
GO

CREATE INDEX [IX_Results_SubStandardId] ON [Results] ([SubStandardId]);
GO

ALTER TABLE [Results] ADD CONSTRAINT [FK_Results_ResultTypes_ResultTypeId] FOREIGN KEY ([ResultTypeId]) REFERENCES [ResultTypes] ([Id]);
GO

ALTER TABLE [Results] ADD CONSTRAINT [FK_Results_ResultTypes_ResultTypeId1] FOREIGN KEY ([ResultTypeId1]) REFERENCES [ResultTypes] ([Id]);
GO

ALTER TABLE [Results] ADD CONSTRAINT [FK_Results_SubStandards_SubStandardId] FOREIGN KEY ([SubStandardId]) REFERENCES [SubStandards] ([Id]);
GO

ALTER TABLE [SubStandards] ADD CONSTRAINT [FK_SubStandards_ResultTypes_ResultTypeId] FOREIGN KEY ([ResultTypeId]) REFERENCES [ResultTypes] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [SubStandards] ADD CONSTRAINT [FK_SubStandards_ResultTypes_ResultTypeId1] FOREIGN KEY ([ResultTypeId1]) REFERENCES [ResultTypes] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240707123006_someUpdates', N'8.0.6');
GO

COMMIT;
GO

