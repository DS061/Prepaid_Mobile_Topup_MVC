SET IDENTITY_INSERT [dbo].[PrepaidCustomer] ON
INSERT INTO [dbo].[PrepaidCustomer] ([Id], [Name], [RegistereddDate]) VALUES (1, N'Dilpreet', N'2021-01-25 00:00:00')
INSERT INTO [dbo].[PrepaidCustomer] ([Id], [Name], [RegistereddDate]) VALUES (2, N'Harjot', N'2021-01-25 00:00:00')
INSERT INTO [dbo].[PrepaidCustomer] ([Id], [Name], [RegistereddDate]) VALUES (3, N'Himmy', N'2021-01-25 00:00:00')
SET IDENTITY_INSERT [dbo].[PrepaidCustomer] OFF
SET IDENTITY_INSERT [dbo].[TopUp] ON
INSERT INTO [dbo].[TopUp] ([Id], [MobileAccountId], [TopUpChannelId], [TopUpAmount]) VALUES (1, 1, 1, CAST(55.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[TopUp] OFF
SET IDENTITY_INSERT [dbo].[MobileAccount] ON
INSERT INTO [dbo].[MobileAccount] ([Id], [Number], [Balance], [PrepaidCustomerId]) VALUES (1, N'45465656', CAST(555.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[MobileAccount] OFF
SET IDENTITY_INSERT [dbo].[TopUpChannel] ON
INSERT INTO [dbo].[TopUpChannel] ([Id], [Name], [Description]) VALUES (1, N'Recharge', N'Recharge dfdf')
SET IDENTITY_INSERT [dbo].[TopUpChannel] OFF
