CREATE TABLE [dbo].[Table_AttendanceData] (
    [ID]           INT          NOT NULL,
    [NumberOfLate] VARCHAR (20) NULL,
    CONSTRAINT [PK_Table_AttendanceData] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Manager_Table__AttendanceData_Table_UserData] FOREIGN KEY ([ID]) REFERENCES [dbo].[Table_UserData] ([ID])
);



