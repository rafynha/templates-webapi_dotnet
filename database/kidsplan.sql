CREATE TABLE [Users] (
  [UserId] bigint PRIMARY KEY IDENTITY(1, 1),
  [Username] varchar(50) UNIQUE NOT NULL,
  [Gender] char(1),
  [PasswordHash] varchar(256) NOT NULL,
  [Email] varchar(100) UNIQUE NOT NULL,
  [IsActive] BIT NOT NULL DEFAULT (1),
  [CreatedAt] datetime NOT NULL DEFAULT (GETDATE()),
  [UpdatedAt] datetime
)
GO

CREATE TABLE [Profiles] (
  [ProfileId] int PRIMARY KEY IDENTITY(1, 1),
  [ProfileName] varchar(50) UNIQUE NOT NULL,
  [Description] varchar(200),
  [CreatedAt] datetime NOT NULL DEFAULT (GETDATE())
)
GO

CREATE TABLE [UserProfiles] (
  [UserProfileId] int PRIMARY KEY IDENTITY(1, 1),
  [UserId] bigint NOT NULL,
  [ProfileId] int NOT NULL,
  [AssignedAt] datetime NOT NULL DEFAULT (GETDATE())
)
GO

CREATE TABLE [Permissions] (
  [PermissionId] int PRIMARY KEY IDENTITY(1, 1),
  [PermissionName] varchar(50) UNIQUE NOT NULL,
  [Description] varchar(200),
  [CreatedAt] datetime NOT NULL DEFAULT (GETDATE())
)
GO

CREATE TABLE [ProfilePermissions] (
  [ProfilePermissionId] int PRIMARY KEY IDENTITY(1, 1),
  [ProfileId] int NOT NULL,
  [PermissionId] int NOT NULL,
  [GrantedAt] datetime NOT NULL DEFAULT (GETDATE())
)
GO

ALTER TABLE [UserProfiles] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId])
GO

ALTER TABLE [UserProfiles] ADD FOREIGN KEY ([ProfileId]) REFERENCES [Profiles] ([ProfileId])
GO

ALTER TABLE [ProfilePermissions] ADD FOREIGN KEY ([ProfileId]) REFERENCES [Profiles] ([ProfileId])
GO

ALTER TABLE [ProfilePermissions] ADD FOREIGN KEY ([PermissionId]) REFERENCES [Permissions] ([PermissionId])
GO

