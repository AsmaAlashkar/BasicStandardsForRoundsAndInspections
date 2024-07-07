BEGIN TRANSACTION;
GO

ALTER TABLE [SubStandards] ADD [SelectedResultType] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240707071552_resultTypeRadioUpdate', N'8.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ResultTypes] DROP CONSTRAINT [FK_ResultTypes_SubStandards_SubStandardId];
GO

DROP INDEX [IX_ResultTypes_SubStandardId] ON [ResultTypes];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ResultTypes]') AND [c].[name] = N'SubStandardId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ResultTypes] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ResultTypes] DROP COLUMN [SubStandardId];
GO

EXEC sp_rename N'[SubStandards].[SelectedResultType]', N'ResultTypeId', N'COLUMN';
GO

CREATE INDEX [IX_SubStandards_ResultTypeId] ON [SubStandards] ([ResultTypeId]);
GO

ALTER TABLE [SubStandards] ADD CONSTRAINT [FK_SubStandards_ResultTypes_ResultTypeId] FOREIGN KEY ([ResultTypeId]) REFERENCES [ResultTypes] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240707074057_OneResultTypeRadioOnSubstandard', N'8.0.6');
GO

COMMIT;
GO

