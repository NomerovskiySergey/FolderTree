Use FolderTree
Go

drop table tbl_TreeNode;
drop function CheckFolderName;
Go

Create function CheckFolderName(
  @ParentId int,
  @FolderName varchar(100)
) RETURNS bit 

As begin

  Declare @isValid bit;
  Declare @repeatCount int;
  Declare @validNameCount int;

  Declare @repeatFridge int = 1;

  Select @repeatCount = Count(*) FROM tbl_TreeNode WHERE (ParentId = @ParentId or ParentId is null) and Name = @FolderName;
  Select @validNameCount = Count(*) from (Values(@FolderName)) as fName(name) where name like '[A-Za-z ]%';

  if (@repeatCount = 1) and (@validNameCount > 0)
	set  @isValid = 1
  else 
	set  @isValid = 0

  return @isValid;
End
Go




Create Table tbl_TreeNode(
	Id int identity(1,1) not null,
	Name varchar(100) not null,
	ParentId int null,
	Depth int not null,
	Url varchar(max),

	Constraint TreeNode_PK_Id primary key (Id),
	Constraint TreeNode_Check_Name Check(dbo.CheckFolderName(ParentId,[Name]) = 1)
);
Go