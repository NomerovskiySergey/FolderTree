USE [FolderTree]
GO

-- 0 level
INSERT INTO [dbo].[tbl_TreeNode] ([Name],[ParentId],[Depth],[Url])
	   VALUES ('Creating Digital Images', null, 0,'Creating Digital Images/')
GO

-- 1 level
INSERT INTO [dbo].[tbl_TreeNode] ([Name],[ParentId],[Depth],[Url])
	   VALUES ('Resources', 1, 1,'Creating Digital Images/Resources')
GO

INSERT INTO [dbo].[tbl_TreeNode] ([Name],[ParentId],[Depth],[Url])
	   VALUES ('Evidence', 1, 1,'Creating Digital Images/Evidence')
GO

INSERT INTO [dbo].[tbl_TreeNode] ([Name],[ParentId],[Depth],[Url])
	   VALUES ('Graphic products', 1, 1,'Creating Digital Images/Graphic products')
GO

-- 2 level
INSERT INTO [dbo].[tbl_TreeNode] ([Name],[ParentId],[Depth],[Url])
	   VALUES ('Primary Sources', 2, 2,'Creating Digital Images/Resources/Primary Source')
GO

INSERT INTO [dbo].[tbl_TreeNode] ([Name],[ParentId],[Depth],[Url])
	   VALUES ('Secondary Source', 2, 2,'Creating Digital Images/Resources/Secondary Source')
GO

INSERT INTO [dbo].[tbl_TreeNode] ([Name],[ParentId],[Depth],[Url])
	   VALUES ('Process', 4, 3,'Creating Digital Images/Graphic products/Process')
GO

INSERT INTO [dbo].[tbl_TreeNode] ([Name],[ParentId],[Depth],[Url])
	   VALUES ('Final Product', 4, 3,'Creating Digital Images/Graphic products/Final Source')
GO



