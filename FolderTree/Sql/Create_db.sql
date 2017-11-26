Use master
Go

If DB_ID ('FolderTree') is not null
Drop database FolderTree
Go

Create database FolderTree
Go

Select name, size, size*1.0/128 AS [Size in MBs] 
From sys.master_files
Where name = 'FolderTree'
Go
