CREATE TABLE tbl_Help_Category
(
	Help_Category_ID					int			IDENTITY(1,1) not null,
	Help_Category_Name					varchar(50)	not null,
	Help_Category_Order					int			not null,
	Help_Category_Parent_ID				int,
	Help_Category_Logged_Out_Available	bit			not null,

	CONSTRAINT pk_Help_Category_ID PRIMARY KEY (Help_Category_ID)
)

CREATE TABLE tbl_Help_Topic
(
	Help_Topic_ID						int			IDENTITY(1,1) 			not null,
	Help_Topic_Header					varchar(100)			not null,
	Help_Topic_Text						varchar(max)			not null,
	Help_Category_ID					int						not null,
	Help_Topic_View_Count				int	DEFAULT 0,
	Help_Topic_Share_Count				int	DEFAULT 0,
	Help_Topic_Last_Updated				date DEFAULT GETDATE(),
	Help_Topic_Priority					int,
	Help_Topic_Logged_Out_Available		bit						not null,
	Help_Topic_Likes					int	DEFAULT 0,
	Help_Topic_Dislikes					int	DEFAULT 0,

	CONSTRAINT pk_Help_Topic_ID PRIMARY KEY (Help_Topic_ID),
	CONSTRAINT fk_Help_Category_ID FOREIGN KEY (Help_Category_ID) REFERENCES tbl_Help_Category (Help_Category_ID)
)

CREATE TABLE tbl_Help_Topic_Tag
(
	Help_Topic_Tag_ID		int		IDENTITY(1,1) 	not null,
	Help_Topic_ID			int			not null,
	Help_Topic_Tag_Text		varchar(50)	not null,

	CONSTRAINT pk_Help_Topic_Tag_ID PRIMARY KEY (Help_Topic_Tag_ID),
	CONSTRAINT fk_Help_Topic_ID FOREIGN KEY (Help_Topic_ID) REFERENCES tbl_Help_Topic (Help_Topic_ID)
)

CREATE TABLE tbl_Help_Topic_Related
(
	Help_Topic_Related_ID	int IDENTITY(1,1) 	not null,
	Help_Topic_ID_First		int	not null,
	Help_Topic_ID_Second	int	not null,

	CONSTRAINT pk_Help_Topic_Related_ID	PRIMARY KEY (Help_Topic_Related_ID),
	CONSTRAINT fk_Help_Topic_ID_First FOREIGN KEY (Help_Topic_ID_First) REFERENCES tbl_Help_Topic (Help_Topic_ID),
	CONSTRAINT fk_Help_Topic_ID_Second FOREIGN KEY (Help_Topic_ID_Second) REFERENCES tbl_Help_Topic (Help_Topic_ID)
)