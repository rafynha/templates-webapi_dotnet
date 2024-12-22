DECLARE @AdminProfileId INT;

INSERT INTO Profiles (ProfileName, CreatedAt)
VALUES ('Admin', GETDATE());

SET @AdminProfileId = SCOPE_IDENTITY();

INSERT INTO ProfilePermissions (ProfileId, PermissionId, GrantedAt)
SELECT @AdminProfileId, PermissionId, GETDATE()
FROM Permissions;






