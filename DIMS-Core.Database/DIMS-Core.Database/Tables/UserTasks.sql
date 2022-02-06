﻿CREATE TABLE [dbo].[UserTasks]
( 
	[UserTaskId] INT IDENTITY(1,1) NOT NULL,
	[TaskId] INT NOT NULL,
	[UserId] INT NOT NULL,
	[StateId] INT NOT NULL,

	CONSTRAINT [PK_UserTasks] PRIMARY KEY CLUSTERED([UserTaskId] ASC),

	FOREIGN KEY([TaskId]) REFERENCES [dbo].[Tasks] ([TaskId])
    ON DELETE CASCADE
    ON UPDATE CASCADE,

	FOREIGN KEY([UserId]) REFERENCES [dbo].[UserProfiles] ([UserId])
    ON DELETE CASCADE
    ON UPDATE CASCADE,

	FOREIGN KEY([StateId]) REFERENCES [dbo].[TaskStates] ([StateId])
    ON DELETE CASCADE
    ON UPDATE CASCADE
)