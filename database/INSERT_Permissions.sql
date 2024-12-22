INSERT INTO Permissions (PermissionName, Description, CreatedAt)
VALUES
-- Usuários
('User.Create', 'Permissão para criar novos usuários', GETDATE()),
('User.Read', 'Permissão para visualizar usuários', GETDATE()),
('User.Update', 'Permissão para atualizar dados dos usuários', GETDATE()),
('User.Delete', 'Permissão para excluir usuários', GETDATE()),
-- Perfis (Roles/Profiles)
('Profile.Create', 'Permissão para criar novos perfis', GETDATE()),
('Profile.Read', 'Permissão para visualizar perfis', GETDATE()),
('Profile.Update', 'Permissão para atualizar perfis', GETDATE()),
('Profile.Delete', 'Permissão para excluir perfis', GETDATE()),
-- Permissões
('Permission.Assign', 'Permissão para atribuir permissões aos perfis', GETDATE()),
('Permission.Read', 'Permissão para visualizar permissões', GETDATE()),
('Permission.Update', 'Permissão para atualizar permissões', GETDATE()),
-- Configurações do Sistema
('Settings.Read', 'Permissão para visualizar configurações do sistema', GETDATE()),
('Settings.Update', 'Permissão para atualizar configurações do sistema', GETDATE()),
-- Relatórios (Reports)
('Reports.View', 'Permissão para visualizar relatórios', GETDATE()),
('Reports.Generate', 'Permissão para gerar relatórios', GETDATE()),
-- Logs
('Logs.View', 'Permissão para visualizar logs de sistema', GETDATE()),
('Logs.Clear', 'Permissão para limpar logs de sistema', GETDATE());